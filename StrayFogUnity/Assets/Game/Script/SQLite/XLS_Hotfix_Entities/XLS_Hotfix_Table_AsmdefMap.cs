using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AsmdefMap实体
/// </summary>
[SQLiteTableMap(-1128168728,"Assets/Game/Editor/XLS_Hotfix/AsmdefMap.xlsx","AsmdefMap", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Hotfix/XLS_Hotfix.db","Assets/c_957487325",typeof(XLS_Hotfix_Table_AsmdefMap),false,false)]
public partial class XLS_Hotfix_Table_AsmdefMap: AbsStrayFogSQLiteEntity
{
	

	

	#region Properties	
		
	/// <summary>
	/// 路径ID
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",false,false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// Asmdef名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"asmdefDllName","","@asmdefDllName2",false,false)]	
	public string asmdefDllName { get; private set; }	
		
	/// <summary>
	/// AsmdefDLL路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"asmdefDllLibraryPath","","@asmdefDllLibraryPath3",false,false)]	
	public string asmdefDllLibraryPath { get; private set; }	
		
	/// <summary>
	/// Asmdef资源文件名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"asmdefDllAssetbundleName","","@asmdefDllAssetbundleName4",false,false)]	
	public string asmdefDllAssetbundleName { get; private set; }	
		
	/// <summary>
	/// AsmdefDLL路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"asmdefPdbLibraryPath","","@asmdefPdbLibraryPath5",false,false)]	
	public string asmdefPdbLibraryPath { get; private set; }	
		
	/// <summary>
	/// Asmdef资源文件名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,6,"asmdefPdbAssetbundleName","","@asmdefPdbAssetbundleName6",false,false)]	
	public string asmdefPdbAssetbundleName { get; private set; }	
		
	/// <summary>
	/// 是否是Hotfix程序集
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,7,"isHotfix","","@isHotfix7",false,false)]	
	public bool isHotfix { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}