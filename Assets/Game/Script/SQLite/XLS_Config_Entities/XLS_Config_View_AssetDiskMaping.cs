using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_AssetDiskMaping实体
/// </summary>
[SQLiteTableMap(1200707353,"","View_AssetDiskMaping", enSQLiteEntityClassify.View,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_View_AssetDiskMaping))]
public partial class XLS_Config_View_AssetDiskMaping: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// fileId
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,0,"@fileId0",false)]	
	public int fileId { get; private set; }	
		
	/// <summary>
	/// folderId
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,0,"@folderId0",false)]	
	public int folderId { get; private set; }	
		
	/// <summary>
	/// fileName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@fileName0",false)]	
	public string fileName { get; private set; }	
		
	/// <summary>
	/// inAssetPath
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@inAssetPath0",false)]	
	public string inAssetPath { get; private set; }	
		
	/// <summary>
	/// outAssetPath
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@outAssetPath0",false)]	
	public string outAssetPath { get; private set; }	
		
	/// <summary>
	/// extEnumValue
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,0,"@extEnumValue0",false)]	
	public int extEnumValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set fileId
	/// </summary>
	/// <param name="_fileId">fileId value</param>
	public void Set_fileId(int _fileId)
	{
		fileId = _fileId;
	}
	
	/// <summary>
	/// Set folderId
	/// </summary>
	/// <param name="_folderId">folderId value</param>
	public void Set_folderId(int _folderId)
	{
		folderId = _folderId;
	}
	
	/// <summary>
	/// Set fileName
	/// </summary>
	/// <param name="_fileName">fileName value</param>
	public void Set_fileName(string _fileName)
	{
		fileName = _fileName;
	}
	
	/// <summary>
	/// Set inAssetPath
	/// </summary>
	/// <param name="_inAssetPath">inAssetPath value</param>
	public void Set_inAssetPath(string _inAssetPath)
	{
		inAssetPath = _inAssetPath;
	}
	
	/// <summary>
	/// Set outAssetPath
	/// </summary>
	/// <param name="_outAssetPath">outAssetPath value</param>
	public void Set_outAssetPath(string _outAssetPath)
	{
		outAssetPath = _outAssetPath;
	}
	
	/// <summary>
	/// Set extEnumValue
	/// </summary>
	/// <param name="_extEnumValue">extEnumValue value</param>
	public void Set_extEnumValue(int _extEnumValue)
	{
		extEnumValue = _extEnumValue;
	}
	
	#endregion
}