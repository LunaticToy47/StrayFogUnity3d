using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideValidate实体
/// </summary>
[SQLiteTableMap(1839133489,"Assets/Game/Editor/XLS_Config/UserGuideValidate.xlsx","UserGuideValidate", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_UserGuideValidate))]
public partial class XLS_Config_Table_UserGuideValidate: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id}.ToArray(); } }

	
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int id { get; private set; }
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string desc { get; private set; }
	/// <summary>
	/// 条件
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public int[] conditions { get; private set; }
	/// <summary>
	/// 条件Int值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public int[] intValues { get; private set; }
	/// <summary>
	/// 条件Vector2值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray)]
	public Vector2[] vector2Values { get; private set; }
}