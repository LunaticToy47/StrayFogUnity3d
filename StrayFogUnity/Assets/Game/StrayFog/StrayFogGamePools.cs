/// <summary>
/// 全局游戏管理器
/// </summary>
public static partial class StrayFogGamePools
{
    #region StrayFogAssetBundleManager
    /// <summary>
    /// StrayFogAssetBundleManager
    /// </summary>
    public static StrayFogAssetBundleManager assetBundleManager
    {
        get
        {
            return  StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogAssetBundleManager>();
        }
    }
    #endregion

    #region StrayFogGuideManager
    /// <summary>
    /// StrayFogGuideManager
    /// </summary>
    public static StrayFogGuideManager guideManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogGuideManager>();
        }
    }
    #endregion

    #region StrayFogGameManager
    /// <summary>
    /// StrayFogGameManager
    /// </summary>
    public static StrayFogGameManager gameManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogGameManager>();
        }
    }
    #endregion

    #region StrayFogSceneManager
    /// <summary>
    /// StrayFogSceneManager
    /// </summary>
    public static StrayFogSceneManager sceneManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogSceneManager>();
        }
    }
    #endregion

    #region StrayFogXLuaManager
    /// <summary>
    /// StrayFogXLuaManager
    /// </summary>
    public static StrayFogXLuaManager xLuaManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogXLuaManager>();
        }
    }
    #endregion

    #region StrayFogSkillManager
    /// <summary>
    /// StrayFogSkillManager
    /// </summary>
    public static StrayFogSkillManager skillManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogSkillManager>();
        }
    }
    #endregion

    #region StrayFogUIWindowManager
    /// <summary>
    /// StrayFogUIWindowManager
    /// </summary>
    public static StrayFogUIWindowManager uiWindowManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogUIWindowManager>();
        }
    }
    #endregion

    #region StrayFogRunningApplication
    /// <summary>
    /// StrayFogRunningApplication
    /// </summary>
    public static StrayFogRunningApplication runningApplication
    {
        get
        {
            return StrayFogRunningUtility.SingleScriptableObject<StrayFogRunningApplication>();
        }
    }
    #endregion

    #region StrayFogSetting
    /// <summary>
    /// StrayFogSetting
    /// </summary>
    public static StrayFogSetting setting
    {
        get
        {
            return StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>();
        }
    }
    #endregion

    #region StrayFogEventHandlerManager
    /// <summary>
    /// StrayFogEventHandlerManager
    /// </summary>
    public static StrayFogEventHandlerManager eventHandlerManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogEventHandlerManager>();
        }
    }
    #endregion    

    #region StrayFogILRuntimeManager
    /// <summary>
    /// StrayFogILRuntimeManager
    /// </summary>
    public static StrayFogILRuntimeManager ILRuntimeManager
    {
        get
        {
            return StrayFogHotfixUtility.SingleMonoBehaviour<StrayFogILRuntimeManager>();
        }
    }
    #endregion
}
