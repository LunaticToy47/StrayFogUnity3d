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
    /// <param name="_dataType">数据类型enSQLiteDataType</param>
    /// <param name="_arrayDimension">数组维度enSQLiteDataTypeArrayDimension</param>
    /// <param name="_xlsColumnValueIndex">XLS表列值索引</param>
    /// <param name="_sqliteColumnName">数据库列名称</param>
    /// <param name="_sqliteColumnValue">数据库列值</param>
    /// <param name="_sqliteParameterName">数据库参数名称</param>
    /// <param name="_isPK">是否是主键</param>
    /// <param name="_isIngore">是否忽略此字段</param>
    public SQLiteFieldTypeAttribute(int _dataType,
        int _arrayDimension,
        int _xlsColumnValueIndex, string _sqliteColumnName, string _sqliteColumnValue,string _sqliteParameterName, bool _isPK, bool _isIngore)
        : base(_dataType.ToString() + "_" + _arrayDimension.ToString())
    {
        dataType = _dataType;
        arrayDimension = _arrayDimension;
        xlsColumnValueIndex = _xlsColumnValueIndex;
        sqliteColumnName = _sqliteColumnName;
        sqliteColumnValue = _sqliteColumnValue;
        sqliteParameterName = _sqliteParameterName;
        isPK = _isPK;
        isIngore = _isIngore;
    }

    /// <summary>
    /// 数据类型enSQLiteDataType
    /// </summary>
    public int dataType { get; private set; }
    /// <summary>
    /// 数组维度enSQLiteDataTypeArrayDimension
    /// </summary>
    public int arrayDimension { get; private set; }
    /// <summary>
    /// XLS表列值索引
    /// </summary>
    public int xlsColumnValueIndex { get; private set; }
    /// <summary>
    /// 数据库列名称
    /// </summary>
    public string sqliteColumnName { get; private set; }
    /// <summary>
    /// 数据库列值
    /// </summary>
    public string sqliteColumnValue { get; private set; }
    /// <summary>
    /// 数据库参数名称
    /// </summary>
    public string sqliteParameterName { get; private set; }
    /// <summary>
    /// 是否是主键
    /// </summary>
    public bool isPK { get; private set; }
    /// <summary>
    /// 是否忽略此字段
    /// </summary>
    public bool isIngore { get; private set; }
}
