using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// UserGuideTrigger实体
/// </summary>
public partial class XLS_Config_Table_UserGuideTrigger: AbsStrayFogSQLiteEntity
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
	/// 下一引导id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int nextId { get; private set; }
	/// <summary>
	/// 引导类型
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int guideType { get; private set; }
	/// <summary>
	/// 显示类型
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int displayType { get; private set; }
	/// <summary>
	/// 关卡id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int levelId { get; private set; }
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
	/// 验证id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int validateId { get; private set; }
}