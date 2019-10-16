using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideConfig实体
/// </summary>
[SQLiteTableMap(1703971369,"Assets/Game/Editor/XLS_Config/UserGuideConfig.xlsx","UserGuideConfig", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_UserGuideConfig),false,false)]
public partial class XLS_Config_Table_UserGuideConfig: AbsStrayFogSQLiteEntity
{
	

	#region Properties	
		
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"desc","","@desc2",false)]	
	public string desc { get; private set; }	
		
	/// <summary>
	/// 下一引导id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"nextId","","@nextId3",false)]	
	public int nextId { get; private set; }	
		
	/// <summary>
	/// 引导类型
	///0：强引导【禁用玩家操作，等待引导触发】【显示引导窗口】
	///1：弱引导【玩家可操作，等待引导触发】【不显示窗口】
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"guideType","","@guideType4",false)]	
	public int guideType { get; private set; }	
		
	/// <summary>
	/// 强引导窗口显示类型
	///0：显示全部
	///1：隐藏引导窗口遮罩背景
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"strongGuidDisplayType","","@strongGuidDisplayType5",false)]	
	public int strongGuidDisplayType { get; private set; }	
		
	/// <summary>
	/// 关卡id
	///0：忽略关卡
	///>0：指定关卡
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"levelId","","@levelId6",false)]	
	public int levelId { get; private set; }	
		
	/// <summary>
	/// 是否忽略服务端返回
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,7,"isIngoreServerBack","","@isIngoreServerBack7",false)]	
	public bool isIngoreServerBack { get; private set; }	
		
	/// <summary>
	/// 【触发参考对象】组
	///UserGuideReferObject.Id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,8,"triggerReferObjectId","","@triggerReferObjectId8",false)]	
	public int[] triggerReferObjectId { get; private set; }	
		
	/// <summary>
	/// 【触发条件】数据类型
	///0：无额外条件
	///1：2D参考类型
	///2：3D参考类型
	///3：玩家等级
	///4：物品
	///5：装备
	///6：任务
	///7：玩家状态
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,9,"triggerConditionType","","@triggerConditionType9",false)]	
	public int triggerConditionType { get; private set; }	
		
	/// <summary>
	/// 【触发条件】数据值
	///0：不填
	///1：[0:隐藏,1:显示]
	///2：[0:隐藏,1:显示]
	///3：等级值[M-N]
	///4：物品配置Id|物品数量
	///5：装备配置Id|装备数量
	///6：[0:任意任务,>0指定任务]
	///7：[0:待机,1:攻击...]
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,10,"triggerConditionValue","","@triggerConditionValue10",false)]	
	public string triggerConditionValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}