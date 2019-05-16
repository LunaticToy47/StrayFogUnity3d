using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/Example_bx_map_pve_1_Level")]
public class Example_bx_map_pve_1_Level : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                
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
