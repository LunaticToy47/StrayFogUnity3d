using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
[SQLiteTableMap(-66345705,"","View_DeterminantVT", enSQLiteEntityClassify.View,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_View_DeterminantVT))]
public partial class XLS_Config_View_DeterminantVT: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// vtName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string vtName { get; private set; }
}