using System;
/// <summary>
/// 销毁接口
/// </summary>
public interface IRecycle
{
    /// <summary>
    /// 回收之前事件处理
    /// </summary>
    event Action<IRecycle> OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件处理
    /// </summary>
    event Action<IRecycle> OnAfterRecycle;
    /// <summary>
    /// 回收
    /// </summary>
    void Recycle();
    /// <summary>
    /// 转场景回收事件处理
    /// </summary>
    event Action<IRecycle> OnToggleSceneRecycleHandler;
    /// 转场景回收
    /// </summary>
    void ToggleSceneRecycle();
}

