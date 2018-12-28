/*
 * SQLite数据类型映射
 */
#region enSQLiteDataType SQLite数据类型映射
/// <summary>
/// 代码类型
/// </summary>
public enum enSQLiteDataType
{
    /// <summary>
    /// Boolean
    /// </summary>
    [Code("bool", "BIT")]
    Boolean,
    /// <summary>
    /// Char
    /// </summary>
    [Code("char", "CHAR")]
    Char,
    /// <summary>
    /// SByte
    /// </summary>
    [Code("sbyte", "TINYSINT")]
    SByte,
    /// <summary>
    /// Byte
    /// </summary>
    [Code("byte", "TINYINT")]
    Byte,
    /// <summary>
    /// Int16
    /// </summary>
    [Code("short", "SMALLINT")]
    Int16,
    /// <summary>
    /// UInt16
    /// </summary>
    [Code("ushort", "SMALLUINT")]
    UInt16,
    /// <summary>
    /// Int32
    /// </summary>
    [Code("int", "INT")]
    Int32,
    /// <summary>
    /// UInt32
    /// </summary>
    [Code("uint", "UINT")]
    UInt32,
    /// <summary>
    /// Int64
    /// </summary>
    [Code("long", "INTEGER")]
    Int64,
    /// <summary>
    /// UInt64
    /// </summary>
    [Code("ulong", "UNSIGNEDINTEGER")]
    UInt64,
    /// <summary>
    /// Single
    /// </summary>
    [Code("float", "SINGLE")]
    Single,
    /// <summary>
    /// Double
    /// </summary>
    [Code("double", "REAL")]
    Double,
    /// <summary>
    /// Decimal
    /// </summary>
    [Code("decimal", "DECIMAL")]
    Decimal,
    /// <summary>
    /// DateTime
    /// </summary>
    [Code("DateTime", "DATETIME")]
    DateTime,
    /// <summary>
    /// String
    /// </summary>
    [Code("string", "NVARCHAR")]
    String,
    /// <summary>
    /// String
    /// </summary>
    [Code("Guid", "UNIQUEIDENTIFIER")]
    Guid,    
    /// <summary>
    /// Vector2
    /// </summary>
    [Code("Vector2", "VECTOR2")]
    Vector2,
    /// <summary>
    /// Vector3
    /// </summary>
    [Code("Vector3", "VECTOR3")]
    Vector3,
    /// <summary>
    /// Vector4
    /// </summary>
    [Code("Vector4", "VECTOR4")]
    Vector4,
}
#endregion

#region enSQLiteDataTypeArrayDimension SQLite数据类型映射数组维度
/// <summary>
/// 数组维度
/// </summary>
public enum enSQLiteDataTypeArrayDimension
{
    /// <summary>
    /// 非数组
    /// </summary>
    [Code("非数组", "","")]
    NoArray,
    /// <summary>
    /// 一维数组
    /// </summary>
    [Code("一维数组", "[]", "BLOB")]
    OneDimensionArray,
    /// <summary>
    /// 二维数组
    /// </summary>
    [Code("二维数组", "[][]", "BLOB")]
    TwoDimensionArray,
}
#endregion
