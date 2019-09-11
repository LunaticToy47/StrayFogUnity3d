using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameLanguage实体
/// </summary>
[SQLiteTableMap(1504319870,"Assets/Game/Editor/XLS_Config/GameLanguage.xlsx","GameLanguage", enSQLiteEntityClassify.Table,true, 1,2,3,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Determinant_Table_GameLanguage),false,false)]
public partial class XLS_Config_Determinant_Table_GameLanguage: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 引导提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"name","value","@GuideTip4",false)]	
	public string GuideTip { get; private set; }	
		
	/// <summary>
	/// 大厅提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"name","value","@LobbyTip5",false)]	
	public string LobbyTip { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}