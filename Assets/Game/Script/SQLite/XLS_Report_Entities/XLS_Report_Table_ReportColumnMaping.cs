using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ReportColumnMaping实体
/// </summary>
[SQLiteTableMap(-417602184,"Assets/Game/Editor/XLS_Report/ReportColumnMaping.xlsx","ReportColumnMaping", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1833182787",typeof(XLS_Report_Table_ReportColumnMaping))]
public partial class XLS_Report_Table_ReportColumnMaping: AbsStrayFogSQLiteEntity
{
	
	/// <summary>
	/// bool非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,1,"@boolCol1",false)]
	public bool boolCol { get; private set; }
	/// <summary>
	/// char非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.NoArray,2,"@charCol2",false)]
	public char charCol { get; private set; }
	/// <summary>
	/// sbyte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.NoArray,3,"@sbyteCol3",false)]
	public sbyte sbyteCol { get; private set; }
	/// <summary>
	/// byte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.NoArray,4,"@byteCol4",false)]
	public byte byteCol { get; private set; }
	/// <summary>
	/// short非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.NoArray,5,"@shortCol5",false)]
	public short shortCol { get; private set; }
	/// <summary>
	/// ushort非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.NoArray,6,"@ushortCol6",false)]
	public ushort ushortCol { get; private set; }
	/// <summary>
	/// int非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,7,"@intCol7",false)]
	public int intCol { get; private set; }
	/// <summary>
	/// uint非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.NoArray,8,"@uintCol8",false)]
	public uint uintCol { get; private set; }
	/// <summary>
	/// long非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.NoArray,9,"@longCol9",false)]
	public long longCol { get; private set; }
	/// <summary>
	/// ulong非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.NoArray,10,"@ulongCol10",false)]
	public ulong ulongCol { get; private set; }
	/// <summary>
	/// float非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.NoArray,11,"@floatCol11",false)]
	public float floatCol { get; private set; }
	/// <summary>
	/// double非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.NoArray,12,"@doubleCol12",false)]
	public double doubleCol { get; private set; }
	/// <summary>
	/// decimal非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.NoArray,13,"@decimalCol13",false)]
	public decimal decimalCol { get; private set; }
	/// <summary>
	/// DateTime非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.NoArray,14,"@DateTimeCol14",false)]
	public DateTime DateTimeCol { get; private set; }
	/// <summary>
	/// string非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,15,"@stringCol15",false)]
	public string stringCol { get; private set; }
	/// <summary>
	/// Guid非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.NoArray,16,"@GuidCol16",false)]
	public Guid GuidCol { get; private set; }
	/// <summary>
	/// Vector2非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.NoArray,17,"@Vector2Col17",false)]
	public Vector2 Vector2Col { get; private set; }
	/// <summary>
	/// Vector3非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.NoArray,18,"@Vector3Col18",false)]
	public Vector3 Vector3Col { get; private set; }
	/// <summary>
	/// Vector4非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.NoArray,19,"@Vector4Col19",false)]
	public Vector4 Vector4Col { get; private set; }
	/// <summary>
	/// bool一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.OneDimensionArray,20,"@boolDIMCol20",false)]
	public bool[] boolDIMCol { get; private set; }
	/// <summary>
	/// char一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.OneDimensionArray,21,"@charDIMCol21",false)]
	public char[] charDIMCol { get; private set; }
	/// <summary>
	/// sbyte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.OneDimensionArray,22,"@sbyteDIMCol22",false)]
	public sbyte[] sbyteDIMCol { get; private set; }
	/// <summary>
	/// byte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.OneDimensionArray,23,"@byteDIMCol23",false)]
	public byte[] byteDIMCol { get; private set; }
	/// <summary>
	/// short一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.OneDimensionArray,24,"@shortDIMCol24",false)]
	public short[] shortDIMCol { get; private set; }
	/// <summary>
	/// ushort一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.OneDimensionArray,25,"@ushortDIMCol25",false)]
	public ushort[] ushortDIMCol { get; private set; }
	/// <summary>
	/// int一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,26,"@intDIMCol26",false)]
	public int[] intDIMCol { get; private set; }
	/// <summary>
	/// uint一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.OneDimensionArray,27,"@uintDIMCol27",false)]
	public uint[] uintDIMCol { get; private set; }
	/// <summary>
	/// long一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.OneDimensionArray,28,"@longDIMCol28",false)]
	public long[] longDIMCol { get; private set; }
	/// <summary>
	/// ulong一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.OneDimensionArray,29,"@ulongDIMCol29",false)]
	public ulong[] ulongDIMCol { get; private set; }
	/// <summary>
	/// float一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.OneDimensionArray,30,"@floatDIMCol30",false)]
	public float[] floatDIMCol { get; private set; }
	/// <summary>
	/// double一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.OneDimensionArray,31,"@doubleDIMCol31",false)]
	public double[] doubleDIMCol { get; private set; }
	/// <summary>
	/// decimal一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.OneDimensionArray,32,"@decimalDIMCol32",false)]
	public decimal[] decimalDIMCol { get; private set; }
	/// <summary>
	/// DateTime一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.OneDimensionArray,33,"@DateTimeDIMCol33",false)]
	public DateTime[] DateTimeDIMCol { get; private set; }
	/// <summary>
	/// string一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.OneDimensionArray,34,"@stringDIMCol34",false)]
	public string[] stringDIMCol { get; private set; }
	/// <summary>
	/// Guid一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.OneDimensionArray,35,"@GuidDIMCol35",false)]
	public Guid[] GuidDIMCol { get; private set; }
	/// <summary>
	/// Vector2一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray,36,"@Vector2DIMCol36",false)]
	public Vector2[] Vector2DIMCol { get; private set; }
	/// <summary>
	/// Vector3一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.OneDimensionArray,37,"@Vector3DIMCol37",false)]
	public Vector3[] Vector3DIMCol { get; private set; }
	/// <summary>
	/// Vector4一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.OneDimensionArray,38,"@Vector4DIMCol38",false)]
	public Vector4[] Vector4DIMCol { get; private set; }
	/// <summary>
	/// bool二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.TwoDimensionArray,39,"@boolDIM2Col39",false)]
	public bool[][] boolDIM2Col { get; private set; }
	/// <summary>
	/// char二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.TwoDimensionArray,40,"@charDIM2Col40",false)]
	public char[][] charDIM2Col { get; private set; }
	/// <summary>
	/// sbyte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.TwoDimensionArray,41,"@sbyteDIM2Col41",false)]
	public sbyte[][] sbyteDIM2Col { get; private set; }
	/// <summary>
	/// byte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.TwoDimensionArray,42,"@byteDIM2Col42",false)]
	public byte[][] byteDIM2Col { get; private set; }
	/// <summary>
	/// short二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.TwoDimensionArray,43,"@shortDIM2Col43",false)]
	public short[][] shortDIM2Col { get; private set; }
	/// <summary>
	/// ushort二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.TwoDimensionArray,44,"@ushortDIM2Col44",false)]
	public ushort[][] ushortDIM2Col { get; private set; }
	/// <summary>
	/// int二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.TwoDimensionArray,45,"@intDIM2Col45",false)]
	public int[][] intDIM2Col { get; private set; }
	/// <summary>
	/// uint二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.TwoDimensionArray,46,"@uintDIM2Col46",false)]
	public uint[][] uintDIM2Col { get; private set; }
	/// <summary>
	/// long二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.TwoDimensionArray,47,"@longDIM2Col47",false)]
	public long[][] longDIM2Col { get; private set; }
	/// <summary>
	/// ulong二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.TwoDimensionArray,48,"@ulongDIM2Col48",false)]
	public ulong[][] ulongDIM2Col { get; private set; }
	/// <summary>
	/// float二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.TwoDimensionArray,49,"@floatDIM2Col49",false)]
	public float[][] floatDIM2Col { get; private set; }
	/// <summary>
	/// double二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.TwoDimensionArray,50,"@doubleDIM2Col50",false)]
	public double[][] doubleDIM2Col { get; private set; }
	/// <summary>
	/// decimal二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.TwoDimensionArray,51,"@decimalDIM2Col51",false)]
	public decimal[][] decimalDIM2Col { get; private set; }
	/// <summary>
	/// DateTime二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.TwoDimensionArray,52,"@DateTimeDIM2Col52",false)]
	public DateTime[][] DateTimeDIM2Col { get; private set; }
	/// <summary>
	/// string二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.TwoDimensionArray,53,"@stringDIM2Col53",false)]
	public string[][] stringDIM2Col { get; private set; }
	/// <summary>
	/// Guid二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.TwoDimensionArray,54,"@GuidDIM2Col54",false)]
	public Guid[][] GuidDIM2Col { get; private set; }
	/// <summary>
	/// Vector2二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.TwoDimensionArray,55,"@Vector2DIM2Col55",false)]
	public Vector2[][] Vector2DIM2Col { get; private set; }
	/// <summary>
	/// Vector3二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.TwoDimensionArray,56,"@Vector3DIM2Col56",false)]
	public Vector3[][] Vector3DIM2Col { get; private set; }
	/// <summary>
	/// Vector4二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.TwoDimensionArray,57,"@Vector4DIM2Col57",false)]
	public Vector4[][] Vector4DIM2Col { get; private set; }
}