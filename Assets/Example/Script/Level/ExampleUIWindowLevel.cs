﻿using System;
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
    static readonly Enum[] msrBtnWindows = new Enum[2] { enUIWindow1389368399.ExamplePlayerListWindow, enUIWindow1389368399.ExampleHeroListWindow };
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
        if (GUILayout.Button("Open All Window"))
        {
            StrayFogGamePools.uiWindowManager.OpenWindow(msrBtnWindows);
        }
        foreach (enUIWindow1389368399 w in msrBtnWindows)
        {
            if (GUILayout.Button(w.ToString()))
            {
                StrayFogGamePools.uiWindowManager.OpenWindow(w);
            }
        }
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        bool single = StrayFogGamePools.uiWindowManager.IsOpenedWindow(enUIWindow1389368399.ExampleHeroListWindow);
        bool multiple = StrayFogGamePools.uiWindowManager.IsOpenedWindow(msrBtnWindows);
    }
}
