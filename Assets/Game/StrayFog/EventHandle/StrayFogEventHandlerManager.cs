using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏事件句柄
/// </summary>
/// <param name="_args">参数对象</param>
public delegate void GameEventHandler(AbsEventHandlerArgs _args);

/// <summary>
/// 事件聚合管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogEventHandlerManager")]
public class StrayFogEventHandlerManager : AbsSingleMonoBehaviour
{
    #region mGameEventHandlerMaping 游戏事件句柄映射
    /// <summary>
    /// 游戏事件句柄映射
    /// </summary>
    static Dictionary<int, List<GameEventHandler>> mGameEventHandlerMaping = new Dictionary<int, List<GameEventHandler>>();
    #endregion

    #region AddListener 添加事件侦听
    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    /// <param name="_eventHandler">事件句柄</param>
    public void AddListener(int _eventId, GameEventHandler _eventHandler)
    {
        if (!mGameEventHandlerMaping.ContainsKey(_eventId))
        {
            mGameEventHandlerMaping.Add(_eventId, new List<GameEventHandler>());
        }
        if (!mGameEventHandlerMaping[_eventId].Contains(_eventHandler))
        {
            mGameEventHandlerMaping[_eventId].Add(_eventHandler);
        }
#if UNITY_EDITOR
        //UnityEngine.Debug.Log(string.Format("AddListener【Type:{0} Handler:{1}】", _eventId, _eventHandler));
#endif
    }
    #endregion

    #region RemoveListener 移除事件侦听
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    /// <param name="_eventHandler">事件句柄</param>
    public void RemoveListener(int _eventId, GameEventHandler _eventHandler)
    {
        if (mGameEventHandlerMaping.ContainsKey(_eventId) 
            && mGameEventHandlerMaping[_eventId].Contains(_eventHandler)
            )
        {
            mGameEventHandlerMaping[_eventId].Remove(_eventHandler);
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
    /// <param name="_eventArgs">事件参数</param>
    public void Dispatch(AbsEventHandlerArgs _eventArgs)
    {
        if (mGameEventHandlerMaping.ContainsKey(_eventArgs.eventId))
        {
            List<int> remove = new List<int>();

            for (int i = 0; i < mGameEventHandlerMaping[_eventArgs.eventId].Count; i++)
            {
                if (mGameEventHandlerMaping[_eventArgs.eventId][i].Target.Equals(null))
                {
                    remove.Add(i);
                }
                else
                {
                    StartCoroutine(OnDispatchInvoke(mGameEventHandlerMaping[_eventArgs.eventId][i], _eventArgs));
                    //mEventAggregatorHandlerMaping[tKey][eKey][i].Invoke(_args);
                }
            }

            foreach (int index in remove)
            {
                mGameEventHandlerMaping[_eventArgs.eventId].RemoveAt(index);
            }
        }
    }

    /// <summary>
    /// 发布事件
    /// </summary>
    /// <param name="_handler">事件</param>
    /// <param name="_args">参数</param>
    /// <returns>异步</returns>
    IEnumerator OnDispatchInvoke(GameEventHandler _handler, AbsEventHandlerArgs _args)
    {        
        _handler.Invoke(_args);
        yield return new WaitForEndOfFrame();        
    }
    #endregion

    #region DrawLevelSelectButtonOnGUI 绘制关卡选择按钮
    /// <summary>
    /// 游戏事件映射
    /// </summary>
    static List<enExampleGameEvent> mEnGameEventMaping = typeof(enExampleGameEvent).ToEnums<enExampleGameEvent>();
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
            foreach (enExampleGameEvent evt in mEnGameEventMaping)
            {
                StrayFogGamePools.eventHandlerManager
                .Dispatch(new GameEventHandlerArgs(evt, this, evt));
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.EndScrollView();
    }
    #endregion
}
