using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏运行时启动关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleRunningStartUpLevel")]
public class ExampleRunningStartUpLevel : AbsMonoBehaviour
{
    /// <summary>
    /// 错误信息
    /// </summary>
    string mError;

    /// <summary>
    /// OnAwake
    /// </summary>
    protected override void OnAwake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                StrayFogGamePools.sceneManager.LoadScene(enAssetDiskMapingFile.f_ExampleGuide_unity,
                enAssetDiskMapingFolder.Assets_Example_AssetBundles_Scene);
            });
        });
    }


    /// <summary>
    /// OnGUI
    /// </summary>
    protected override void OnGUI()
    {
        Debug.LogError("StrayFogRunningStartUpLevel=>SQLite");
        GUILayout.Label(StrayFogGamePools.setting.JsonSerialize());
        GUILayout.Label(mError);
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
    }
}
