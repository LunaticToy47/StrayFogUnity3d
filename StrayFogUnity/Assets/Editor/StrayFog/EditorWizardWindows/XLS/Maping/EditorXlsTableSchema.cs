﻿#if UNITY_EDITOR
using System.IO;
/// <summary>
/// XLS表格架构
/// </summary>
public class EditorXlsTableSchema : AbsScriptableObject
{
    /// <summary>
    /// 表名称
    /// </summary>
    [AliasTooltip("表名称")]
    [ReadOnly]
    public string tableName;
    /// <summary>
    /// 表架构配置路径
    /// </summary>
    [AliasTooltip("表架构配置路径")]
    [ReadOnly]
    public string tableSchemaAssetPath;
    /// <summary>
    /// 文件路径
    /// </summary>
    [AliasTooltip("文件路径")]
    [ReadOnly]
    public string fileName;    
    /// <summary>
    /// 数据库路径
    /// </summary>
    [AliasTooltip("数据库路径")]
    [ReadOnly]
    public string dbPath;
    /// <summary>
    /// 表分类
    /// </summary>
    [AliasTooltip("表分类")]
    [ReadOnly]
    public enSQLiteEntityClassify classify = enSQLiteEntityClassify.Table;

    /// <summary>
    /// 脚本目录分类
    /// </summary>
    [AliasTooltip("脚本目录分类")]
    [ReadOnly]
    public enEditorApplicationFolder scriptFolderClassify = enEditorApplicationFolder.Game_Script_SQLite;
    /// <summary>
    /// 是否是行列式表
    /// </summary>
    [AliasTooltip("是否是行列式表")]
    public bool isDeterminant;
    /// <summary>
    /// 是否可修改数据
    /// </summary>
    [AliasTooltip("是否可修改数据")]
    public bool canModifyData;
    /// <summary>
    /// 列
    /// </summary>
    [AliasTooltip("列")]    
    public EditorXlsTableColumnSchema[] columns;

    #region dbName 数据库名称
    /// <summary>
    /// 数据库名称
    /// </summary>
    public string dbName { get { return Path.GetFileName(dbPath); } }
    #endregion

    #region dbConnectionString 数据库连接字符串
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public string dbConnectionString { get { return StrayFogRunningPool.runningSetting.EditorGetSQLiteConnectionString(dbPath); } }
    #endregion

    #region assetBundleDbName 数据库外部资源名称
    /// <summary>
    /// 数据库外部资源名称
    /// </summary>
    public string assetBundleDbName { get { return Path.Combine(EditorStrayFogApplication.TryRelativeToAssets(), "SQLite".ToHex() + "/c_" + dbPath.UniqueHashCode().ToString().Replace("-", "_")).TransPathSeparatorCharToUnityChar(); } }
    #endregion

    #region dbKey 数据库Key值
    /// <summary>
    /// 数据库Key值
    /// </summary>
    public int dbKey { get { return dbConnectionString.UniqueHashCode(); } }
    #endregion

    #region dbEnumName 数据库枚举值
    /// <summary>
    /// 数据库枚举值
    /// </summary>
    public string dbEnumName { get { return Path.GetFileNameWithoutExtension(dbName); } }
    #endregion

    #region className 类名称
    /// <summary>
    /// 类名称
    /// </summary>
    public string className { get {
            string prefix = string.Empty;
            string className = string.Empty;
            if (isDeterminant)
            {
                prefix = "Determinant_";
            }
            prefix += classify.ToString() + "_";

            if (tableName.StartsWith(prefix))
            {
                className = tableName;
            }
            else
            {
                className = prefix + tableName;
            }            
            return Path.GetFileNameWithoutExtension(dbName) + "_" + className;
        } }
    #endregion

    #region Sqlit实体脚本保存目录
    /// <summary>
    /// Sqlit实体脚本保存目录
    /// </summary>
    public string scriptSqliteEntityFolder { get { return Path.Combine(Path.GetFullPath(scriptFolderClassify.GetAttribute<EditorApplicationFolderAttribute>().path), dbEnumName + (isDeterminant? "_DeterminantEntities" : "_Entities")); } }
    #endregion
}
#endif
