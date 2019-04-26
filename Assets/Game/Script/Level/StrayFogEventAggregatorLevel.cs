using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EventAggregator关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogEventAggregatorLevel")]
public class StrayFogEventAggregatorLevel : AbsLevel
{
    /// <summary>
    /// 事件映射
    /// </summary>
    static List<enUGUIEvent> mEventMaping = typeof(enUGUIEvent).ToEnums<enUGUIEvent>();
    /// <summary>
    /// 可发布事件
    /// </summary>
    bool mCanDispatch = false;
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        mCanDispatch = false;
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                foreach (enUGUIEvent evt in mEventMaping)
                {
                    StrayFogGamePools.eventAggregatorManager
                    .AddListener(evt,
                        (args) =>
                        {
                            Debug.Log(this + " " + args.JsonSerialize());
                        }
                    );
                }
                mCanDispatch = true;
            });            
        });
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        if (mCanDispatch)
        {
            StrayFogGamePools.eventAggregatorManager.DrawLevelSelectButtonOnGUI();
        }        
    }
}
