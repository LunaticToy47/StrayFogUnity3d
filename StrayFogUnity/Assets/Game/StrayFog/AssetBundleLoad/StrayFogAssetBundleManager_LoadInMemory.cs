using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源管理器
/// </summary>
public partial class StrayFogAssetBundleManager
{
    #region LoadAssetInMemory

    #region Enum
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_file">文件</param>
    /// <param name="_folder">文件夹</param>
    /// <param name="_outputEvent">输出事件</param>
    /// <param name="_extraParemeter">额外参数</param>
    public void LoadAssetInMemory(Enum _file, Enum _folder, AssetBundleOutputEventHandler _outputEvent, params object[] _extraParemeter)
    {
        LoadAssetInMemory(_file, _folder, _outputEvent, (p, i) => { }, _extraParemeter);
    }
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_file">文件</param>
    /// <param name="_folder">文件夹</param>
    /// <param name="_outputEvent">输出事件</param>
    /// <param name="_progressEvent">进度事件</param>
    /// <param name="_extraParemeter">额外参数</param>
    public void LoadAssetInMemory(Enum _file, Enum _folder, AssetBundleOutputEventHandler _outputEvent, AssetBundleProgressEventHandler _progressEvent, params object[] _extraParemeter)
    {
        LoadAssetInMemory(Convert.ToInt32(_file), Convert.ToInt32(_folder), _outputEvent, _progressEvent, _extraParemeter);
    }
    #endregion

    #region int
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_outputEvent">输出事件</param>
    /// <param name="_extraParemeter">额外参数</param>
    public void LoadAssetInMemory(int _fileId, int _folderId, AssetBundleOutputEventHandler _outputEvent, params object[] _extraParemeter)
    {
        LoadAssetInMemory(_fileId, _folderId, _outputEvent, (p, i) => { }, _extraParemeter);
    }
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_outputEvent">输出事件</param>
    /// <param name="_progressEvent">进度事件</param>
    /// <param name="_extraParemeter">额外参数</param>
    public void LoadAssetInMemory(int _fileId, int _folderId, AssetBundleOutputEventHandler _outputEvent, AssetBundleProgressEventHandler _progressEvent, params object[] _extraParemeter)
    {
        OnLoadAssetInMemory(_fileId, _folderId, _outputEvent, _progressEvent, _extraParemeter);
    }
    #endregion

    #endregion

    #region OnLoadAssetInMemory 加载资源到内存
    /// <summary>
    /// 资源组件映射
    /// </summary>
    Dictionary<int, AssetBundleMonoBehaviour> mAssetBundleMonoBehaviourMaping = new Dictionary<int, AssetBundleMonoBehaviour>();
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_outputEvent">输出</param>
    /// <param name="_progressEvent">进度</param>
    /// <param name="_extraParemeter">额外参数</param>
    void OnLoadAssetInMemory(int _fileId, int _folderId, 
        AssetBundleOutputEventHandler _outputEvent, AssetBundleProgressEventHandler _progressEvent, 
        params object[] _extraParemeter)
    {
        XLS_Config_View_AssetDiskMaping config = GetAssetDiskMaping(_fileId, _folderId);
        if (config != null)
        {
            IAssetBundleFileParameter file = GetAssetBundleFile(_fileId, _folderId);
            AssetBundleMonoBehaviour mono = OnCreateMono(file);
            IAssetBundleInput input = new AssetBundleInput(config, _extraParemeter);
            IAssetBundleRequestInMemory request = new AssetBundleRequestInMemory(input,_outputEvent,_progressEvent);
            mono.Request(request);
            mono.BeginLoad();
        }
        else
        {
            throw new UnityException(string.Format("Can't find XLS_Config_View_AssetDiskMaping for 【folderId:{0}】【fileId:{1}】", _folderId, _fileId));
        }
    }

    /// <summary>
    /// 请求加载依赖项
    /// </summary>
    /// <param name="_request">请求资源</param>
    /// <returns>依赖资源</returns>
    AssetBundleMonoBehaviour[] Mono_OnRequestLoadDependencies(AssetBundleMonoBehaviour _request)
    {
        AssetBundleMonoBehaviour[] result = null;
        if (!_request.fileParameter.isInternal)
        {
            string[] deps = mAssetBundleManifest.GetDirectDependencies(_request.fileParameter.assetBundleName);
            if (deps != null && deps.Length > 0)
            {
                result = new AssetBundleMonoBehaviour[deps.Length];
                for (int i = 0; i < deps.Length; i++)
                {
                    IAssetBundleFileParameter file = OnGetAssetBundleFile(deps[i].UniqueHashCode());
                    result[i] = OnCreateMono(file);
                    result[i].BeginLoad();
                }
            }
        }
        return result;
    }

    /// <summary>
    /// 创建组件
    /// </summary>
    /// <param name="_fileParameter">文件参数</param>
    /// <returns>组件</returns>
    AssetBundleMonoBehaviour OnCreateMono(IAssetBundleFileParameter _fileParameter)
    {
        if (!mAssetBundleMonoBehaviourMaping.ContainsKey(_fileParameter.assetBundleId))
        {
            GameObject go = new GameObject(_fileParameter.assetBundleName);
            go.hideFlags = gameObject.hideFlags;
            go.transform.SetParent(gameObject.transform);
            AssetBundleMonoBehaviour mono = go.AddDynamicComponent<AssetBundleMonoBehaviour>();
            mono.OnRequestLoadDependencies += Mono_OnRequestLoadDependencies;
            mono.SetParameter(_fileParameter);
            mAssetBundleMonoBehaviourMaping.Add(_fileParameter.assetBundleId, mono);
        }
        return mAssetBundleMonoBehaviourMaping[_fileParameter.assetBundleId];
    }
    #endregion
}
