using System;
using UnityEngine;
/// <summary>
/// XLS表格列架构
/// </summary>
[Serializable]
public class EditorXlsTableColumnSchema
{
    /// <summary>
    /// XLS表列索引
    /// </summary>
    [AliasTooltip("XLS表列索引")]
    [ReadOnly]
    public int xlsColumnIndex;
    /// <summary>
    /// 列名称
    /// </summary>
    [AliasTooltip("列名称")]
    [ReadOnly]
    public string columnName;
    /// <summary>
    /// SQLite列名称
    /// </summary>
    [AliasTooltip("SQLite列名称")]
    [ReadOnly]
    [HideInInspector]
    public string sqliteColumnName;
    /// <summary>
    /// 列描述
    /// </summary>
    [AliasTooltip("列描述")]
    [ReadOnly]
    public string desc;
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

    #region sqliteParameterName 数据为参数名称
    /// <summary>
    /// 数据为参数名称
    /// </summary>
    public string sqliteParameterName { get { return string.Format("@{0}{1}", columnName, xlsColumnIndex); } }
    #endregion
}