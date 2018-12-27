/// <summary>
/// XLS表格架构
/// </summary>
public class EditorXlsTableSchema : AbsScriptableObject
{
    /// <summary>
    /// 列
    /// </summary>
    [AliasTooltipAttribute("列")]
    public EditorXlsTableColumnSchema[] columns;
}
