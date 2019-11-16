using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/Example_bx_map_pve_1_Level")]
public class Example_bx_map_pve_1_Level : AbsLevel
{
    /// <summary>
    /// OnAwake
    /// </summary>
    protected override void OnAwake()
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
    protected override void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
    }
}
