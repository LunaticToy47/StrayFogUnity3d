#if UNITY_EDITOR
using Mono.Data.Sqlite;
using System;
using System.Reflection;
using UnityEngine;
/// <summary>
/// UIWindow设定选择资源
/// </summary>
public class EditorSelectionUIWindowSetting : EditorSelectionAssetDiskMaping
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionUIWindowSetting(string _pathOrGuid) : base(_pathOrGuid)
    {
    }

    /// <summary>
    /// 读取配置
    /// </summary>
    public void Read()
    {
        EditorEngineAssetConfig absCfg = new EditorEngineAssetConfig(fileInSide,
            enEditorApplicationFolder.Game_Editor_UIWindow.GetAttribute<EditorApplicationFolderAttribute>().path,
            enFileExt.Asset, typeof(EditorUIWindowAsset).FullName);
        if (!absCfg.Exists())
        {
            absCfg.CreateAsset();
        }
        absCfg.LoadAsset();
        assetNode = (EditorUIWindowAsset)absCfg.engineAsset;
        ownerAssembly = EditorStrayFogAssembly.GetType(assetNode.name).Assembly;
    }

    /// <summary>
    /// 是否绘制
    /// </summary>
    public bool isDraw { get; set; }
    /// <summary>
    /// 窗口ID
    /// </summary>
    public int winId { get { return (fileId.ToString() + folderId.ToString()).UniqueHashCode(); } }
    /// <summary>
    /// 窗口所属应用程序集
    /// </summary>
    public Assembly ownerAssembly { get; private set; }
    /// <summary>
    /// 资源节点
    /// </summary>
    public EditorUIWindowAsset assetNode { get; set; }
}
#endif