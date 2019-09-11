using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 事件句柄
/// </summary>
/// <param name="_args">参数</param>
public delegate void StrayFogEventHandler(StrayFogEventHandlerArgs _args);
/// <summary>
/// 事件回调句柄
/// </summary>
/// <param name="_callbackArgs">回调参数</param>
public delegate void StrayFogCallbackHandler(StrayFogCallbackHandlerArgs _callbackArgs);
/// <summary>
/// 事件聚合管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogEventHandlerManager")]
public sealed class StrayFogEventHandlerManager : AbsSingleMonoBehaviour
{
    #region mEventHandlerMaping 事件处理映射
    /// <summary>
    /// 事件处理映射
    /// </summary>
    static Dictionary<int, List<StrayFogEventHandler>> mEventHandlerMaping = new Dictionary<int, List<StrayFogEventHandler>>();
    #endregion

    #region mCallbackHandlerMaping 回调事件处理映射
    /// <summary>
    /// 回调事件处理映射
    /// </summary>
    static Dictionary<int, List<StrayFogCallbackHandler>> mCallbackHandlerMaping = new Dictionary<int, List<StrayFogCallbackHandler>>();
    #endregion

    #region AddListener 添加事件侦听
    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <param name="_eventId">事件枚举</param>
    /// <param name="_event">事件</param>
    public void AddListener(int _eventId, StrayFogEventHandler _event)
    {
        if (!mEventHandlerMaping.ContainsKey(_eventId))
        {
            mEventHandlerMaping.Add(_eventId, new List<StrayFogEventHandler>());
        }
        if (!_event.IsValid())
        {
#if UNITY_EDITOR
            Debug.LogError(string.Format("注册消息【{0}】失败=>Delegate.Target is null.", _eventId));
#endif
        }
        else if (!mEventHandlerMaping[_eventId].Contains(_event))
        {
            mEventHandlerMaping[_eventId].Add(_event);
        }
    }

    /// <summary>
    /// 添加事件侦听
    /// </summary>
    /// <param name="_eventId">事件枚举</param>
    /// <param name="_callback">事件回调</param>
    public void AddCallbackListener(int _eventId, StrayFogCallbackHandler _callback)
    {
        if (!mCallbackHandlerMaping.ContainsKey(_eventId))
        {
            mCallbackHandlerMaping.Add(_eventId, new List<StrayFogCallbackHandler>());
        }
        if (!_callback.IsValid())
        {
#if UNITY_EDITOR
            Debug.LogError(string.Format("注册消息【{0}】失败=>Delegate.Target is null.", _eventId));
#endif
        }
        else if (!mCallbackHandlerMaping[_eventId].Contains(_callback))
        {
            mCallbackHandlerMaping[_eventId].Add(_callback);
        }
    }
    #endregion

    #region RemoveListener 移除事件侦听
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    /// <param name="_event">事件</param>
    public void RemoveListener(int _eventId, StrayFogEventHandler _event)
    {
        if (mEventHandlerMaping.ContainsKey(_eventId)
            && mEventHandlerMaping[_eventId].Contains(_event))
        {
            mEventHandlerMaping[_eventId].Remove(_event);
        }
    }
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    /// <param name="_callback">回调事件</param>
    public void RemoveCallbackListener(int _eventId, StrayFogCallbackHandler _callback)
    {
        if (mCallbackHandlerMaping.ContainsKey(_eventId)
            && mCallbackHandlerMaping[_eventId].Contains(_callback))
        {
            mCallbackHandlerMaping[_eventId].Remove(_callback);
        }
    }
    /// <summary>
    /// 移除事件侦听
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    public void RemoveListener(int _eventId)
    {
        if (mEventHandlerMaping.ContainsKey(_eventId))
        {
            mEventHandlerMaping[_eventId].Clear();
        }
        mEventHandlerMaping.Remove(_eventId);
        if (mCallbackHandlerMaping.ContainsKey(_eventId))
        {
            mCallbackHandlerMaping[_eventId].Clear();
        }
        mCallbackHandlerMaping.Remove(_eventId);
    }
    #endregion

    #region ClearInvalidListener 清除无效的事件侦听
    /// <summary>
    /// 清除无效的事件侦听
    /// </summary>
    public void ClearInvalidListener()
    {
        foreach (KeyValuePair<int, List<StrayFogEventHandler>> key in mEventHandlerMaping)
        {
            List<StrayFogEventHandler> remove = new List<StrayFogEventHandler>();
            for (int i = 0; i < key.Value.Count; i++)
            {
                if (!key.Value[i].IsValid())
                {
                    remove.Add(key.Value[i]);
#if UNITY_EDITOR
                    Debug.LogError(string.Format("清除无效的事件侦听【{0}】【{1}】=>Delegate.Target is null.", key.Key, key.Value[i]));
#endif
                }
            }
            foreach (StrayFogEventHandler item in remove)
            {
                key.Value.Remove(item);
            }
        }

        foreach (KeyValuePair<int, List<StrayFogCallbackHandler>> key in mCallbackHandlerMaping)
        {
            List<StrayFogCallbackHandler> remove = new List<StrayFogCallbackHandler>();
            for (int i = 0; i < key.Value.Count; i++)
            {
                if (!key.Value[i].IsValid())
                {
                    remove.Add(key.Value[i]);
#if UNITY_EDITOR
                    Debug.LogError(string.Format("清除无效的回调事件侦听【{0}】【{1}】=>Delegate.Target is null.", key.Key, key.Value[i]));
#endif
                }
            }
            foreach (StrayFogCallbackHandler item in remove)
            {
                key.Value.Remove(item);
            }
        }
    }
    #endregion

    #region Dispatch 发布事件侦听
    /// <summary>
    /// 发布事件侦听
    /// </summary>
    /// <param name="_args">事件参数</param>
    public void Dispatch(StrayFogEventHandlerArgs _args)
    {
        Dispatch(_args, null);
    }

    /// <summary>
    /// 发布事件侦听
    /// </summary>
    /// <param name="_args">事件参数</param>
    /// <param name="_callback">回调</param>
    public void Dispatch(StrayFogEventHandlerArgs _args, StrayFogCallbackHandler _callback)
    {        
        OnProcessEventHandler(_args);
        OnProcessCallbackHandler(_args,_callback);        
    }

    /// <summary>
    /// 处理EventHandler事件
    /// </summary>
    /// <param name="_args">参数</param>
    void OnProcessEventHandler(StrayFogEventHandlerArgs _args)
    {
        int tKey = _args.eventId;
        if (mEventHandlerMaping.ContainsKey(tKey))
        {
            List<StrayFogEventHandler> remove = new List<StrayFogEventHandler>();
            for (int i = 0; i < mEventHandlerMaping[tKey].Count; i++)
            {
                if (!mEventHandlerMaping[tKey][i].IsValid())
                {
                    remove.Add(mEventHandlerMaping[tKey][i]);
#if UNITY_EDITOR
                    Debug.LogError(string.Format("发布EventHandler消息【{0}】失败=>Delegate.Target is null.", tKey));
#endif
                }
                else
                {
                    try
                    {
                        mEventHandlerMaping[tKey][i].Invoke(_args);
                    }
                    catch (Exception ep)
                    {
#if UNITY_EDITOR
                        Debug.LogError(string.Format("发布消息【{0}】失败=>{1}", tKey, ep.Message));
#endif
                    }
                }
            }

            foreach (StrayFogEventHandler item in remove)
            {
                mEventHandlerMaping[tKey].Remove(item);
            }
        }
    }

    /// <summary>
    /// 处理CallbackHandler事件
    /// </summary>
    /// <param name="_args">事件参数</param>
    /// <param name="_callback">回调</param>
    void OnProcessCallbackHandler(StrayFogEventHandlerArgs _args, StrayFogCallbackHandler _callback)
    {
        int tKey = _args.eventId;
        if (mCallbackHandlerMaping.ContainsKey(tKey))
        {
            List<StrayFogCallbackHandler> remove = new List<StrayFogCallbackHandler>();
            for (int i = 0; i < mCallbackHandlerMaping[tKey].Count; i++)
            {
                if (!mCallbackHandlerMaping[tKey][i].IsValid())
                {
                    remove.Add(mCallbackHandlerMaping[tKey][i]);
#if UNITY_EDITOR
                    Debug.LogError(string.Format("发布CallbackHandler消息【{0}】失败=>Delegate.Target is null.", tKey));
#endif
                }
                else
                {
                    try
                    {
                        StrayFogCallbackHandlerArgs callbackArgs = new StrayFogCallbackHandlerArgs(_args);
                        mCallbackHandlerMaping[tKey][i].Invoke(callbackArgs);
                        _callback?.Invoke(callbackArgs);
                    }
                    catch (Exception ep)
                    {
#if UNITY_EDITOR
                        Debug.LogError(string.Format("发布消息【{0}】失败=>{1}", tKey, ep.Message));
#endif
                    }
                }
            }

            foreach (StrayFogCallbackHandler item in remove)
            {
                mCallbackHandlerMaping[tKey].Remove(item);
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
            foreach (int eventId in mEventHandlerMaping.Keys)
            {
                StrayFogEventHandlerArgs arg = new StrayFogEventHandlerArgs(eventId);
                arg.SetValue(this);
                Dispatch(arg, (callback) => { Debug.Log("Get CallbackHandler Value=>" + callback); });
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndScrollView();
    }
    #endregion
}
