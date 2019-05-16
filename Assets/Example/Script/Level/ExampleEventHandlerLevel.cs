using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EventAggregator关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleEventHandlerLevel")]
public class ExampleEventHandlerLevel : AbsLevel
{
    /// <summary>
    /// 游戏事件映射
    /// </summary>
    static List<enExampleGameEvent> mEnGameEventMaping = typeof(enExampleGameEvent).ToEnums<enExampleGameEvent>();
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
                    foreach (enExampleGameEvent evt in mEnGameEventMaping)
                    {
                        StrayFogGamePools.eventAggregatorManager
                        .AddListener((int)evt,
                            (args) =>
                            {
                                //Debug.Log(this + "【enGameEvent】 " + args.JsonSerialize());
                                throw new UnityException(this + "【enGameEvent】 " + args.JsonSerialize());
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
