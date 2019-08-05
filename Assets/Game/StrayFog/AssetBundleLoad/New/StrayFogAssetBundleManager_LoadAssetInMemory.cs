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
    public void OnLoadAssetInMemory(int _fileId, int _folderId, params object[] _extraParameter)
    {
        XLS_Config_View_AssetDiskMaping config = OnGetAssetDiskMaping(_folderId, _fileId);
        IAssetBundleInputParameter input = new AssetBundleInputParameter(config, _extraParameter);
        IAssetBundleLoadPathParameter path = OnGetAssetBundlePath(_folderId, _fileId);
        AssetBundleLoadMemoryParameter abop = new AssetBundleLoadMemoryParameter(input, path);
        if (abop.isValid)
        {

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
            Debug.LogError(error);
            #endregion
        }
    }
    #endregion
}
