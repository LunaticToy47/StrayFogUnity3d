using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// TableColumnMaping实体
/// </summary>
[SQLiteTableMap(169751818,"Assets/Game/Editor/XLS_Config/TableColumnMaping.xlsx","TableColumnMaping", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_TableColumnMaping),false,false)]
public partial class XLS_Config_Table_TableColumnMaping: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// bool非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,1,"boolCol","","@boolCol1",false,false)]	
	public bool boolCol { get; private set; }	
		
	/// <summary>
	/// char非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.NoArray,2,"charCol","","@charCol2",false,false)]	
	public char charCol { get; private set; }	
		
	/// <summary>
	/// sbyte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.NoArray,3,"sbyteCol","","@sbyteCol3",false,false)]	
	public sbyte sbyteCol { get; private set; }	
		
	/// <summary>
	/// byte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.NoArray,4,"byteCol","","@byteCol4",false,false)]	
	public byte byteCol { get; private set; }	
		
	/// <summary>
	/// short非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.NoArray,5,"shortCol","","@shortCol5",false,false)]	
	public short shortCol { get; private set; }	
		
	/// <summary>
	/// ushort非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.NoArray,6,"ushortCol","","@ushortCol6",false,false)]	
	public ushort ushortCol { get; private set; }	
		
	/// <summary>
	/// int非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,7,"intCol","","@intCol7",false,false)]	
	public int intCol { get; private set; }	
		
	/// <summary>
	/// uint非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.NoArray,8,"uintCol","","@uintCol8",false,false)]	
	public uint uintCol { get; private set; }	
		
	/// <summary>
	/// long非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.NoArray,9,"longCol","","@longCol9",false,false)]	
	public long longCol { get; private set; }	
		
	/// <summary>
	/// ulong非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.NoArray,10,"ulongCol","","@ulongCol10",false,false)]	
	public ulong ulongCol { get; private set; }	
		
	/// <summary>
	/// float非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.NoArray,11,"floatCol","","@floatCol11",false,false)]	
	public float floatCol { get; private set; }	
		
	/// <summary>
	/// double非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.NoArray,12,"doubleCol","","@doubleCol12",false,false)]	
	public double doubleCol { get; private set; }	
		
	/// <summary>
	/// decimal非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.NoArray,13,"decimalCol","","@decimalCol13",false,false)]	
	public decimal decimalCol { get; private set; }	
		
	/// <summary>
	/// DateTime非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.NoArray,14,"DateTimeCol","","@DateTimeCol14",false,false)]	
	public DateTime DateTimeCol { get; private set; }	
		
	/// <summary>
	/// string非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,15,"stringCol","","@stringCol15",false,false)]	
	public string stringCol { get; private set; }	
		
	/// <summary>
	/// Guid非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.NoArray,16,"GuidCol","","@GuidCol16",false,false)]	
	public Guid GuidCol { get; private set; }	
		
	/// <summary>
	/// Vector2非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.NoArray,17,"Vector2Col","","@Vector2Col17",false,false)]	
	public Vector2 Vector2Col { get; private set; }	
		
	/// <summary>
	/// Vector3非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.NoArray,18,"Vector3Col","","@Vector3Col18",false,false)]	
	public Vector3 Vector3Col { get; private set; }	
		
	/// <summary>
	/// Vector4非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.NoArray,19,"Vector4Col","","@Vector4Col19",false,false)]	
	public Vector4 Vector4Col { get; private set; }	
		
	/// <summary>
	/// bool一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.OneDimensionArray,20,"boolDIMCol","","@boolDIMCol20",false,false)]	
	public bool[] boolDIMCol { get; private set; }	
		
	/// <summary>
	/// char一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.OneDimensionArray,21,"charDIMCol","","@charDIMCol21",false,false)]	
	public char[] charDIMCol { get; private set; }	
		
	/// <summary>
	/// sbyte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.OneDimensionArray,22,"sbyteDIMCol","","@sbyteDIMCol22",false,false)]	
	public sbyte[] sbyteDIMCol { get; private set; }	
		
	/// <summary>
	/// byte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.OneDimensionArray,23,"byteDIMCol","","@byteDIMCol23",false,false)]	
	public byte[] byteDIMCol { get; private set; }	
		
	/// <summary>
	/// short一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.OneDimensionArray,24,"shortDIMCol","","@shortDIMCol24",false,false)]	
	public short[] shortDIMCol { get; private set; }	
		
	/// <summary>
	/// ushort一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.OneDimensionArray,25,"ushortDIMCol","","@ushortDIMCol25",false,false)]	
	public ushort[] ushortDIMCol { get; private set; }	
		
	/// <summary>
	/// int一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,26,"intDIMCol","","@intDIMCol26",false,false)]	
	public int[] intDIMCol { get; private set; }	
		
	/// <summary>
	/// uint一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.OneDimensionArray,27,"uintDIMCol","","@uintDIMCol27",false,false)]	
	public uint[] uintDIMCol { get; private set; }	
		
	/// <summary>
	/// long一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.OneDimensionArray,28,"longDIMCol","","@longDIMCol28",false,false)]	
	public long[] longDIMCol { get; private set; }	
		
	/// <summary>
	/// ulong一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.OneDimensionArray,29,"ulongDIMCol","","@ulongDIMCol29",false,false)]	
	public ulong[] ulongDIMCol { get; private set; }	
		
	/// <summary>
	/// float一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.OneDimensionArray,30,"floatDIMCol","","@floatDIMCol30",false,false)]	
	public float[] floatDIMCol { get; private set; }	
		
	/// <summary>
	/// double一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.OneDimensionArray,31,"doubleDIMCol","","@doubleDIMCol31",false,false)]	
	public double[] doubleDIMCol { get; private set; }	
		
	/// <summary>
	/// decimal一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.OneDimensionArray,32,"decimalDIMCol","","@decimalDIMCol32",false,false)]	
	public decimal[] decimalDIMCol { get; private set; }	
		
	/// <summary>
	/// DateTime一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.OneDimensionArray,33,"DateTimeDIMCol","","@DateTimeDIMCol33",false,false)]	
	public DateTime[] DateTimeDIMCol { get; private set; }	
		
	/// <summary>
	/// string一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.OneDimensionArray,34,"stringDIMCol","","@stringDIMCol34",false,false)]	
	public string[] stringDIMCol { get; private set; }	
		
	/// <summary>
	/// Guid一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.OneDimensionArray,35,"GuidDIMCol","","@GuidDIMCol35",false,false)]	
	public Guid[] GuidDIMCol { get; private set; }	
		
	/// <summary>
	/// Vector2一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray,36,"Vector2DIMCol","","@Vector2DIMCol36",false,false)]	
	public Vector2[] Vector2DIMCol { get; private set; }	
		
	/// <summary>
	/// Vector3一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.OneDimensionArray,37,"Vector3DIMCol","","@Vector3DIMCol37",false,false)]	
	public Vector3[] Vector3DIMCol { get; private set; }	
		
	/// <summary>
	/// Vector4一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.OneDimensionArray,38,"Vector4DIMCol","","@Vector4DIMCol38",false,false)]	
	public Vector4[] Vector4DIMCol { get; private set; }	
		
	/// <summary>
	/// bool二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.TwoDimensionArray,39,"boolDIM2Col","","@boolDIM2Col39",false,false)]	
	public bool[][] boolDIM2Col { get; private set; }	
		
	/// <summary>
	/// char二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.TwoDimensionArray,40,"charDIM2Col","","@charDIM2Col40",false,false)]	
	public char[][] charDIM2Col { get; private set; }	
		
	/// <summary>
	/// sbyte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.TwoDimensionArray,41,"sbyteDIM2Col","","@sbyteDIM2Col41",false,false)]	
	public sbyte[][] sbyteDIM2Col { get; private set; }	
		
	/// <summary>
	/// byte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.TwoDimensionArray,42,"byteDIM2Col","","@byteDIM2Col42",false,false)]	
	public byte[][] byteDIM2Col { get; private set; }	
		
	/// <summary>
	/// short二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.TwoDimensionArray,43,"shortDIM2Col","","@shortDIM2Col43",false,false)]	
	public short[][] shortDIM2Col { get; private set; }	
		
	/// <summary>
	/// ushort二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.TwoDimensionArray,44,"ushortDIM2Col","","@ushortDIM2Col44",false,false)]	
	public ushort[][] ushortDIM2Col { get; private set; }	
		
	/// <summary>
	/// int二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.TwoDimensionArray,45,"intDIM2Col","","@intDIM2Col45",false,false)]	
	public int[][] intDIM2Col { get; private set; }	
		
	/// <summary>
	/// uint二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.TwoDimensionArray,46,"uintDIM2Col","","@uintDIM2Col46",false,false)]	
	public uint[][] uintDIM2Col { get; private set; }	
		
	/// <summary>
	/// long二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.TwoDimensionArray,47,"longDIM2Col","","@longDIM2Col47",false,false)]	
	public long[][] longDIM2Col { get; private set; }	
		
	/// <summary>
	/// ulong二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.TwoDimensionArray,48,"ulongDIM2Col","","@ulongDIM2Col48",false,false)]	
	public ulong[][] ulongDIM2Col { get; private set; }	
		
	/// <summary>
	/// float二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.TwoDimensionArray,49,"floatDIM2Col","","@floatDIM2Col49",false,false)]	
	public float[][] floatDIM2Col { get; private set; }	
		
	/// <summary>
	/// double二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.TwoDimensionArray,50,"doubleDIM2Col","","@doubleDIM2Col50",false,false)]	
	public double[][] doubleDIM2Col { get; private set; }	
		
	/// <summary>
	/// decimal二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.TwoDimensionArray,51,"decimalDIM2Col","","@decimalDIM2Col51",false,false)]	
	public decimal[][] decimalDIM2Col { get; private set; }	
		
	/// <summary>
	/// DateTime二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.TwoDimensionArray,52,"DateTimeDIM2Col","","@DateTimeDIM2Col52",false,false)]	
	public DateTime[][] DateTimeDIM2Col { get; private set; }	
		
	/// <summary>
	/// string二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.TwoDimensionArray,53,"stringDIM2Col","","@stringDIM2Col53",false,false)]	
	public string[][] stringDIM2Col { get; private set; }	
		
	/// <summary>
	/// Guid二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.TwoDimensionArray,54,"GuidDIM2Col","","@GuidDIM2Col54",false,false)]	
	public Guid[][] GuidDIM2Col { get; private set; }	
		
	/// <summary>
	/// Vector2二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.TwoDimensionArray,55,"Vector2DIM2Col","","@Vector2DIM2Col55",false,false)]	
	public Vector2[][] Vector2DIM2Col { get; private set; }	
		
	/// <summary>
	/// Vector3二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.TwoDimensionArray,56,"Vector3DIM2Col","","@Vector3DIM2Col56",false,false)]	
	public Vector3[][] Vector3DIM2Col { get; private set; }	
		
	/// <summary>
	/// Vector4二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.TwoDimensionArray,57,"Vector4DIM2Col","","@Vector4DIM2Col57",false,false)]	
	public Vector4[][] Vector4DIM2Col { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}