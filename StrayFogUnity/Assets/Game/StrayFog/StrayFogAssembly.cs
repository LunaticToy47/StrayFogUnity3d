using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
/// <summary>
/// 引擎程序集
/// </summary>
public sealed class StrayFogAssembly
{
    /// <summary>
    /// 动态程序集组
    /// </summary>
    public static List<Assembly> dynamicAssemblies { get; private set; }

    #region LoadDynamicAssembly 加载所有dll动态库
    /// <summary>
    /// 加载所有dll动态库
    /// </summary>
    public static void LoadDynamicAssembly()
    {
        if (dynamicAssemblies == null)
        {
            dynamicAssemblies = new List<Assembly>();
            List<XLS_Config_Table_AsmdefMap> maps = StrayFogConfigHelper.Select<XLS_Config_Table_AsmdefMap>();
            string dllPath = string.Empty;
            string pdbPath = string.Empty;
            Assembly tmpAssembly = null;
            foreach (XLS_Config_Table_AsmdefMap m in maps)
            {
                if (StrayFogGamePools.setting.isInternal)
                {
                    dllPath = m.asmdefDllPath;
                    pdbPath = m.asmdefPdbPath;
                }
                else
                {
                    dllPath = Path.Combine(StrayFogGamePools.setting.assetBundleRoot, m.asmdefDllAssetbundleName);
                    pdbPath = Path.Combine(StrayFogGamePools.setting.assetBundleRoot, m.asmdefPdbAssetbundleName);
                }
                if (File.Exists(dllPath) && File.Exists(pdbPath))
                {
                    tmpAssembly = Assembly.Load(File.ReadAllBytes(dllPath), File.ReadAllBytes(pdbPath));
                    dynamicAssemblies.Add(tmpAssembly);
                }
            }
            tmpAssembly = Assembly.GetCallingAssembly();
            if (tmpAssembly != null && !dynamicAssemblies.Contains(tmpAssembly))
            {
                dynamicAssemblies.Add(tmpAssembly);
            }
            tmpAssembly = Assembly.GetEntryAssembly();
            if (tmpAssembly != null && !dynamicAssemblies.Contains(tmpAssembly))
            {
                dynamicAssemblies.Add(tmpAssembly);
            }
            tmpAssembly = Assembly.GetExecutingAssembly();
            if (tmpAssembly != null && !dynamicAssemblies.Contains(tmpAssembly))
            {
                dynamicAssemblies.Add(tmpAssembly);
            }
        }
    }
    #endregion

    #region GetType Type映射
    /// <summary>
    /// Type映射
    /// </summary>
    static Dictionary<int, Type> mTypeMaping = new Dictionary<int, Type>();
    /// <summary>
    /// 获得指定名称的Type
    /// </summary>    
    /// <returns>Type</returns>
    public static Type GetType<T>()
    {
        return GetType(typeof(T).FullName);
    }

    /// <summary>
    /// 获得指定名称的Type
    /// </summary>
    /// <param name="_typeName">Type名称</param>
    /// <returns>Type</returns>
    public static Type GetType(string _typeName)
    {
        int key = _typeName.GetHashCode();
        if (!mTypeMaping.ContainsKey(key))
        {
            Type type = null;
            if (dynamicAssemblies != null && dynamicAssemblies.Count > 0)
            {
                foreach (Assembly m in dynamicAssemblies)
                {
                    type = m.GetType(_typeName);
                    if (type == null)
                    {
                        type = m.GetType(m.GetName().Name + "." + _typeName);
                    }
                    if (type != null)
                    {
                        break;
                    }
                }
            }
            mTypeMaping.Add(key, type);
        }
        return mTypeMaping[key];
    }
    #endregion

    #region GetExportedTypes 获得继承于指定类别的所有类别组
    /// <summary>
    /// 子类组映射
    /// </summary>
    static Dictionary<int, List<Type>> mExportedTypesMaping = new Dictionary<int, List<Type>>();
    /// <summary>
    /// 获得继承于指定类别的所有类别组
    /// </summary>
    /// <param name="_parentType">父类别</param>
    /// <returns>类别组</returns>
    public static List<Type> GetExportedTypes(Type _parentType)
    {
        int key = _parentType.GetHashCode();
        if (!mExportedTypesMaping.ContainsKey(key))
        {
            mExportedTypesMaping.Add(key, new List<Type>());
            if (dynamicAssemblies != null)
            {
                Type[] types = null;
                foreach (Assembly m in dynamicAssemblies)
                {
                    types = m.GetExportedTypes();
                    if (types != null && types.Length > 0)
                    {
                        foreach (Type t in types)
                        {
                            if (t.IsTypeOrSubTypeOf(_parentType))
                            {
                                mExportedTypesMaping[key].Add(t);
                            }
                        }
                    }
                }
            }
        }
        return mExportedTypesMaping[key];
    }
    #endregion
}
