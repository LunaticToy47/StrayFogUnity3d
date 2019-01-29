using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
[SQLiteTableMap(-66345705,"","View_DeterminantVT", enSQLiteEntityClassify.View,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_View_DeterminantVT),false,false)]
public partial class XLS_Config_View_DeterminantVT: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// vtName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@vtName0",false)]	
	public string vtName { get; private set; }	
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set vtName
	/// </summary>
	/// <param name="_vtName">vtName value</param>
	public void Set_vtName(string _vtName)
	{
		vtName = _vtName;
	}
	
	#endregion
}