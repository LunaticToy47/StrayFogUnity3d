﻿using System.Collections.Generic;
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
        if (StrayFogSetting.current.isInternal)
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
    /// Instantiate
    /// </summary>
    /// <param name="_assetDiskMaping">磁盘映射</param>
    /// <param name="_type">对象类别</param>
    /// <returns>对象</returns>
    Object OnInstantiate(View_AssetDiskMaping _assetDiskMaping, System.Type _type)
    {
        Object result = null;
        int key = _assetDiskMaping.inAssetPath.GetHashCode();
        if (_assetDiskMaping.extEnumValue != (int)enFileExt.Scene)
        {
            if (!mCacheMemoryMaping.ContainsKey(key))
            {
                Object value = null;
                if (StrayFogSetting.current.isInternal)
                {
                    value = StrayFogApplication.current.LoadAssetAtPath(_assetDiskMaping.inAssetPath, _type);
                }
                else
                {
                    value = mAssetBundle.LoadAsset(_assetDiskMaping.fileName, _type);
                }
                mCacheMemoryMaping.Add(key, value);
            }
            result = mCacheMemoryMaping[key];
            if (result != null)
            {
                bool isMemory = result is Texture || result is Sprite ||
                    _assetDiskMaping.extEnumValue == (int)enFileExt.Asset ||
                    _assetDiskMaping.extEnumValue == (int)enFileExt.TextAsset
                    ;
                if (!isMemory)
                {
                    result = Instantiate(result);
                }
            }
        }
        return result;
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