using System;
using UnityEngine;
/// <summary>
/// 注册组件
/// </summary>
[AddComponentMenu("Game/StrayFogRegisterMonoBehaviour")]
public class StrayFogRegisterMonoBehaviour : AbsMonoBehaviour
{
    /// <summary>
    /// 组件脚本名称
    /// </summary>
    [AliasTooltip("组件脚本名称", "默认值=gameObject.name")]
    public string monoBehaviourScriptName;
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        string scriptName = monoBehaviourScriptName;
        if (string.IsNullOrEmpty(scriptName))
        {
            scriptName = gameObject.name;
        }
        Type type = StrayFogAssembly.GetType(scriptName);
        if (type != null)
        {
            gameObject.AddComponent(type);
        }
        else
        {
            Debug.LogErrorFormat("Can't found type 【{0}】", scriptName);
        }
    }
}
