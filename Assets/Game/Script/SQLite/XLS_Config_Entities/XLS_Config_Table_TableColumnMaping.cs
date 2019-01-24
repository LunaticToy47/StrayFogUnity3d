using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// TableColumnMaping实体
/// </summary>
[SQLiteTableMap(-2027841950,"Assets/Game/Editor/XLS_Config/TableColumnMaping.xlsx","TableColumnMaping", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_TableColumnMaping))]
public partial class XLS_Config_Table_TableColumnMaping: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// bool非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool boolCol { get; private set; }
	/// <summary>
	/// char非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.NoArray)]
	public char charCol { get; private set; }
	/// <summary>
	/// sbyte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.NoArray)]
	public sbyte sbyteCol { get; private set; }
	/// <summary>
	/// byte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.NoArray)]
	public byte byteCol { get; private set; }
	/// <summary>
	/// short非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.NoArray)]
	public short shortCol { get; private set; }
	/// <summary>
	/// ushort非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.NoArray)]
	public ushort ushortCol { get; private set; }
	/// <summary>
	/// int非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int intCol { get; private set; }
	/// <summary>
	/// uint非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.NoArray)]
	public uint uintCol { get; private set; }
	/// <summary>
	/// long非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.NoArray)]
	public long longCol { get; private set; }
	/// <summary>
	/// ulong非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.NoArray)]
	public ulong ulongCol { get; private set; }
	/// <summary>
	/// float非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.NoArray)]
	public float floatCol { get; private set; }
	/// <summary>
	/// double非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.NoArray)]
	public double doubleCol { get; private set; }
	/// <summary>
	/// decimal非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.NoArray)]
	public decimal decimalCol { get; private set; }
	/// <summary>
	/// DateTime非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.NoArray)]
	public DateTime DateTimeCol { get; private set; }
	/// <summary>
	/// string非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string stringCol { get; private set; }
	/// <summary>
	/// Guid非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.NoArray)]
	public Guid GuidCol { get; private set; }
	/// <summary>
	/// Vector2非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.NoArray)]
	public Vector2 Vector2Col { get; private set; }
	/// <summary>
	/// Vector3非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.NoArray)]
	public Vector3 Vector3Col { get; private set; }
	/// <summary>
	/// Vector4非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.NoArray)]
	public Vector4 Vector4Col { get; private set; }
	/// <summary>
	/// bool一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public bool[] boolDIMCol { get; private set; }
	/// <summary>
	/// char一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public char[] charDIMCol { get; private set; }
	/// <summary>
	/// sbyte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public sbyte[] sbyteDIMCol { get; private set; }
	/// <summary>
	/// byte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public byte[] byteDIMCol { get; private set; }
	/// <summary>
	/// short一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public short[] shortDIMCol { get; private set; }
	/// <summary>
	/// ushort一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public ushort[] ushortDIMCol { get; private set; }
	/// <summary>
	/// int一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public int[] intDIMCol { get; private set; }
	/// <summary>
	/// uint一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public uint[] uintDIMCol { get; private set; }
	/// <summary>
	/// long一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public long[] longDIMCol { get; private set; }
	/// <summary>
	/// ulong一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public ulong[] ulongDIMCol { get; private set; }
	/// <summary>
	/// float一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public float[] floatDIMCol { get; private set; }
	/// <summary>
	/// double一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public double[] doubleDIMCol { get; private set; }
	/// <summary>
	/// decimal一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public decimal[] decimalDIMCol { get; private set; }
	/// <summary>
	/// DateTime一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public DateTime[] DateTimeDIMCol { get; private set; }
	/// <summary>
	/// string一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public string[] stringDIMCol { get; private set; }
	/// <summary>
	/// Guid一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public Guid[] GuidDIMCol { get; private set; }
	/// <summary>
	/// Vector2一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public Vector2[] Vector2DIMCol { get; private set; }
	/// <summary>
	/// Vector3一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public Vector3[] Vector3DIMCol { get; private set; }
	/// <summary>
	/// Vector4一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public Vector4[] Vector4DIMCol { get; private set; }
	/// <summary>
	/// bool二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public bool[][] boolDIM2Col { get; private set; }
	/// <summary>
	/// char二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public char[][] charDIM2Col { get; private set; }
	/// <summary>
	/// sbyte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public sbyte[][] sbyteDIM2Col { get; private set; }
	/// <summary>
	/// byte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public byte[][] byteDIM2Col { get; private set; }
	/// <summary>
	/// short二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public short[][] shortDIM2Col { get; private set; }
	/// <summary>
	/// ushort二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public ushort[][] ushortDIM2Col { get; private set; }
	/// <summary>
	/// int二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public int[][] intDIM2Col { get; private set; }
	/// <summary>
	/// uint二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public uint[][] uintDIM2Col { get; private set; }
	/// <summary>
	/// long二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public long[][] longDIM2Col { get; private set; }
	/// <summary>
	/// ulong二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public ulong[][] ulongDIM2Col { get; private set; }
	/// <summary>
	/// float二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public float[][] floatDIM2Col { get; private set; }
	/// <summary>
	/// double二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public double[][] doubleDIM2Col { get; private set; }
	/// <summary>
	/// decimal二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public decimal[][] decimalDIM2Col { get; private set; }
	/// <summary>
	/// DateTime二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public DateTime[][] DateTimeDIM2Col { get; private set; }
	/// <summary>
	/// string二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public string[][] stringDIM2Col { get; private set; }
	/// <summary>
	/// Guid二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public Guid[][] GuidDIM2Col { get; private set; }
	/// <summary>
	/// Vector2二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public Vector2[][] Vector2DIM2Col { get; private set; }
	/// <summary>
	/// Vector3二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public Vector3[][] Vector3DIM2Col { get; private set; }
	/// <summary>
	/// Vector4二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.TwoDimensionArray)]
	public Vector4[][] Vector4DIM2Col { get; private set; }
}