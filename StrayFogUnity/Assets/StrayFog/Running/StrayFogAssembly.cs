using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
/// <summary>
/// 引擎程序集
/// </summary>
public sealed class StrayFogAssembly
{
    //#region LoadDynamicAssembly 加载所有dll动态库
    ///// <summary>
    ///// 加载所有dll动态库
    ///// </summary>
    ///// <param name="_onRequestInternalHotfixDllPaths">请求内部Hotfix热更Dll路径</param>
    ///// <param name="_onRequestAssetBundleHotfixDllPaths">请求外部资源包Hotfix热更Dll路径</param>
    ///// <param name="_onComplete">完成回调</param>
    //public static void LoadDynamicAssembly(Func<Dictionary<string, string>> _onRequestInternalHotfixDllPaths,
    //    Func<Dictionary<string, string>> _onRequestAssetBundleHotfixDllPaths, Action _onComplete)
    //{
    //    if (dynamicAssemblies == null)
    //    {
    //        dynamicAssemblies = new List<Assembly>();

    //        Assembly tmpAssembly = null;
    //        #region Hotfix Dll
    //        Dictionary<string, string> dllSource = new Dictionary<string, string>();
    //        if (StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isInternal)
    //        {
    //            dllSource = _onRequestInternalHotfixDllPaths?.Invoke();
    //        }
    //        else
    //        {
    //            dllSource = _onRequestAssetBundleHotfixDllPaths?.Invoke();
    //        }

    //        if (dllSource != null && dllSource.Count > 0)
    //        {
    //            string dllPath = string.Empty;
    //            string pdbPath = string.Empty;
    //            foreach (KeyValuePair<string, string> key in dllSource)
    //            {
    //                dllPath = key.Key;
    //                pdbPath = key.Value;
    //                if (File.Exists(dllPath) && File.Exists(pdbPath))
    //                {
    //                    tmpAssembly = Assembly.Load(File.ReadAllBytes(dllPath), File.ReadAllBytes(pdbPath));
    //                    dynamicAssemblies.Add(tmpAssembly);
    //                }
    //            }
    //        }
    //        #endregion

    //        tmpAssembly = Assembly.GetCallingAssembly();
    //        if (tmpAssembly != null && !dynamicAssemblies.Contains(tmpAssembly))
    //        {
    //            dynamicAssemblies.Add(tmpAssembly);
    //        }
    //        tmpAssembly = Assembly.GetEntryAssembly();
    //        if (tmpAssembly != null && !dynamicAssemblies.Contains(tmpAssembly))
    //        {
    //            dynamicAssemblies.Add(tmpAssembly);
    //        }
    //        tmpAssembly = Assembly.GetExecutingAssembly();
    //        if (tmpAssembly != null && !dynamicAssemblies.Contains(tmpAssembly))
    //        {
    //            dynamicAssemblies.Add(tmpAssembly);
    //        }
    //        _onComplete?.Invoke();
    //    }
    //}
    //#endregion

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
            //if (dynamicAssemblies != null && dynamicAssemblies.Count > 0)
            //{
            //    foreach (Assembly m in dynamicAssemblies)
            //    {
            //        type = m.GetType(_typeName);
            //        if (type == null)
            //        {
            //            type = m.GetType(m.GetName().Name + "." + _typeName);
            //        }
            //        if (type != null)
            //        {
            //            break;
            //        }
            //    }
            //}
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
            //if (dynamicAssemblies != null)
            //{
            //    Type[] types = null;
            //    foreach (Assembly m in dynamicAssemblies)
            //    {
            //        types = m.GetExportedTypes();
            //        if (types != null && types.Length > 0)
            //        {
            //            foreach (Type t in types)
            //            {
            //                if (t.IsTypeOrSubTypeOf(_parentType))
            //                {
            //                    mExportedTypesMaping[key].Add(t);
            //                }
            //            }
            //        }
            //    }
            //}
        }
        return mExportedTypesMaping[key];
    }
    #endregion
}
