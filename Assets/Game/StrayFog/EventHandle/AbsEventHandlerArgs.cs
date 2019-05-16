/// <summary>
/// 事件聚合参数
/// </summary>
public abstract class AbsEventHandlerArgs
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public int eventId { get; private set; }

    /// <summary>
    /// 事件聚合参数
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    public AbsEventHandlerArgs(int _eventId)
    {
        eventId = _eventId;
    }
}
