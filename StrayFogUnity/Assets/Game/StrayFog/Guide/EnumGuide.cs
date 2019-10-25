#region enGuideStatus 引导状态
using System;
/// <summary>
/// 引导状态
/// </summary>
public enum enGuideStatus
{
    /// <summary>
    /// 等待触发
    /// </summary>
    [AliasTooltip("等待触发")]
    WaitTrigger = 0,
    /// <summary>
    /// 等待验证
    /// </summary>
    [AliasTooltip("等待验证")]
    WaitValidate = 1,
    /// <summary>
    /// 已完成
    /// </summary>
    [AliasTooltip("已完成")]
    Finish = 2,
}
#endregion

#region enUserGuideConfig_GuideType 引导触发类别
/// <summary>
/// 引导触发类别
/// UserGuideConfig.guideType
/// </summary>
public enum enUserGuideConfig_GuideType
{
    /// <summary>
    /// 强引导【禁用玩家操作，等待引导触发】
    /// </summary>
    [AliasTooltip("强引导【禁用玩家操作，等待引导触发】")]
    Strong = 0,
    /// <summary>
    /// 弱引导【玩家可操作，等待引导触发】
    /// </summary>
    [AliasTooltip("弱引导【玩家可操作，等待引导触发】")]
    Weakness = 1
}
#endregion

#region enUserGuideConfig_ConditionMatchType 引导条件匹配类型
/// <summary>
/// 引导条件匹配类型
/// </summary>
public enum enUserGuideConfig_ConditionMatchType
{
    /// <summary>
    /// 全匹配
    /// </summary>
    [AliasTooltip("全匹配")]
    And,
    /// <summary>
    /// 任意匹配
    /// </summary>
    [AliasTooltip("任意匹配")]
    Or,
}
#endregion

#region enUserGuideConfig_StrongGuidDisplayType 强引导窗口显示类型
/// <summary>
/// 强引导窗口显示类型
/// UserGuideConfig.strongGuidDisplayType
/// </summary>
public enum enUserGuideConfig_StrongGuidDisplayType
{
    /// <summary>
    /// 全部显示
    /// </summary>
    [AliasTooltip("全部显示")]
    All = 0,
    /// <summary>
    /// 隐藏引导窗口遮罩背景
    /// </summary>
    [AliasTooltip("隐藏引导窗口遮罩背景")]
    HiddenMaskBg = 1
}
#endregion

#region enUserGuideConfig_TriggerConditionType 【触发条件】数据类型
/// <summary>
/// 【触发条件】数据类型
/// UserGuideConfig.triggerConditionType
/// </summary>
public enum enUserGuideConfig_TriggerConditionType
{
    /// <summary>
    /// 触发参考对象
    /// </summary>
    [AliasTooltip("触发参考对象")]
    ReferObject = 0,
    /// <summary>
    /// 玩家等级
    /// </summary>
    [AliasTooltip("玩家等级")]
    PlayerLv = 1,
    /// <summary>
    /// 物品
    /// </summary>
    [AliasTooltip("物品")]
    Item = 2,
    /// <summary>
    /// 装备
    /// </summary>
    [AliasTooltip("装备")]
    Equip = 3,
    /// <summary>
    /// 任务
    /// </summary>
    [AliasTooltip("任务")]
    Task = 4,
    /// <summary>
    /// 玩家状态
    /// </summary>
    [AliasTooltip("玩家状态")]
    PlayerStatus = 5,
}
#endregion

#region enUserGuideConfig_ValidateConditionType 验证条件类别
/// <summary>
/// 验证条件类别
/// UserGuideConfig.validateConditionType
/// </summary>
public enum enUserGuideConfig_ValidateConditionType
{
    /// <summary>
    /// 点击触发参考对象
    /// </summary>
    [AliasTooltip("点击触发参考对象")]
    Click = 0,
    /// <summary>
    /// 拖拽触发参考对象到验证参考对象
    /// </summary>
    [AliasTooltip("拖拽触发参考对象到验证参考对象")]
    Drag = 1,
    /// <summary>
    /// 触发参考对象移动到验证参考对象
    /// </summary>
    [AliasTooltip("触发参考对象移动到验证参考对象")]
    MoveTo = 2,
}
#endregion

#region enUserGuideReferObject_ReferType 参考对象类型
/// <summary>
/// 参考对象类型
/// </summary>
[Flags]
public enum enUserGuideReferObject_ReferType
{
    /// <summary>
    /// 无参考对象
    /// </summary>
    None = 1 << 0,
    /// <summary>
    /// 2D参考
    /// </summary>
    Refer2D = 1 << 1,
    /// <summary>
    /// 3D参考
    /// </summary>
    Refer3D = 1 << 2,
}
#endregion

#region enUserGuideReferObject_Refer2DType 2D参考类型
/// <summary>
/// 2D参考类型
/// </summary>
public enum enUserGuideReferObject_Refer2DType
{
    /// <summary>
    /// 无参考对象
    /// </summary>
    None = 0,
    /// <summary>
    /// UI窗口控件
    /// </summary>
    UIWindowControl = 1,
    /// <summary>
    /// UI窗口动态生成控件
    /// </summary>
    UIWindowDynamicControl = 2,
}
#endregion

#region enUserGuideReferObject_Refer2DSearchDynamicConditionType 2D动态组件搜索条件类别
/// <summary>
/// 2D动态组件搜索条件类别
/// </summary>
public enum enUserGuideReferObject_Refer2DSearchDynamicConditionType
{
    /// <summary>
    /// 索引
    /// </summary>
    Index = 0,
    /// <summary>
    /// 物品
    /// </summary>
    Item = 1,
    /// <summary>
    /// 装备
    /// </summary>
    Equip = 2,
}
#endregion

#region enUserGuideReferObject_Refer3DType 3D参考类型
/// <summary>
/// 3D参考类型
/// </summary>
public enum enUserGuideReferObject_Refer3DType
{
    /// <summary>
    /// 无参考对象
    /// </summary>
    None = 0,
    /// <summary>
    /// 玩家
    /// </summary>
    Player = 1,
    /// <summary>
    /// NPC
    /// </summary>
    NPC = 2,
    /// <summary>
    /// Monster
    /// </summary>
    Monster = 3,
    /// <summary>
    /// Boss
    /// </summary>
    Boss = 4,
    /// <summary>
    /// 物品
    /// </summary>
    Item = 5,
    /// <summary>
    /// 坐标
    /// </summary>
    Coordinate = 6
}
#endregion