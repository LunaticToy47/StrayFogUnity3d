using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 项目游戏开始脚本
/// </summary>
public class ProjectGameStart
{
    /*
     * https://www.cnblogs.com/meteoric_cry/p/7602122.html
     * Before –> Awake –> OnEnable –> After –> RuntimeMethodLoad –> Start。
     * [MethodImpl(MethodImplOptions.Synchronized)]
     */
    /// <summary>
    /// 程序主入口点
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnProjectGameStart()
    {
        Debug.Log("OnProjectGameStart");
        StrayFogAssembly.LoadDynamicAssembly(OnLoadAsmdefMap());
    }

    #region OnLoadAsmdefMap 加载AsmdefMap
    /// <summary>
    /// 加载AsmdefMap
    /// </summary>
    /// <returns>Asmdef路径映射</returns>
    static Dictionary<int, StrayFogAsmdefPathMap> OnLoadAsmdefMap()
    {
        Dictionary<int, StrayFogAsmdefPathMap> result = new Dictionary<int, StrayFogAsmdefPathMap>();
        //List<XLS_Config_Table_AsmdefMap> maps = StrayFogConfigHelper.Select<XLS_Config_Table_AsmdefMap>();
        //if (maps != null)
        //{
        //    StrayFogAsmdefPathMap temp = null;
        //    foreach (XLS_Config_Table_AsmdefMap m in maps)
        //    {
        //        if (StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseAssetBundle)
        //        {
        //            temp = new StrayFogAsmdefPathMap(m.id,
        //                Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, m.asmdefDllAssetbundleName),
        //                Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, m.asmdefPdbAssetbundleName),
        //                m.isHotfix);                    
        //        }
        //        else
        //        {
        //            temp = new StrayFogAsmdefPathMap(m.id, m.asmdefDllPath, m.asmdefPdbPath, m.isHotfix);
        //        }
        //        if (!result.ContainsKey(temp.asmdefId))
        //        {
        //            result.Add(temp.asmdefId, temp);
        //        }
        //    }
        //}
        return result;
    }
    #endregion
}
