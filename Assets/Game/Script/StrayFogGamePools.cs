/// <summary>
/// 全局游戏管理器
/// </summary>
public static class StrayFogGamePools
{
    #region StrayFogAssetBundleManager
    /// <summary>
    /// StrayFogAssetBundleManager
    /// </summary>
    public static StrayFogAssetBundleManager assetBundleManager
    {
        get
        {
            return StrayFogRunningUtility.SingleMonoBehaviour<StrayFogAssetBundleManager>();
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
            return StrayFogRunningUtility.SingleMonoBehaviour<StrayFogGuideManager>();
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
            return StrayFogRunningUtility.SingleMonoBehaviour<StrayFogGameManager>();
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
            return StrayFogRunningUtility.SingleMonoBehaviour<StrayFogSceneManager>();
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
            return StrayFogRunningUtility.SingleMonoBehaviour<StrayFogXLuaManager>();
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
            return StrayFogRunningUtility.SingleMonoBehaviour<StrayFogUIWindowManager>();
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
}
