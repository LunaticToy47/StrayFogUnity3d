using UnityEngine;
/// <summary>
/// 资源管理器【加载资源到内存】
/// </summary>
public sealed partial class StrayFogNewAssetBundleManager
{
    #region 加载资源到内存 OnLoadAssetInMemory
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
        AssetBundleErrorEventHandler _onErrorCallback,
        params object[] _extraParameter)
    {
        XLS_Config_View_AssetDiskMaping config = OnGetAssetDiskMaping(_folderId, _fileId);
        IAssetBundleLoadPathParameter path = OnGetAssetBundlePath(_folderId, _fileId);
        IAssetBundleInputParameter input = new AssetBundleInputParameter(config, _extraParameter);
        bool isValid = config != null && path != null;
        if (isValid)
        {
            AssetBundleLoadMemoryParameter abop = new AssetBundleLoadMemoryParameter(input, path, _onResultCallback, _onProgressCallback, _onErrorCallback);

        }
        else
        {
            #region 输出错误信息
            string error = string.Empty;
            if (config == null)
            {
                error = string.Format("Can't find XLS_Config_View_AssetDiskMaping for 【folderId:{0}】【fileId:{1}】", _folderId, _fileId);
            }
            else if (path == null)
            {
                error = string.Format("Can't find IAssetBundlePathParameter for 【folderId:{0}】【fileId:{1}】", _folderId, _fileId);
            }
#if UNITY_EDITOR
            Debug.LogError(error);
#endif
            _onErrorCallback?.Invoke(error, input);
            #endregion
        }
    }
    #endregion
}
