using UnityEngine;
/// <summary>
/// 资源管理器【加载资源到内存】
/// </summary>
public sealed partial class StrayFogNewAssetBundleManager : AbsSingleMonoBehaviour
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
    public void OnLoadAssetInMemory(int _fileId, int _folderId) {
        Debug.Log(mAssetBundleManifestParameterMaping);
    }
    #endregion
}
