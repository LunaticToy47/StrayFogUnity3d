using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_AssetDiskMaping实体
/// </summary>
[SQLiteTableMap(1200707353,"","View_AssetDiskMaping", enSQLiteEntityClassify.View,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_View_AssetDiskMaping))]
public partial class XLS_Config_View_AssetDiskMaping: AbsStrayFogSQLiteEntity
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