using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源组件
/// </summary>
[AddComponentMenu("StrayFog/Game/AssetBundle/AssetBundleMonoBehaviour")]
[DisallowMultipleComponent()]
public class AssetBundleMonoBehaviour : AbsMonoBehaviour
{
    /// <summary>
    /// 请求加载依赖项
    /// </summary>
    public event Func<AssetBundleMonoBehaviour, AssetBundleMonoBehaviour[]> OnRequestLoadDependencies;
    /// <summary>
    /// 加载资源完成
    /// </summary>
    public event Action<AssetBundleMonoBehaviour> OnLoadAssetBundleComplete;

    /// <summary>
    /// 文件参数
    /// </summary>
    public IAssetBundleFileParameter fileParameter { get; private set; }
    /// <summary>
    /// 是否加载完成
    /// </summary>
    public bool isDone { get; private set; }
    /// <summary>
    /// 加载进度
    /// </summary>
    public float progress { get; private set; }

    #region SetParameter 设置参数
    /// <summary>
    /// 设置参数
    /// </summary>
    /// <param name="_fileParameter">文件参数</param>
    public void SetParameter(IAssetBundleFileParameter _fileParameter)
    {
        fileParameter = _fileParameter;        
        mLoadState = enLoadState.Wait;
        isDone = false;
        progress = 0;
        mIsExecuteQueue = false;
    }
    #endregion

    #region Request 请求资源
    /// <summary>
    /// 请求队列
    /// </summary>
    Queue<IAssetBundleRequestInMemory> mQueueRequest = new Queue<IAssetBundleRequestInMemory>();    
    /// <summary>
    /// 添加请求
    /// </summary>
    /// <param name="_request">请求</param>
    public void Request(IAssetBundleRequestInMemory _request)
    {        
        mQueueRequest.Enqueue(_request);        
    }
    #endregion

    #region BeginLoad
    /// <summary>
    /// 加载状态
    /// </summary>
    enum enLoadState
    {
        Wait,
        Dependencies,
        AssetBundle,
        Ready
    }
    /// <summary>
    /// 加载状态
    /// </summary>
    enLoadState mLoadState = enLoadState.Wait;
    /// <summary>
    /// 资源
    /// </summary>
    AssetBundle mAssetBundle = null;
    /// <summary>
    /// 依赖项
    /// </summary>
    AssetBundleMonoBehaviour[] mDependencies = null;
    /// <summary>
    /// 开始加载
    /// </summary>
    public void BeginLoad()
    {
        if (mLoadState == enLoadState.Wait)
        {
            mLoadState = enLoadState.Dependencies;
            mDependencies = OnRequestLoadDependencies(this);
            OnAddOrRemoveDependenciesEvent(mDependencies, true);
            D_OnLoadAssetBundleComplete(this);
        }
        else
        {
            OnExecuteQueueRequest();
        }
    }

    void D_OnLoadAssetBundleComplete(AssetBundleMonoBehaviour _mono)
    {
        bool isLoadAllDependencies = true;
        if (mDependencies != null && mDependencies.Length > 0)
        {
            float temP = 0;
            foreach (AssetBundleMonoBehaviour d in mDependencies)
            {
                temP += d.progress;
                isLoadAllDependencies &= d.isDone;
            }
            progress = temP / (mDependencies.Length + 1);
            foreach (IAssetBundleRequestInMemory q in mQueueRequest)
            {
                q.progressEvent?.Invoke(progress, q.input);
            }
        }
        if (isLoadAllDependencies && mLoadState == enLoadState.Dependencies)
        {
            if (fileParameter.isInternal)
            {
                mLoadState = enLoadState.Ready;
                OnExecuteQueueRequest();
            }
            else
            {
                mLoadState = enLoadState.AssetBundle;
                AssetBundleCreateRequest requestAssetBundle = AssetBundle.LoadFromFileAsync(fileParameter.assetBundlePath);
                requestAssetBundle.completed += RequestAssetBundle_completed;
            }
        }
    }

    /// <summary>
    /// 加载AssetBundle
    /// </summary>
    /// <param name="_request">AssetBundleCreateRequest</param>
    void RequestAssetBundle_completed(AsyncOperation _request)
    {
        AssetBundleCreateRequest req = (AssetBundleCreateRequest)_request;
        mAssetBundle = req.assetBundle;
        progress = 1;
        isDone = true;
        mLoadState = enLoadState.Ready;
        foreach (IAssetBundleRequestInMemory q in mQueueRequest)
        {
            q.progressEvent?.Invoke(progress, q.input);
        }
        OnLoadAssetBundleComplete?.Invoke(this);
        OnExecuteQueueRequest();
    }

    /// <summary>
    /// 添加或移除依赖项事件
    /// </summary>
    /// <param name="_deps">依赖项</param>
    /// <param name="_isAdd">是否添加事件</param>
    void OnAddOrRemoveDependenciesEvent(AssetBundleMonoBehaviour[] _deps,bool _isAdd)
    {
        if (_deps != null && _deps.Length > 0)
        {
            foreach (AssetBundleMonoBehaviour d in _deps)
            {
                if (_isAdd)
                {
                    d.OnLoadAssetBundleComplete += D_OnLoadAssetBundleComplete;
                }
                else
                {
                    d.OnLoadAssetBundleComplete -= D_OnLoadAssetBundleComplete;
                }
            }
        }
    }
    #endregion

    #region OnExecuteQueueRequest
    /// <summary>
    /// 是否在执行队列
    /// </summary>
    bool mIsExecuteQueue = false;
    /// <summary>
    /// 资源结果组件
    /// </summary>
    Dictionary<int, AssetBundleOutputMonoBehaviour> mAssetBundleResultMonoBehaviour = new Dictionary<int, AssetBundleOutputMonoBehaviour>();
    /// <summary>
    /// 执行请求队列
    /// </summary>
    void OnExecuteQueueRequest()
    {
        if (mAssetBundle != null && mLoadState == enLoadState.Ready)
        {
            if (!mIsExecuteQueue)
            {
                mIsExecuteQueue = true;
                while (mQueueRequest.Count > 0)
                {
                    IAssetBundleRequestInMemory req = mQueueRequest.Dequeue();
                    if (!mAssetBundleResultMonoBehaviour.ContainsKey(req.input.uniqueId))
                    {
                        GameObject go = new GameObject(req.input.config.fileName);
                        go.hideFlags = hideFlags;
                        go.transform.SetParent(transform);
                        AssetBundleOutputMonoBehaviour mono = go.AddComponent<AssetBundleOutputMonoBehaviour>();
                        mono.SetParameter(fileParameter,mAssetBundle);
                        mAssetBundleResultMonoBehaviour.Add(req.input.uniqueId, mono);
                    }
                    AssetBundleOutput output = new AssetBundleOutput(req.input);
                    output.OnInstantiate += Output_OnInstantiate;
                    req.outputEvent?.Invoke(output);
                }
                mIsExecuteQueue = false;
            }
        }
    }

    /// <summary>
    /// 资源输出请求实例化事件句柄
    /// </summary>
    /// <param name="_defaultSelfActive">默认激活状态</param>
    /// <param name="_input">输入</param>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    /// <param name="_type">资源类型</param>
    void Output_OnInstantiate(bool _defaultSelfActive, IAssetBundleInput _input, AssetBundleInstantiateEventHandler _callback, object[] _extraParameter,Type _type)
    {
        if (mAssetBundleResultMonoBehaviour.ContainsKey(_input.uniqueId))
        {
            mAssetBundleResultMonoBehaviour[_input.uniqueId].RequestInstantiate(_defaultSelfActive,_input, _callback,_extraParameter, _type);
        }
    }
    #endregion

    #region OnDispose
    /// <summary>
    /// 销毁
    /// </summary>
    protected override void OnDispose()
    {
        isDone = false;
        mIsExecuteQueue = false;
        progress = 0;
        mQueueRequest.Clear();
        OnAddOrRemoveDependenciesEvent(mDependencies, false);
        foreach (AssetBundleOutputMonoBehaviour m in mAssetBundleResultMonoBehaviour.Values)
        {
            m.Dispose();
        }
        mDependencies = null;
        if (mAssetBundle != null)
        {
            mAssetBundle.Unload(false);
        }
        mAssetBundle = null;
        mLoadState = enLoadState.Wait;
        base.OnDispose();
    }
    #endregion
}
