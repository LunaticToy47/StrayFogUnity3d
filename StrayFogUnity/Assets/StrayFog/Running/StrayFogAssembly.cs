using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
/// <summary>
/// 引擎程序集
/// </summary>
public sealed class StrayFogAssembly
{
    #region LoadDynamicAssembly 加载所有dll动态库
    /// <summary>
    /// 加载dll动态库
    /// </summary>
    public static void LoadDynamicAssembly()
    {
        mDynamicAssemblyMaping.Clear();
        Assembly temp = null;
        StrayFogHotfixAsmdefStaticSetting asmdef = StrayFogRunningPool.asmdefStaticSetting;
        if (asmdef.settings != null)
        {
            foreach (StrayFogHotfixAsmdefStaticSettingItem key in asmdef.settings)
            {
                temp = Assembly.Load(File.ReadAllBytes(key.hotfixAsmdefDllAssetBundlePath), File.ReadAllBytes(key.hotfixAsmdefPdbAssetBundlePath));
                if (temp != null)
                {
                    mDynamicAssemblyMaping.Add(key.hotfixAsmdefId, temp);
                }
            }
        }        
    }
    #endregion

    #region CreateInstance 创建指定类别的实例
    /// <summary>
    /// 创建指定类别的实例
    /// </summary>
    /// <param name="_typeName">类名称</param>
    /// <returns>实例</returns>
    public static object CreateInstance(string _typeName)
    {
        Type type = GetType(_typeName);
        return type != null ? Activator.CreateInstance(type) : null;
    }
    #endregion

    #region GetType Type映射
    /// <summary>
    /// 动态链接库组
    /// </summary>
    static Dictionary<int,Assembly> mDynamicAssemblyMaping = new Dictionary<int, Assembly>();
    /// <summary>
    /// 类与程序集映射
    /// </summary>
    static Dictionary<int, int> mTypeForAssemblyMaping = new Dictionary<int, int>();
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
            if (mDynamicAssemblyMaping != null && mDynamicAssemblyMaping.Count > 0)
            {
                foreach (KeyValuePair<int, Assembly> asm in mDynamicAssemblyMaping)
                {
                    type = asm.Value.GetType(_typeName);
                    if (type != null)
                    {
                        mTypeForAssemblyMaping.Add(key, asm.Key);
                        mTypeMaping.Add(key, type);
                        break;
                    }
                }
            }            
        }
        return mTypeMaping.ContainsKey(key) ? mTypeMaping[key] : null;
    }
    #endregion
}
