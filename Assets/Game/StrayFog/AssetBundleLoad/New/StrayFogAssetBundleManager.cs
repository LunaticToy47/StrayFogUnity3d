using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 资源管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogAssetBundleManager")]
public sealed partial class StrayFogNewAssetBundleManager : AbsSingleMonoBehaviour
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
    /// AssetBundleManifestParameter映射
    /// </summary>
    Dictionary<int, AssetBundleParameter> mAssetBundleManifestParameterMaping = new Dictionary<int, AssetBundleParameter>();


    /// <summary>
    /// 收集磁盘映射
    /// </summary>
    void OnCollectAssetDiskMaping()
    {
#if UNITY_EDITOR
        string editorABPN = typeof(AssetBundleParameter).Name;
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
                    AssetBundleParameter abmp = new AssetBundleParameter(n);
                    if (!mAssetBundleManifestParameterMaping.ContainsKey(abmp.assetId))
                    {
                        mAssetBundleManifestParameterMaping.Add(abmp.assetId, abmp);
                    }
                }
            }
#if UNITY_EDITOR
            watch.Stop();
            Debug.LogFormat("Collection {0} from 【Manifest =>{1}】,Time:{2}", editorABPN, mAssetBundleManifestParameterMaping.Count, watch.Elapsed);
            watch.Reset();
#endif
        }

#if UNITY_EDITOR
        int beforeCollectXlsConfigABMPC = mAssetBundleManifestParameterMaping.Count;
        watch.Start();
#endif
        AssetBundleParameter tempAbp = null;
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
                    tempAbp = new AssetBundleParameter(v.inAssetPath);
                }
                else
                {
                    tempAbp = new AssetBundleParameter(v.outAssetPath);
                }
                if (!mAssetBundleManifestParameterMaping.ContainsKey(tempAbp.assetId))
                {
                    mAssetBundleManifestParameterMaping.Add(tempAbp.assetId, tempAbp);
                }
#if UNITY_EDITOR
                if (mXLSToManifestMaping[v.folderId][v.fileId] != 0 && mXLSToManifestMaping[v.folderId][v.fileId] != tempAbp.assetId)
                {
                    Debug.LogErrorFormat("Asset 【{0}】【{1}_{2}】has the two assetId 【{3}_{4}】【{5}_{6}】",
                        v.inAssetPath,v.folderId,v.fileId,
                        mAssetBundleManifestParameterMaping[mXLSToManifestMaping[v.folderId][v.fileId]].assetId, mAssetBundleManifestParameterMaping[mXLSToManifestMaping[v.folderId][v.fileId]].assetPath,
                        tempAbp.assetId, tempAbp.assetPath
                        );
                }
#endif
                mXLSToManifestMaping[v.folderId][v.fileId] = tempAbp.assetId;
            }
        }
#if UNITY_EDITOR
        watch.Stop();
        Debug.LogFormat("Collection {0} from 【{1}=> {2}】,Time: {3}",
            editorABPN, editorXLSN, mapings.Count, watch.Elapsed);
        Debug.LogFormat("Collection {0} between {1} and {2} different【{3}】,Time:{4}",
            editorABPN, editorManifestN, editorXLSN, mAssetBundleManifestParameterMaping.Count - beforeCollectXlsConfigABMPC, watch.Elapsed);
        watch.Reset();
#endif
    }
    #endregion
}
