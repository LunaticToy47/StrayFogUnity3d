#if UNITY_EDITOR
/// <summary>
/// SQLite表格列
/// </summary>
public class SQLiteEntityProperty
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_name">属性名称</param>
    public SQLiteEntityProperty(string _name)
    {
        name = _name;
    }
    /// <summary>
    /// 名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public string typeName { get; set; }
    /// <summary>
    /// 列说明
    /// </summary>
    public string desc { get; set; }
    /// <summary>
    /// 数据类型名称
    /// </summary>
    public string sqliteDataTypeName { get; set; }
    /// <summary>
    /// 是否是PK
    /// </summary>
    public bool isPK { get; set; }
}
#endif