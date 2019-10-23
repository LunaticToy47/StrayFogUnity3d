/// <summary>
/// 引导条件抽象
/// </summary>
public class AbsGuideCondition : IGuideCondition
{
    #region isMatchCondition 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足条件,false:不满足条件</returns>
    public bool isMatchCondition()
    {
        return OnIsMatchCondition();
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected virtual bool OnIsMatchCondition() { return false; }
    #endregion
}