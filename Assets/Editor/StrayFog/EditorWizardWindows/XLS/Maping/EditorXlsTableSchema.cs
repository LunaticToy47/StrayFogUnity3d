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
    /// 是否是行列式表
    /// </summary>
    [AliasTooltip("是否是行列式表")]
    public bool isDeterminant;
    /// <summary>
    /// 是否生成脚本
    /// </summary>
    [AliasTooltip("是否生成脚本")]
    public bool isCreateScript;
    /// <summary>
    /// 列
    /// </summary>
    [AliasTooltip("列")]
    public EditorXlsTableColumnSchema[] columns;
}
