#if UNITY_EDITOR
/// <summary>
/// Editor工具集合
/// </summary>
public sealed class EditorStrayFogUtility
{
    /// <summary>
    /// CMD工具
    /// </summary>
    public readonly static EditorUtility_CMD cmd = StrayFogHotfixUtility.Single<EditorUtility_CMD>();
    /// <summary>
    /// 正则表达式工具
    /// </summary>
    public readonly static EditorUtility_Regex regex = StrayFogHotfixUtility.Single<EditorUtility_Regex>();
    /// <summary>
    /// 收集资源工具
    /// </summary>
    public readonly static EditorUtility_CollectAsset collectAsset = StrayFogHotfixUtility.Single<EditorUtility_CollectAsset>();
    /// <summary>
    /// 注册表工具
    /// </summary>
    public readonly static EditorUtility_Regedit regedit = StrayFogHotfixUtility.Single<EditorUtility_Regedit>();
    /// <summary>
    /// AssetBundleName资源工具
    /// </summary>
    public readonly static EditorUtility_AssetBundleName assetBundleName = StrayFogHotfixUtility.Single<EditorUtility_AssetBundleName>();
    /// <summary>
    /// GUILayout工具
    /// </summary>
    public readonly static EditorUtility_GUILayout guiLayout = StrayFogHotfixUtility.Single<EditorUtility_GUILayout>();
}
#endif