using System;
/// <summary>
/// 抽象MonoBehaviour【IStatus接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IStatus
{
    #region IStatus
    /// <summary>
    /// 切换运行状态之前事件
    /// </summary>
    public event Action<IStatus, int, int> OnBeforeToggleStatus;
    /// <summary>
    /// 切换运行状态之后事件
    /// </summary>
    public event Action<IStatus, int, int> OnAfterToggleStatus;

    /// <summary>
    /// 当前状态
    /// </summary>
    public int currentStatus { get; private set; }

    /// <summary>
    /// 是否是指定状态
    /// </summary>
    /// <param name="_status">指定状态</param>
    /// <returns>True:是,False:否</returns>
    public bool isStatus(int _status)
    {
        return currentStatus.Equals(_status);
    }
    /// <summary>
    /// 切换到目标状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    public void ToggleStatus(int _destStatus)
    {
        OnBeforeToggleStatus?.Invoke(this, currentStatus, _destStatus);
        int from = currentStatus;
        OnToggleStatus(_destStatus);
        currentStatus = _destStatus;
        OnAfterToggleStatus?.Invoke(this, from, _destStatus);
    }
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    protected virtual void OnToggleStatus(int _destStatus) { }
    #endregion
}