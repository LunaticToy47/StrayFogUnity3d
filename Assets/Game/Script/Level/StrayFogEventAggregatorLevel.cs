using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EventAggregator关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogEventAggregatorLevel")]
public class StrayFogEventAggregatorLevel : AbsLevel
{
    /// <summary>
    /// UGUI事件映射
    /// </summary>
    static List<enUGUIEvent> mEnUGUIEventMaping = typeof(enUGUIEvent).ToEnums<enUGUIEvent>();
    /// <summary>
    /// 游戏事件映射
    /// </summary>
    static List<enGameEvent> mEnGameEventMaping = typeof(enGameEvent).ToEnums<enGameEvent>();
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
                for (int i = 0; i < 10; i++)
                {
                    foreach (enUGUIEvent evt in mEnUGUIEventMaping)
                    {
                        StrayFogGamePools.eventAggregatorManager
                        .AddListener(evt,
                            (args) =>
                            {
                                Debug.Log(this + "【enUGUIEvent】 " + args.JsonSerialize());
                            }
                        );
                    }
                    foreach (enGameEvent evt in mEnGameEventMaping)
                    {
                        StrayFogGamePools.eventAggregatorManager
                        .AddListener(evt,
                            (args) =>
                            {
                                Debug.Log(this + "【enGameEvent】 " + args.JsonSerialize());
                            }
                        );
                    }
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
