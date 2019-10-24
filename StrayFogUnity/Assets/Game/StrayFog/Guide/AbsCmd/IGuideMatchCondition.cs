/// <summary>
/// 引导条件匹配接口
/// </summary>
public interface IGuideMatchCondition
{
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCondition(params object[] _parameters);

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    void Excute(params object[] _parameters);
}
