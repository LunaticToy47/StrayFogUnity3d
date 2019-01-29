using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFile实体
/// </summary>
[SQLiteTableMap(-206577796,"Assets/Game/Editor/XLS_Config/AssetDiskMapingFile.xlsx","AssetDiskMapingFile", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_AssetDiskMapingFile),true,false)]
public partial class XLS_Config_Table_AssetDiskMapingFile: AbsStrayFogSQLiteEntity
{
		
	#region constructor
	/// <summary>
    /// constructor
    /// </summary>
    XLS_Config_Table_AssetDiskMapingFile()
    {
    }

    /// <summary>
    /// constructor
    /// </summary>
   /// <param name="_fileId">fileId</param>
   /// <param name="_folderId">folderId</param>	
    public XLS_Config_Table_AssetDiskMapingFile(int _fileId,int _folderId)
    {
		fileId = _fileId;
		folderId = _folderId;
    }
    #endregion
	

	#region Properties	
		
	/// <summary>
	/// 文件id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"@fileId1",true)]	
	public int fileId { get; private set; }	
		
	/// <summary>
	/// 文件夹id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,2,"@folderId2",true)]	
	public int folderId { get; private set; }	
		
	/// <summary>
	/// 内部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"@inSide3",false)]	
	public string inSide { get; private set; }	
		
	/// <summary>
	/// 扩展名
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"@ext4",false)]	
	public string ext { get; private set; }	
		
	/// <summary>
	/// 外部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"@outSide5",false)]	
	public string outSide { get; private set; }	
		
	/// <summary>
	/// 扩展名枚举值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"@extEnumValue6",false)]	
	public int extEnumValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set inSide
	/// </summary>
	/// <param name="_inSide">inSide value</param>
	public void Set_inSide(string _inSide)
	{
		inSide = _inSide;
	}
	
	/// <summary>
	/// Set ext
	/// </summary>
	/// <param name="_ext">ext value</param>
	public void Set_ext(string _ext)
	{
		ext = _ext;
	}
	
	/// <summary>
	/// Set outSide
	/// </summary>
	/// <param name="_outSide">outSide value</param>
	public void Set_outSide(string _outSide)
	{
		outSide = _outSide;
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