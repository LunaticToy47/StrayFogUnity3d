#region enGuideStatus 引导状态
/// <summary>
/// 引导状态
/// </summary>
public enum enGuideStatus
{
    /// <summary>
    /// 等待触发
    /// </summary>
    [AliasTooltip("等待触发")]
    WaitTrigger,
    /// <summary>
    /// 等待验证
    /// </summary>
    [AliasTooltip("等待验证")]
    WaitValidate,
    /// <summary>
    /// 已完成
    /// </summary>
    [AliasTooltip("已完成")]
    Finish,
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
    Strong,
    /// <summary>
    /// 弱引导【玩家可操作，等待引导触发】
    /// </summary>
    [AliasTooltip("弱引导【玩家可操作，等待引导触发】")]
    Weakness
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
    All,
    /// <summary>
    /// 隐藏引导窗口遮罩背景
    /// </summary>
    [AliasTooltip("隐藏引导窗口遮罩背景")]
    HiddenMaskBg
}
#endregion

#region UserGuideConfig_TriggerConditionType 【触发条件】数据类型
/// <summary>
/// 【触发条件】数据类型
/// UserGuideConfig.triggerConditionType
/// </summary>
public enum enUserGuideConfig_TriggerConditionType
{
    /// <summary>
    /// 无条件
    /// </summary>
    [AliasTooltip("无条件")]
    None = 0,
    /// <summary>
    /// 2D参考类型
    /// </summary>
    [AliasTooltip("2D参考类型")]
    Refer2D = 1,
    /// <summary>
    /// 3D参考类型
    /// </summary>
    [AliasTooltip("3D参考类型")]
    Refer3D = 2,
    /// <summary>
    /// 玩家等级
    /// </summary>
    [AliasTooltip("玩家等级")]
    PlayerLv = 3,
    /// <summary>
    /// 物品
    /// </summary>
    [AliasTooltip("物品")]
    Item = 4,
    /// <summary>
    /// 装备
    /// </summary>
    [AliasTooltip("装备")]
    Equip = 5,
    /// <summary>
    /// 任务
    /// </summary>
    [AliasTooltip("任务")]
    Task = 6,
    /// <summary>
    /// 玩家状态
    /// </summary>
    [AliasTooltip("玩家状态")]
    PlayerStatus = 7,
}
#endregion