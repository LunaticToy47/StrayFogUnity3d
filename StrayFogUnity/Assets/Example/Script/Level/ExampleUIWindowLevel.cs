using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// UI窗口关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleUIWindowLevel")]
public class ExampleUIWindowLevel : AbsLevel
{
    /// <summary>
    /// UIWindow字段信息与说明属性映射
    /// </summary>
    static Dictionary<FieldInfo, AliasTooltipAttribute> mUIWindowFieldAttrMaping = typeof(enUIWindow).GetFieldInfoAttribute<AliasTooltipAttribute>();
    /// <summary>
    /// 按钮可操作窗口
    /// </summary>
    static readonly int[] msrBtnWindows = new int[3] {
        enUIWindow.ExamplePlayerListWindow,
        enUIWindow.ExampleHeroListWindow,
        enUIWindow.ExampleMessageBoxWindow,
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
    /// UIWindow别名属性
    /// </summary>
    Dictionary<int, AliasTooltipAttribute> mUIWindowAliasMaping = new Dictionary<int, AliasTooltipAttribute>();
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        foreach (KeyValuePair<FieldInfo, AliasTooltipAttribute> key in mUIWindowFieldAttrMaping)
        {
            int value = (int)key.Key.GetValue(null);
            mUIWindowAliasMaping.Add(value, key.Value);
        }
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                Time.timeScale = 0;
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
        foreach (int w in msrBtnWindows)
        {
            if (GUILayout.Button(mUIWindowAliasMaping[w].alias))
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
