    /// <summary>
    /// 定时器事件处理
    /// </summary>
    /// <param name="_time">时间</param>
    public delegate void EventHandlerTimer(ITime _time);
    /// <summary>
    /// 时间缩放事件处理
    /// </summary>
    /// <param name="_time">时间</param>
    /// <param name="_from">修改前时间缩放</param>
    /// <param name="_to">修改后时间缩放</param>
    public delegate void EventHandlerTimeScale(ITime _time, bool _from, bool _to);
    /// <summary>
    /// 同步时间缩放事件处理
    /// </summary>
    /// <param name="_time">时间</param>
    public delegate void EventHandlerSyncTimeScale(ITime _time);
/// <summary>
/// 时间接口
/// </summary>
public interface ITime
{
    /// <summary>
    /// 时间增量
    /// </summary>
    float deltaTime { get; }
    /// <summary>
    /// 时间
    /// </summary>
    float time { get; }
    /// <summary>
    /// fixedDeltaTime
    /// </summary>
    float fixedDeltaTime { get; }
    /// <summary>
    /// fixedTime
    /// </summary>
    float fixedTime { get; }
    /// <summary>
    /// 切换TimeScale之前
    /// </summary>
    event EventHandlerTimeScale OnBeforeToggleTimeScale;
    /// <summary>
    /// 切换TimeScale之后
    /// </summary>
    event EventHandlerTimeScale OnAfterToggleTimeScale;
    /// <summary>
    /// 同步TimeScale之前
    /// </summary>
    event EventHandlerSyncTimeScale OnBeforeSyncTimeScale;
    /// <summary>
    /// 同步TimeScale之后
    /// </summary>
    event EventHandlerSyncTimeScale OnAfterSyncTimeScale;
    /// <summary>
    /// 是否忽略时间缩放
    /// </summary>
    bool isIgnoreTimeScale { get; }
    /// <summary>
    /// 切换时间缩放
    /// </summary>
    /// <param name="_isIgnoreTimeScale">是否忽略时间缩放</param>
    void ToggleTimeScale(bool _isIgnoreTimeScale);
    /// <summary>
    /// 同步时间缩放
    /// </summary>
    /// <param name="_syncTime">同步时间</param>
    void SyncTimeScale(ITime _syncTime);
}
