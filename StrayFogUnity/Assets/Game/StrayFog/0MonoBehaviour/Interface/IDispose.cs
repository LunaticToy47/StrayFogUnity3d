using System;
/// <summary>
/// 销毁接口
/// </summary>
public interface IDispose : IDisposable
{
    /// <summary>
    /// 销毁之前事件处理
    /// </summary>
    event Action<IDispose> OnBeforeDisposing;

    /// <summary>
    /// 销毁之后事件处理
    /// </summary>
    event Action<IDispose> OnAfterDisposing;
}
