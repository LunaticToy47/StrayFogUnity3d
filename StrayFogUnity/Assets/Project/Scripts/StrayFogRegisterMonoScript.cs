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
#endif

    /// <summary>
    /// Asmdef文件Id
    /// </summary>
    [ReadOnly()]
    [AliasTooltip("Asmdef文件Id", "AsmdefMap.xlsx映射数据")]
    public int asmdefId;

    /// <summary>
    /// 组件脚本名称
    /// </summary>
    [ReadOnly()]
    [AliasTooltip("组件脚本名称")]
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
