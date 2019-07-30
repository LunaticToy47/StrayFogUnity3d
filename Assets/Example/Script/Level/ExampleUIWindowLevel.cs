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
    static readonly Enum[] msrBtnWindows = new Enum[3] {
        enUIWindow1389368399.ExamplePlayerListWindow,
        enUIWindow1389368399.ExampleHeroListWindow,
        enUIWindow1389368399.ExampleMessageBoxWindow,
    };
    /// <summary>
    /// 是否自动开启关闭窗口时间
    /// </summary>
    static readonly float mAutoOpenCloseWindowSeconds = 10;
    /// <summary>
    /// 自动开启关闭窗口时间
    /// </summary>
    float mTempAutoOpenCloseWindowSeconds = 0;
    /// <summary>
    /// 是否是自动打开窗口
    /// </summary>
    bool mTempIsAutoOpenWindow = false;
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
        if (GUILayout.Button("Close All Window"))
        {
            StrayFogGamePools.uiWindowManager.CloseWindow(msrBtnWindows);
        }
        if (GUILayout.Button(string.Format("Start Auto OpenClose Window {0} seconds", mAutoOpenCloseWindowSeconds)))
        {
            mTempAutoOpenCloseWindowSeconds = mAutoOpenCloseWindowSeconds;
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
        bool single = StrayFogGamePools.uiWindowManager.IsOpenedWindow(msrBtnWindows[0]);
        bool multiple = StrayFogGamePools.uiWindowManager.IsOpenedWindow(msrBtnWindows);
        if (mTempAutoOpenCloseWindowSeconds > 0)
        {
            mTempAutoOpenCloseWindowSeconds -= deltaTime;
            if (mTempIsAutoOpenWindow)
            {
                StrayFogGamePools.uiWindowManager.OpenWindow(msrBtnWindows);
            }
            else
            {
                StrayFogGamePools.uiWindowManager.CloseWindow(msrBtnWindows);
            }
            mTempIsAutoOpenWindow = !mTempIsAutoOpenWindow;
        }
    }
}
