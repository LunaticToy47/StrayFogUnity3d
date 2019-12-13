using System;
/// <summary>
/// 抽象MonoBehaviour【IRecycle接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IRecycle
{
    #region IRecycle
    /// <summary>
    /// 回收之前事件处理
    /// </summary>
    public event Action<IRecycle> OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件处理
    /// </summary>
    public event Action<IRecycle> OnAfterRecycle;
    /// <summary>
    /// 回收
    /// </summary>
    public void Recycle()
    {
        OnBeforeRecycle?.Invoke(this);
        OnRecycle();
        OnAfterRecycle?.Invoke(this);
    }
    /// <summary>
    /// 回收
    /// </summary>
    protected virtual void OnRecycle() { }
    #endregion

    #region ToggleSceneRecycle
    /// <summary>
    /// 转场景回收事件处理
    /// </summary>
    public event Action<IRecycle> OnToggleSceneRecycleHandler;
    /// 转场景回收
    /// </summary>
    public void ToggleSceneRecycle()
    {
        OnToggleSceneRecycle();
        OnToggleSceneRecycleHandler?.Invoke(this);
    }
    /// <summary>
    /// 转场景回收
    /// </summary>
    protected virtual void OnToggleSceneRecycle() { }
    #endregion
}