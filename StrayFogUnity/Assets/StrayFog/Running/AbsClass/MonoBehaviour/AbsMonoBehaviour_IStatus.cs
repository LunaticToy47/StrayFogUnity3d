using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour【IStatus接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IStatus
{
    #region IStatus
    /// <summary>
    /// 切换运行状态之前事件
    /// </summary>
    public event EventHandlerToggleStatus OnBeforeToggleStatus;
    /// <summary>
    /// 切换运行状态之后事件
    /// </summary>
    public event EventHandlerToggleStatus OnAfterToggleStatus;

    /// <summary>
    /// 运行状态
    /// </summary>
    int mCurrentStatus = int.MinValue;
    /// <summary>
    /// 当前状态
    /// </summary>
    public int currentStatus { get { return mCurrentStatus; } }

    /// <summary>
    /// 是否是指定状态
    /// </summary>
    /// <param name="_status">指定状态</param>
    /// <returns>True:是,False:否</returns>
    public bool isStatus(int _status)
    {
        return mCurrentStatus.Equals(_status);
    }
    /// <summary>
    /// 切换到目标状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    public void ToggleStatus(int _destStatus)
    {
        if (OnBeforeToggleStatus != null)
        {
            OnBeforeToggleStatus(this, mCurrentStatus, _destStatus);
        }
        int from = mCurrentStatus;
        OnToggleStatus(_destStatus);
        mCurrentStatus = _destStatus;
        if (OnAfterToggleStatus != null)
        {
            OnAfterToggleStatus(this, from, _destStatus);
        }
    }

    /// <summary>
    /// 自动回收协程
    /// </summary>
    Coroutine mDelayToggleStatusCoroutine = null;
    /// <summary>
    /// 延时指定时间后，切换到指定状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    /// <param name="_delay">延时</param>
    public void ToggleStatus(int _destStatus, float _delay)
    {
        _delay = Mathf.Clamp(_delay, 0, float.MaxValue);
        if (mDelayToggleStatusCoroutine != null)
        {
            StopCoroutine(mDelayToggleStatusCoroutine);
        }
        StartCoroutine(OnDelayToggleStatus(_destStatus, _delay));
    }

    /// <summary>
    /// 指定时间后切换状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    /// <param name="_delay">延时时间</param>
    /// <returns>异步</returns>
    System.Collections.IEnumerator OnDelayToggleStatus(int _destStatus, float _delay)
    {
        if (_delay > 0)
        {
            yield return new WaitForEndOfFrame();
            _delay = Mathf.Clamp(_delay - deltaTime, 0, float.MaxValue);
            StartCoroutine(OnDelayToggleStatus(_destStatus, _delay));
        }
        else
        {
            yield return null;
            ToggleStatus(_destStatus);
        }
    }

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    protected virtual void OnToggleStatus(int _destStatus) { }
    #endregion
}