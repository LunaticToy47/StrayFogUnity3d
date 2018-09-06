#if UNITY_EDITOR
/// <summary>
/// Editor工具集合
/// </summary>
public sealed class EditorStrayFogUtility
{
    /// <summary>
    /// CMD工具
    /// </summary>
    public readonly static EditorUtility_CMD cmd = StrayFogRunningUtility.Single<EditorUtility_CMD>();
    /// <summary>
    /// 正则表达式工具
    /// </summary>
    public readonly static EditorUtility_Regex regex = StrayFogRunningUtility.Single<EditorUtility_Regex>();
    /// <summary>
    /// 收集资源工具
    /// </summary>
    public readonly static EditorUtility_CollectAsset collectAsset = StrayFogRunningUtility.Single<EditorUtility_CollectAsset>();
    /// <summary>
    /// 注册表工具
    /// </summary>
    public readonly static EditorUtility_Regedit regedit = StrayFogRunningUtility.Single<EditorUtility_Regedit>();
    /// <summary>
    /// AssetBundleName资源工具
    /// </summary>
    public readonly static EditorUtility_AssetBundleName assetBundleName = StrayFogRunningUtility.Single<EditorUtility_AssetBundleName>();
    /// <summary>
    /// GUILayout工具
    /// </summary>
    public readonly static EditorUtility_GUILayout guiLayout = StrayFogRunningUtility.Single<EditorUtility_GUILayout>();
}
#endif