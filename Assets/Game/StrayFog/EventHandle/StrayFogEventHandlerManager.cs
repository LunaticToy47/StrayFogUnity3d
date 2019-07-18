using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏事件句柄
/// </summary>
/// <param name="_args">参数对象</param>
public delegate void EventAggregatorHandler(EventHandlerArgs _args);

/// <summary>
/// 事件聚合管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogEventHandlerManager")]
public class StrayFogEventHandlerManager : AbsSingleMonoBehaviour
{
    #region mEventAggregatorHandlerMaping 事件聚合处理映射
    /// <summary>
    /// 事件聚合处理映射
    /// </summary>
    static Dictionary<int, List<EventAggregatorHandler>> mEventAggregatorHandlerMaping = new Dictionary<int, List<EventAggregatorHandler>>();
    #endregion

    #region AddListener 添加事件侦听
    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <param name="_eventId">事件枚举</param>
    /// <param name="_event">事件</param>
    public void AddListener(int _eventId, EventAggregatorHandler _event)
    {
        if (!mEventAggregatorHandlerMaping.ContainsKey(_eventId))
        {
            mEventAggregatorHandlerMaping.Add(_eventId, new List<EventAggregatorHandler>());
        }
        if (_event.Target == null || _event.Target.Equals(null))
        {
#if UNITY_EDITOR
            Debug.LogError(string.Format("注册消息【{0}】失败=>Delegate.Target is null.", _eventId));
#endif
        }
        else if (!mEventAggregatorHandlerMaping[_eventId].Contains(_event))
        {
            mEventAggregatorHandlerMaping[_eventId].Add(_event);
        }
    }
    #endregion

    #region RemoveListener 移除事件侦听
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <param name="_eventId">事件枚举</param>
    /// <param name="_event">事件</param>
    public void RemoveListener(int _eventId, EventAggregatorHandler _event)
    {
        if (mEventAggregatorHandlerMaping.ContainsKey(_eventId)
            && mEventAggregatorHandlerMaping[_eventId].Contains(_event))
        {
            mEventAggregatorHandlerMaping[_eventId].Remove(_event);
        }
    }
    #endregion

    #region ClearInvalidListener 清除无效的事件侦听
    /// <summary>
    /// 
    /// </summary>
    public void ClearInvalidListener()
    {

    }
    #endregion

    #region Dispatch 发布事件侦听
    /// <summary>
    /// 发布事件侦听
    /// </summary>
    /// <param name="_args">事件参数</param>
    public void Dispatch(EventHandlerArgs _args)
    {
        int tKey = _args.eventId;

        if (mEventAggregatorHandlerMaping.ContainsKey(tKey))
        {
            List<EventAggregatorHandler> remove = new List<EventAggregatorHandler>();
            for (int i = 0; i < mEventAggregatorHandlerMaping[tKey].Count; i++)
            {
                if (mEventAggregatorHandlerMaping[tKey][i].Target == null || mEventAggregatorHandlerMaping[tKey][i].Target.Equals(null))
                {
                    remove.Add(mEventAggregatorHandlerMaping[tKey][i]);
#if UNITY_EDITOR
                    Debug.LogError(string.Format("发布消息【{0}】失败=>Delegate.Target is null.", tKey));
#endif
                }
                else
                {
                    try
                    {
                        mEventAggregatorHandlerMaping[tKey][i].Invoke(_args);
                    }
                    catch (Exception ep)
                    {
#if UNITY_EDITOR
                        Debug.LogError(string.Format("发布消息【{0}】失败=>{1}", tKey, ep.Message));
#endif
                    }
                }
            }

            foreach (EventAggregatorHandler item in remove)
            {
                mEventAggregatorHandlerMaping[tKey].Remove(item);
            }
        }
    }
    #endregion

    #region DrawLevelSelectButtonOnGUI 绘制关卡选择按钮    
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// OnGUI绘制关卡选择按钮
    /// </summary>
    public void DrawLevelSelectButtonOnGUI()
    {
        GUILayout.Space(10);
        mScrollViewPosition = GUILayout.BeginScrollView(mScrollViewPosition);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Dispatch【Game】Events"))
        {
            foreach (int eventId in mEventAggregatorHandlerMaping.Keys)
            {
                EventHandlerArgs arg = new EventHandlerArgs(eventId);
                arg.SetValue(this);
                StrayFogGamePools.eventHandlerManager.Dispatch(arg);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }
    #endregion
}
