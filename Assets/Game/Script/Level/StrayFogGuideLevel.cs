using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
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
            StartCoroutine(OpenLobby());
        });
    }

    void OnGUI()
    {
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
    IEnumerator OpenLobby()
    {
        //yield return new WaitForSeconds(1);
        yield return null;
        UnityEngine.Debug.Log("Open=>" + enUIWindow.LobbyWindow);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIWindowView>(
            new Enum[2] { enUIWindow.LobbyWindow, enUIWindow.MessageBoxWindow },
            (wins, args) =>
            {
                Stopwatch w = (Stopwatch)args[0];
                w.Stop();
                UnityEngine.Debug.Log(w.Elapsed + "=>" + wins.JsonSerialize());
            }, watch);
    }
}
