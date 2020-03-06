using System;
using System.Text;
/// <summary>
/// 引擎工具
/// </summary>
public sealed class StrayFogRunningPool
{
    #region SingleScriptableObject 单例AbsSingleScriptableObject对象扩展
    /// <summary>
    /// 单例AbsSingleScriptableObject对象扩展
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public static T SingleScriptableObject<T>()
        where T : AbsSingleScriptableObject
    {
        return AbsSingleScriptableObject.current<T>();
    }
    #endregion

    #region StrayFogSetting 设置文件
    /// <summary>
    /// 设置文件
    /// </summary>
    public static StrayFogSetting runningSetting {
        get {
            return SingleScriptableObject<StrayFogSetting>();
        }
    }
    #endregion

    #region StrayFogAsmdefHotfixSetting 设置文件
    /// <summary>
    /// Asmdef设置文件
    /// </summary>
    public static StrayFogHotfixAsmdefSetting asmdefSetting
    {
        get
        {
#if UNITY_EDITOR
            return null;
#else
            return SingleScriptableObject<StrayFogHotfixAsmdefSetting>();
#endif
        }
    }
#endregion
}

