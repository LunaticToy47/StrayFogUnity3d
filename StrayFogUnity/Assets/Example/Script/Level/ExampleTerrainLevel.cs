using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// 地形关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleTerrainLevel")]
public class ExampleTerrainLevel : AbsLevel
{
    /// <summary>
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                coroutine.StartCoroutine(LoadTerrain());
            });            
        });
    }

    /// <summary>
    /// 加载角色
    /// </summary>
    /// <returns>异步</returns>
    IEnumerator LoadTerrain()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        StrayFogGamePools.assetBundleManager.LoadAssetInMemory(
            enAssetDiskMapingFile.f_Terrain_prefab,
            enAssetDiskMapingFolder.Assets_Example_AssetBundles_Terrain,
            (output) =>
            {
                output.Instantiate<GameObject>((result) =>
                {
                    GameObject terrain = (GameObject)result.asset;
                    Stopwatch w = (Stopwatch)result.input.extraParameter[0];
                    w.Stop();
                    UnityEngine.Debug.Log(w.Elapsed + "=>" + terrain.gameObject);
                });
            }, watch);
    }

    /// <summary>
    /// OnRunGUI
    /// </summary>
    protected override void OnRunGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
    }
}
