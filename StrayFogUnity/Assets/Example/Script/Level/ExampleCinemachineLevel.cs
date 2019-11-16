using UnityEngine;
/// <summary>
/// EventAggregator关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleCinemachineLevel")]
public class ExampleCinemachineLevel : AbsLevel
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
