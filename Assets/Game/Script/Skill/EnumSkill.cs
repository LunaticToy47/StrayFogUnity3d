/*
*技能相关枚举
*/

/// <summary>
/// 技能施放模式
/// </summary>
public enum enSkillFireMode
{
    /// <summary>
    /// 主动技能
    /// </summary>
    [AliasTooltip("主动技能")]
    Active,
    /// <summary>
    /// 被动技能
    /// </summary>
    [AliasTooltip("被动技能")]
    Passive,
}

/// <summary>
/// 销毁条件
/// </summary>
public enum enSkillDestoryCondition
{
    /// <summary>
    /// 指定时间
    /// </summary>
    [AliasTooltip("指定时间")]
    Duration = 0x1,
    /// <summary>
    /// 命中目标
    /// </summary>
    [AliasTooltip("命中目标")]
    TargetHit = 0x2,
}

/// <summary>
/// 销毁优先级
/// </summary>
public enum enSkillDestoryPriority
{
    /// <summary>
    /// 满足任意销毁条件
    /// </summary>
    [AliasTooltip("满足任意销毁条件")]
    Any,
    /// <summary>
    /// 满足最高级销毁条件
    /// </summary>
    [AliasTooltip("满足最高级销毁条件")]
    Highest = 100,
}

/// <summary>
/// 技能提示形状
/// </summary>
public enum enSkillPromptShape
{
/// <summary>
/// 圆形
/// </summary>
[AliasTooltip("圆形")]
Circle,
/// <summary>
/// 直线
/// </summary>
[AliasTooltip("直线")]
Line,
/// <summary>
/// 扇形
/// </summary>
[AliasTooltip("扇形")]
Sector,
}
