/// <summary>
/// Game事件聚合参数
/// </summary>
public class GameEventAggregatorArgs : AbsEventAggregatorArgs
{
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extralParameter { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_eventType">事件类型</param>
    /// <param name="_sender">发送者</param>
    /// <param name="_extralParameter">额外参数</param>
    public GameEventAggregatorArgs(enGameEvent _eventType,object _sender,params object[] _extralParameter) : base(_eventType,_sender)
    {
        extralParameter = _extralParameter;
    }
}
