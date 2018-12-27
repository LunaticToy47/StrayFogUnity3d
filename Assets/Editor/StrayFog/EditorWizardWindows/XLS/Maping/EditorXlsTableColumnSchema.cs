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
    public string name;
    /// <summary>
    /// 列描述
    /// </summary>
    [AliasTooltip("列描述")]
    public string desc;
    /// <summary>
    /// 列类型
    /// </summary>
    [AliasTooltip("列类型")]
    public enTypeCode type;
    /// <summary>
    /// 数组维度
    /// </summary>
    [AliasTooltip("数组维度")]
    public enArrayDimension arrayDimension;
}

#region enTypeCode 代码类型
/// <summary>
/// 代码类型
/// </summary>
public enum enTypeCode
{
    /// <summary>
    /// Boolean
    /// </summary>
    [Code("bool")]
    Boolean = 3,
    /// <summary>
    /// Char
    /// </summary>
    [Code("char")]
    Char = 4,
    /// <summary>
    /// SByte
    /// </summary>
    [Code("sbyte")]
    SByte = 5,
    /// <summary>
    /// Byte
    /// </summary>
    [Code("byte")]
    Byte = 6,
    /// <summary>
    /// Int16
    /// </summary>
    [Code("short")]
    Int16 = 7,
    /// <summary>
    /// UInt16
    /// </summary>
    [Code("ushort")]
    UInt16 = 8,
    /// <summary>
    /// Int32
    /// </summary>
    [Code("int")]
    Int32 = 9,
    /// <summary>
    /// UInt32
    /// </summary>
    [Code("uint")]
    UInt32 = 10,
    /// <summary>
    /// Int64
    /// </summary>
    [Code("long")]
    Int64 = 11,
    /// <summary>
    /// UInt64
    /// </summary>
    [Code("ulong")]
    UInt64 = 12,
    /// <summary>
    /// Single
    /// </summary>
    [Code("float")]
    Single = 13,
    /// <summary>
    /// Double
    /// </summary>
    [Code("double")]
    Double = 14,
    /// <summary>
    /// Decimal
    /// </summary>
    [Code("decimal")]
    Decimal = 15,
    /// <summary>
    /// DateTime
    /// </summary>
    [Code("DateTime")]
    DateTime = 16,
    /// <summary>
    /// String
    /// </summary>
    [Code("string")]
    String = 18,
    /// <summary>
    /// Vector2
    /// </summary>
    [Code("Vector2")]
    Vector2 = 100,
    /// <summary>
    /// Vector3
    /// </summary>
    [Code("Vector3")]
    Vector3 = 200,
    /// <summary>
    /// Vector4
    /// </summary>
    [Code("Vector4")]
    Vector4 = 300,
}
#endregion

#region enArrayDimension 数组维度
/// <summary>
/// 数组维度
/// </summary>
public enum enArrayDimension
{
    /// <summary>
    /// 非数组
    /// </summary>
    [Code("非数组", "")]
    NoArray,
    /// <summary>
    /// 一维数组
    /// </summary>
    [Code("一维数组", "[]")]
    OneDimensionArray,
    /// <summary>
    /// 二维数组
    /// </summary>
    [Code("二维数组", "[]", "TAS")]
    TwoDimensionArray,
}
#endregion