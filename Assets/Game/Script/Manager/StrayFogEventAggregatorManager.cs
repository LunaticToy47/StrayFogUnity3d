using System;
using UnityEngine.EventSystems;

/// <summary>
/// 事件聚合句柄
/// </summary>
/// <param name="_args">参数</param>
public delegate void EventAggregatorHandler(AbsEventAggregatorArgs _args);

/// <summary>
/// 事件聚合管理器
/// </summary>
public class StrayFogEventAggregatorManager : AbsSingleMonoBehaviour
{

    public void AddListener(Enum _eventType, EventAggregatorHandler _event)
    {

    }

    public void RemoveListener(Enum _eventType, EventAggregatorHandler _event)
    {

    }

    public void Dispatch(AbsEventAggregatorArgs _args)
    {

    }    
}
