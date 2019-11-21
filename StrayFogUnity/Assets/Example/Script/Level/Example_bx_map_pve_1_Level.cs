using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/Example_bx_map_pve_1_Level")]
public class Example_bx_map_pve_1_Level : AbsLevel
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
                
            });
        });
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
