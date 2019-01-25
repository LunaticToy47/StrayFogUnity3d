using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFolder实体
/// </summary>
[SQLiteTableMap(-432580056,"Assets/Game/Editor/XLS_Config/AssetDiskMapingFolder.xlsx","AssetDiskMapingFolder", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_AssetDiskMapingFolder))]
public partial class XLS_Config_Table_AssetDiskMapingFolder: AbsStrayFogSQLiteEntity
{
	
	/// <summary>
	/// 文件夹Id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"@folderId1",true)]
	public int folderId { get; private set; }
	/// <summary>
	/// 内部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"@inSide2",false)]
	public string inSide { get; private set; }
	/// <summary>
	/// 外部资源路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"@outSide3",false)]
	public string outSide { get; private set; }
}