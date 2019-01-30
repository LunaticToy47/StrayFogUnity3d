using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideTrigger实体
/// </summary>
[SQLiteTableMap(248584192,"Assets/Game/Editor/XLS_Config/UserGuideTrigger.xlsx","UserGuideTrigger", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_UserGuideTrigger),true,false)]
public partial class XLS_Config_Table_UserGuideTrigger: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","@id1",true)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"desc","@desc2",false)]	
	public string desc { get; private set; }	
		
	/// <summary>
	/// 下一引导id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"nextId","@nextId3",false)]	
	public int nextId { get; private set; }	
		
	/// <summary>
	/// 引导类型
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"guideType","@guideType4",false)]	
	public int guideType { get; private set; }	
		
	/// <summary>
	/// 显示类型
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"displayType","@displayType5",false)]	
	public int displayType { get; private set; }	
		
	/// <summary>
	/// 关卡id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"levelId","@levelId6",false)]	
	public int levelId { get; private set; }	
		
	/// <summary>
	/// 条件
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,7,"conditions","@conditions7",false)]	
	public int[] conditions { get; private set; }	
		
	/// <summary>
	/// 条件Int值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,8,"intValues","@intValues8",false)]	
	public int[] intValues { get; private set; }	
		
	/// <summary>
	/// 验证id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,9,"validateId","@validateId9",false)]	
	public int validateId { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}