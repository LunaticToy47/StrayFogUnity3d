using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideReferObject实体
/// </summary>
[SQLiteTableMap(-1509086768,"Assets/Game/Editor/XLS_Config/UserGuideReferObject.xlsx","UserGuideReferObject", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_UserGuideReferObject),true,false)]
public partial class XLS_Config_Table_UserGuideReferObject: AbsStrayFogSQLiteEntity
{
	

	
	protected override int OnResolvePkSequenceId()
    {
        return (id.ToString()).UniqueHashCode();
    }
	

	#region Properties	
		
	/// <summary>
	/// 参考对象Id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true,false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 2D参考类型
	///0：无参考对象
	///1：UI窗口
	///2：UI窗口控件
	///3：UI窗口动态生成控件
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,2,"refer2DType","","@refer2DType2",false,false)]	
	public int refer2DType { get; private set; }	
		
	/// <summary>
	/// 2D参考值
	///0：不填
	///1：【窗口名称|遮罩控件名称】
	///2：【窗口名称|控件名称|相对于控件子节点Graphic遮罩名称】
	///3：【窗口名称|动态控件父节点名称|动态控件模板名称|相对于动态控件模板子节点Graphic遮罩名称】
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,3,"refer2DValue","","@refer2DValue3",false,false)]	
	public string refer2DValue { get; private set; }	
		
	/// <summary>
	/// 2D动态组件搜索条件
	///0：索引
	///1：物品
	///2：装备
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"refer2DSearchDynamicConditionType","","@refer2DSearchDynamicConditionType4",false,false)]	
	public int refer2DSearchDynamicConditionType { get; private set; }	
		
	/// <summary>
	/// 2D动态组件搜索值
	///0：索引值
	///1：物品配置ID
	///2：装备配置ID
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,5,"refer2DSearchDynamicConditionValue","","@refer2DSearchDynamicConditionValue5",false,false)]	
	public string refer2DSearchDynamicConditionValue { get; private set; }	
		
	/// <summary>
	/// 3D参考类型
	///0：无参考对象
	///1：Player玩家
	///2：NPC
	///3：Monster
	///4：Boss
	///5：Item物品
	///6：坐标
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"refer3DType","","@refer3DType6",false,false)]	
	public int refer3DType { get; private set; }	
		
	/// <summary>
	/// 3D参考值
	///0：不填
	///1：暂时不填
	///2：NPC配置Id
	///3：Monster配置Id
	///4：Boss配置Id
	///5：Item物品配置Id
	///6：坐标(x,y,z)
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,7,"refer3DValue","","@refer3DValue7",false,false)]	
	public string refer3DValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}