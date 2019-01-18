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
    /// 数据库名称
    /// </summary>
    [AliasTooltip("数据库名称")]
    [ReadOnly]
    public string dbName;
    /// <summary>
    /// 数据库路径
    /// </summary>
    [AliasTooltip("数据库路径")]
    [ReadOnly]
    public string dbConnectionString;
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

    #region ClassName 类名称
    /// <summary>
    /// 类名称
    /// </summary>
    public string ClassName { get {
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
            return className;
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
        table.dbName = dbName;
        table.dbConnectionString = dbConnectionString;
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
