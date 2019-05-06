using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
/// <summary>
/// EntityComponentSystem关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogEntityComponentSystemLevel")]
public class StrayFogEntityComponentSystemLevel : AbsLevel
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
