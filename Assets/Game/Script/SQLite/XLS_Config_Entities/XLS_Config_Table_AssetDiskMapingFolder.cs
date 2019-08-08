using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFolder实体
/// </summary>
[SQLiteTableMap(-1159787211,"Assets/Game/Editor/XLS_Config/AssetDiskMapingFolder.xlsx","AssetDiskMapingFolder", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_902350952",typeof(XLS_Config_Table_AssetDiskMapingFolder),true,false)]
public partial class XLS_Config_Table_AssetDiskMapingFolder: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 文件夹Id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"folderId","","@folderId1",true)]	
	public int folderId { get; private set; }	
		
	/// <summary>
	/// 内部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"inSide","","@inSide2",false)]	
	public string inSide { get; private set; }	
		
	/// <summary>
	/// 外部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"outSide","","@outSide3",false)]	
	public string outSide { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}