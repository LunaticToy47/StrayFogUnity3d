#if UNITY_EDITOR
/// <summary>
/// Editor工具集合
/// </summary>
public sealed class EditorStrayFogUtility
{
    #region Single 单例AbsSingle对象扩展
    /// <summary>
    /// 单例AbsSingle对象扩展
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public static T Single<T>()
        where T : AbsEditorSingle, new()
    {
        return AbsEditorSingle.current<T>();
    }
    #endregion    

    /// <summary>
    /// CMD工具
    /// </summary>
    public readonly static EditorUtility_CMD cmd = Single<EditorUtility_CMD>();
    /// <summary>
    /// 正则表达式工具
    /// </summary>
    public readonly static EditorUtility_Regex regex = Single<EditorUtility_Regex>();
    /// <summary>
    /// 收集资源工具
    /// </summary>
    public readonly static EditorUtility_CollectAsset collectAsset = Single<EditorUtility_CollectAsset>();
    /// <summary>
    /// 注册表工具
    /// </summary>
    public readonly static EditorUtility_Regedit regedit = Single<EditorUtility_Regedit>();
    /// <summary>
    /// AssetBundleName资源工具
    /// </summary>
    public readonly static EditorUtility_AssetBundleName assetBundleName = Single<EditorUtility_AssetBundleName>();
    /// <summary>
    /// GUILayout工具
    /// </summary>
    public readonly static EditorUtility_GUILayout guiLayout = Single<EditorUtility_GUILayout>();
}
#endif