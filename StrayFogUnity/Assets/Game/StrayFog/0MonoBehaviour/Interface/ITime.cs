using System;
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
    /// Arg1:时间
    /// Arg2:修改前时间缩放
    /// Arg3:修改后时间缩放
    /// </summary>
    event Action<ITime, bool, bool> OnBeforeToggleTimeScale;
    /// <summary>
    /// 切换TimeScale之后
    /// Arg1:时间
    /// Arg2:修改前时间缩放
    /// Arg3:修改后时间缩放
    /// </summary>
    event Action<ITime, bool, bool> OnAfterToggleTimeScale;
    /// <summary>
    /// 同步TimeScale之前
    /// Arg1:时间
    /// </summary>
    event Action<ITime> OnBeforeSyncTimeScale;
    /// <summary>
    /// 同步TimeScale之后
    /// Arg1:时间
    /// </summary>
    event Action<ITime> OnAfterSyncTimeScale;
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
