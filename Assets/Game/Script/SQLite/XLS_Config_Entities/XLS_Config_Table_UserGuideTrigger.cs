using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideTrigger实体
/// </summary>
[SQLiteTableMap(248584192,"Assets/Game/Editor/XLS_Config/UserGuideTrigger.xlsx","UserGuideTrigger", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_UserGuideTrigger))]
public partial class XLS_Config_Table_UserGuideTrigger: AbsStrayFogSQLiteEntity
{
		
	#region constructor
    /// <summary>
    /// constructor
    /// </summary>
   /// <param name="_id">id</param>	
    public XLS_Config_Table_UserGuideTrigger(int _id)
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
	/// 下一引导id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"@nextId3",false)]	
	public int nextId { get; private set; }	
		
	/// <summary>
	/// 引导类型
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"@guideType4",false)]	
	public int guideType { get; private set; }	
		
	/// <summary>
	/// 显示类型
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"@displayType5",false)]	
	public int displayType { get; private set; }	
		
	/// <summary>
	/// 关卡id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"@levelId6",false)]	
	public int levelId { get; private set; }	
		
	/// <summary>
	/// 条件
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,7,"@conditions7",false)]	
	public int[] conditions { get; private set; }	
		
	/// <summary>
	/// 条件Int值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,8,"@intValues8",false)]	
	public int[] intValues { get; private set; }	
		
	/// <summary>
	/// 验证id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,9,"@validateId9",false)]	
	public int validateId { get; private set; }	
	
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
	/// Set nextId
	/// </summary>
	/// <param name="_nextId">nextId value</param>
	public void Set_nextId(int _nextId)
	{
		nextId = _nextId;
	}
	
	/// <summary>
	/// Set guideType
	/// </summary>
	/// <param name="_guideType">guideType value</param>
	public void Set_guideType(int _guideType)
	{
		guideType = _guideType;
	}
	
	/// <summary>
	/// Set displayType
	/// </summary>
	/// <param name="_displayType">displayType value</param>
	public void Set_displayType(int _displayType)
	{
		displayType = _displayType;
	}
	
	/// <summary>
	/// Set levelId
	/// </summary>
	/// <param name="_levelId">levelId value</param>
	public void Set_levelId(int _levelId)
	{
		levelId = _levelId;
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
	/// Set validateId
	/// </summary>
	/// <param name="_validateId">validateId value</param>
	public void Set_validateId(int _validateId)
	{
		validateId = _validateId;
	}
	
	#endregion
}