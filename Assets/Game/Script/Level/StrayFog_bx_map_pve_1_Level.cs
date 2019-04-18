using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFog_bx_map_pve_1_Level")]
public class StrayFog_bx_map_pve_1_Level : AbsLevel
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
    }
}
