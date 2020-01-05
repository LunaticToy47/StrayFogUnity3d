using UnityEngine;
/// <summary>
/// ExampleLobbyExtendMonobehaviour
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExampleLobbyExtendMonobehaviour")]
public class ExampleLobbyExtendMonobehaviour : AbsMonoBehaviour
{
    protected override void OnRunAwake()
    {
        throw new UnityException("【ExampleLobbyExtendMonobehaviour】throw new UnityException");
    }
}