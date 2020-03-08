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
        StrayFogAssembly.LoadDynamicAssembly();
    }
}
