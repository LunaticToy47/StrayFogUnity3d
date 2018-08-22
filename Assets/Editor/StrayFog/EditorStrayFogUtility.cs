
/// <summary>
/// Editor工具集合
/// </summary>
public sealed class EditorStrayFogUtility
{
    /// <summary>
    /// CMD工具
    /// </summary>
    public readonly static EditorUtility_CMD cmd = EditorUtility_CMD.current;
    /// <summary>
    /// 正则表达式工具
    /// </summary>
    public readonly static EditorUtility_Regex regex = EditorUtility_Regex.current;
    /// <summary>
    /// 收集资源工具
    /// </summary>
    public readonly static EditorUtility_CollectAsset collectAsset = EditorUtility_CollectAsset.current;
    /// <summary>
    /// 注册表工具
    /// </summary>
    public readonly static EditorUtility_Regedit regedit = EditorUtility_Regedit.current;
    /// <summary>
    /// AssetBundleName资源工具
    /// </summary>
    public readonly static EditorUtility_AssetBundleName assetBundleName = EditorUtility_AssetBundleName.current;
    /// <summary>
    /// GUILayout工具
    /// </summary>
    public readonly static EditorUtility_GUILayout guiLayout = EditorUtility_GUILayout.current;
}
