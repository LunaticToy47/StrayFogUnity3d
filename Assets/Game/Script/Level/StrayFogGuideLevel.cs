using System.Collections;
using System.Diagnostics;
using System.Reflection;
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
        //StrayFogRunningUtility.SingleMonoBehaviour<StrayFogGameManager>().Initialization(() =>
        //{
        //    StartCoroutine(OpenLobby());
        //});
    }

    void OnGUI()
    {        
        StrayFogSetting setting = StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>();
        GUI.skin.label.fontSize = 40;
        GUI.color = Color.black;
        GUILayout.Label(setting.ToData());
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
        StrayFogRunningUtility.SingleMonoBehaviour<StrayFogUIWindowManager>().OpenWindow<LobbyWindow>(enUIWindow.LobbyWindow,
            (wins, args) =>
            {
                Stopwatch w = (Stopwatch)args[0];
                w.Stop();
                UnityEngine.Debug.Log(w.Elapsed + "=>" + wins.JsonSerialize());
            }, watch);
    }
}
