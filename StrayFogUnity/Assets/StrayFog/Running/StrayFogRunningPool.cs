using UnityEngine;
/// <summary>
/// 引擎工具
/// </summary>
public sealed partial class StrayFogRunningPool
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

    #region StrayFogAsmdefHotfixStaticSetting 设置文件
    /// <summary>
    /// HotfixAsmdef设置
    /// </summary>
    static StrayFogHotfixAsmdefStaticSetting mStrayFogHotfixAsmdefStaticSetting;
    /// <summary>
    /// Asmdef静态设置文件
    /// </summary>
    public static StrayFogHotfixAsmdefStaticSetting asmdefStaticSetting
    {
        get
        {
            if (mStrayFogHotfixAsmdefStaticSetting == null)
            {
                if (runningSetting.isUseAssetBundle)
                {
                    AssetBundle ab = AssetBundle.LoadFromFile(HotfixAsmdefStaticSettingPath);
                    mStrayFogHotfixAsmdefStaticSetting = ab.LoadAllAssets<StrayFogHotfixAsmdefStaticSetting>()[0];
                    ab.Unload(false);
                    ab = null;
                }
                else
                {
                    mStrayFogHotfixAsmdefStaticSetting = (StrayFogHotfixAsmdefStaticSetting)SingleScriptableObject<StrayFogRunningApplication>().LoadAssetAtPath(HotfixAsmdefStaticSettingPath, typeof(StrayFogHotfixAsmdefStaticSetting));
                }
            }            
            return mStrayFogHotfixAsmdefStaticSetting;
        }
    }
#endregion
}

