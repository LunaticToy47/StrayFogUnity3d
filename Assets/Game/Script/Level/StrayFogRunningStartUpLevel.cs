using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏运行时启动关卡
/// </summary>
[AddComponentMenu("Game/StrayFogRunningStartUpLevel")]
public class StrayFogRunningStartUpLevel : AbsMonoBehaviour
{
    /// <summary>
    /// 表格
    /// </summary>
    List<XLS_Config_Table_TableColumnMaping> mTables = new List<XLS_Config_Table_TableColumnMaping>();
    /// <summary>
    /// 错误信息
    /// </summary>
    string mError;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            try
            {
                mTables = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_TableColumnMaping>();
            }
            catch (Exception ep)
            {
                mError = ep.Message;
            }
            StrayFogGamePools.assetBundleManager.LoadAssetInMemory(
                enAssetDiskMapingFile.f_ExampleGuide_unity,
                enAssetDiskMapingFolder.Assets_Game_AssetBundles_Scene,
                (result) =>
                {
                    StrayFogGamePools.sceneManager.LoadScene(result.assetName);
                }, 1, "A");
        });
    }


    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        Debug.LogError("StrayFogRunningStartUpLevel=>SQLite");
        //GUILayout.Label(StrayFogGamePools.setting.dbSource);
        //GUILayout.Label(StrayFogGamePools.setting.dbConnectionString);
        foreach (XLS_Config_Table_TableColumnMaping t in mTables)
        {
            GUILayout.Label(t.JsonSerialize());
        }
        GUILayout.Label(mError);
    }
}
