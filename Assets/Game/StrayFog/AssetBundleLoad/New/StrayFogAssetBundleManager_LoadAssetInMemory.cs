using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源管理器【加载资源到内存】
/// </summary>
public partial class StrayFogNewAssetBundleManager
{
    #region 加载资源到内存 LoadAssetInMemory
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_onErrorCallback">错误回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void LoadAssetInMemory(int _fileId, int _folderId,
        AssetBundleResultEventHandler _onResultCallback,
        AssetBundleProgressEventHandler _onProgressCallback,
        params object[] _extraParameter)
    {
        OnLoadAssetInMemory(_fileId, _folderId, _onResultCallback, _onProgressCallback, _extraParameter);
    }
    #endregion

    #region OnLoadAssetInMemory 加载资源到内存
    /// <summary>
    /// 资源内存组件映射
    /// </summary>
    Dictionary<int, AssetBundleMemoryMonoBehaviour> mMemoryMonoMaping = new Dictionary<int, AssetBundleMemoryMonoBehaviour>();
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_onErrorCallback">错误回调</param>
    /// <param name="_extraParameter">额外参数</param>
    void OnLoadAssetInMemory(int _fileId, int _folderId,
    AssetBundleResultEventHandler _onResultCallback,
    AssetBundleProgressEventHandler _onProgressCallback,
    params object[] _extraParameter)
    {
        XLS_Config_View_AssetDiskMaping config = OnGetAssetDiskMaping(_folderId, _fileId);
        if (config != null)
        {
            AssetBundleFileParameter path = OnGetAssetBundleFile(_folderId, _fileId);
            IAssetBundleInputParameter input = new AssetBundleInputParameter(config, _extraParameter);
            IAssetBundleOutputParameter output = new AssetBundleOutputParameter(_onResultCallback, _onProgressCallback);            
            AssetBundleMemoryMonoBehaviour mono = OnCreateMemoryMono(path);
            mono.AddRequest(input,output);
        }
        else
        {
            throw new UnityException(string.Format("Can't find XLS_Config_View_AssetDiskMaping for 【folderId:{0}】【fileId:{1}】", _folderId, _fileId));
        }
    }

    /// <summary>
    /// 创建内存加载组件
    /// </summary>
    /// <param name="_file">路径</param>
    /// <returns>内存加载组件</returns>
    AssetBundleMemoryMonoBehaviour OnCreateMemoryMono(AssetBundleFileParameter _file)
    {
        if (!mMemoryMonoMaping.ContainsKey(_file.assetId))
        {
#if UNITY_EDITOR
            GameObject go = new GameObject(_file.assetPath);
#else
            GameObject go = new GameObject(_file.assetId);
#endif
            AssetBundleMemoryMonoBehaviour mono = go.AddComponent<AssetBundleMemoryMonoBehaviour>();
            mono.OnGetAssetBundleMemoryMonoBehaviour += Mono_OnGetAssetBundleMemoryMonoBehaviour;
            mono.OnRequestLoadDependencies += Mono_OnRequestLoadDependencies;
            mMemoryMonoMaping.Add(_file.assetId, mono);
            mono.BeginLoad(_file);
        }
        return mMemoryMonoMaping[_file.assetId];
    }

    /// <summary>
    /// 请求加载依赖项
    /// </summary>
    /// <param name="_arg">请求资源参数</param>
    /// <returns>依赖项组件</returns>
    AssetBundleMemoryMonoBehaviour[] Mono_OnRequestLoadDependencies(AssetBundleFileParameter _arg)
    {
        AssetBundleMemoryMonoBehaviour[] result = null;
        if (!_arg.isInternal)
        {
            string[] deps = mAssetBundleManifest.GetDirectDependencies(_arg.assetPath);
            if (deps != null && deps.Length > 0)
            {
                result = new AssetBundleMemoryMonoBehaviour[deps.Length];
                for (int i = 0; i < deps.Length; i++)
                {
                    AssetBundleFileParameter file = OnGetAssetBundleFile(deps[i].UniqueHashCode());
                    result[i] = OnCreateMemoryMono(file);
                }
            }
        }
        return result;
    }

    /// <summary>
    /// 获得指定的资源内存加载组件
    /// </summary>
    /// <param name="_assetId">资源Id</param>
    /// <returns>资源内存加载组件</returns>
    AssetBundleMemoryMonoBehaviour Mono_OnGetAssetBundleMemoryMonoBehaviour(int _assetId)
    {
        return mMemoryMonoMaping.ContainsKey(_assetId) ? mMemoryMonoMaping[_assetId] : default(AssetBundleMemoryMonoBehaviour);
    }
    #endregion
}
