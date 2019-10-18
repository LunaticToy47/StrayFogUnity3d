using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// XLS关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleXLSLevel")]
public class ExampleXLSLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                List<XLS_Config_Table_AssetDiskMapingFile> tables = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_AssetDiskMapingFile>();
                watch.Stop();
                Debug.Log(tables +" "+ tables.Count +  " " + watch.Elapsed);
            });            
        });
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
        if (GUILayout.Button("Update "))
        {
            XLS_Report_Determinant_Table_ReportDeterminant tbRd = StrayFogSQLiteEntityHelper.Select<XLS_Report_Determinant_Table_ReportDeterminant>()[0];          
            tbRd.Set_ReportTip(Guid.NewGuid().ToString());
            StrayFogSQLiteEntityHelper.Update(tbRd);
            StrayFogSQLiteEntityHelper.SaveExcelPackage();
            Debug.Log("Update"  + tbRd +"=>" + tbRd.JsonSerialize());
        }
        if (GUILayout.Button("Insert"))
        {
            XLS_Report_Table_Report tbInsertRp = new XLS_Report_Table_Report(Guid.NewGuid().ToString().UniqueHashCode());
            Debug.Log(tbInsertRp + " Before Insert" + tbInsertRp.JsonSerialize());
            tbInsertRp.Set_stringCol("Insert"+Guid.NewGuid().ToString());
            StrayFogSQLiteEntityHelper.Insert(tbInsertRp);
            StrayFogSQLiteEntityHelper.SaveExcelPackage();
            Debug.Log("After Insert =>" + StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>().JsonSerialize());
        }
        if (GUILayout.Button("Delete"))
        {
            XLS_Report_Table_Report tbDeleteRp = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>()[0];
            Debug.Log(tbDeleteRp + " Before Delete" + tbDeleteRp.JsonSerialize());
            StrayFogSQLiteEntityHelper.Delete(tbDeleteRp);
            StrayFogSQLiteEntityHelper.SaveExcelPackage();
            Debug.Log("After Delete =>" + StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>().JsonSerialize());
        }
        if (GUILayout.Button("Reload All"))
        {
            List<XLS_Report_Table_Report> tbReloadRps = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
            if (tbReloadRps.Count > 0)
            {
                Debug.Log(tbReloadRps + " Before Reload" + tbReloadRps.JsonSerialize());
                StrayFogSQLiteEntityHelper.Delete(tbReloadRps[0]);
            }            
            StrayFogSQLiteEntityHelper.Reload<XLS_Report_Table_Report>(enSQLiteReloadClassify.DiskCoverAllCahche);
            Debug.Log("After Reload =>" + StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>().JsonSerialize());
        }

        if (GUILayout.Button("Reload Same"))
        {
            List<XLS_Report_Table_Report> tbReloadSameRps = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
            if (tbReloadSameRps.Count > 0)
            {
                Debug.Log(tbReloadSameRps + " Before Reload Same" + tbReloadSameRps.JsonSerialize());
                tbReloadSameRps[0].Set_stringCol("Reload Same");
                StrayFogSQLiteEntityHelper.Update(tbReloadSameRps[0]);
            }
            StrayFogSQLiteEntityHelper.Reload<XLS_Report_Table_Report>();
            Debug.Log("After Reload Same=>" + StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>().JsonSerialize());
        }
    }
}