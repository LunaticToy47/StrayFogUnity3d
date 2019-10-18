/// <summary>
/// 引导触发类别
/// UserGuideConfig.guideType
/// </summary>
public enum enGuideType
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
/// 强引导窗口显示类型
/// UserGuideConfig.strongGuidDisplayType
/// </summary>
public enum enStrongGuidDisplayType
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
