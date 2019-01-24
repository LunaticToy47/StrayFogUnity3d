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
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// 引导提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string GuideTip { get; private set; }
	/// <summary>
	/// 大厅提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string LobbyTip { get; private set; }
}