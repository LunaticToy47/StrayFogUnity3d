using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 资源加载组件
/// </summary>
public class AssetBundleLoaderMonoBehaviour : AbsMonoBehaviour
{
    #region enLoaderState 加载状态
    /// <summary>
    /// 加载状态
    /// </summary>
    enum enLoaderState
    {
        /// <summary>
        /// 等待加载
        /// </summary>
        Wait,
        /// <summary>
        /// 加载依赖项中
        /// </summary>
        LoadingDependencies,
        /// <summary>
        /// 加载AssetBundle
        /// </summary>
        LoadingAssetBundle,
        /// <summary>
        /// AssetBundle准备完成
        /// </summary>
        ReadyAssetBundle,
    }
    #endregion

    #region LoadingDependenciesEventHandler 加载依赖项事件句柄
    /// <summary>
    /// 加载依赖项事件句柄
    /// </summary>
    /// <param name="_loader">加载项</param>
    /// <returns></returns>
    public delegate int[] LoadingDependenciesEventHandler(AssetBundleLoaderMonoBehaviour _loader);
    /// <summary>
    /// 加载依赖项事件
    /// </summary>
    public event LoadingDependenciesEventHandler OnLoadingDependencies;
    #endregion

    #region GetLoaderMonoBehaviourEventHandler 获得指定资源id的加载组件
    /// <summary>
    /// 获得指定资源id的加载组件
    /// </summary>
    /// <param name="_assetId">资源id</param>
    /// <returns>加载组件</returns>
    public delegate AssetBundleLoaderMonoBehaviour GetLoaderMonoBehaviourEventHandler(int _assetId);
    /// <summary>
    /// 获得指定资源id的加载组件
    /// </summary>
    public event GetLoaderMonoBehaviourEventHandler OnGetLoaderMonoBehaviour;
    #endregion

    #region isDone 是否完成
    /// <summary>
    /// 是否完成
    /// </summary>
    public bool isDone { get { return mLoaderState == enLoaderState.ReadyAssetBundle; } }
    #endregion

    #region progress 进度
    /// <summary>
    /// 进度
    /// </summary>
    public float progress { get; private set; }
    #endregion

    #region SetAssetParameter 设置资源参数
    /// <summary>
    /// 资源id
    /// </summary>
    public int assetId { get; private set; }
    /// <summary>
    /// 资源路径
    /// </summary>
    public string assetPath { get; private set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string assetBundleName { get; private set; }
    /// <summary>
    /// 设置资源参数
    /// </summary>
    /// <param name="_assetId">资源id</param>
    /// <param name="_assetPath">资源路径</param>
    /// <param name="_assetBundleName">资源名称</param>
    public void SetAssetParameter(int _assetId, string _assetPath, string _assetBundleName)
    {
        assetId = _assetId;
        assetPath = _assetPath;
        assetBundleName = _assetBundleName;
    }
    #endregion

    #region BeginLoad 开始加载
    /// <summary>
    /// 资源项
    /// </summary>
    AssetBundle mAssetBundle = null;
    /// <summary>
    /// 资源异步
    /// </summary>
    AssetBundleCreateRequest mAssetBundleCreateRequest = null;
    /// <summary>
    /// 等待
    /// </summary>
    enLoaderState mLoaderState = enLoaderState.Wait;
    /// <summary>
    /// 参数队列
    /// </summary>
    Queue<AssetBundleLoaderParameter> mQueueLoad = new Queue<AssetBundleLoaderParameter>();
    /// <summary>
    /// 设置参数
    /// </summary>
    /// <param name="_parameter">加载参数</param>
    public void BeginLoad(AssetBundleLoaderParameter _parameter)
    {
        if (StrayFogGamePools.setting.isInternal)
        {
            #region 内部资源加载
            if (File.Exists(_parameter.assetDiskMaping.inAssetPath))
            {
                AssetBundleResult result = new AssetBundleResult(_parameter.assetDiskMaping, OnInstantiate, _parameter.extraParameter);
                if (_parameter.progressCallback != null)
                {
                    _parameter.progressCallback.Invoke(_parameter.assetDiskMaping, 1);
                }
                if (_parameter.resultCallback != null)
                {
                    _parameter.resultCallback.Invoke(result);
                }
            }
            else
            {
                if (_parameter.errorCallback != null)
                {
                    _parameter.errorCallback.Invoke(_parameter.assetDiskMaping, string.Format("The path asset was not found.【{0}】 ", _parameter.assetDiskMaping.inAssetPath));
                }
            }
            #endregion
        }
        else
        {
            #region 外部资源加载
            if (mLoaderState == enLoaderState.Wait)
            {
                OnBeginLoadingDependencies();
            }
            mQueueLoad.Enqueue(_parameter);
            #endregion
        }
    }
    #endregion

    #region OnInstantiate 获得实体对象
    /// <summary>
    /// 内存缓存映射
    /// </summary>
    Dictionary<int, Object> mCacheMemoryMaping = new Dictionary<int, Object>();
    /// <summary>
    /// 资源与请求映射
    /// </summary>
    Dictionary<int, int> mCacheAssetRequestMaping = new Dictionary<int, int>();
    /// <summary>
    /// 资源请求回调
    /// </summary>
    Dictionary<int, List<object>> mCacheAssetRequestCallback = new Dictionary<int, List<object>>();
    /// <summary>
    /// Instantiate
    /// </summary>
    /// <param name="_assetDiskMaping">磁盘映射</param>    
    /// <param name="_type">对象类别</param>
    /// <param name="_params">额外参数</param>
    /// <param name="_callback">回调</param>
    /// <returns>对象</returns>
    void OnInstantiate(XLS_Config_View_AssetDiskMaping _assetDiskMaping, System.Type _type, object[] _params, 
        System.Action<Object, object[]> _callback)
    {
        Object result = null;
        int key = _assetDiskMaping.inAssetPath.GetHashCode();
        if (_assetDiskMaping.extEnumValue != (int)enFileExt.Scene)
        {
            if (!mCacheMemoryMaping.ContainsKey(key))
            {
                if (StrayFogGamePools.setting.isInternal)
                {
                    result = StrayFogGamePools.runningApplication.LoadAssetAtPath(_assetDiskMaping.inAssetPath, _type);
                    mCacheMemoryMaping.Add(key, result);
                    OnInstantiateCallback(result, _assetDiskMaping, _params, _callback);
                }
                else
                {
                    if (!mCacheAssetRequestCallback.ContainsKey(key))
                    {
                        mCacheAssetRequestCallback.Add(key, new List<object>());
                    }
                    mCacheAssetRequestCallback[key].Add(new object[3] { _assetDiskMaping , _params , _callback });

                    if (!mCacheAssetRequestMaping.ContainsKey(key))
                    {
                        AssetBundleRequest assetRequest = mAssetBundle.LoadAssetAsync(_assetDiskMaping.fileName, _type);
                        int hashCode = assetRequest.GetHashCode();
                        mCacheAssetRequestMaping.Add(key, hashCode);
                        assetRequest.completed += AssetRequest_completed;
                    }
                }
            }
            else
            {
                OnInstantiateCallback(mCacheMemoryMaping[key], _assetDiskMaping, _params, _callback);
            }
        }
        else
        {
            _callback(result, _params);
        }
    }

    /// <summary>
    /// 资源请求
    /// </summary>
    /// <param name="_async">异步</param>
    void AssetRequest_completed(AsyncOperation _async)
    {
        AssetBundleRequest req = (AssetBundleRequest)_async;
        int hashCode = req.GetHashCode();
        int callbackKey = 0;
        foreach (KeyValuePair<int, int> key in mCacheAssetRequestMaping)
        {
            if (key.Value == hashCode)
            {
                callbackKey = key.Key;
                break;
            }
        }
        if (!mCacheMemoryMaping.ContainsKey(callbackKey))
        {
            mCacheMemoryMaping.Add(callbackKey, req.asset);
        }
        foreach (object key in mCacheAssetRequestCallback[callbackKey])
        {
            object[] p = (object[])key;
            OnInstantiateCallback(req.asset,(XLS_Config_View_AssetDiskMaping)p[0],(object[])p[1],(System.Action<Object, object[]>)p[2]);
        }
    }

    /// <summary>
    /// 实例回调
    /// </summary>
    /// <param name="_asset">资源对象</param>
    /// <param name="_assetDiskMaping">磁盘映射</param>
    /// <param name="_params">额外参数</param>
    /// <param name="_callback">回调</param>
    void OnInstantiateCallback(Object _asset, XLS_Config_View_AssetDiskMaping _assetDiskMaping, object[] _params,
        System.Action<Object, object[]> _callback)
    {
        if (_asset != null)
        {
            bool isMemory = _asset is Texture || _asset is Sprite ||
                _assetDiskMaping.extEnumValue == (int)enFileExt.Asset ||
                _assetDiskMaping.extEnumValue == (int)enFileExt.TextAsset;
            if (!isMemory)
            {
                StartCoroutine(OnCallback(_asset, _params, _callback));
            }
            else
            {
                _callback(_asset, _params);
            }
        }
        else
        {
            _callback(_asset, _params);
        }        
    }

    /// <summary>
    /// 回调
    /// </summary>
    /// <param name="_asset">资源对象</param>
    /// <param name="_params">额外参数</param>
    /// <param name="_callback">回调</param>
    IEnumerator OnCallback(Object _asset, object[] _params, System.Action<Object, object[]> _callback)
    {
        yield return new WaitForEndOfFrame();        
        if (_asset is GameObject)
        {
            bool isActive = (bool)_params[2];
            ((GameObject)_asset).SetActive(isActive);
        }
        _asset = Instantiate(_asset);
        _callback(_asset, _params);
    }
    #endregion

    #region OnBeginLoadingDependencies 开始加载依赖项
    /// <summary>
    /// 依赖项
    /// </summary>
    int[] mDependencyIds = null;
    /// <summary>
    /// 开始加载依赖项
    /// </summary>
    void OnBeginLoadingDependencies()
    {
        if (mDependencyIds == null)
        {
            mDependencyIds = OnLoadingDependencies(this);
            mLoaderState = enLoaderState.LoadingDependencies;
        }
    }
    #endregion

    #region OnIsDependenciesLoaded 依赖项是否加载完成
    /// <summary>
    /// 所有依赖项是否加载完成
    /// </summary>
    void OnIsDependenciesLoaded()
    {
        bool isDone = true;
        foreach (int id in mDependencyIds)
        {
            isDone &= OnGetLoaderMonoBehaviour(id).isDone;
        }
        if (isDone)
        {
            if (mAssetBundle == null)
            {
                mAssetBundleCreateRequest = AssetBundle.LoadFromFileAsync(assetPath);
                mLoaderState = enLoaderState.LoadingAssetBundle;
            }
        }
    }
    #endregion

    #region OnWaitReadyAssetBundle 等待AssetBundle准备好
    /// <summary>
    /// 等待AssetBundle准备好
    /// </summary>
    void OnWaitReadyAssetBundle()
    {
        if (mAssetBundleCreateRequest != null)
        {
            progress = mAssetBundleCreateRequest.progress;
            if (mAssetBundleCreateRequest.isDone)
            {
                mAssetBundle = mAssetBundleCreateRequest.assetBundle;
                mAssetBundleCreateRequest = null;
                mLoaderState = enLoaderState.ReadyAssetBundle;
            }
        }
    }
    #endregion

    #region OnReadyAssetBundle AssetBundle已准备好
    /// <summary>
    /// AssetBundle已准备好
    /// </summary>
    void OnReadyAssetBundle()
    {
        while (mQueueLoad.Count > 0)
        {
            AssetBundleLoaderParameter ablp = mQueueLoad.Dequeue();
            if (ablp.resultCallback != null)
            {
                ablp.resultCallback.Invoke(new AssetBundleResult(ablp.assetDiskMaping, OnInstantiate, ablp.extraParameter));
            }
        }
    }
    #endregion
    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        switch (mLoaderState)
        {
            case enLoaderState.LoadingDependencies:
                OnIsDependenciesLoaded();
                break;
            case enLoaderState.LoadingAssetBundle:
                OnWaitReadyAssetBundle();
                break;
            case enLoaderState.ReadyAssetBundle:
                OnReadyAssetBundle();
                break;
        }
    }
}
