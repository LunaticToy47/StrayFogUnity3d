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
            IAssetBundleLoadPathParameter path = OnGetAssetBundlePath(_folderId, _fileId);
            IAssetBundleInputParameter input = new AssetBundleInputParameter(config, _extraParameter);
            AssetBundleLoadMemoryParameter abop = new AssetBundleLoadMemoryParameter(input, path, _onResultCallback, _onProgressCallback);

        }
        else
        {
            throw new UnityException(string.Format("Can't find XLS_Config_View_AssetDiskMaping for 【folderId:{0}】【fileId:{1}】", _folderId, _fileId));
        }
    }
    #endregion
}
