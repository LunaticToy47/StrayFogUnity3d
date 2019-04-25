using System;
/// <summary>
/// 事件聚合参数
/// </summary>
public abstract class AbsEventAggregatorArgs
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public Enum eventType { get; private set; }
    /// <summary>
    /// 事件发送者
    /// </summary>
    public object sender { get; private set; }

    /// <summary>
    /// 事件聚合参数
    /// </summary>
    /// <param name="_eventType">事件类型</param>
    /// <param name="_sender">事件发送者</param>
    public AbsEventAggregatorArgs(Enum _eventType, object _sender)
    {
        eventType = _eventType;
        sender = _sender;
    }
}
