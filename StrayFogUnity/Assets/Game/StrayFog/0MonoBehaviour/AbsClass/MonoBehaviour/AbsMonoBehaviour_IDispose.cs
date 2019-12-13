using System;
/// <summary>
/// 抽象MonoBehaviour【IDispose接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IDispose
{
    #region IDispose
    /// <summary>
    /// 销毁事件处理
    /// </summary>
    public event Action<IDispose> OnBeforeDisposing;
    /// <summary>
    /// 销毁之后事件处理
    /// </summary>
    public event Action<IDispose> OnAfterDisposing;
    /// <summary>
    /// 销毁对象
    /// </summary>
    public void Dispose()
    {
        OnBeforeDisposing?.Invoke(this);
        OnDispose();
        OnAfterDisposing?.Invoke(this);
    }

    /// <summary>
    /// 销毁
    /// </summary>
    protected virtual void OnDispose() { }
    #endregion
}
