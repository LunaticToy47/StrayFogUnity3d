﻿using System;
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
    List<Table_TableColumnMaping> mTables = new List<Table_TableColumnMaping>();
    /// <summary>
    /// 错误信息
    /// </summary>
    string mError;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogUtility.SingleMonoBehaviour<StrayFogGameManager>().Initialization(() =>
        {
            try
            {
                mTables = SQLiteEntityHelper.Select<Table_TableColumnMaping>();
            }
            catch (Exception ep)
            {
                mError = ep.Message;
            }
            StrayFogUtility.SingleMonoBehaviour<StrayFogAssetBundleManager>().LoadAssetInMemory(
                enAssetDiskMapingFile.f_ExampleGuide_unity,
                enAssetDiskMapingFolder.Assets_Game_AssetBundles_Scene,
                (result) =>
                {
                    StrayFogUtility.SingleMonoBehaviour<StrayFogSceneManager>().LoadScene(result.assetName);
                }, 1, "A");
        });
    }


    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label(StrayFogUtility.SingleScriptableObject<StrayFogSetting>().dbSource);
        GUILayout.Label(StrayFogUtility.SingleScriptableObject<StrayFogSetting>().dbConnectionString);
        foreach (Table_TableColumnMaping t in mTables)
        {
            GUILayout.Label(t.JsonSerialize());
        }
        GUILayout.Label(mError);
    }
}
