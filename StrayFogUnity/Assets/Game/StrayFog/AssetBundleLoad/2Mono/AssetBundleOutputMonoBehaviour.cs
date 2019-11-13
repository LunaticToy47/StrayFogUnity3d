using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 资源Output组件
/// </summary>
[AddComponentMenu("StrayFog/Game/AssetBundle/AssetBundleOutputMonoBehaviour")]
[DisallowMultipleComponent()]
public class AssetBundleOutputMonoBehaviour : AbsMonoBehaviour
{
    /// <summary>
    /// 文件参数
    /// </summary>
    IAssetBundleFileParameter mFileParameter;
    /// <summary>
    /// 设置参数
    /// </summary>
    /// <param name="_fileParameter">文件参数</param>
    public void SetParameter(IAssetBundleFileParameter _fileParameter)
    {
        mFileParameter = _fileParameter;
    }

    /// <summary>
    /// OnDispose
    /// </summary>
    protected override void OnDispose()
    {
        mExecuteQueueResultCallback.Clear();
        mQueueResultCallback.Clear();
        mAssetMaping.Clear();        
        mRequestKeyForTypeKeyMaping.Clear();
        mHasRequest.Clear();
        base.OnDispose();
    }

    /// <summary>
    /// 结果回调
    /// </summary>
    class ResultCallback
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_defaultSelfActive">默认激活状态</param>
        /// <param name="_input">输入</param>
        /// <param name="_callback">回调</param>
        /// <param name="_extraParameter">额外参数</param>
        public ResultCallback(bool _defaultSelfActive,IAssetBundleInput _input, Action<IAssetBundleResult> _callback, object[] _extraParameter)
        {
            defaultSelfActive = _defaultSelfActive;
            input = _input;
            callback = _callback;
            extraParameter = _extraParameter;
        }
        /// <summary>
        /// 默认激活状态
        /// </summary>
        public bool defaultSelfActive { get; private set; }
        /// <summary>
        /// 输入
        /// </summary>
        public IAssetBundleInput input { get; private set; }
        /// <summary>
        /// 回调
        /// </summary>
        public Action<IAssetBundleResult> callback { get; private set; }
        /// <summary>
        /// 额外参数
        /// </summary>
        public object[] extraParameter { get; private set; }
    }

    /// <summary>
    /// 结果队列映射
    /// </summary>
    Dictionary<int, Queue<ResultCallback>> mQueueResultCallback = new Dictionary<int, Queue<ResultCallback>>();
    /// <summary>
    /// 是否在处理队列
    /// </summary>
    Dictionary<int, bool> mExecuteQueueResultCallback = new Dictionary<int, bool>();
    /// <summary>
    /// 资源映射
    /// </summary>
    Dictionary<int, UnityEngine.Object> mAssetMaping = new Dictionary<int, UnityEngine.Object>();
    /// <summary>
    /// 已请求资源加载组
    /// </summary>
    List<int> mHasRequest = new List<int>();
    /// <summary>
    /// 请求与类型Key映射
    /// </summary>
    Dictionary<int, int> mRequestKeyForTypeKeyMaping = new Dictionary<int, int>();

    /// <summary>
    /// 请求实例化
    /// </summary>
    /// <param name="_defaultSelfActive">默认激活状态</param>
    /// <param name="_input">输入</param>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    /// <param name="_type">资源类型</param>
    /// <param name="_assetBundle">资源包</param>
    public void RequestInstantiate(bool _defaultSelfActive, IAssetBundleInput _input,
        Action<IAssetBundleResult> _callback,object[] _extraParameter,Type _type, AssetBundle _assetBundle)
    {
        int key = _type.GetHashCode();
        if (!mQueueResultCallback.ContainsKey(key))
        {
            mQueueResultCallback.Add(key, new Queue<ResultCallback>());
        }
        mQueueResultCallback[key].Enqueue(new ResultCallback(_defaultSelfActive, _input, _callback, _extraParameter));
        if (!mExecuteQueueResultCallback.ContainsKey(key))
        {
            mExecuteQueueResultCallback.Add(key, false);
        }
        if (mAssetMaping.ContainsKey(key) && mAssetMaping[key] == null)
        {
            mHasRequest.Remove(key);
        }
        if (!mHasRequest.Contains(key))
        {
            mHasRequest.Add(key);
            if (mFileParameter.isInternal)
            {
#if UNITY_EDITOR
                UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(mFileParameter.assetBundlePath, _type);
                mAssetMaping.Add(key, obj);
                OnCallQueue(key);
#endif
            }
            else if (!mRequestKeyForTypeKeyMaping.ContainsKey(key))
            {
                AssetBundleRequest request = _assetBundle.LoadAssetAsync(_input.config.fileName, _type);
                request.allowSceneActivation = false;
                request.completed += Request_completed;
                int reqKey = request.GetHashCode();
                mRequestKeyForTypeKeyMaping.Add(reqKey, key);
            }
        }
        else
        {
            OnCallQueue(key);
        }
    }

    void Request_completed(AsyncOperation obj)
    {
        AssetBundleRequest request = (AssetBundleRequest)obj;
        int reqKey = request.GetHashCode();
        int key = mRequestKeyForTypeKeyMaping[reqKey];
        if (!mAssetMaping.ContainsKey(key))
        {
            mAssetMaping.Add(key, request.asset);
        }
        else
        {
            mAssetMaping[key] = request.asset;
        }
        OnCallQueue(key);
    }

    /// <summary>
    /// 调用队列
    /// </summary>
    /// <param name="_key">键值</param>
    void OnCallQueue(int _key)
    {
        if (!mExecuteQueueResultCallback[_key])
        {
            mExecuteQueueResultCallback[_key] = true;
            if (mQueueResultCallback.ContainsKey(_key))
            {                
                Queue<ResultCallback> queue = mQueueResultCallback[_key];
                while (queue.Count > 0)
                {
                    ResultCallback call = queue.Dequeue();
                    coroutine.StartCoroutine(OnResultCallback(_key, call));
                }                
            }
            mExecuteQueueResultCallback[_key] = false;
        }
    }

    /// <summary>
    /// 结果回调
    /// </summary>
    /// <param name="_key">Key</param>
    /// <param name="_call">回调</param>
    /// <returns></returns>
    IEnumerator OnResultCallback(int _key, ResultCallback _call)
    {
        yield return new WaitForEndOfFrame();
        UnityEngine.Object asset = null;
        if (mAssetMaping.ContainsKey(_key))
        {
            asset = mAssetMaping[_key];
        }
        bool isMemory = asset is Texture || asset is Sprite ||
                _call.input.config.extEnumValue == (int)enFileExt.Asset ||
                _call.input.config.extEnumValue == (int)enFileExt.TextAsset ||
                _call.input.config.extEnumValue == (int)enFileExt.Scene;
        if (isMemory)
        {
            _call.callback?.Invoke(new AssetBundleResult(_call.input, _call.extraParameter, asset));
        }
        else
        {
            UnityEngine.Object result = null;
            if (asset != null)
            {
                yield return new WaitForEndOfFrame();
                result = GameObject.Instantiate(asset);
                if (result is GameObject)
                {
                    ((GameObject)result).SetActive(_call.defaultSelfActive);
                }
            }
            _call.callback?.Invoke(new AssetBundleResult(_call.input, _call.extraParameter, result));
        }
    }
}
