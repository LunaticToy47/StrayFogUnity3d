using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// UI窗口关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleUIWindowLevel")]
public class ExampleUIWindowLevel : AbsLevel
{
    /// <summary>
    /// 按钮可操作窗口
    /// </summary>
    static readonly enUIWindow1389368399[] msrBtnWindows = new enUIWindow1389368399[2] { enUIWindow1389368399.ExamplePlayerListWindow, enUIWindow1389368399.ExampleHeroListWindow };
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

    void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
        foreach (enUIWindow1389368399 w in msrBtnWindows)
        {
            if (GUILayout.Button(w.ToString()))
            {
                StrayFogGamePools.uiWindowManager.OpenWindow(w);
            }
        }
    }

    /// <summary>
    /// 测试窗口
    /// </summary>
    static readonly Enum[] mTempWins = new Enum[2]
    {
        enUIWindow1389368399.ExampleLobbyWindow,
        enUIWindow1389368399.ExampleHeroListWindow
    };

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        bool single = StrayFogGamePools.uiWindowManager.IsOpenedWindow(enUIWindow1389368399.ExampleHeroListWindow);
        bool multiple = StrayFogGamePools.uiWindowManager.IsOpenedWindow(mTempWins);
    }
}
