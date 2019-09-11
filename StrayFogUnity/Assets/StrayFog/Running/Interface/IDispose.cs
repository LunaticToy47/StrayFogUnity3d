using System;
    /// <summary>
    /// 对象销毁处理
    /// </summary>
    /// <param name="_dispose">销毁对象</param>
    public delegate void EventHandlerDispose(IDispose _dispose);
/// <summary>
/// 销毁接口
/// </summary>
public interface IDispose : IDisposable
{
    /// <summary>
    /// 销毁之前事件处理
    /// </summary>
    event EventHandlerDispose OnBeforeDisposing;

    /// <summary>
    /// 销毁之后事件处理
    /// </summary>
    event EventHandlerDispose OnAfterDisposing;
}
