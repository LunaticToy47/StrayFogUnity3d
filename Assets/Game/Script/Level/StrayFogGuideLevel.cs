using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 引导关卡
/// </summary>
[AddComponentMenu("Game/StrayFogGuideLevel")]
public class StrayFogGuideLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            
        });
    }

    void OnGUI()
    {
        if (GUILayout.Button("Start Guid"))
        {
            StartCoroutine(OnOpenLobby());
        }
        GUI.skin.label.fontSize = 40;
        GUI.color = Color.black;
        GUILayout.Label(StrayFogGamePools.setting.ToData());

        string path = StrayFogGamePools.setting.assetBundleRoot + "/ab_xboxone";
        if (!Directory.Exists(StrayFogGamePools.setting.assetBundleRoot))
        {
            Directory.CreateDirectory(StrayFogGamePools.setting.assetBundleRoot);
        }
        GUILayout.Label(path);
        GUILayout.Label(File.Exists(path).ToString());
        File.WriteAllText(path+".txt", "11111");
        GUILayout.Label(File.Exists(path).ToString());
    }

    /// <summary>
    /// OpenLobby
    /// </summary>
    /// <returns>异步</returns>
    IEnumerator OnOpenLobby()
    {        
        yield return new WaitForEndOfFrame();
        UnityEngine.Debug.Log("Open=>" + enUIWindow.LobbyWindow);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        for (int i = 0; i < 10; i++)
        {
            OnOpenWindows(watch);
        }
    }

    /// <summary>
    /// OnOpenWindows
    /// </summary>
    /// <param name="_watch">Stopwatch</param>
    void OnOpenWindows(Stopwatch _watch)
    {
        StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIWindowView>(
            new Enum[2] { enUIWindow.LobbyWindow, enUIWindow.MessageBoxWindow },
            (wins, args) =>
            {
                Stopwatch w = (Stopwatch)args[0];
                w.Stop();
                UnityEngine.Debug.Log(w.Elapsed + "=>" + wins.JsonSerialize());
            }, _watch);
    }
}
