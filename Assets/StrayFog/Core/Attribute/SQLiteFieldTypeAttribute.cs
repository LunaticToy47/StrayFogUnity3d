using System;
using UnityEngine;
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
    public SQLiteFieldTypeAttribute(enSQLiteDataType _dataType, enSQLiteDataTypeArrayDimension _arrayDimension)
        : this(_dataType.ToString() +"_" + _arrayDimension.ToString(), _dataType, _arrayDimension)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_arrayDimension">数组维度</param>
    public SQLiteFieldTypeAttribute(string _alias, enSQLiteDataType _dataType, enSQLiteDataTypeArrayDimension _arrayDimension)
        : base(_alias)
    {
        dataType = _dataType;
        arrayDimension = _arrayDimension;
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enSQLiteDataType dataType { get; private set; }
    /// <summary>
    /// 数组维度
    /// </summary>
    public enSQLiteDataTypeArrayDimension arrayDimension { get; private set; }
}
