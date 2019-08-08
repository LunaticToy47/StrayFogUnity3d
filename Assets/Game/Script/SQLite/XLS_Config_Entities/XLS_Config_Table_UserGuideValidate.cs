using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideValidate实体
/// </summary>
[SQLiteTableMap(249757027,"Assets/Game/Editor/XLS_Config/UserGuideValidate.xlsx","UserGuideValidate", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_902350952",typeof(XLS_Config_Table_UserGuideValidate),true,false)]
public partial class XLS_Config_Table_UserGuideValidate: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"desc","","@desc2",false)]	
	public string desc { get; private set; }	
		
	/// <summary>
	/// 条件
	///0：无条件
	///1：2D锚点位置
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,3,"conditions","","@conditions3",false)]	
	public int[] conditions { get; private set; }	
		
	/// <summary>
	/// 条件Int值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,4,"intValues","","@intValues4",false)]	
	public int[] intValues { get; private set; }	
		
	/// <summary>
	/// 条件Vector2值
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Vector2,enSQLiteDataTypeArrayDimension.OneDimensionArray,5,"vector2Values","","@vector2Values5",false)]	
	public Vector2[] vector2Values { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}