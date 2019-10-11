using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 引导关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleGuideLevel")]
public class ExampleGuideLevel : AbsLevel
{
    /// <summary>
    /// 滚动视图
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
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
        if (GUILayout.Button("Start Guid"))
        {
            StartCoroutine(OnOpenLobby());
        }
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
        mScrollViewPosition = GUILayout.BeginScrollView(mScrollViewPosition);
        GUI.skin.label.fontSize = 40;
        GUI.color = Color.black;
        GUILayout.Label(StrayFogGamePools.setting.ToData());
        GUILayout.Label("Dynamic=>CD:" + StrayFogAssembly.dynamicAssemblies.Count + " T:" + Time.time);
        string path = StrayFogGamePools.setting.assetBundleRoot + "/ab_xboxone";
        if (!Directory.Exists(StrayFogGamePools.setting.assetBundleRoot))
        {
            Directory.CreateDirectory(StrayFogGamePools.setting.assetBundleRoot);
        }
        GUILayout.Label(path);
        GUILayout.Label(File.Exists(path).ToString());
        File.WriteAllText(path+".txt", GetType().Module.ToString());
        GUILayout.Label(File.Exists(path).ToString());
        GUILayout.EndScrollView();
    }

    /// <summary>
    /// OpenLobby
    /// </summary>
    /// <returns>异步</returns>
    IEnumerator OnOpenLobby()
    {        
        yield return new WaitForEndOfFrame();
        UnityEngine.Debug.Log("Open=>" + enUIWindow.ExampleLobbyWindow);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        int count = UnityEngine.Random.Range(1, 20);
        for (int i = 0; i < count; i++)
        {
            OnOpenWindows(watch, count, i >= count - 1);
        }
    }

    /// <summary>
    /// OnOpenWindows
    /// </summary>
    /// <param name="_watch">Stopwatch</param>
    /// <param name="_count">数量</param>
    /// <param name="_isEnd">是否是最后一个</param>
    void OnOpenWindows(Stopwatch _watch,int _count,bool _isEnd)
    {
        int[] winSrc = new int[2] { enUIWindow.ExampleLobbyWindow, enUIWindow.ExampleHeroListWindow };

        int randomStart = _count % winSrc.Length;
        int randomEnd = winSrc.Length - 1;
        int temp = winSrc[randomStart];
        winSrc[randomStart] = winSrc[randomEnd];
        winSrc[randomEnd] = temp;
        if (_isEnd)
        {
            UnityEngine.Debug.Log("Is End=>" + winSrc.JsonSerialize());
        }
        else
        {
            UnityEngine.Debug.Log(winSrc.JsonSerialize());
        }
        
        StrayFogGamePools.uiWindowManager.OpenWindow(winSrc,
            (wins, args) =>
            {
                Stopwatch w = (Stopwatch)args[0];
                w.Stop();
                UnityEngine.Debug.Log(w.Elapsed + "=>" + wins.JsonSerialize());
            }, _watch);
    }
}
