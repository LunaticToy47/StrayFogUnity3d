    /// <summary>
    /// 对象回收处理
    /// </summary>
    /// <param name="_recycle">回收对象</param>
    public delegate void EventHandlerRecycle(IRecycle _recycle);
/// <summary>
/// 销毁接口
/// </summary>
public interface IRecycle
{
    /// <summary>
    /// 回收之前事件处理
    /// </summary>
    event EventHandlerRecycle OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件处理
    /// </summary>
    event EventHandlerRecycle OnAfterRecycle;
    /// <summary>
    /// 回收
    /// </summary>
    void Recycle();
    /// <summary>
    /// 延时指定时间后回收
    /// </summary>
    /// <param name="_delay">延时</param>
    void Recycle(float _delay);
}

