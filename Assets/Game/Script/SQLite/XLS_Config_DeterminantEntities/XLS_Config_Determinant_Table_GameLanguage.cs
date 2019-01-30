using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameLanguage实体
/// </summary>
[SQLiteTableMap(1091601591,"Assets/Game/Editor/XLS_Config/GameLanguage.xlsx","GameLanguage", enSQLiteEntityClassify.Table,true, 1,2,3,4,"c__1581584321",typeof(XLS_Config_Determinant_Table_GameLanguage),false,false)]
public partial class XLS_Config_Determinant_Table_GameLanguage: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 引导提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"name","@GuideTip0",false)]	
	public string GuideTip { get; private set; }	
		
	/// <summary>
	/// 大厅提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"name","@LobbyTip0",false)]	
	public string LobbyTip { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}