using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideConfig实体
/// </summary>
[SQLiteTableMap(1703971369,"Assets/Game/Editor/XLS_Config/UserGuideConfig.xlsx","UserGuideConfig", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_UserGuideConfig),true,false)]
public partial class XLS_Config_Table_UserGuideConfig: AbsStrayFogSQLiteEntity
{
	

	
	protected override int OnResolvePkSequenceId()
    {
        return (id.ToString()).UniqueHashCode();
    }
	

	#region Properties	
		
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true,false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"desc","","@desc2",false,true)]	
	public string desc { get; private set; }	
		
	/// <summary>
	/// 下一引导id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"nextId","","@nextId3",false,false)]	
	public int nextId { get; private set; }	
		
	/// <summary>
	/// 引导类型
	///0：强引导【禁用玩家操作，等待引导触发】【显示引导窗口】
	///1：弱引导【玩家可操作，等待引导触发】【不显示窗口】
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"guideType","","@guideType4",false,false)]	
	public int guideType { get; private set; }	
		
	/// <summary>
	/// 强引导窗口显示类型
	///0：显示全部
	///1：隐藏引导窗口遮罩背景
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"strongGuidDisplayType","","@strongGuidDisplayType5",false,false)]	
	public int strongGuidDisplayType { get; private set; }	
		
	/// <summary>
	/// 关卡id
	///0：忽略关卡
	///>0：指定关卡
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"levelId","","@levelId6",false,false)]	
	public int levelId { get; private set; }	
		
	/// <summary>
	/// 是否忽略服务端返回
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,7,"isIngoreServerBack","","@isIngoreServerBack7",false,false)]	
	public bool isIngoreServerBack { get; private set; }	
		
	/// <summary>
	/// 箭头位置
	///0：箭头在框左侧
	///1：箭头在框右侧
	///2：箭头在框上侧
	///3：箭头在框下侧
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,8,"arrowEdge","","@arrowEdge8",false,false)]	
	public int arrowEdge { get; private set; }	
		
	/// <summary>
	/// 【触发参考对象】组
	///UserGuideReferObject.Id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,9,"triggerReferObjectId","","@triggerReferObjectId9",false,false)]	
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
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,10,"triggerConditionType","","@triggerConditionType10",false,false)]	
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
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,11,"triggerConditionValue","","@triggerConditionValue11",false,false)]	
	public string triggerConditionValue { get; private set; }	
		
	/// <summary>
	/// 转到下一引导方式
	///0：完成操作
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,12,"transNextGuidePattern","","@transNextGuidePattern12",false,false)]	
	public int transNextGuidePattern { get; private set; }	
		
	/// <summary>
	/// 【验证参考对象】组
	///UserGuideReferObject.Id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,13,"validateReferObjectId","","@validateReferObjectId13",false,false)]	
	public int[] validateReferObjectId { get; private set; }	
		
	/// <summary>
	/// 验证条件类别
	///0：Click 点击触发参考对象
	///1：Drag 拖拽触发参考对象到验证参考对象
	///2：MoveTo 触发参考对象移动到验证参考对象
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,14,"validateConditionType","","@validateConditionType14",false,false)]	
	public int validateConditionType { get; private set; }	
		
	/// <summary>
	/// 验证条件值
	///0：[0:点击任意触发参考对象,0|1|2：按索引触发参考对象]
	///1：[0:拖拽任意参考对象到任意验证对象,0-1|2-3指定索引的参考对象拖拽到指定验证对象]
	///2：[0:任意]
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,15,"validateConditionValue","","@validateConditionValue15",false,false)]	
	public string validateConditionValue { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}