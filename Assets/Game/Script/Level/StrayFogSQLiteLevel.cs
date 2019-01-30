//#define PK_TABLE
#define NoPK_TABLE
using System;
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
        Stopwatch watch = new Stopwatch();
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            watch.Stop();
            UnityEngine.Debug.LogFormat("StrayFogGamePools.gameManager.Initialization=>{0}",watch.Elapsed.ToString());
            
            #region PK Table
#if PK_TABLE
            watch.Reset();
            watch.Start();
            List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
            watch.Stop();
            UnityEngine.Debug.LogFormat("【PK Table】SQLite Data Select=>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

            watch.Reset();
            watch.Start();
            StrayFogSQLiteEntityHelper.Insert(reports[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("【PK Table】SQLite Data Insert 【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

            watch.Reset();
            watch.Start();
            XLS_Report_Table_Report insertReport = new XLS_Report_Table_Report(Guid.NewGuid().ToString().GetHashCode());
            insertReport.Set_stringCol(Guid.NewGuid().ToString());
            StrayFogSQLiteEntityHelper.Insert(insertReport);
            watch.Stop();
            UnityEngine.Debug.LogFormat("【PK Table】SQLite Data Insert 【Different PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

            watch.Reset();
            watch.Start();
            reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
            watch.Stop();
            UnityEngine.Debug.LogFormat("【PK Table】SQLite Data Select=>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
#endif
            #endregion


            #region NoPK_TABLE
#if NoPK_TABLE
            watch.Reset();
            watch.Start();
            List<XLS_Report_Table_ReportColumnMaping> reportColumnMapings = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_ReportColumnMaping>();
            watch.Stop();
            UnityEngine.Debug.LogFormat("【NoPk Table】SQLite Data Select=>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);

            watch.Reset();
            watch.Start();
            StrayFogSQLiteEntityHelper.Insert(reportColumnMapings[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("【NoPk Table】SQLite Data Insert =>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);

            watch.Reset();
            watch.Start();
            reportColumnMapings = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_ReportColumnMaping>();
            watch.Stop();
            UnityEngine.Debug.LogFormat("【NoPk Table】SQLite Data Select=>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);
            #endif
            #endregion

        });
    }
}
