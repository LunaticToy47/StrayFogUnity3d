using UnityEngine;
/// <summary>
/// 全局变量
/// </summary>
public sealed class EditorStrayFogGlobalVariable
{
    #region UIWindow
    /// <summary>
    /// UI窗口视图脚本目录
    /// </summary>
    public static readonly string uiWindowViewScriptFolder = enEditorApplicationFolder.Game_Running_UIWindow.GetAttribute<EditorApplicationFolderAttribute>().path;
    /// <summary>
    /// UI窗口视图脚本
    /// </summary>
    public static readonly EditorTextAssetConfig uiWindowViewScript = new EditorTextAssetConfig("", uiWindowViewScriptFolder, enFileExt.CS, "");
    /// <summary>
    /// UI窗口预置目录
    /// </summary>
    public static readonly string uiWindowPrefabFolder = enEditorApplicationFolder.Game_AssetBundles_UIWindow.GetAttribute<EditorApplicationFolderAttribute>().path;
    /// <summary>
    /// UI窗口预置
    /// </summary>
    public static readonly EditorEngineAssetConfig uiWindowPrefab = new EditorEngineAssetConfig("", uiWindowPrefabFolder, enFileExt.Prefab, typeof(GameObject).FullName);
    #endregion
}
