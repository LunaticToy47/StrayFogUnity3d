/// <summary>
/// 引导执行命令接口
/// </summary>
public interface IGuideExcuteCommand
{
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    void Excute(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters);
}