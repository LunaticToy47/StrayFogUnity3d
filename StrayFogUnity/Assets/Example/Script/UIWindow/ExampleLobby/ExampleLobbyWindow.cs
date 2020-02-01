using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ExampleLobbyWindow
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExampleLobbyWindow")]
public class ExampleLobbyWindow : AbsUIWindowView
{
    /// <summary>
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        Text txt = gameObject.transform.Find("btnRadarBg/Text").GetComponent<Text>();
        Button btnRadarBg = gameObject.transform.Find("btnRadarBg").GetComponent<Button>();
        btnRadarBg.onClick.AddListener(() =>
        {
            Vector3 scale = Vector3.one * 4f;
            txt.text = scale.ToString();
            btnRadarBg.transform.localScale = scale;

            if (StrayFogGamePools.uiWindowManager.IsOpenedWindow(enUIWindow_GameExample.ExampleMessageBoxWindow))
            {
                StrayFogGamePools.uiWindowManager.CloseWindow(enUIWindow_GameExample.ExampleMessageBoxWindow);
            }
            else
            {
                StrayFogGamePools.uiWindowManager.OpenWindow(enUIWindow_GameExample.ExampleMessageBoxWindow);
            }            
        });
        gameObject.transform.Find("btnRadar").gameObject.AddComponent<UIDragMono>();
    }
}