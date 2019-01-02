#if UNITY_EDITOR
using Mono.Data.Sqlite;
using System;
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
    /// 插入UI窗口设定SQL
    /// </summary>
    /// <returns>SQL</returns>
    public string ExecuteInsertUIWindowSetting()
    {
        string sql = string.Format("INSERT INTO UIWindowSetting (id,name,fileId,folderId,renderMode,layer,openMode,closeMode,isIgnoreOpenCloseMode,isNotAutoRestoreSequenceWindow,isDonotDestroyInstance,isImmediateDisplay,isManualCloseWhenGotoScene,isGuideWindow) VALUES({0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})",
            winId, nameWithoutExtension, fileId, folderId,
            (int)assetNode.renderMode,
            (int)assetNode.layer, 
            (int)assetNode.openMode, 
            (int)assetNode.closeMode,
            Convert.ToInt32(assetNode.isIgnoreOpenCloseMode),
            Convert.ToInt32(assetNode.isNotAutoRestoreSequenceWindow),
            Convert.ToInt32(assetNode.isDonotDestroyInstance),
            Convert.ToInt32(assetNode.isImmediateDisplay),
            Convert.ToInt32(assetNode.isManualCloseWhenGotoScene),
            Convert.ToInt32(assetNode.isGuideWindow)
            );
        SQLiteHelper.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 更新UI窗口设定SQL
    /// </summary>
    /// <returns>SQL</returns>
    public string ExecuteUpdateUIWindowSetting()
    {
        string sql = string.Format("UPDATE UIWindowSetting SET name='{1}',fileId={2},folderId={3},renderMode={4},layer={5},openMode={6},closeMode={7},isIgnoreOpenCloseMode={8},isNotAutoRestoreSequenceWindow={9},isDonotDestroyInstance={10},isImmediateDisplay={11},isManualCloseWhenGotoScene={12},isGuideWindow={13} WHERE id={0}",
            winId, nameWithoutExtension, fileId, folderId,
            (int)assetNode.renderMode, 
            (int)assetNode.layer,
            (int)assetNode.openMode, 
            (int)assetNode.closeMode,
            Convert.ToInt32(assetNode.isIgnoreOpenCloseMode),
            Convert.ToInt32(assetNode.isNotAutoRestoreSequenceWindow),
            Convert.ToInt32(assetNode.isDonotDestroyInstance),
            Convert.ToInt32(assetNode.isImmediateDisplay),
            Convert.ToInt32(assetNode.isManualCloseWhenGotoScene),
            Convert.ToInt32(assetNode.isGuideWindow)
            );
        SQLiteHelper.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 删除UI窗口设定SQL
    /// </summary>
    /// <returns>SQL</returns>
    public static string ExecuteDeleteAllUIWindowSetting()
    {
        string sql = "DELETE FROM UIWindowSetting";
        SQLiteHelper.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 删除UI窗口设定SQL
    /// </summary>
    /// <returns>SQL</returns>
    public string ExecuteDeleteUIWindowSetting()
    {
        string sql = string.Format("DELETE FROM UIWindowSetting WHERE id={0}", winId);
        SQLiteHelper.sqlHelper.ExecuteNonQuery(sql);
        return sql;
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
    /// 资源节点
    /// </summary>
    public EditorUIWindowAsset assetNode { get; set; }
}
#endif