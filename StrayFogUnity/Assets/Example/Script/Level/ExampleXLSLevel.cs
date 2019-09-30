using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// XLS关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleXLSLevel")]
public class ExampleXLSLevel : AbsLevel
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
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                List<XLS_Config_Table_AssetDiskMapingFile> tables = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_AssetDiskMapingFile>();
                watch.Stop();
                Debug.Log(tables +" "+ tables.Count +  " " + watch.Elapsed);
            });            
        });
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
    }
}