/// <summary>
/// 引导条件匹配接口
/// </summary>
public interface IGuideMatchCondition
{
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCondition(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters);

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_parameters">参数</param>
    void Excute(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters);
}
