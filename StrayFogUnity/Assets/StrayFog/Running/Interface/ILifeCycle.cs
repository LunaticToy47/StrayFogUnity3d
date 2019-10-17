/// <summary>
/// 处理数据之前事件句柄
/// </summary>
/// <param name="_self">对象</param>
public delegate void EventHandlerLifeCycleBeforeProcessData(ILifeCycle _self);
/// <summary>
/// 处理数据之后事件句柄
/// </summary>
/// <param name="_self">对象</param>
public delegate void EventHandlerLifeCycleAfterProcessData(ILifeCycle _self);
/// <summary>
/// 处理Prefab之前事件句柄
/// </summary>
/// <param name="_self">对象</param>
public delegate void EventHandlerLifeCycleBeforeProcessPrefab(ILifeCycle _self);
/// <summary>
/// 处理Prefab之后事件句柄
/// </summary>
/// <param name="_self">对象</param>
public delegate void EventHandlerLifeCycleAfterProcessPrefab(ILifeCycle _self);
/// <summary>
/// 处理Other之前事件句柄
/// </summary>
/// <param name="_self">对象</param>
public delegate void EventHandlerLifeCycleBeforeProcessOther(ILifeCycle _self);
/// <summary>
/// 处理Other之后事件句柄
/// </summary>
/// <param name="_self">对象</param>
public delegate void EventHandlerLifeCycleAfterProcessOther(ILifeCycle _self);
/// <summary>
/// 生命周期
/// </summary>
public interface ILifeCycle
{
    /// <summary>
    /// 处理数据之前
    /// </summary>
    event EventHandlerLifeCycleBeforeProcessData OnBeforeLifeCycleProcessData;
    /// <summary>
    /// 处理数据之后
    /// </summary>
    event EventHandlerLifeCycleAfterProcessData OnAfterLifeCycleProcessData;
    /// <summary>
    /// 处理预置之前
    /// </summary>
    event EventHandlerLifeCycleBeforeProcessPrefab OnBeforeLifeCycleProcessPrefab;
    /// <summary>
    /// 处理预置之后
    /// </summary>
    event EventHandlerLifeCycleAfterProcessPrefab OnAfterLifeCycleProcessPrefab;
    /// <summary>
    /// 处理其他之前
    /// </summary>
    event EventHandlerLifeCycleBeforeProcessOther OnBeforeLifeCycleProcessOther;
    /// <summary>
    /// 处理其他之后
    /// </summary>
    event EventHandlerLifeCycleAfterProcessOther OnAfterLifeCycleProcessOther;
    /// <summary>
    /// 处理数据
    /// </summary>
    void ProcessData();
    /// <summary>
    /// 处理预置
    /// </summary>
    void ProcessPrefab();
    /// <summary>
    /// 处理其他
    /// </summary>
    void ProcessOther();
}
