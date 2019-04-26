using System;
/// <summary>
/// 事件聚合句柄
/// </summary>
/// <typeparam name="T">参数类型</typeparam>
/// <param name="_args">参数对象</param>
public delegate void EventAggregatorHandler<T>(T _args) where T : AbsEventAggregatorArgs;

/// <summary>
/// 事件聚合管理器
/// </summary>
public class StrayFogEventAggregatorManager : AbsSingleMonoBehaviour
{
    #region AddListener 添加事件侦听
    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <typeparam name="T">事件参数类型</typeparam>
    /// <param name="_eventType">事件枚举</param>
    /// <param name="_event">事件</param>
    public void AddListener<T>(Enum _eventType, EventAggregatorHandler<T> _event)
         where T : AbsEventAggregatorArgs
    {

    }
    #endregion

    #region RemoveListener 移除事件侦听
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <typeparam name="T">事件参数类型</typeparam>
    /// <param name="_eventType">事件枚举</param>
    /// <param name="_event">事件</param>
    public void RemoveListener<T>(Enum _eventType, EventAggregatorHandler<T> _event)
        where T : AbsEventAggregatorArgs
    {

    }
    #endregion

    #region Dispatch 发布事件侦听
    /// <summary>
    /// 发布事件侦听
    /// </summary>
    /// <typeparam name="T">事件参数类型</typeparam>
    /// <param name="_args">事件参数</param>
    public void Dispatch<T>(T _args)
        where T : AbsEventAggregatorArgs
    {

    }
    #endregion
}
