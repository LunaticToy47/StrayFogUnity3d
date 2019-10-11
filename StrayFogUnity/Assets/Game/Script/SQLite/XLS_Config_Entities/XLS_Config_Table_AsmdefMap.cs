using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AsmdefMap实体
/// </summary>
[SQLiteTableMap(-305506126,"Assets/Game/Editor/XLS_Config/AsmdefMap.xlsx","AsmdefMap", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_AsmdefMap),true,false)]
public partial class XLS_Config_Table_AsmdefMap: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 路径ID
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// Asmdef名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"asmdefDllName","","@asmdefDllName2",false)]	
	public string asmdefDllName { get; private set; }	
		
	/// <summary>
	/// AsmdefDLL路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"asmdefDllPath","","@asmdefDllPath3",false)]	
	public string asmdefDllPath { get; private set; }	
		
	/// <summary>
	/// Asmdef资源文件名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"asmdefDllAssetbundleName","","@asmdefDllAssetbundleName4",false)]	
	public string asmdefDllAssetbundleName { get; private set; }	
		
	/// <summary>
	/// AsmdefDLL路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"asmdefPdbPath","","@asmdefPdbPath5",false)]	
	public string asmdefPdbPath { get; private set; }	
		
	/// <summary>
	/// Asmdef资源文件名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,6,"asmdefPdbAssetbundleName","","@asmdefPdbAssetbundleName6",false)]	
	public string asmdefPdbAssetbundleName { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}