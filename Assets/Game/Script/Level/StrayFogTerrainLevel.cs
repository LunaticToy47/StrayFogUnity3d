using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// 地形关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogTerrainLevel")]
public class StrayFogTerrainLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                StartCoroutine(LoadTerrain());
            });            
        });
    }

    /// <summary>
    /// 加载角色
    /// </summary>
    /// <returns>异步</returns>
    IEnumerator LoadTerrain()
    {
        yield return new WaitForSeconds(1);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        StrayFogGamePools.assetBundleManager.LoadAssetInMemory(
            enAssetDiskMapingFile.f_Terrain_prefab,
            enAssetDiskMapingFolder.Assets_Game_AssetBundles_Terrain,
            (result) =>
            {
                result.Instantiate<GameObject>((rst, args) =>
                {
                    GameObject terrain = rst;
                    Stopwatch w = (Stopwatch)args[0];
                    w.Stop();
                    UnityEngine.Debug.Log(w.Elapsed + "=>" + terrain.gameObject);
                }, result.extraParameter);

            }, watch);
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }
}
