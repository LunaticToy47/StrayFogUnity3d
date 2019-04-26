using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// XLS关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogXLSLevel")]
public class StrayFogXLSLevel : AbsLevel
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
                List<XLS_Config_Table_TableColumnMaping> tables = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_TableColumnMaping>();
                Debug.Log(tables);
            });            
        });
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventAggregatorManager.DrawLevelSelectButtonOnGUI();
    }
}