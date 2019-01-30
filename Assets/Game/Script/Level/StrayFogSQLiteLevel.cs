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
            UnityEngine.Debug.LogFormat("StrayFogGamePools.gameManager.Initialization=>{0}", watch.Elapsed.ToString());
        });
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        #region Insert
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Insert 【PK】【Same Key】 Table"))
        {
            InsertPKSameKeyTable();
        }
        if (GUILayout.Button("Insert 【PK】 【Different Key】 Table"))
        {
            InsertPKDifferentKeyTable();
        }
        if (GUILayout.Button("Insert 【No PK 】Table"))
        {
            InsertNoPKTable();
        }
        GUILayout.EndHorizontal();
        #endregion
    }

    #region Insert
    #region 插入PK表有重复键数据
    /// <summary>
    /// 插入PK表有重复键数据
    /// </summary>
    void InsertPKSameKeyTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("【PK Table 】【Same Key】【{0}->{1}】Insert", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【PK Table 】【Same Key】SQLite Data Select=>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        StrayFogSQLiteEntityHelper.Insert(reports[0]);
        watch.Stop();
        UnityEngine.Debug.LogFormat("【PK Table】【Same Key】SQLite Data Insert 【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【PK Table】【Same Key】SQLite Data Select=>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }
    #endregion

    #region 插入PK表无重复键数据
    /// <summary>
    /// 插入PK表无重复键数据
    /// </summary>
    void InsertPKDifferentKeyTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("【PK Table 】【Different Key】 【{0}->{1}】Insert", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【PK Table 】【Different Key】SQLite Data Select=>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        XLS_Report_Table_Report insertReport = new XLS_Report_Table_Report(Guid.NewGuid().ToString().GetHashCode());
        insertReport.Set_stringCol(Guid.NewGuid().ToString());
        StrayFogSQLiteEntityHelper.Insert(insertReport);
        watch.Stop();
        UnityEngine.Debug.LogFormat("【PK Table】【Different Key】SQLite Data Insert 【Different PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【PK Table】【Different Key】SQLite Data Select=>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }
    #endregion

    #region 插入NoPK表数据
    /// <summary>
    /// 插入NoPK表数据
    /// </summary>
    void InsertNoPKTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_ReportColumnMaping>();
        UnityEngine.Debug.LogFormat("NoPk Table 【{0}->{1}】Insert", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

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
    }
    #endregion
    #endregion
}
