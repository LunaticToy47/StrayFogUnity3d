using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源AssetBundle内存组件
/// </summary>
[AddComponentMenu("StrayFog/Game/AssetBundle/AssetBundleMemoryMonoBehaviour")]
[DisallowMultipleComponent()]
public class AssetBundleMemoryMonoBehaviour : AbsMonoBehaviour
{
    /// <summary>
    /// 内存加载进度
    /// </summary>
    public event Action<AssetBundleMemoryMonoBehaviour> OnMemoryLoadProgress;
    /// <summary>
    /// 内存加载完成
    /// </summary>
    public event Action<AssetBundleMemoryMonoBehaviour> OnMemoryLoadComplete;
    /// <summary>
    /// 请求加载依赖项
    /// </summary>
    public event Func<AssetBundleFileParameter, AssetBundleMemoryMonoBehaviour[]> OnRequestLoadDependencies;

    /// <summary>
    /// 资源文件参数
    /// </summary>
    public AssetBundleFileParameter fileParameter { get; private set; }
    /// <summary>
    /// 是否加载完成
    /// </summary>
    public bool isDone { get; private set; }
    /// <summary>
    /// 加载进度
    /// </summary>
    public float progress { get; private set; }
    /// <summary>
    /// 依赖项
    /// </summary>
    AssetBundleMemoryMonoBehaviour[] mDependencies = null;
    /// <summary>
    /// 依赖项加载完成
    /// </summary>
    bool mLoadDependenciesComplete = false;
    /// <summary>
    /// AssetBundle
    /// </summary>
    AssetBundle mAssetBundle = null;
    /// <summary>
    /// 是否已开始加载
    /// </summary>
    bool mIsBeginLoad = false;

    #region SetParameter 设置参数
    /// <summary>
    /// 设置参数
    /// </summary>
    /// <param name="_fileParameter">资源文件参数</param>
    public void SetParameter(AssetBundleFileParameter _fileParameter)
    {
        fileParameter = _fileParameter;
    }
    #endregion

    #region BeginLoad 开始加载
    /// <summary>
    /// 开始加载
    /// </summary>
    public void BeginLoad()
    {
        if (!mIsBeginLoad)
        {
            mIsBeginLoad = true;
            mDependencies = OnRequestLoadDependencies(fileParameter);
            mLoadDependenciesComplete = fileParameter.isInternal || mDependencies == null || mDependencies.Length <= 0;
            if (mLoadDependenciesComplete)
            {
                M_OnMemoryLoadComplete(this);
            }
            else
            {
                foreach (AssetBundleMemoryMonoBehaviour m in mDependencies)
                {
                    m.OnMemoryLoadComplete += M_OnMemoryLoadComplete;
                }
            }
        }        
    }
    /// <summary>
    /// 内存加载完成
    /// </summary>
    /// <param name="_mono">内存项</param>
    void M_OnMemoryLoadComplete(AssetBundleMemoryMonoBehaviour _mono)
    {
        if (mDependencies != null && mDependencies.Length > 0)
        {
            float temP = 0;
            foreach (AssetBundleMemoryMonoBehaviour m in mDependencies)
            {
                temP += m.progress;
            }            
            if (temP >= mDependencies.Length)
            {
                mLoadDependenciesComplete = true;
                progress = temP / (mDependencies.Length + 1);                
            }
            OnMemoryLoadProgress?.Invoke(this);
        }
        if (mLoadDependenciesComplete)
        {
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(fileParameter.assetPath);
            request.completed += Request_completed;
        }
    }

    /// <summary>
    /// 资源加载完成
    /// </summary>
    /// <param name="obj">异步</param>
    void Request_completed(AsyncOperation obj)
    {
        AssetBundleCreateRequest request = (AssetBundleCreateRequest)obj;
        mAssetBundle = request.assetBundle;
        progress = 1;
        isDone = true;
        OnCallMemoryLoadComplete();
    }
    #endregion

    #region AddRequest 添加请求
    /// <summary>
    /// 结果组件
    /// </summary>
    Dictionary<int, AssetBundleResultMonoBehaviour> mResultMonoMaping = new Dictionary<int, AssetBundleResultMonoBehaviour>();
    /// <summary>
    /// 添加请求
    /// </summary>
    /// <param name="_input">输入参数</param>
    /// <param name="_output">输出参数</param>
    public void AddRequest(IAssetBundleInputParameter _input, IAssetBundleOutputParameter _output)
    {
        if (!mResultMonoMaping.ContainsKey(_input.uniqueId))
        {
            GameObject go = new GameObject(_input.config.fileName);
            go.hideFlags = hideFlags;
            go.transform.SetParent(transform);
            AssetBundleResultMonoBehaviour mono = go.AddComponent<AssetBundleResultMonoBehaviour>();
            mono.SetInputParameter(this,_input);
            mResultMonoMaping.Add(_input.uniqueId, mono);
        }
        mResultMonoMaping[_input.uniqueId].AddRequest(_output);
        OnCallMemoryLoadComplete();
    }

    /// <summary>
    /// 调用内存加载完成
    /// </summary>
    void OnCallMemoryLoadComplete()
    {
        if (isDone)
        {
            OnMemoryLoadProgress?.Invoke(this);
            OnMemoryLoadComplete?.Invoke(this);
        }        
    }
    #endregion

    #region CreateResult
    /// <summary>
    /// 创建结果接口
    /// </summary>
    /// <param name="_input">输入参数</param>
    /// <returns>结果接口</returns>
    public IAssetBundleResult CreateResult(IAssetBundleInputParameter _input)
    {
        return default(IAssetBundleResult);
    }
    #endregion

    #region OnDispose
    /// <summary>
    /// OnDispose
    /// </summary>
    protected override void OnDispose()
    {
        isDone = false;
        progress = 0;
        mDependencies = null;
        mLoadDependenciesComplete = false;
        mAssetBundle.Unload(false);
        mAssetBundle = null;
        mIsBeginLoad = false;
    }
    #endregion
}
