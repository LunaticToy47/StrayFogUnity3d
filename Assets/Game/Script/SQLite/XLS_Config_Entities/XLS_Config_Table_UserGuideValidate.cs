using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideValidate实体
/// </summary>
[SQLiteTableMap(1839133489,"Assets/Game/Editor/XLS_Config/UserGuideValidate.xlsx","UserGuideValidate", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_UserGuideValidate),true)]
public partial class XLS_Config_Table_UserGuideValidate: AbsStrayFogSQLiteEntity
{
		
	#region constructor
	/// <summary>
    /// constructor
    /// </summary>
    XLS_Config_Table_UserGuideValidate()
    {
    }

    /// <summary>
    /// constructor
    /// </summary>
   /// <param name="_id">id</param>	
    public XLS_Config_Table_UserGuideValidate(int _id)
    {
		id = _id;
    }
    #endregion
	

	#region Properties	
		
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"@id1",true)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"@desc2",false)]	
	public string desc { get; private set; }	
		
	/// <summary>
	/// 条件
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,3,"@conditions3",false)]	
	public int[] conditions { get; private set; }	
		
	/// <summary>
	/// 条件Int值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,4,"@intValues4",false)]	
	public int[] intValues { get; private set; }	
		
	/// <summary>
	/// 条件Vector2值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray,5,"@vector2Values5",false)]	
	public Vector2[] vector2Values { get; private set; }	
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set desc
	/// </summary>
	/// <param name="_desc">desc value</param>
	public void Set_desc(string _desc)
	{
		desc = _desc;
	}
	
	/// <summary>
	/// Set conditions
	/// </summary>
	/// <param name="_conditions">conditions value</param>
	public void Set_conditions(int[] _conditions)
	{
		conditions = _conditions;
	}
	
	/// <summary>
	/// Set intValues
	/// </summary>
	/// <param name="_intValues">intValues value</param>
	public void Set_intValues(int[] _intValues)
	{
		intValues = _intValues;
	}
	
	/// <summary>
	/// Set vector2Values
	/// </summary>
	/// <param name="_vector2Values">vector2Values value</param>
	public void Set_vector2Values(Vector2[] _vector2Values)
	{
		vector2Values = _vector2Values;
	}
	
	#endregion
}