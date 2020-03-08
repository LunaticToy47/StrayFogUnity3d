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
    /// ILRuntime模式AppDomain
    /// </summary>
    static ILRuntime.Runtime.Enviorment.AppDomain mILRuntimeAppDomain;

    /// <summary>
    /// 加载dll动态库
    /// </summary>
    public static void LoadDynamicAssembly()
    {
        if (StrayFogRunningPool.runningSetting.isUseILRuntime && mILRuntimeAppDomain == null)
        {
            mILRuntimeAppDomain = new ILRuntime.Runtime.Enviorment.AppDomain();
        }
        StrayFogHotfixAsmdefStaticSetting asmdef = StrayFogRunningPool.asmdefStaticSetting;
        if (asmdef.settings != null)
        {
            foreach (StrayFogHotfixAsmdefStaticSettingItem key in asmdef.settings)
            {
                if (StrayFogRunningPool.runningSetting.isUseILRuntime)
                {
                    mILRuntimeAppDomain.LoadAssembly(new MemoryStream(File.ReadAllBytes(key.hotfixAsmdefDllAssetBundlePath)));
                }
                else
                {
                    AppDomain.CurrentDomain.Load(File.ReadAllBytes(key.hotfixAsmdefDllAssetBundlePath), File.ReadAllBytes(key.hotfixAsmdefPdbAssetBundlePath));                    
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
        Type type = Type.GetType(_typeName);
        return type != null ? Activator.CreateInstance(type) : null;
    }
    #endregion
}
