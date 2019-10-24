/// <summary>
/// 引导条件匹配接口
/// </summary>
public interface IGuideMatchCondition
{
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <param name="_status">当前引导状态</param>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCondition(enGuideStatus _status, params object[] _parameters);

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_parameters">参数</param>
    void Excute(enGuideStatus _status, params object[] _parameters);
}
