using System.Collections;
using System.Diagnostics;
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
        StrayFogGameManager.current.Initialization(() =>
        {
            StartCoroutine(OpenLobby());
        });
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
        StrayFogUIWindowManager.current.OpenWindow<LobbyWindow>(enUIWindow.LobbyWindow,
            (wins, args) =>
            {
                Stopwatch w = (Stopwatch)args[0];
                w.Stop();
                UnityEngine.Debug.Log(w.Elapsed + "=>" + wins.JsonSerialize());
            }, watch);
    }
}
