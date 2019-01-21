using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// XLS关卡
/// </summary>
[AddComponentMenu("Game/StrayFogXLSLevel")]
public class StrayFogXLSLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            List<Table_TableColumnMaping> tables = StrayFogSQLiteEntityHelper.Select<Table_TableColumnMaping>();
            Debug.Log(tables);
        });
    }
}