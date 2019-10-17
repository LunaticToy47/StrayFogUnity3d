using System;
using UnityEngine;
/// <summary>
/// XLS表格列架构
/// </summary>
[Serializable]
public class EditorXlsTableColumnSchema
{
    /// <summary>
    /// 列名称
    /// </summary>
    [AliasTooltip("列名称")]
    [ReadOnly]
    public string columnName;
    /// <summary>
    /// 列描述
    /// </summary>
    [AliasTooltip("列描述")]
    [ReadOnly]
    public string desc;
    /// <summary>
    /// XLS表列值索引
    /// </summary>
    [AliasTooltip("XLS表列值索引")]
    [ReadOnly]
    public int xlsColumnValueIndex;    
    /// <summary>
    /// 是否是主键
    /// </summary>
    [AliasTooltip("是否是主键")]
    public bool isPK;
    /// <summary>
    /// 是否允许为空
    /// </summary>
    [AliasTooltip("是否允许为空")]
    public bool isNull;
    /// <summary>
    /// SQLite列名称
    /// </summary>
    [AliasTooltip("SQLite列名称")]
    [ReadOnly]
    public string sqliteColumnName;
    /// <summary>
    /// SQLite列值
    /// </summary>
    [AliasTooltip("SQLite列值")]
    [ReadOnly]
    public string sqliteColumnValue;       
    /// <summary>
    /// 列类型
    /// </summary>
    [AliasTooltip("列类型")]
    [ReadOnly]
    public enSQLiteDataType dataType;
    /// <summary>
    /// 数组维度
    /// </summary>
    [AliasTooltip("数组维度")]
    [ReadOnly]
    public enSQLiteDataTypeArrayDimension arrayDimension;
    /// <summary>
    /// 是否忽略此列
    /// </summary>
    [AliasTooltip("是否忽略此列")]
    public bool isIngore;

    /// <summary>
    /// SQLite数据库不为空架构
    /// </summary>
    public string sqliteSchemaNotNull { get { return isNull | isIngore ? "" : "NOT NULL"; } }

    #region sqliteParameterName 数据为参数名称
    /// <summary>
    /// 数据为参数名称
    /// </summary>
    public string sqliteParameterName { get { return string.Format("@{0}{1}", columnName, xlsColumnValueIndex); } }
    #endregion
}