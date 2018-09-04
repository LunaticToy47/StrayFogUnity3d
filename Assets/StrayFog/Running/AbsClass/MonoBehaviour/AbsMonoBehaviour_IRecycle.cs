using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour【IRecycle接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IRecycle
{
    #region IRecycle
    /// <summary>
    /// 回收之前事件处理
    /// </summary>
    public event EventHandlerRecycle OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件处理
    /// </summary>
    public event EventHandlerRecycle OnAfterRecycle;
    /// <summary>
    /// 回收
    /// </summary>
    public void Recycle()
    {
        if (OnBeforeRecycle != null)
        {
            OnBeforeRecycle(this);
        }
        OnRecycle();
        if (OnAfterRecycle != null)
        {
            OnAfterRecycle(this);
        }
    }
    /// <summary>
    /// 回收
    /// </summary>
    protected virtual void OnRecycle() { }

    /// <summary>
    /// 自动回收协程
    /// </summary>
    Coroutine mAutoRecycleCoroutine = null;
    /// <summary>
    /// 指定时间后自动回收
    /// </summary>
    /// <param name="_delay">延时时间</param>
    public void Recycle(float _delay)
    {
        _delay = Mathf.Clamp(_delay, 0, float.MaxValue);
        if (mAutoRecycleCoroutine != null)
        {
            StopCoroutine(mAutoRecycleCoroutine);
        }
        StartCoroutine(OnDelayRecycle(_delay));
    }

    /// <summary>
    /// 指定时间后回收
    /// </summary>
    /// <param name="_delay">延时时间</param>
    /// <returns>异步</returns>
    System.Collections.IEnumerator OnDelayRecycle(float _delay)
    {
        if (_delay > 0)
        {
            yield return new WaitForEndOfFrame();
            _delay = Mathf.Clamp(_delay - deltaTime, 0, float.MaxValue);
            StartCoroutine(OnDelayRecycle(_delay));
        }
        else
        {
            yield return null;
            Recycle();
        }
    }
    #endregion
}