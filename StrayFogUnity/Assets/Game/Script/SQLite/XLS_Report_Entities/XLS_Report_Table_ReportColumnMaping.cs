using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ReportColumnMaping实体
/// </summary>
[SQLiteTableMap(139879864,"Assets/Game/Editor/XLS_Report/ReportColumnMaping.xlsx","ReportColumnMaping", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Report/XLS_Report.db","c__338089280",typeof(XLS_Report_Table_ReportColumnMaping),false,true)]
public partial class XLS_Report_Table_ReportColumnMaping: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// bool非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,1,"boolCol","","@boolCol1",false)]	
	public bool boolCol { get; private set; }	
		
	/// <summary>
	/// char非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.NoArray,2,"charCol","","@charCol2",false)]	
	public char charCol { get; private set; }	
		
	/// <summary>
	/// sbyte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.NoArray,3,"sbyteCol","","@sbyteCol3",false)]	
	public sbyte sbyteCol { get; private set; }	
		
	/// <summary>
	/// byte非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.NoArray,4,"byteCol","","@byteCol4",false)]	
	public byte byteCol { get; private set; }	
		
	/// <summary>
	/// short非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.NoArray,5,"shortCol","","@shortCol5",false)]	
	public short shortCol { get; private set; }	
		
	/// <summary>
	/// ushort非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.NoArray,6,"ushortCol","","@ushortCol6",false)]	
	public ushort ushortCol { get; private set; }	
		
	/// <summary>
	/// int非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,7,"intCol","","@intCol7",false)]	
	public int intCol { get; private set; }	
		
	/// <summary>
	/// uint非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.NoArray,8,"uintCol","","@uintCol8",false)]	
	public uint uintCol { get; private set; }	
		
	/// <summary>
	/// long非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.NoArray,9,"longCol","","@longCol9",false)]	
	public long longCol { get; private set; }	
		
	/// <summary>
	/// ulong非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.NoArray,10,"ulongCol","","@ulongCol10",false)]	
	public ulong ulongCol { get; private set; }	
		
	/// <summary>
	/// float非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.NoArray,11,"floatCol","","@floatCol11",false)]	
	public float floatCol { get; private set; }	
		
	/// <summary>
	/// double非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.NoArray,12,"doubleCol","","@doubleCol12",false)]	
	public double doubleCol { get; private set; }	
		
	/// <summary>
	/// decimal非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.NoArray,13,"decimalCol","","@decimalCol13",false)]	
	public decimal decimalCol { get; private set; }	
		
	/// <summary>
	/// DateTime非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.NoArray,14,"DateTimeCol","","@DateTimeCol14",false)]	
	public DateTime DateTimeCol { get; private set; }	
		
	/// <summary>
	/// string非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,15,"stringCol","","@stringCol15",false)]	
	public string stringCol { get; private set; }	
		
	/// <summary>
	/// Guid非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.NoArray,16,"GuidCol","","@GuidCol16",false)]	
	public Guid GuidCol { get; private set; }	
		
	/// <summary>
	/// Vector2非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.NoArray,17,"Vector2Col","","@Vector2Col17",false)]	
	public Vector2 Vector2Col { get; private set; }	
		
	/// <summary>
	/// Vector3非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.NoArray,18,"Vector3Col","","@Vector3Col18",false)]	
	public Vector3 Vector3Col { get; private set; }	
		
	/// <summary>
	/// Vector4非数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.NoArray,19,"Vector4Col","","@Vector4Col19",false)]	
	public Vector4 Vector4Col { get; private set; }	
		
	/// <summary>
	/// bool一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.OneDimensionArray,20,"boolDIMCol","","@boolDIMCol20",false)]	
	public bool[] boolDIMCol { get; private set; }	
		
	/// <summary>
	/// char一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.OneDimensionArray,21,"charDIMCol","","@charDIMCol21",false)]	
	public char[] charDIMCol { get; private set; }	
		
	/// <summary>
	/// sbyte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.OneDimensionArray,22,"sbyteDIMCol","","@sbyteDIMCol22",false)]	
	public sbyte[] sbyteDIMCol { get; private set; }	
		
	/// <summary>
	/// byte一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.OneDimensionArray,23,"byteDIMCol","","@byteDIMCol23",false)]	
	public byte[] byteDIMCol { get; private set; }	
		
	/// <summary>
	/// short一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.OneDimensionArray,24,"shortDIMCol","","@shortDIMCol24",false)]	
	public short[] shortDIMCol { get; private set; }	
		
	/// <summary>
	/// ushort一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.OneDimensionArray,25,"ushortDIMCol","","@ushortDIMCol25",false)]	
	public ushort[] ushortDIMCol { get; private set; }	
		
	/// <summary>
	/// int一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,26,"intDIMCol","","@intDIMCol26",false)]	
	public int[] intDIMCol { get; private set; }	
		
	/// <summary>
	/// uint一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.OneDimensionArray,27,"uintDIMCol","","@uintDIMCol27",false)]	
	public uint[] uintDIMCol { get; private set; }	
		
	/// <summary>
	/// long一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.OneDimensionArray,28,"longDIMCol","","@longDIMCol28",false)]	
	public long[] longDIMCol { get; private set; }	
		
	/// <summary>
	/// ulong一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.OneDimensionArray,29,"ulongDIMCol","","@ulongDIMCol29",false)]	
	public ulong[] ulongDIMCol { get; private set; }	
		
	/// <summary>
	/// float一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.OneDimensionArray,30,"floatDIMCol","","@floatDIMCol30",false)]	
	public float[] floatDIMCol { get; private set; }	
		
	/// <summary>
	/// double一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.OneDimensionArray,31,"doubleDIMCol","","@doubleDIMCol31",false)]	
	public double[] doubleDIMCol { get; private set; }	
		
	/// <summary>
	/// decimal一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.OneDimensionArray,32,"decimalDIMCol","","@decimalDIMCol32",false)]	
	public decimal[] decimalDIMCol { get; private set; }	
		
	/// <summary>
	/// DateTime一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.OneDimensionArray,33,"DateTimeDIMCol","","@DateTimeDIMCol33",false)]	
	public DateTime[] DateTimeDIMCol { get; private set; }	
		
	/// <summary>
	/// string一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.OneDimensionArray,34,"stringDIMCol","","@stringDIMCol34",false)]	
	public string[] stringDIMCol { get; private set; }	
		
	/// <summary>
	/// Guid一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.OneDimensionArray,35,"GuidDIMCol","","@GuidDIMCol35",false)]	
	public Guid[] GuidDIMCol { get; private set; }	
		
	/// <summary>
	/// Vector2一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray,36,"Vector2DIMCol","","@Vector2DIMCol36",false)]	
	public Vector2[] Vector2DIMCol { get; private set; }	
		
	/// <summary>
	/// Vector3一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.OneDimensionArray,37,"Vector3DIMCol","","@Vector3DIMCol37",false)]	
	public Vector3[] Vector3DIMCol { get; private set; }	
		
	/// <summary>
	/// Vector4一维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.OneDimensionArray,38,"Vector4DIMCol","","@Vector4DIMCol38",false)]	
	public Vector4[] Vector4DIMCol { get; private set; }	
		
	/// <summary>
	/// bool二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.TwoDimensionArray,39,"boolDIM2Col","","@boolDIM2Col39",false)]	
	public bool[][] boolDIM2Col { get; private set; }	
		
	/// <summary>
	/// char二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Char,enSQLiteDataTypeArrayDimension.TwoDimensionArray,40,"charDIM2Col","","@charDIM2Col40",false)]	
	public char[][] charDIM2Col { get; private set; }	
		
	/// <summary>
	/// sbyte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.SByte,enSQLiteDataTypeArrayDimension.TwoDimensionArray,41,"sbyteDIM2Col","","@sbyteDIM2Col41",false)]	
	public sbyte[][] sbyteDIM2Col { get; private set; }	
		
	/// <summary>
	/// byte二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.TwoDimensionArray,42,"byteDIM2Col","","@byteDIM2Col42",false)]	
	public byte[][] byteDIM2Col { get; private set; }	
		
	/// <summary>
	/// short二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int16,enSQLiteDataTypeArrayDimension.TwoDimensionArray,43,"shortDIM2Col","","@shortDIM2Col43",false)]	
	public short[][] shortDIM2Col { get; private set; }	
		
	/// <summary>
	/// ushort二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt16,enSQLiteDataTypeArrayDimension.TwoDimensionArray,44,"ushortDIM2Col","","@ushortDIM2Col44",false)]	
	public ushort[][] ushortDIM2Col { get; private set; }	
		
	/// <summary>
	/// int二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.TwoDimensionArray,45,"intDIM2Col","","@intDIM2Col45",false)]	
	public int[][] intDIM2Col { get; private set; }	
		
	/// <summary>
	/// uint二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt32,enSQLiteDataTypeArrayDimension.TwoDimensionArray,46,"uintDIM2Col","","@uintDIM2Col46",false)]	
	public uint[][] uintDIM2Col { get; private set; }	
		
	/// <summary>
	/// long二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int64,enSQLiteDataTypeArrayDimension.TwoDimensionArray,47,"longDIM2Col","","@longDIM2Col47",false)]	
	public long[][] longDIM2Col { get; private set; }	
		
	/// <summary>
	/// ulong二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.UInt64,enSQLiteDataTypeArrayDimension.TwoDimensionArray,48,"ulongDIM2Col","","@ulongDIM2Col48",false)]	
	public ulong[][] ulongDIM2Col { get; private set; }	
		
	/// <summary>
	/// float二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Single,enSQLiteDataTypeArrayDimension.TwoDimensionArray,49,"floatDIM2Col","","@floatDIM2Col49",false)]	
	public float[][] floatDIM2Col { get; private set; }	
		
	/// <summary>
	/// double二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Double,enSQLiteDataTypeArrayDimension.TwoDimensionArray,50,"doubleDIM2Col","","@doubleDIM2Col50",false)]	
	public double[][] doubleDIM2Col { get; private set; }	
		
	/// <summary>
	/// decimal二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Decimal,enSQLiteDataTypeArrayDimension.TwoDimensionArray,51,"decimalDIM2Col","","@decimalDIM2Col51",false)]	
	public decimal[][] decimalDIM2Col { get; private set; }	
		
	/// <summary>
	/// DateTime二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.DateTime,enSQLiteDataTypeArrayDimension.TwoDimensionArray,52,"DateTimeDIM2Col","","@DateTimeDIM2Col52",false)]	
	public DateTime[][] DateTimeDIM2Col { get; private set; }	
		
	/// <summary>
	/// string二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.TwoDimensionArray,53,"stringDIM2Col","","@stringDIM2Col53",false)]	
	public string[][] stringDIM2Col { get; private set; }	
		
	/// <summary>
	/// Guid二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Guid,enSQLiteDataTypeArrayDimension.TwoDimensionArray,54,"GuidDIM2Col","","@GuidDIM2Col54",false)]	
	public Guid[][] GuidDIM2Col { get; private set; }	
		
	/// <summary>
	/// Vector2二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.TwoDimensionArray,55,"Vector2DIM2Col","","@Vector2DIM2Col55",false)]	
	public Vector2[][] Vector2DIM2Col { get; private set; }	
		
	/// <summary>
	/// Vector3二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector3,enSQLiteDataTypeArrayDimension.TwoDimensionArray,56,"Vector3DIM2Col","","@Vector3DIM2Col56",false)]	
	public Vector3[][] Vector3DIM2Col { get; private set; }	
		
	/// <summary>
	/// Vector4二维数组
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector4,enSQLiteDataTypeArrayDimension.TwoDimensionArray,57,"Vector4DIM2Col","","@Vector4DIM2Col57",false)]	
	public Vector4[][] Vector4DIM2Col { get; private set; }	
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set boolCol
	/// </summary>
	/// <param name="_boolCol">boolCol value</param>
	public void Set_boolCol(bool _boolCol)
	{
		boolCol = _boolCol;
	}
	
	/// <summary>
	/// Set charCol
	/// </summary>
	/// <param name="_charCol">charCol value</param>
	public void Set_charCol(char _charCol)
	{
		charCol = _charCol;
	}
	
	/// <summary>
	/// Set sbyteCol
	/// </summary>
	/// <param name="_sbyteCol">sbyteCol value</param>
	public void Set_sbyteCol(sbyte _sbyteCol)
	{
		sbyteCol = _sbyteCol;
	}
	
	/// <summary>
	/// Set byteCol
	/// </summary>
	/// <param name="_byteCol">byteCol value</param>
	public void Set_byteCol(byte _byteCol)
	{
		byteCol = _byteCol;
	}
	
	/// <summary>
	/// Set shortCol
	/// </summary>
	/// <param name="_shortCol">shortCol value</param>
	public void Set_shortCol(short _shortCol)
	{
		shortCol = _shortCol;
	}
	
	/// <summary>
	/// Set ushortCol
	/// </summary>
	/// <param name="_ushortCol">ushortCol value</param>
	public void Set_ushortCol(ushort _ushortCol)
	{
		ushortCol = _ushortCol;
	}
	
	/// <summary>
	/// Set intCol
	/// </summary>
	/// <param name="_intCol">intCol value</param>
	public void Set_intCol(int _intCol)
	{
		intCol = _intCol;
	}
	
	/// <summary>
	/// Set uintCol
	/// </summary>
	/// <param name="_uintCol">uintCol value</param>
	public void Set_uintCol(uint _uintCol)
	{
		uintCol = _uintCol;
	}
	
	/// <summary>
	/// Set longCol
	/// </summary>
	/// <param name="_longCol">longCol value</param>
	public void Set_longCol(long _longCol)
	{
		longCol = _longCol;
	}
	
	/// <summary>
	/// Set ulongCol
	/// </summary>
	/// <param name="_ulongCol">ulongCol value</param>
	public void Set_ulongCol(ulong _ulongCol)
	{
		ulongCol = _ulongCol;
	}
	
	/// <summary>
	/// Set floatCol
	/// </summary>
	/// <param name="_floatCol">floatCol value</param>
	public void Set_floatCol(float _floatCol)
	{
		floatCol = _floatCol;
	}
	
	/// <summary>
	/// Set doubleCol
	/// </summary>
	/// <param name="_doubleCol">doubleCol value</param>
	public void Set_doubleCol(double _doubleCol)
	{
		doubleCol = _doubleCol;
	}
	
	/// <summary>
	/// Set decimalCol
	/// </summary>
	/// <param name="_decimalCol">decimalCol value</param>
	public void Set_decimalCol(decimal _decimalCol)
	{
		decimalCol = _decimalCol;
	}
	
	/// <summary>
	/// Set DateTimeCol
	/// </summary>
	/// <param name="_DateTimeCol">DateTimeCol value</param>
	public void Set_DateTimeCol(DateTime _DateTimeCol)
	{
		DateTimeCol = _DateTimeCol;
	}
	
	/// <summary>
	/// Set stringCol
	/// </summary>
	/// <param name="_stringCol">stringCol value</param>
	public void Set_stringCol(string _stringCol)
	{
		stringCol = _stringCol;
	}
	
	/// <summary>
	/// Set GuidCol
	/// </summary>
	/// <param name="_GuidCol">GuidCol value</param>
	public void Set_GuidCol(Guid _GuidCol)
	{
		GuidCol = _GuidCol;
	}
	
	/// <summary>
	/// Set Vector2Col
	/// </summary>
	/// <param name="_Vector2Col">Vector2Col value</param>
	public void Set_Vector2Col(Vector2 _Vector2Col)
	{
		Vector2Col = _Vector2Col;
	}
	
	/// <summary>
	/// Set Vector3Col
	/// </summary>
	/// <param name="_Vector3Col">Vector3Col value</param>
	public void Set_Vector3Col(Vector3 _Vector3Col)
	{
		Vector3Col = _Vector3Col;
	}
	
	/// <summary>
	/// Set Vector4Col
	/// </summary>
	/// <param name="_Vector4Col">Vector4Col value</param>
	public void Set_Vector4Col(Vector4 _Vector4Col)
	{
		Vector4Col = _Vector4Col;
	}
	
	/// <summary>
	/// Set boolDIMCol
	/// </summary>
	/// <param name="_boolDIMCol">boolDIMCol value</param>
	public void Set_boolDIMCol(bool[] _boolDIMCol)
	{
		boolDIMCol = _boolDIMCol;
	}
	
	/// <summary>
	/// Set charDIMCol
	/// </summary>
	/// <param name="_charDIMCol">charDIMCol value</param>
	public void Set_charDIMCol(char[] _charDIMCol)
	{
		charDIMCol = _charDIMCol;
	}
	
	/// <summary>
	/// Set sbyteDIMCol
	/// </summary>
	/// <param name="_sbyteDIMCol">sbyteDIMCol value</param>
	public void Set_sbyteDIMCol(sbyte[] _sbyteDIMCol)
	{
		sbyteDIMCol = _sbyteDIMCol;
	}
	
	/// <summary>
	/// Set byteDIMCol
	/// </summary>
	/// <param name="_byteDIMCol">byteDIMCol value</param>
	public void Set_byteDIMCol(byte[] _byteDIMCol)
	{
		byteDIMCol = _byteDIMCol;
	}
	
	/// <summary>
	/// Set shortDIMCol
	/// </summary>
	/// <param name="_shortDIMCol">shortDIMCol value</param>
	public void Set_shortDIMCol(short[] _shortDIMCol)
	{
		shortDIMCol = _shortDIMCol;
	}
	
	/// <summary>
	/// Set ushortDIMCol
	/// </summary>
	/// <param name="_ushortDIMCol">ushortDIMCol value</param>
	public void Set_ushortDIMCol(ushort[] _ushortDIMCol)
	{
		ushortDIMCol = _ushortDIMCol;
	}
	
	/// <summary>
	/// Set intDIMCol
	/// </summary>
	/// <param name="_intDIMCol">intDIMCol value</param>
	public void Set_intDIMCol(int[] _intDIMCol)
	{
		intDIMCol = _intDIMCol;
	}
	
	/// <summary>
	/// Set uintDIMCol
	/// </summary>
	/// <param name="_uintDIMCol">uintDIMCol value</param>
	public void Set_uintDIMCol(uint[] _uintDIMCol)
	{
		uintDIMCol = _uintDIMCol;
	}
	
	/// <summary>
	/// Set longDIMCol
	/// </summary>
	/// <param name="_longDIMCol">longDIMCol value</param>
	public void Set_longDIMCol(long[] _longDIMCol)
	{
		longDIMCol = _longDIMCol;
	}
	
	/// <summary>
	/// Set ulongDIMCol
	/// </summary>
	/// <param name="_ulongDIMCol">ulongDIMCol value</param>
	public void Set_ulongDIMCol(ulong[] _ulongDIMCol)
	{
		ulongDIMCol = _ulongDIMCol;
	}
	
	/// <summary>
	/// Set floatDIMCol
	/// </summary>
	/// <param name="_floatDIMCol">floatDIMCol value</param>
	public void Set_floatDIMCol(float[] _floatDIMCol)
	{
		floatDIMCol = _floatDIMCol;
	}
	
	/// <summary>
	/// Set doubleDIMCol
	/// </summary>
	/// <param name="_doubleDIMCol">doubleDIMCol value</param>
	public void Set_doubleDIMCol(double[] _doubleDIMCol)
	{
		doubleDIMCol = _doubleDIMCol;
	}
	
	/// <summary>
	/// Set decimalDIMCol
	/// </summary>
	/// <param name="_decimalDIMCol">decimalDIMCol value</param>
	public void Set_decimalDIMCol(decimal[] _decimalDIMCol)
	{
		decimalDIMCol = _decimalDIMCol;
	}
	
	/// <summary>
	/// Set DateTimeDIMCol
	/// </summary>
	/// <param name="_DateTimeDIMCol">DateTimeDIMCol value</param>
	public void Set_DateTimeDIMCol(DateTime[] _DateTimeDIMCol)
	{
		DateTimeDIMCol = _DateTimeDIMCol;
	}
	
	/// <summary>
	/// Set stringDIMCol
	/// </summary>
	/// <param name="_stringDIMCol">stringDIMCol value</param>
	public void Set_stringDIMCol(string[] _stringDIMCol)
	{
		stringDIMCol = _stringDIMCol;
	}
	
	/// <summary>
	/// Set GuidDIMCol
	/// </summary>
	/// <param name="_GuidDIMCol">GuidDIMCol value</param>
	public void Set_GuidDIMCol(Guid[] _GuidDIMCol)
	{
		GuidDIMCol = _GuidDIMCol;
	}
	
	/// <summary>
	/// Set Vector2DIMCol
	/// </summary>
	/// <param name="_Vector2DIMCol">Vector2DIMCol value</param>
	public void Set_Vector2DIMCol(Vector2[] _Vector2DIMCol)
	{
		Vector2DIMCol = _Vector2DIMCol;
	}
	
	/// <summary>
	/// Set Vector3DIMCol
	/// </summary>
	/// <param name="_Vector3DIMCol">Vector3DIMCol value</param>
	public void Set_Vector3DIMCol(Vector3[] _Vector3DIMCol)
	{
		Vector3DIMCol = _Vector3DIMCol;
	}
	
	/// <summary>
	/// Set Vector4DIMCol
	/// </summary>
	/// <param name="_Vector4DIMCol">Vector4DIMCol value</param>
	public void Set_Vector4DIMCol(Vector4[] _Vector4DIMCol)
	{
		Vector4DIMCol = _Vector4DIMCol;
	}
	
	/// <summary>
	/// Set boolDIM2Col
	/// </summary>
	/// <param name="_boolDIM2Col">boolDIM2Col value</param>
	public void Set_boolDIM2Col(bool[][] _boolDIM2Col)
	{
		boolDIM2Col = _boolDIM2Col;
	}
	
	/// <summary>
	/// Set charDIM2Col
	/// </summary>
	/// <param name="_charDIM2Col">charDIM2Col value</param>
	public void Set_charDIM2Col(char[][] _charDIM2Col)
	{
		charDIM2Col = _charDIM2Col;
	}
	
	/// <summary>
	/// Set sbyteDIM2Col
	/// </summary>
	/// <param name="_sbyteDIM2Col">sbyteDIM2Col value</param>
	public void Set_sbyteDIM2Col(sbyte[][] _sbyteDIM2Col)
	{
		sbyteDIM2Col = _sbyteDIM2Col;
	}
	
	/// <summary>
	/// Set byteDIM2Col
	/// </summary>
	/// <param name="_byteDIM2Col">byteDIM2Col value</param>
	public void Set_byteDIM2Col(byte[][] _byteDIM2Col)
	{
		byteDIM2Col = _byteDIM2Col;
	}
	
	/// <summary>
	/// Set shortDIM2Col
	/// </summary>
	/// <param name="_shortDIM2Col">shortDIM2Col value</param>
	public void Set_shortDIM2Col(short[][] _shortDIM2Col)
	{
		shortDIM2Col = _shortDIM2Col;
	}
	
	/// <summary>
	/// Set ushortDIM2Col
	/// </summary>
	/// <param name="_ushortDIM2Col">ushortDIM2Col value</param>
	public void Set_ushortDIM2Col(ushort[][] _ushortDIM2Col)
	{
		ushortDIM2Col = _ushortDIM2Col;
	}
	
	/// <summary>
	/// Set intDIM2Col
	/// </summary>
	/// <param name="_intDIM2Col">intDIM2Col value</param>
	public void Set_intDIM2Col(int[][] _intDIM2Col)
	{
		intDIM2Col = _intDIM2Col;
	}
	
	/// <summary>
	/// Set uintDIM2Col
	/// </summary>
	/// <param name="_uintDIM2Col">uintDIM2Col value</param>
	public void Set_uintDIM2Col(uint[][] _uintDIM2Col)
	{
		uintDIM2Col = _uintDIM2Col;
	}
	
	/// <summary>
	/// Set longDIM2Col
	/// </summary>
	/// <param name="_longDIM2Col">longDIM2Col value</param>
	public void Set_longDIM2Col(long[][] _longDIM2Col)
	{
		longDIM2Col = _longDIM2Col;
	}
	
	/// <summary>
	/// Set ulongDIM2Col
	/// </summary>
	/// <param name="_ulongDIM2Col">ulongDIM2Col value</param>
	public void Set_ulongDIM2Col(ulong[][] _ulongDIM2Col)
	{
		ulongDIM2Col = _ulongDIM2Col;
	}
	
	/// <summary>
	/// Set floatDIM2Col
	/// </summary>
	/// <param name="_floatDIM2Col">floatDIM2Col value</param>
	public void Set_floatDIM2Col(float[][] _floatDIM2Col)
	{
		floatDIM2Col = _floatDIM2Col;
	}
	
	/// <summary>
	/// Set doubleDIM2Col
	/// </summary>
	/// <param name="_doubleDIM2Col">doubleDIM2Col value</param>
	public void Set_doubleDIM2Col(double[][] _doubleDIM2Col)
	{
		doubleDIM2Col = _doubleDIM2Col;
	}
	
	/// <summary>
	/// Set decimalDIM2Col
	/// </summary>
	/// <param name="_decimalDIM2Col">decimalDIM2Col value</param>
	public void Set_decimalDIM2Col(decimal[][] _decimalDIM2Col)
	{
		decimalDIM2Col = _decimalDIM2Col;
	}
	
	/// <summary>
	/// Set DateTimeDIM2Col
	/// </summary>
	/// <param name="_DateTimeDIM2Col">DateTimeDIM2Col value</param>
	public void Set_DateTimeDIM2Col(DateTime[][] _DateTimeDIM2Col)
	{
		DateTimeDIM2Col = _DateTimeDIM2Col;
	}
	
	/// <summary>
	/// Set stringDIM2Col
	/// </summary>
	/// <param name="_stringDIM2Col">stringDIM2Col value</param>
	public void Set_stringDIM2Col(string[][] _stringDIM2Col)
	{
		stringDIM2Col = _stringDIM2Col;
	}
	
	/// <summary>
	/// Set GuidDIM2Col
	/// </summary>
	/// <param name="_GuidDIM2Col">GuidDIM2Col value</param>
	public void Set_GuidDIM2Col(Guid[][] _GuidDIM2Col)
	{
		GuidDIM2Col = _GuidDIM2Col;
	}
	
	/// <summary>
	/// Set Vector2DIM2Col
	/// </summary>
	/// <param name="_Vector2DIM2Col">Vector2DIM2Col value</param>
	public void Set_Vector2DIM2Col(Vector2[][] _Vector2DIM2Col)
	{
		Vector2DIM2Col = _Vector2DIM2Col;
	}
	
	/// <summary>
	/// Set Vector3DIM2Col
	/// </summary>
	/// <param name="_Vector3DIM2Col">Vector3DIM2Col value</param>
	public void Set_Vector3DIM2Col(Vector3[][] _Vector3DIM2Col)
	{
		Vector3DIM2Col = _Vector3DIM2Col;
	}
	
	/// <summary>
	/// Set Vector4DIM2Col
	/// </summary>
	/// <param name="_Vector4DIM2Col">Vector4DIM2Col value</param>
	public void Set_Vector4DIM2Col(Vector4[][] _Vector4DIM2Col)
	{
		Vector4DIM2Col = _Vector4DIM2Col;
	}
	
	#endregion
}