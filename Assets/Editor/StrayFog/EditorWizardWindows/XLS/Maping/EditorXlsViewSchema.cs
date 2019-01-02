/// <summary>
/// XLS视图架构
/// </summary>
public class EditorXlsViewSchema : AbsScriptableObject
{
    /// <summary>
    /// 视图名称
    /// </summary>
    [AliasTooltip("视图名称")]
    [ReadOnly]
    public string viewName;
    /// <summary>
    /// 列
    /// </summary>
    [AliasTooltip("列")]
    public EditorXlsTableColumnSchema[] columns;
}
