using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameLanguage实体
/// </summary>
[SQLiteTableMap(294742871,"Assets/Game/Editor/XLS_Config/GameLanguage.xlsx","GameLanguage", enSQLiteEntityClassify.Table,true, 1,2,3,4,"c__1581584321",typeof(XLS_Config_Table_GameLanguage))]
public partial class XLS_Config_Table_GameLanguage: AbsStrayFogSQLiteEntity
{
	
	/// <summary>
	/// 引导提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@GuideTip0",false)]
	public string GuideTip { get; private set; }
	/// <summary>
	/// 大厅提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@LobbyTip0",false)]
	public string LobbyTip { get; private set; }
}