/*
 * SQLite数据类型映射
 */
#region enSQLiteDataType SQLite数据类型映射
/// <summary>
/// 代码类型
/// </summary>
public static class enSQLiteDataType
{
    /// <summary>
    /// Boolean
    /// </summary>
    [Code("bool", "BIT")]
    public const int Boolean = 0x1;
    /// <summary>
    /// Char
    /// </summary>
    [Code("char", "CHAR")]
    public const int Char = 0x2;
    /// <summary>
    /// SByte
    /// </summary>
    [Code("sbyte", "TINYSINT")]
    public const int SByte = 0x4;
    /// <summary>
    /// Byte
    /// </summary>
    [Code("byte", "TINYINT")]
    public const int Byte = 0x8;
    /// <summary>
    /// Int16
    /// </summary>
    [Code("short", "SMALLINT")]
    public const int Int16 = 0x10;
    /// <summary>
    /// UInt16
    /// </summary>
    [Code("ushort", "SMALLUINT")]
    public const int UInt16 = 0x20;
    /// <summary>
    /// Int32
    /// </summary>
    [Code("int", "INT")]
    public const int Int32 = 0x40;
    /// <summary>
    /// UInt32
    /// </summary>
    [Code("uint", "UINT")]
    public const int UInt32 = 0x80;
    /// <summary>
    /// Int64
    /// </summary>
    [Code("long", "INTEGER")]
    public const int Int64 = 0x100;
    /// <summary>
    /// UInt64
    /// </summary>
    [Code("ulong", "UNSIGNEDINTEGER")]
    public const int UInt64 = 0x200;
    /// <summary>
    /// Single
    /// </summary>
    [Code("float", "SINGLE")]
    public const int Single = 0x400;
    /// <summary>
    /// Double
    /// </summary>
    [Code("double", "REAL")]
    public const int Double = 0x800;
    /// <summary>
    /// Decimal
    /// </summary>
    [Code("decimal", "DECIMAL")]
    public const int Decimal = 0x1000;
    /// <summary>
    /// DateTime
    /// </summary>
    [Code("DateTime", "DATETIME")]
    public const int DateTime = 0x2000;
    /// <summary>
    /// String
    /// </summary>
    [Code("string", "NVARCHAR")]
    public const int String = 0x4000;
    /// <summary>
    /// String
    /// </summary>
    [Code("Guid", "UNIQUEIDENTIFIER")]
    public const int Guid = 0x8000;
    /// <summary>
    /// Vector2
    /// </summary>
    [Code("Vector2", "VECTOR2")]
    public const int Vector2 = 0x10000;
    /// <summary>
    /// Vector3
    /// </summary>
    [Code("Vector3", "VECTOR3")]
    public const int Vector3 = 0x20000;
    /// <summary>
    /// Vector4
    /// </summary>
    [Code("Vector4", "VECTOR4")]
    public const int Vector4 = 0x40000;
}
#endregion

#region enSQLiteDataTypeArrayDimension SQLite数据类型映射数组维度
/// <summary>
/// 数组维度
/// </summary>
public static class enSQLiteDataTypeArrayDimension
{
    /// <summary>
    /// 非数组
    /// </summary>
    [Code("非数组", "","")]
    public const int NoArray = 0x1;
    /// <summary>
    /// 一维数组
    /// </summary>
    [Code("一维数组", "[]", "DIM")]
    public const int OneDimensionArray = 0x2;
    /// <summary>
    /// 二维数组
    /// </summary>
    [Code("二维数组", "[][]", "DIM2")]
    public const int TwoDimensionArray = 0x4;
}
#endregion
