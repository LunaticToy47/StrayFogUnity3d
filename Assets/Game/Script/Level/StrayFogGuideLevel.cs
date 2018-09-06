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
        StrayFogUtility.SingleMonoBehaviour<StrayFogGameManager>().Initialization(() =>
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
        StrayFogUtility.SingleMonoBehaviour<StrayFogUIWindowManager>().OpenWindow<LobbyWindow>(enUIWindow.LobbyWindow,
            (wins, args) =>
            {
                Stopwatch w = (Stopwatch)args[0];
                w.Stop();
                UnityEngine.Debug.Log(w.Elapsed + "=>" + wins.JsonSerialize());
            }, watch);
    }
}
