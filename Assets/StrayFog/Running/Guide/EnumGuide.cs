/// <summary>
/// 引导触发条件
/// </summary>
public enum enGuideTriggerCondition
{
    /// <summary>
    /// 无条件触发
    /// </summary>
    [AliasTooltip("无条件触发")]
    None,
    /// <summary>
    /// 指定窗口
    /// </summary>
    [AliasTooltip("指定窗口")]
    SpecifyWindow,
}

/// <summary>
/// 引导触发类别
/// </summary>
public enum enGuideTriggerType
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

/// <summary>
/// 引导显示类型
/// </summary>
public enum enGuideDisplayType
{
    /// <summary>
    /// 默认显示
    /// </summary>
    [AliasTooltip("默认显示")]
    Default,
    /// <summary>
    /// 隐藏窗口
    /// </summary>
    [AliasTooltip("隐藏窗口")]
    HideWindow,
    /// <summary>
    /// 隐藏背景
    /// </summary>
    [AliasTooltip("隐藏背景")]
    HideBackground,
}

/// <summary>
/// 引导验证条件
/// </summary>
public enum enGuideValidateCondition
{
    /// <summary>
    /// 无条件
    /// </summary>
    [AliasTooltip("无条件")]
    None,
    /// <summary>
    /// 2D锚点位置
    /// </summary>
    [AliasTooltip("2D锚点位置")]
    Anchor2DPosition,
}

