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

    public void AddListener<T>(Enum _eventType, EventAggregatorHandler<T> _event)
         where T : AbsEventAggregatorArgs
    {

    }

    public void RemoveListener<T>(Enum _eventType, EventAggregatorHandler<T> _event)
        where T : AbsEventAggregatorArgs
    {

    }

    public void Dispatch<T>(T _args)
        where T : AbsEventAggregatorArgs
    {

    }    
}
