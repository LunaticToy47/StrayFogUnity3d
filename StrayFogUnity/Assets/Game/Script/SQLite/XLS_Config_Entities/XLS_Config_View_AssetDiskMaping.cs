using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_AssetDiskMaping实体
/// </summary>
[SQLiteTableMap(1510004801,"","View_AssetDiskMaping", enSQLiteEntityClassify.View,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","Assets/c_334573285",typeof(XLS_Config_View_AssetDiskMaping),false,false)]
public partial class XLS_Config_View_AssetDiskMaping: AbsStrayFogSQLiteEntity
{
	

	

	#region Properties	
		
	/// <summary>
	/// fileId
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@fileId0",false,false)]	
	public int fileId { get; private set; }	
		
	/// <summary>
	/// folderId
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@folderId0",false,false)]	
	public int folderId { get; private set; }	
		
	/// <summary>
	/// fileName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@fileName0",false,false)]	
	public string fileName { get; private set; }	
		
	/// <summary>
	/// inAssetPath
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@inAssetPath0",false,false)]	
	public string inAssetPath { get; private set; }	
		
	/// <summary>
	/// outAssetPath
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@outAssetPath0",false,false)]	
	public string outAssetPath { get; private set; }	
		
	/// <summary>
	/// extEnumValue
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@extEnumValue0",false,false)]	
	public int extEnumValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}