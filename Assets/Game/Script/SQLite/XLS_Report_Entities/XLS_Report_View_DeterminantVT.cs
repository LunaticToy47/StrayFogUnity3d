using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
[SQLiteTableMap(1342827752,"","View_DeterminantVT", enSQLiteEntityClassify.View,false, 1,4,2,4,"c__1833182787",typeof(XLS_Report_View_DeterminantVT))]
public partial class XLS_Report_View_DeterminantVT: AbsStrayFogSQLiteEntity
{
	
	/// <summary>
	/// vtName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,0,"@vtName0",false)]
	public string vtName { get; private set; }
}