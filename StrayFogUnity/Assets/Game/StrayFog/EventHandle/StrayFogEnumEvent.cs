/// <summary>
/// StrayFogEvent
/// </summary>
public enum enStrayFogEvent
{
    #region 心跳
    /// <summary>
    /// 心跳
    /// </summary>
    [AliasTooltip("心跳")]
    HeartBeat = 1<< 60,
    #endregion

    #region TimeScale
    /// <summary>
    /// 是否禁止修改TimeScale
    /// </summary>
    [AliasTooltip("是否禁止修改TimeScale")]
    IsForbidModifyTimeScale,
    #endregion
}
