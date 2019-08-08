using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
[SQLiteTableMap(-1669761042,"","View_DeterminantVT", enSQLiteEntityClassify.View,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_902350952",typeof(XLS_Config_View_DeterminantVT),false,false)]
public partial class XLS_Config_View_DeterminantVT: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// vtName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"","","@vtName0",false)]	
	public string vtName { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}