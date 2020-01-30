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
    static Dictionary<int,string> mEnGameEventMaping = typeof(enExampleGameEvent).ValueToNameForConstField();
    /// <summary>
    /// 可发布事件
    /// </summary>
    bool mCanDispatch = false;
    /// <summary>
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        mCanDispatch = false;
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    foreach (KeyValuePair<int, string> evt in mEnGameEventMaping)
                    {
                        StrayFogGamePools.eventHandlerManager
                        .AddListener(evt.Key,
                            (args) =>
                            {
                                Debug.Log(this + "AddListener => " + args.ToString() + " " + this);
                                //throw new UnityException(this + "AddListener => " + args.ToString());
                            }
                        );
                        StrayFogGamePools.eventHandlerManager
                        .AddCallbackListener(evt.Key,
                            (args) =>
                            {
                                Debug.Log("AddCallbackListener =>" + args.ToString() + " " + this);
                                args.SetValue("Before CallbackHandler");       
                            }
                        );
                    }
                }                
                mCanDispatch = true;
            });            
        });
    }

    /// <summary>
    /// OnRunGUI
    /// </summary>
    protected override void OnRunGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        if (mCanDispatch)
        {
            StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
        }        
    }
}
