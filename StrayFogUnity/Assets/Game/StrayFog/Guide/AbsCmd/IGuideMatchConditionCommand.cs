/// <summary>
/// 引导条件匹配命令接口
/// </summary>
public interface IGuideMatchConditionCommand
{
    /// <summary>
    /// 是否匹配条件
    /// </summary>
    bool isMatch { get; }

    /// <summary>
    /// 条件运算符
    /// </summary>
    enUserGuideConfig_ConditionOperator conditionOperator { get; }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCondition(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters);    
}
