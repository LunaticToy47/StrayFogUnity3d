using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 注册组件
/// </summary>
[AddComponentMenu("StrayFog/Game/ProjectAPK/StrayFogRegisterMonoScript")]
public sealed class StrayFogRegisterMonoScript : MonoBehaviour
{
#if UNITY_EDITOR
    /// <summary>
    /// 脚本
    /// </summary>
    public MonoScript monoScript;

    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    float EditorSetMonoScript(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;
        if (monoScript != null)
        {
            monoBehaviourScriptName = monoScript.GetClass().FullName;
        }        
        return _position.y - y;
    }
#endif
    /// <summary>
    /// 组件脚本名称
    /// </summary>
    [ReadOnly()]
    [AliasTooltip("组件脚本名称")]
    [InvokeMethod("EditorSetMonoScript",true)]
    public string monoBehaviourScriptName;
    
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        
        //StrayFogSetting
        //StrayFogGamePools.gameManager.Initialization(() =>
        //{
        //    StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
        //    {
        //        string scriptName = monoBehaviourScriptName;
        //        if (string.IsNullOrEmpty(scriptName))
        //        {
        //            scriptName = gameObject.name;
        //        }
        //        Type type = StrayFogAssembly.GetType(scriptName);
        //        if (type != null)
        //        {
        //            gameObject.AddComponent(type);
        //        }
        //        else
        //        {
        //            Debug.LogErrorFormat("Can't found type 【{0}】", scriptName);
        //        }
        //    });
        //});
    }
}
