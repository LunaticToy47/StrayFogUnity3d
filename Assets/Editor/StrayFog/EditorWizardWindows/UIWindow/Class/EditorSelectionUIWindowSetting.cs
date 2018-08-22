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
            (int)renderMode, (int)layer, (int)openMode, (int)closeMode,
            Convert.ToInt32(isIgnoreOpenCloseMode),
            Convert.ToInt32(isNotAutoRestoreSequenceWindow),
            Convert.ToInt32(isDonotDestroyInstance),
            Convert.ToInt32(isImmediateDisplay),
            Convert.ToInt32(isManualCloseWhenGotoScene),
            Convert.ToInt32(isGuideWindow)
            );
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
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
            (int)renderMode, (int)layer, (int)openMode, (int)closeMode,
            Convert.ToInt32(isIgnoreOpenCloseMode),
            Convert.ToInt32(isNotAutoRestoreSequenceWindow),
            Convert.ToInt32(isDonotDestroyInstance),
            Convert.ToInt32(isImmediateDisplay),
            Convert.ToInt32(isManualCloseWhenGotoScene),
            Convert.ToInt32(isGuideWindow)
            );
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 删除UI窗口设定SQL
    /// </summary>
    /// <returns>SQL</returns>
    public static string ExecuteDeleteAllUIWindowSetting()
    {
        string sql = "DELETE FROM UIWindowSetting";
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 删除UI窗口设定SQL
    /// </summary>
    /// <returns>SQL</returns>
    public string ExecuteDeleteUIWindowSetting()
    {
        string sql = string.Format("DELETE FROM UIWindowSetting WHERE id={0}", winId);
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 读取配置
    /// </summary>
    public void Read()
    {
        SqliteDataReader reader = EditorStrayFogApplication.sqlHelper.ExecuteQuery(string.Format("SELECT * FROM UIWindowSetting WHERE id={0}", winId));
        if (reader.Read())
        {
            renderMode = (RenderMode)reader.GetInt32(reader.GetOrdinal("renderMode"));
            layer = (enUIWindowLayer)reader.GetInt32(reader.GetOrdinal("layer"));
            openMode = (enUIWindowOpenMode)reader.GetInt32(reader.GetOrdinal("openMode"));
            closeMode = (enUIWindowCloseMode)reader.GetInt32(reader.GetOrdinal("closeMode"));
            isIgnoreOpenCloseMode = reader.GetBoolean(reader.GetOrdinal("isIgnoreOpenCloseMode"));
            isNotAutoRestoreSequenceWindow = reader.GetBoolean(reader.GetOrdinal("isNotAutoRestoreSequenceWindow"));
            isDonotDestroyInstance = reader.GetBoolean(reader.GetOrdinal("isDonotDestroyInstance"));
            isImmediateDisplay = reader.GetBoolean(reader.GetOrdinal("isImmediateDisplay"));
            isManualCloseWhenGotoScene = reader.GetBoolean(reader.GetOrdinal("isManualCloseWhenGotoScene"));
            isGuideWindow = reader.GetBoolean(reader.GetOrdinal("isGuideWindow"));
        }
        reader.Close();
        reader = null;
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
    /// 画布绘制模式
    /// </summary>
    [AliasTooltip("画布绘制模式")]
    public RenderMode renderMode { get; set; }
    /// <summary>
    /// 窗口Layer
    /// </summary>
    [AliasTooltip("窗口Layer")]
    public enUIWindowLayer layer { get; set; }
    /// <summary>
    /// 打开模式
    /// </summary>
    [AliasTooltip("打开模式")]
    public enUIWindowOpenMode openMode { get; set; }
    /// <summary>
    /// 关闭模式
    /// </summary>
    [AliasTooltip("关闭模式")]
    public enUIWindowCloseMode closeMode { get; set; }
    /// <summary>
    /// 是否忽略开启关闭模式
    /// </summary>
    [AliasTooltip("是否忽略开启关闭模式")]
    public bool isIgnoreOpenCloseMode { get; set; }
    /// <summary>
    /// 是否是不可自动恢复序列窗口
    /// </summary>
    [AliasTooltip("是否是不可自动恢复序列窗口")]
    public bool isNotAutoRestoreSequenceWindow { get; set; }
    /// <summary>
    /// 是否是不可销毁实例
    /// </summary>
    [AliasTooltip("画布绘制模式")]
    public bool isDonotDestroyInstance { get; set; }
    /// <summary>
    /// 是否立即显示
    /// </summary>
    [AliasTooltip("是否立即显示")]
    public bool isImmediateDisplay { get; set; }
    /// <summary>
    /// 跳转场景时是否手动关闭
    /// </summary>
    [AliasTooltip("跳转场景时是否手动关闭")]
    public bool isManualCloseWhenGotoScene { get; set; }
    /// <summary>
    /// 是否是引导窗口
    /// </summary>
    [AliasTooltip("是否是引导窗口")]
    public bool isGuideWindow { get; set; }
}
