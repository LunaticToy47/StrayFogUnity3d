using UnityEngine;
/// <summary>
/// EventAggregator关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogEventAggregatorLevel")]
public class StrayFogEventAggregatorLevel : AbsLevel
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
