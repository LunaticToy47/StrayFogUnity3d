using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// View_AssetDiskMaping实体
/// </summary>
public partial class View_AssetDiskMaping: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// fileId
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int fileId { get; private set; }
	/// <summary>
	/// folderId
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int folderId { get; private set; }
	/// <summary>
	/// fileName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string fileName { get; private set; }
	/// <summary>
	/// inAssetPath
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string inAssetPath { get; private set; }
	/// <summary>
	/// outAssetPath
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string outAssetPath { get; private set; }
	/// <summary>
	/// extEnumValue
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int extEnumValue { get; private set; }
}