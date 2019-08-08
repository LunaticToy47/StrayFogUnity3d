using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
[SQLiteTableMap(1757406525,"","View_DeterminantVT", enSQLiteEntityClassify.View,false, 1,4,2,4,"Assets/Game/Editor/XLS_Report/XLS_Report.db","c_1478433336",typeof(XLS_Report_View_DeterminantVT),false,false)]
public partial class XLS_Report_View_DeterminantVT: AbsStrayFogSQLiteEntity
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