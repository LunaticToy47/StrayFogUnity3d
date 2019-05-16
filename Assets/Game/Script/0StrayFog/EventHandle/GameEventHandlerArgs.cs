/// <summary>
/// Game事件聚合参数
/// </summary>
public class GameEventHandlerArgs : AbsEventHandlerArgs
{
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extralParameter { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_eventType">事件类型</param>
    /// <param name="_extralParameter">额外参数</param>
    public GameEventHandlerArgs(enExampleGameEvent _eventType, params object[] _extralParameter)
        : this((int)_eventType, _extralParameter)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_eventType">事件类型</param>
    /// <param name="_extralParameter">额外参数</param>
    public GameEventHandlerArgs(int _eventType, params object[] _extralParameter)
        : base(_eventType)
    {
        extralParameter = _extralParameter;
    }
}
