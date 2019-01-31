using System;
/// <summary>
/// 代码特性
/// </summary>
[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public class SQLiteFieldTypeAttribute : AliasTooltipAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_arrayDimension">数组维度</param>
    /// <param name="_xlsColumnIndex">XLS表列索引</param>
    /// <param name="_sqliteColumnName">数据库列名称</param>
    /// <param name="_sqliteParameterName">数据库参数名称</param>
    /// <param name="_isPK">是否是主键</param>
    public SQLiteFieldTypeAttribute(enSQLiteDataType _dataType,
        enSQLiteDataTypeArrayDimension _arrayDimension,
        int _xlsColumnIndex, string _sqliteColumnName, string _sqliteParameterName, bool _isPK)
        : base(_dataType.ToString() + "_" + _arrayDimension.ToString())
    {
        dataType = _dataType;
        arrayDimension = _arrayDimension;
        xlsColumnIndex = _xlsColumnIndex;
        sqliteColumnName = _sqliteColumnName;
        sqliteParameterName = _sqliteParameterName;
        isPK = _isPK;
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enSQLiteDataType dataType { get; private set; }
    /// <summary>
    /// 数组维度
    /// </summary>
    public enSQLiteDataTypeArrayDimension arrayDimension { get; private set; }
    /// <summary>
    /// XLS表列索引
    /// </summary>
    public int xlsColumnIndex { get; private set; }
    /// <summary>
    /// 数据库列名称
    /// </summary>
    public string sqliteColumnName { get; private set; }
    /// <summary>
    /// 数据库参数名称
    /// </summary>
    public string sqliteParameterName { get; private set; }
    /// <summary>
    /// 是否是主键
    /// </summary>
    public bool isPK { get; private set; }
}
