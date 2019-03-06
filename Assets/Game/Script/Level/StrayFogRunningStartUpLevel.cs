using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏运行时启动关卡
/// </summary>
[AddComponentMenu("Game/Level/StrayFogRunningStartUpLevel")]
public class StrayFogRunningStartUpLevel : AbsMonoBehaviour
{
    /// <summary>
    /// 错误信息
    /// </summary>
    string mError;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.sceneManager.LoadScene(enAssetDiskMapingFile.f_ExampleGuide_unity,
                enAssetDiskMapingFolder.Assets_Game_AssetBundles_Scene);
        });
    }


    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        Debug.LogError("StrayFogRunningStartUpLevel=>SQLite");
        GUILayout.Label(StrayFogGamePools.setting.JsonSerialize());
        GUILayout.Label(mError);
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }
}
