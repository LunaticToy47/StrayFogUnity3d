using System;
using UnityEngine.EventSystems;

/// <summary>
/// 事件聚合句柄
/// </summary>
/// <param name="_eventId">事件ID</param>
/// <param name="_extralParameter">额外参数</param>
public delegate void EventAggregatorHandler(int _eventId,params object[] _extralParameter);

/// <summary>
/// 事件聚合管理器
/// </summary>
public class StrayFogEventAggregatorManager : AbsSingleMonoBehaviour
{

    public void AddListener(int _eventId, EventAggregatorHandler _event)
    {
        
    }

    public void RemoveListener(int _eventId, EventAggregatorHandler _event)
    {

    }

    public void Dispatch(int _eventId)
    {

    }    
}
