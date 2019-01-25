using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Report实体
/// </summary>
[SQLiteTableMap(210367,"Assets/Game/Editor/XLS_Report/Report.xlsx","Report", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1833182787",typeof(XLS_Report_Table_Report))]
public partial class XLS_Report_Table_Report: AbsStrayFogSQLiteEntity
{
	
	/// <summary>
	/// id主键
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"@idCol1",true)]
	public int idCol { get; private set; }
	/// <summary>
	/// 字符串
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"@stringCol2",false)]
	public string stringCol { get; private set; }
}