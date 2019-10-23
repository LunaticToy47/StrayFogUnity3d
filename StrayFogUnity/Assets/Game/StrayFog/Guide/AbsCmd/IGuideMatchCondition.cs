/// <summary>
/// 引导条件匹配接口
/// </summary>
public interface IGuideMatchCondition
{
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCondition();
}
