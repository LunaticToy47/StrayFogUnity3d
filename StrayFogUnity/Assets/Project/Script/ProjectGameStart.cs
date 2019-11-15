using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 项目游戏开始脚本
/// </summary>
public class ProjectGameStart
{
    /// <summary>
    /// 程序主入口点
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnProjectGameStart()
    {
        List<XLS_Config_Table_AsmdefMap> maps = StrayFogConfigHelper.Select<XLS_Config_Table_AsmdefMap>();
    }
}
