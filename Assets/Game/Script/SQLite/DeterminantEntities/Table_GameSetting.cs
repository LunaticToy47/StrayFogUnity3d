using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// GameSetting实体
/// </summary>
public partial class Table_GameSetting: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// 分辨率
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.NoArray)]
	public Vector2 resolution { get; private set; }
	/// <summary>
	/// 帧率
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int targetFrameRate { get; private set; }
	/// <summary>
	/// 是否运行引导
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isRunGuide { get; private set; }
}