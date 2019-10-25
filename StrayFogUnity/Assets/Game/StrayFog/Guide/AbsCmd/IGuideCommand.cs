/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand
{
    /// <summary>
    /// 当前引导状态
    /// </summary>
    enGuideStatus status { get; }
}
