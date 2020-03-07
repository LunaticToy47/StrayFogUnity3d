using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ReportDeterminant实体
/// </summary>
[SQLiteTableMap(-1747853252,"Assets/Game/Editor/XLS_Report/ReportDeterminant.xlsx","ReportDeterminant", enSQLiteEntityClassify.Table,true, 1,2,3,4,"Assets/Game/Editor/XLS_Report/XLS_Report.db","Assets/c_1478679219",typeof(XLS_Report_Determinant_Table_ReportDeterminant),false,true)]
public partial class XLS_Report_Determinant_Table_ReportDeterminant: AbsStrayFogSQLiteEntity
{
	

	

	#region Properties	
		
	/// <summary>
	/// 报表提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"name","value","@ReportTip4",false,false)]	
	public string ReportTip { get; private set; }	
		
	/// <summary>
	/// 行列式提示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"name","value","@DeterminantTip5",false,false)]	
	public string DeterminantTip { get; private set; }	
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set ReportTip
	/// </summary>
	/// <param name="_ReportTip">ReportTip value</param>
	public void Set_ReportTip(string _ReportTip)
	{
		ReportTip = _ReportTip;
	}
	
	/// <summary>
	/// Set DeterminantTip
	/// </summary>
	/// <param name="_DeterminantTip">DeterminantTip value</param>
	public void Set_DeterminantTip(string _DeterminantTip)
	{
		DeterminantTip = _DeterminantTip;
	}
	
	#endregion
}