using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("Game/StrayFogSQLiteLevel")]
public class StrayFogSQLiteLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<XLS_Config_Table_TableColumnMaping> data = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_TableColumnMaping>();
            watch.Stop();
            UnityEngine.Debug.LogFormat("SQLite Data=>{0} , Time=>{1}", data, watch.Elapsed);
        });
    }
}
