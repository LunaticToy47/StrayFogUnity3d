using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Report实体
/// </summary>
[SQLiteTableMap(210367,"Assets/Game/Editor/XLS_Report/Report.xlsx","Report", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1833182787",typeof(XLS_Report_Table_Report),true)]
public partial class XLS_Report_Table_Report: AbsStrayFogSQLiteEntity
{
		
	#region constructor
	/// <summary>
    /// constructor
    /// </summary>
    XLS_Report_Table_Report()
    {
    }

    /// <summary>
    /// constructor
    /// </summary>
   /// <param name="_idCol">idCol</param>	
    public XLS_Report_Table_Report(int _idCol)
    {
		idCol = _idCol;
    }
    #endregion
	

	#region Properties	
		
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
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set stringCol
	/// </summary>
	/// <param name="_stringCol">stringCol value</param>
	public void Set_stringCol(string _stringCol)
	{
		stringCol = _stringCol;
	}
	
	#endregion
}