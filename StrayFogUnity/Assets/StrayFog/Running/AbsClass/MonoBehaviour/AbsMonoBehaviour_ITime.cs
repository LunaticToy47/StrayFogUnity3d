using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour【ITime接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : ITime
{
    #region ITime
    /// <summary>
    /// deltaTime
    /// </summary>
    public float deltaTime { get { return mIsIgnoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime; } }
    /// <summary>
    /// time
    /// </summary>
    public float time { get { return mIsIgnoreTimeScale ? Time.unscaledTime : Time.time; } }
    /// <summary>
    /// fixedDeltaTime
    /// </summary>
    public float fixedDeltaTime { get { return mIsIgnoreTimeScale ? Time.fixedUnscaledDeltaTime : Time.fixedDeltaTime; } }
    /// <summary>
    /// fixedTime
    /// </summary>
    public float fixedTime { get { return mIsIgnoreTimeScale ? Time.fixedUnscaledTime : Time.fixedTime; } }
    /// <summary>
    /// 切换TimeScale之前
    /// </summary>
    public event EventHandlerTimeScale OnBeforeToggleTimeScale;
    /// <summary>
    /// 切换TimeScale之后
    /// </summary>
    public event EventHandlerTimeScale OnAfterToggleTimeScale;
    /// <summary>
    /// 同步TimeScale之前
    /// </summary>
    public event EventHandlerSyncTimeScale OnBeforeSyncTimeScale;
    /// <summary>
    /// 同步TimeScale之后
    /// </summary>
    public event EventHandlerSyncTimeScale OnAfterSyncTimeScale;
    /// <summary>
    /// 是否忽略时间缩放
    /// </summary>
    bool mIsIgnoreTimeScale = false;
    /// <summary>
    /// 是否忽略时间缩放
    /// </summary>
    public bool isIgnoreTimeScale { get { return mIsIgnoreTimeScale; } }
    /// <summary>
    /// 切换时间缩放
    /// </summary>
    /// <param name="_isIgnoreTimeScale">是否忽略时间缩放</param>
    public void ToggleTimeScale(bool _isIgnoreTimeScale)
    {
        if (OnBeforeToggleTimeScale != null)
        {
            OnBeforeToggleTimeScale(this, mIsIgnoreTimeScale, _isIgnoreTimeScale);
        }
        bool from = mIsIgnoreTimeScale;
        mIsIgnoreTimeScale = _isIgnoreTimeScale;
        OnToggleTimeScale(this, mIsIgnoreTimeScale, _isIgnoreTimeScale);
        if (OnAfterToggleTimeScale != null)
        {
            OnAfterToggleTimeScale(this, from, _isIgnoreTimeScale);
        }
    }
    /// <summary>
    /// 切换时间缩放
    /// </summary>
    /// <param name="_time">时间</param>
    /// <param name="_from">修改前时间缩放</param>
    /// <param name="_to">修改后时间缩放</param>
    protected virtual void OnToggleTimeScale(ITime _time, bool _from, bool _to) { }
    /// <summary>
    /// 同步时间缩放
    /// </summary>
    /// <param name="_syncTime">同步时间</param>
    public void SyncTimeScale(ITime _syncTime)
    {
        if (OnBeforeSyncTimeScale != null)
        {
            OnBeforeSyncTimeScale(_syncTime);
        }
        OnSyncTimeScale(_syncTime);
        if (OnAfterSyncTimeScale != null)
        {
            OnAfterSyncTimeScale(_syncTime);
        }
    }

    /// <summary>
    /// 同步时间缩放
    /// </summary>
    /// <param name="_syncTime">同步时间</param>
    protected virtual void OnSyncTimeScale(ITime _syncTime) { }
    #endregion
}
