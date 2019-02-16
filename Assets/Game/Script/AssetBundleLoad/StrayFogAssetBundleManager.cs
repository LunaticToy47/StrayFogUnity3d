using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 资源结果回调句柄
/// </summary>
/// <param name="_result">结果</param>
public delegate void AssetResultCallbackEventHandle(AssetBundleResult _result);
/// <summary>
/// 资源加载进度回调句柄
/// </summary>
/// <param name="_args">参数</param>
/// <param name="_progress">进度</param>
public delegate void AssetProgressCallbackEventHandle(XLS_Config_View_AssetDiskMaping _args, float _progress);
/// <summary>
/// 资源错误进度回调句柄
/// </summary>
/// <param name="_args">参数</param>
/// <param name="_error">错误信息</param>
public delegate void AssetErrorCallbackEventHandle(XLS_Config_View_AssetDiskMaping _args, string  _error);
/// <summary>
/// 资源管理器
/// </summary>
public sealed class StrayFogAssetBundleManager : AbsSingleMonoBehaviour
{
    #region OnAfterConstructor
    /// <summary>
    /// 映射表
    /// </summary>
    AssetBundleManifest mAssetBundleManifest;
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        #region 加载AssetBundleManifest
        if (File.Exists(StrayFogGamePools.setting.manifestPath))
        {
            AssetBundle ab = AssetBundle.LoadFromFile(StrayFogGamePools.setting.manifestPath);
            if (ab != null)
            {
                mAssetBundleManifest = ab.LoadAsset<AssetBundleManifest>(typeof(AssetBundleManifest).Name);
                ab.Unload(false);
                ab = null;
            }
        }
        else if (!StrayFogGamePools.setting.isInternal)
        {
            Debug.LogError("Can not find 【AssetBundleManifest】=>" + StrayFogGamePools.setting.manifestPath);
        }
        #endregion
        base.OnAfterConstructor();
    }
    #endregion

    #region OnGetAssetDiskMaping 获得磁盘映射数据
    /// <summary>
    /// 获得磁盘映射数据
    /// </summary>
    static Dictionary<int, Dictionary<int, XLS_Config_View_AssetDiskMaping>> msAssetDiskMaping = new Dictionary<int, Dictionary<int, XLS_Config_View_AssetDiskMaping>>();
    /// <summary>
    /// 获得指定磁盘映射
    /// </summary>
    /// <param name="_fileId">文件id</param>
    /// <param name="_folderId">文件夹id</param>
    XLS_Config_View_AssetDiskMaping OnGetAssetDiskMaping(int _fileId, int _folderId)
    {
        XLS_Config_View_AssetDiskMaping result = null;
        if (msAssetDiskMaping.Count <= 0)
        {
            List<XLS_Config_View_AssetDiskMaping> mapings = StrayFogSQLiteEntityHelper.Select<XLS_Config_View_AssetDiskMaping>();
            if (mapings.Count > 0)
            {
                foreach (XLS_Config_View_AssetDiskMaping v in mapings)
                {
                    if (!msAssetDiskMaping.ContainsKey(v.folderId))
                    {
                        msAssetDiskMaping.Add(v.folderId, new Dictionary<int, XLS_Config_View_AssetDiskMaping>());
                    }
                    if (!msAssetDiskMaping[v.folderId].ContainsKey(v.fileId))
                    {
                        msAssetDiskMaping[v.folderId].Add(v.fileId, v);
                    }
                }
            }
        }
        if (msAssetDiskMaping.ContainsKey(_folderId) && msAssetDiskMaping[_folderId].ContainsKey(_fileId))
        {
            result = msAssetDiskMaping[_folderId][_fileId];
        }
        return result;
    }
    #endregion

    #region OnGetKey 获得Key
    /// <summary>
    /// 获得Key
    /// </summary>
    /// <param name="_assetBundleName">资源名称</param>
    /// <param name="_assetId">资源id</param>
    /// <param name="_assetPath">资源路径</param>
    void OnGetKey(string _assetBundleName, out int _assetId, out string _assetPath)
    {
        _assetId = _assetBundleName.UniqueHashCode();
        _assetPath = Path.Combine(StrayFogGamePools.setting.assetBundleRoot, _assetBundleName).TransPathSeparatorCharToUnityChar();
    }
    #endregion

    #region OnCreateLoaderMonoBehaviour 创建加载组件
    /// <summary>
    /// 加载组件映射
    /// </summary>
    static Dictionary<int, AssetBundleLoaderMonoBehaviour> mLoaderMaping = new Dictionary<int, AssetBundleLoaderMonoBehaviour>();
    /// <summary>
    /// 创建加载组件
    /// </summary>
    /// <param name="_assetBundleName">资源名称</param>
    /// <returns>加载组件</returns>
    AssetBundleLoaderMonoBehaviour OnCreateLoaderMonoBehaviour(string _assetBundleName)
    {
        int key = 0;
        string path = string.Empty;
        OnGetKey(_assetBundleName, out key, out path);
        if (!mLoaderMaping.ContainsKey(key))
        {
            GameObject go = new GameObject(_assetBundleName);
            go.hideFlags = hideFlags;
            go.transform.SetParent(transform);
            mLoaderMaping.Add(key, go.AddComponent<AssetBundleLoaderMonoBehaviour>());
            mLoaderMaping[key].SetAssetParameter(key, path, _assetBundleName);
            mLoaderMaping[key].OnLoadingDependencies += StrayFogAssetBundleManager_OnLoadingDependencies;
            mLoaderMaping[key].OnGetLoaderMonoBehaviour += StrayFogAssetBundleManager_OnGetLoaderMonoBehaviour;
        }
        return mLoaderMaping[key];
    }
    #endregion

    #region StrayFogAssetBundleManager_OnGetLoaderMonoBehaviour 获得指定资源id的加载组件
    /// <summary>
    /// 获得指定资源id的加载组件
    /// </summary>
    /// <param name="_assetId">资源id</param>
    /// <returns>加载组件</returns>
    AssetBundleLoaderMonoBehaviour StrayFogAssetBundleManager_OnGetLoaderMonoBehaviour(int _assetId)
    {
        return mLoaderMaping[_assetId];
    }
    #endregion

    #region StrayFogAssetBundleManager_OnLoadingDependencies 加载依赖项
    /// <summary>
    /// 加载依赖项
    /// </summary>
    /// <param name="_loader">加载项</param>
    /// <returns>依赖项id组</returns>
    int[] StrayFogAssetBundleManager_OnLoadingDependencies(AssetBundleLoaderMonoBehaviour _loader)
    {
        List<int> ids = new List<int>();
        string[] deps = mAssetBundleManifest.GetDirectDependencies(_loader.assetBundleName);
        if (deps != null && deps.Length > 0)
        {
            foreach (string d in deps)
            {
                AssetBundleLoaderMonoBehaviour loader = OnCreateLoaderMonoBehaviour(d);
                if (!ids.Contains(loader.assetId))
                {
                    loader.BeginLoad(new AssetBundleLoaderParameter(null, null, null, null, null));
                    ids.Add(loader.assetId);
                }
            }
        }
        return ids.ToArray();
    }
    #endregion

    #region LoadAssetInMemory 加载资源到内存
    #region Enum
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_file">文件</param>
    /// <param name="_folder">文件夹</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void LoadAssetInMemory(Enum _file, Enum _folder,
            AssetResultCallbackEventHandle _onResultCallback,
            params object[] _extraParameter)
    {
        LoadAssetInMemory(_file, _folder, _onResultCallback, (args, progress) => { }, _extraParameter);
    }

    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_file">文件</param>
    /// <param name="_folder">文件夹</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void LoadAssetInMemory(Enum _file, Enum _folder,
            AssetResultCallbackEventHandle _onResultCallback,
            AssetProgressCallbackEventHandle _onProgressCallback,
            params object[] _extraParameter)
    {
        LoadAssetInMemory(_file, _folder, _onResultCallback, _onProgressCallback, (args, error) => { Debug.LogError(error); }, _extraParameter);
    }
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_file">文件</param>
    /// <param name="_folder">文件夹</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_onErrorCallback">错误回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void LoadAssetInMemory(Enum _file, Enum _folder,
            AssetResultCallbackEventHandle _onResultCallback,
            AssetProgressCallbackEventHandle _onProgressCallback,
            AssetErrorCallbackEventHandle _onErrorCallback,
            params object[] _extraParameter)
    {
        LoadAssetInMemory(Convert.ToInt32(_file), Convert.ToInt32(_folder), _onResultCallback, _onProgressCallback, _onErrorCallback, _extraParameter);
    }
    #endregion

    #region Int
    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void LoadAssetInMemory(int _fileId, int _folderId,
            AssetResultCallbackEventHandle _onResultCallback,
            params object[] _extraParameter)
    {
        LoadAssetInMemory(_fileId, _folderId, _onResultCallback, (args, progress) => { }, _extraParameter);
    }

    /// <summary>
    /// 加载资源到内存
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void LoadAssetInMemory(int _fileId, int _folderId,
            AssetResultCallbackEventHandle _onResultCallback,
            AssetProgressCallbackEventHandle _onProgressCallback,
            params object[] _extraParameter)
    {
        LoadAssetInMemory(_fileId, _folderId, _onResultCallback, _onProgressCallback, (args, error) => { Debug.LogError(error); }, _extraParameter);
    }
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
            AssetResultCallbackEventHandle _onResultCallback,
            AssetProgressCallbackEventHandle _onProgressCallback,
            AssetErrorCallbackEventHandle _onErrorCallback,
            params object[] _extraParameter)
    {
        if (_onResultCallback == null)
        {
            throw new UnityException("The parameter '_onCallback' is not empty.");
        }
        XLS_Config_View_AssetDiskMaping adm = OnGetAssetDiskMaping(_fileId, _folderId);
        if (adm != null)
        {
            AssetBundleLoaderParameter ablp = new AssetBundleLoaderParameter(adm, _onResultCallback, _onProgressCallback, _onErrorCallback, _extraParameter);
            OnCreateLoaderMonoBehaviour(adm.outAssetPath).BeginLoad(ablp);
        }
        else
        {
            _onErrorCallback(adm, string.Format("Can't find maping 【file:{0}】【folder:{1}】", _fileId, _folderId));
        }
    }
    #endregion
    #endregion

    #region GetAssetPath 获得资源路径
    /// <summary>
    /// 获得资源路径
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <returns>资源路径</returns>
    public string GetAssetPath(int _fileId, int _folderId)
    {
        XLS_Config_View_AssetDiskMaping adm = OnGetAssetDiskMaping(_fileId, _folderId);
        int key = 0;
        string path = string.Empty;
        OnGetKey(adm.outAssetPath, out key, out path);
        return path;
    }

    /// <summary>
    /// 获得资源路径
    /// </summary>
    /// <param name="_file">文件</param>
    /// <param name="_folder">文件夹</param>
    /// <returns>资源路径</returns>
    public string GetAssetPath(Enum _file, Enum _folder)
    {
        return GetAssetPath(Convert.ToInt32(_file), Convert.ToInt32(_folder));
    }
    #endregion
}
