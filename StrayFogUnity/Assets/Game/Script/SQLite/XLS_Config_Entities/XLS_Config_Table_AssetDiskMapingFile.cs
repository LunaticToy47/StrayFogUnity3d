using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFile实体
/// </summary>
[SQLiteTableMap(-1016234597,"Assets/Game/Editor/XLS_Config/AssetDiskMapingFile.xlsx","AssetDiskMapingFile", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_AssetDiskMapingFile),true,false)]
public partial class XLS_Config_Table_AssetDiskMapingFile: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 文件id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"fileId","","@fileId1",true,false)]	
	public int fileId { get; private set; }	
		
	/// <summary>
	/// 文件夹id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,2,"folderId","","@folderId2",true,false)]	
	public int folderId { get; private set; }	
		
	/// <summary>
	/// 内部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"inSide","","@inSide3",false,false)]	
	public string inSide { get; private set; }	
		
	/// <summary>
	/// 扩展名
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"ext","","@ext4",false,false)]	
	public string ext { get; private set; }	
		
	/// <summary>
	/// 外部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"outSide","","@outSide5",false,false)]	
	public string outSide { get; private set; }	
		
	/// <summary>
	/// 扩展名枚举值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"extEnumValue","","@extEnumValue6",false,false)]	
	public int extEnumValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}