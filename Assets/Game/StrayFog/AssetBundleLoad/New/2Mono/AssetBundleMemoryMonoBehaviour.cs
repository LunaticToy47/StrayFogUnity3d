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
    /// 开始加载
    /// </summary>
    /// <param name="_fileParameter">资源文件参数</param>
    public void BeginLoad(AssetBundleFileParameter _fileParameter)
    {
        fileParameter = _fileParameter;
        mDependencies = OnRequestLoadDependencies(_fileParameter);
        if (mDependencies == null || mDependencies.Length <= 0)
        {
            mLoadDependenciesComplete = true;
        }
    }

    /// <summary>
    /// 获得指定的资源内存加载组件
    /// </summary>
    public event Func<int, AssetBundleMemoryMonoBehaviour> OnGetAssetBundleMemoryMonoBehaviour;
    /// <summary>
    /// 请求加载依赖项
    /// </summary>
    public event Func<AssetBundleFileParameter, AssetBundleMemoryMonoBehaviour[]> OnRequestLoadDependencies;
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
            AssetBundleResultMonoBehaviour mono = go.AddComponent<AssetBundleResultMonoBehaviour>();
            mono.SetInputParameter(_input);
        }
        mResultMonoMaping[_input.uniqueId].AddRequest(_output);
    }
}
