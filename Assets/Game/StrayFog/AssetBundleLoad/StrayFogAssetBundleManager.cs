using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 资源管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogAssetBundleManager")]
public sealed partial class StrayFogAssetBundleManager : AbsSingleMonoBehaviour
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
        if (!StrayFogGamePools.setting.isInternal)
        {
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
            else
            {
                Debug.LogError("Can not find 【AssetBundleManifest】=>" + StrayFogGamePools.setting.manifestPath);
            }
        }
        #endregion
        OnCollectAssetDiskMaping();
        base.OnAfterConstructor();
    }
    #endregion

    #region OnCollectAssetDiskMaping 收集磁盘映射
    /// <summary>
    /// 磁盘数据映射
    /// </summary>
    Dictionary<int, Dictionary<int, XLS_Config_View_AssetDiskMaping>> mXLS_Config_View_AssetDiskMaping = new Dictionary<int, Dictionary<int, XLS_Config_View_AssetDiskMaping>>();
    /// <summary>
    /// XLS到Manifest数据映射
    /// </summary>
    Dictionary<int, Dictionary<int, int>> mXLSToManifestMaping = new Dictionary<int, Dictionary<int, int>>();
    /// <summary>
    /// AssetBundlePathParameter映射
    /// </summary>
    Dictionary<int, IAssetBundleFileParameter> mAssetBundlePathParameterMaping = new Dictionary<int, IAssetBundleFileParameter>();


    /// <summary>
    /// 收集磁盘映射
    /// </summary>
    void OnCollectAssetDiskMaping()
    {
#if UNITY_EDITOR
        string editorABPN = typeof(IAssetBundleFileParameter).Name;
        string editorManifestN = typeof(AssetBundleManifest).Name;
        string editorXLSN = typeof(XLS_Config_View_AssetDiskMaping).Name;
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        watch.Start();
#endif
        if (mAssetBundleManifest != null)
        {
            string[] names = mAssetBundleManifest.GetAllAssetBundles();
            if (names != null && names.Length > 0)
            {
                foreach (string n in names)
                {
                    IAssetBundleFileParameter abmp = new AssetBundleFileParameter(n);
                    if (!mAssetBundlePathParameterMaping.ContainsKey(abmp.assetBundleId))
                    {
                        mAssetBundlePathParameterMaping.Add(abmp.assetBundleId, abmp);
                    }
                }
            }
#if UNITY_EDITOR
            watch.Stop();
            Debug.LogFormat("Collection {0} from 【Manifest =>{1}】,Time:{2}", editorABPN, mAssetBundlePathParameterMaping.Count, watch.Elapsed);
            watch.Reset();
#endif
        }

#if UNITY_EDITOR
        int beforeCollectXlsConfigABMPC = mAssetBundlePathParameterMaping.Count;
        watch.Start();
#endif
        IAssetBundleFileParameter tempAbp = null;
        mXLS_Config_View_AssetDiskMaping.Clear();
        List<XLS_Config_View_AssetDiskMaping> mapings = StrayFogSQLiteEntityHelper.Select<XLS_Config_View_AssetDiskMaping>();
        if (mapings.Count > 0)
        {
            foreach (XLS_Config_View_AssetDiskMaping v in mapings)
            {
                if (!mXLS_Config_View_AssetDiskMaping.ContainsKey(v.folderId))
                {
                    mXLS_Config_View_AssetDiskMaping.Add(v.folderId, new Dictionary<int, XLS_Config_View_AssetDiskMaping>());
                }
                if (!mXLS_Config_View_AssetDiskMaping[v.folderId].ContainsKey(v.fileId))
                {
                    mXLS_Config_View_AssetDiskMaping[v.folderId].Add(v.fileId, v);
                }
                if (!mXLSToManifestMaping.ContainsKey(v.folderId))
                {
                    mXLSToManifestMaping.Add(v.folderId, new Dictionary<int, int>());
                }
                if (!mXLSToManifestMaping[v.folderId].ContainsKey(v.fileId))
                {
                    mXLSToManifestMaping[v.folderId].Add(v.fileId, 0);
                }
                if (StrayFogGamePools.setting.isInternal)
                {
                    tempAbp = new AssetBundleFileParameter(v.inAssetPath);
                }
                else
                {
                    tempAbp = new AssetBundleFileParameter(v.outAssetPath);
                }
                if (!mAssetBundlePathParameterMaping.ContainsKey(tempAbp.assetBundleId))
                {
                    mAssetBundlePathParameterMaping.Add(tempAbp.assetBundleId, tempAbp);
                }
#if UNITY_EDITOR
                if (mXLSToManifestMaping[v.folderId][v.fileId] != 0 && mXLSToManifestMaping[v.folderId][v.fileId] != tempAbp.assetBundleId)
                {
                    Debug.LogErrorFormat("Asset 【{0}】【{1}_{2}】has the two assetId 【{3}_{4}】【{5}_{6}】",
                        v.inAssetPath, v.folderId, v.fileId,
                        mAssetBundlePathParameterMaping[mXLSToManifestMaping[v.folderId][v.fileId]].assetBundleId, mAssetBundlePathParameterMaping[mXLSToManifestMaping[v.folderId][v.fileId]].assetBundlePath,
                        tempAbp.assetBundleId, tempAbp.assetBundlePath
                        );
                }
#endif
                mXLSToManifestMaping[v.folderId][v.fileId] = tempAbp.assetBundleId;
            }
        }
#if UNITY_EDITOR
        watch.Stop();
        Debug.LogFormat("Collection {0} from 【{1}=> {2}】,Time: {3}",
            editorABPN, editorXLSN, mapings.Count, watch.Elapsed);
        Debug.LogFormat("Collection {0} between {1} and {2} different【{3}】,Time:{4}",
            editorABPN, editorManifestN, editorXLSN, mAssetBundlePathParameterMaping.Count - beforeCollectXlsConfigABMPC, watch.Elapsed);
        watch.Reset();
#endif
    }
    #endregion

    #region OnGetAssetBundleFile 获得资源文件
    /// <summary>
    /// 获得资源文件
    /// </summary>
    /// <param name="_assetId">资源Id</param>
    /// <returns>资源文件参数</returns>
    IAssetBundleFileParameter OnGetAssetBundleFile(int _assetId)
    {
        IAssetBundleFileParameter path = default(IAssetBundleFileParameter);
        if (mAssetBundlePathParameterMaping.ContainsKey(_assetId))
        {
            path = mAssetBundlePathParameterMaping[_assetId];
        }
        return path;
    }
    #endregion    

    #region GetAssetBundleFile 获得资源文件
    /// <summary>
    /// 获得资源文件
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <returns>资源文件参数</returns>
    public IAssetBundleFileParameter GetAssetBundleFile(int _fileId, int _folderId)
    {
        IAssetBundleFileParameter path = default(IAssetBundleFileParameter);
        if (mXLSToManifestMaping.ContainsKey(_folderId)
            && mXLSToManifestMaping[_folderId].ContainsKey(_fileId)
            && mAssetBundlePathParameterMaping.ContainsKey(mXLSToManifestMaping[_folderId][_fileId]))
        {
            path = mAssetBundlePathParameterMaping[mXLSToManifestMaping[_folderId][_fileId]];
        }
        return path;
    }
    #endregion

    #region GetAssetDiskMaping 获得资源磁盘映射
    /// <summary>
    /// 获得资源磁盘映射
    /// </summary>
    /// <param name="_fileId">文件Id</param>
    /// <param name="_folderId">文件夹Id</param>
    /// <returns>资源磁盘映射</returns>
    public XLS_Config_View_AssetDiskMaping GetAssetDiskMaping(int _fileId, int _folderId)
    {
        XLS_Config_View_AssetDiskMaping config = default(XLS_Config_View_AssetDiskMaping);
        if (mXLS_Config_View_AssetDiskMaping.ContainsKey(_folderId)
            && mXLS_Config_View_AssetDiskMaping[_folderId].ContainsKey(_fileId))
        {
            config = mXLS_Config_View_AssetDiskMaping[_folderId][_fileId];
        }
        return config;
    }
    #endregion
}
