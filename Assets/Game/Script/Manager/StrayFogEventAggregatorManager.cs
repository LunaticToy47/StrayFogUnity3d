using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 事件聚合句柄
/// </summary>
/// <param name="_args">参数对象</param>
public delegate void EventAggregatorHandler(AbsEventAggregatorArgs _args);

/// <summary>
/// 事件聚合管理器
/// </summary>
public class StrayFogEventAggregatorManager : AbsSingleMonoBehaviour
{
    #region mEventAggregatorHandlerMaping 事件聚合处理映射
    /// <summary>
    /// 事件聚合处理映射
    /// </summary>
    static Dictionary<int, Dictionary<int, List<EventAggregatorHandler>>> mEventAggregatorHandlerMaping = new Dictionary<int, Dictionary<int, List<EventAggregatorHandler>>>();
    #endregion

    #region AddListener 添加事件侦听
    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <param name="_eventType">事件枚举</param>
    /// <param name="_event">事件</param>
    public void AddListener(Enum _eventType, EventAggregatorHandler _event)
    {
        int tKey = _eventType.GetType().GetHashCode();
        int eKey = _eventType.GetHashCode();
        if (!mEventAggregatorHandlerMaping.ContainsKey(tKey))
        {
            mEventAggregatorHandlerMaping.Add(tKey, new Dictionary<int, List<EventAggregatorHandler>>());
        }
        if (!mEventAggregatorHandlerMaping[tKey].ContainsKey(eKey))
        {
            mEventAggregatorHandlerMaping[tKey].Add(eKey, new List<EventAggregatorHandler>());
        }
        if (!mEventAggregatorHandlerMaping[tKey][eKey].Contains(_event))
        {
            mEventAggregatorHandlerMaping[tKey][eKey].Add(_event);
        }        
#if UNITY_EDITOR
        //UnityEngine.Debug.Log(string.Format("AddListener【Type:{0} Handler:{1}】", tKey, eKey));
#endif
    }
    #endregion

    #region RemoveListener 移除事件侦听
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <param name="_eventType">事件枚举</param>
    /// <param name="_event">事件</param>
    public void RemoveListener(Enum _eventType, EventAggregatorHandler _event)
    {
        int tKey = _eventType.GetType().GetHashCode();
        int eKey = _event.GetHashCode();
        if (mEventAggregatorHandlerMaping.ContainsKey(tKey) 
            && mEventAggregatorHandlerMaping[tKey].ContainsKey(eKey)
            && mEventAggregatorHandlerMaping[tKey][eKey].Contains(_event))
        {
            mEventAggregatorHandlerMaping[tKey][eKey].Remove(_event);
        }
#if UNITY_EDITOR
            //UnityEngine.Debug.Log(string.Format("RemoveListener【Type:{0} Handler:{1}】", tKey, eKey));
#endif
        }
    #endregion

    #region Dispatch 发布事件侦听
    /// <summary>
    /// 发布事件侦听
    /// </summary>
    /// <param name="_args">事件参数</param>
    public void Dispatch(AbsEventAggregatorArgs _args)
    {
        int tKey = _args.eventType.GetType().GetHashCode();
        int eKey = _args.eventType.GetHashCode();
        if (mEventAggregatorHandlerMaping.ContainsKey(tKey) && mEventAggregatorHandlerMaping[tKey].ContainsKey(eKey))
        {
            List<int> remove = new List<int>();

            for (int i = 0; i < mEventAggregatorHandlerMaping[tKey][eKey].Count; i++)
            {
                if (mEventAggregatorHandlerMaping[tKey][eKey][i].Target.Equals(null))
                {
                    remove.Add(i);
                }
                else
                {
                    mEventAggregatorHandlerMaping[tKey][eKey][i].Invoke(_args);
                }
            }

            foreach (int index in remove)
            {
                mEventAggregatorHandlerMaping[tKey][eKey].RemoveAt(index);
            }
        }
    }
    #endregion

    #region DrawLevelSelectButtonOnGUI 绘制关卡选择按钮
    /// <summary>
    /// UGUI事件映射
    /// </summary>
    static List<enUGUIEvent> mEnUGUIEventMaping = typeof(enUGUIEvent).ToEnums<enUGUIEvent>();
    /// <summary>
    /// 游戏事件映射
    /// </summary>
    static List<enGameEvent> mEnGameEventMaping = typeof(enGameEvent).ToEnums<enGameEvent>();
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
        foreach (enUGUIEvent evt in mEnUGUIEventMaping)
        {
            if (GUILayout.Button(string.Format("Dispatch【UGUI】【{0}】", evt)))
            {
                StrayFogGamePools.eventAggregatorManager
                .Dispatch(new UGUIEventAggregatorArgs(evt, this, evt));
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        foreach (enGameEvent evt in mEnGameEventMaping)
        {
            if (GUILayout.Button(string.Format("Dispatch【Game】【{0}】", evt)))
            {
                StrayFogGamePools.eventAggregatorManager
                .Dispatch(new GameEventAggregatorArgs(evt, this, evt));
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }
    #endregion
}
