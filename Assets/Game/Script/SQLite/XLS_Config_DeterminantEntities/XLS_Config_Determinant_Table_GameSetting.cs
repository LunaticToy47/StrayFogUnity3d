using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameSetting实体
/// </summary>
[SQLiteTableMap(-200362774,"Assets/Game/Editor/XLS_Config/GameSetting.xlsx","GameSetting", enSQLiteEntityClassify.Table,true, 1,2,3,4,"c__1581584321",typeof(XLS_Config_Determinant_Table_GameSetting),false,false)]
public partial class XLS_Config_Determinant_Table_GameSetting: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 分辨率
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.NoArray,4,"name","@resolution4",false)]	
	public Vector2 resolution { get; private set; }	
		
	/// <summary>
	/// 帧率
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"name","@targetFrameRate5",false)]	
	public int targetFrameRate { get; private set; }	
		
	/// <summary>
	/// 是否运行引导
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,6,"name","@isRunGuide6",false)]	
	public bool isRunGuide { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}