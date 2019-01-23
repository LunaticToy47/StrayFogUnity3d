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
    /// 是否是行列式表
    /// </summary>
    [AliasTooltip("是否是行列式表")]
    public bool isDeterminant;
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
    public string dbConnectionString { get { return StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().GetSQLiteConnectionString(dbPath); } }
    #endregion

    #region assetBundleDbName 数据库外部资源名称
    /// <summary>
    /// 数据库外部资源名称
    /// </summary>
    public string assetBundleDbName { get { return "c_" + dbPath.UniqueHashCode().ToString().Replace("-", "_"); } }
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
            string prefix = classify.ToString() + "_";
            string className = string.Empty;
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

    #region Copy 复制
    /// <summary>
    /// Copy
    /// </summary>
    /// <returns>XLS表格架构</returns>
    public EditorXlsTableSchema Copy()
    {
        EditorXlsTableSchema table = new EditorXlsTableSchema();
        table.tableName = tableName;
        table.fileName = fileName;
        table.dbPath = dbPath;
        table.isDeterminant = isDeterminant;
        table.classify = classify;
        if (columns != null && columns.Length > 0)
        {
            table.columns = new EditorXlsTableColumnSchema[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                table.columns[i] = columns[i].Copy();
            }
        }
        else
        {
            table.columns = new EditorXlsTableColumnSchema[0];
        }
        return table;
    }
    #endregion
}
