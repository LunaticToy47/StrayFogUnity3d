using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
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
        //StrayFogAssembly.LoadDynamicAssembly(
        //    () =>
        //    {
        //        List<XLS_Config_Table_AsmdefMap> maps = StrayFogConfigHelper.Select<XLS_Config_Table_AsmdefMap>();
        //        Dictionary<string, string> result = new Dictionary<string, string>();
        //        foreach (XLS_Config_Table_AsmdefMap m in maps)
        //        {
        //            if (m.isHotfix)
        //            {
        //                result.Add(m.asmdefDllPath, m.asmdefPdbPath);
        //            }
        //        }
        //        return result;
        //    },
        //    () =>
        //    {
        //        List<XLS_Config_Table_AsmdefMap> maps = StrayFogConfigHelper.Select<XLS_Config_Table_AsmdefMap>();
        //        Dictionary<string, string> result = new Dictionary<string, string>();
        //        foreach (XLS_Config_Table_AsmdefMap m in maps)
        //        {
        //            if (m.isHotfix)
        //            {
        //                result.Add(Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, m.asmdefDllAssetbundleName),
        //                    Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, m.asmdefPdbAssetbundleName));
        //            }
        //        }
        //        return result;
        //    }, () => {
        //        OnMountMonoScript();
        //    }
        //);        
    }

    /// <summary>
    /// 挂载脚本
    /// </summary>
    void OnMountMonoScript()
    {
        Type type = StrayFogAssembly.GetType(monoBehaviourScriptName);


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
