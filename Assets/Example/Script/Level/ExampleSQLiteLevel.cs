using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleSQLiteLevel")]
public class ExampleSQLiteLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        Stopwatch watch = new Stopwatch();
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                watch.Stop();
                UnityEngine.Debug.LogFormat("StrayFogGamePools.gameManager.Initialization=>{0}", watch.Elapsed.ToString());
            });
        });
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        #region Select
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Select Table"))
        {
            SelectTable();
        }
        GUILayout.EndHorizontal();
        #endregion

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

        #region Update
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Update 【Normal】Table"))
        {
            UpdateNormalTable();
        }
        if (GUILayout.Button("Update 【Determinant】 Table"))
        {
            UpdateDeterminantTable();
        }
        GUILayout.EndHorizontal();
        #endregion

        #region Delete
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Delete Table"))
        {
            DeleteTable();
        }
        if (GUILayout.Button("Delete All Table"))
        {
            DeleteAllTable();
        }
        GUILayout.EndHorizontal();
        #endregion

        #region Refresh
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh Table"))
        {
            RefreshTable();
        }
        GUILayout.EndHorizontal();
        #endregion

        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventAggregatorManager.DrawLevelSelectButtonOnGUI();
    }

    /// <summary>
    /// 获得数据来源
    /// </summary>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>来源</returns>
    string GetSrcData(SQLiteTableMapAttribute _tableAttribute)
    {
        string path = string.Empty;
        if (StrayFogGamePools.setting.isUseSQLite)
        {
            if (StrayFogGamePools.setting.isInternal)
            {
                path = _tableAttribute.dbSQLitePath;
            }
            else
            {
                path = _tableAttribute.dbSQLiteAssetBundleName;
            }
        }
        else
        {
            path = _tableAttribute.xlsFilePath;
        }
        return path;
    }

    #region Select
    /// <summary>
    /// SelectTable
    /// </summary>
    void SelectTable()
    {
        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("【Select  Table 】【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        Stopwatch watch = new Stopwatch();
        watch.Start();
        List<XLS_Report_Table_Report> maps = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table【{0}->{1}】Count->{2} Time->{3}", GetSrcData(tableAttribute), tableAttribute.sqliteTableName, maps.Count, watch.Elapsed);
    }
    #endregion

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
        UnityEngine.Debug.LogFormat("【Insert PK Table 】【Same Key】【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Select PK Table 】【Same Key】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        if (reports.Count > 0)
        {
            watch.Reset();
            watch.Start();
            StrayFogSQLiteEntityHelper.Insert(reports[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("【Insert PK Table】【Same Key】SQLite Data  【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());
        }

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Select PK Table】【Same Key】SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
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
        UnityEngine.Debug.LogFormat("【Insert PK Table 】【Different Key】 【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Select PK Table 】【Different Key】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        XLS_Report_Table_Report insertReport = new XLS_Report_Table_Report(Guid.NewGuid().ToString().GetHashCode());
        insertReport.Set_stringCol("Insert PK Table");
        StrayFogSQLiteEntityHelper.Insert(insertReport);
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Insert PK Table】【Different Key】SQLite Data  【Different PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Select PK Table】【Different Key】SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
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
        UnityEngine.Debug.LogFormat("Insert 【NoPk Table】 【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        watch.Reset();
        watch.Start();
        List<XLS_Report_Table_ReportColumnMaping> reportColumnMapings = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_ReportColumnMaping>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【NoPk Table】SQLite Data =>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);

        if (reportColumnMapings.Count > 0)
        {
            watch.Reset();
            watch.Start();
            reportColumnMapings[0].Set_stringCol("Insert NoPk Table");
            StrayFogSQLiteEntityHelper.Insert(reportColumnMapings[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("Insert【NoPk Table】SQLite Data  =>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);
        }

        watch.Reset();
        watch.Start();
        reportColumnMapings = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_ReportColumnMaping>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【NoPk Table】SQLite Data =>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);
    }
    #endregion
    #endregion

    #region Update
    #region 更新普通表
    /// <summary>
    /// 更新普通表
    /// </summary>
    void UpdateNormalTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("Update【Normal Table 】【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Normal Table 】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        if (reports.Count > 0)
        {
            watch.Reset();
            watch.Start();
            reports[0].Set_stringCol("UpdateNormal Table");
            StrayFogSQLiteEntityHelper.Update(reports[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("Update【Normal Table】SQLite Data 【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());
        }

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Normal Table】SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }
    #endregion

    #region 更新行列式表
    /// <summary>
    /// 更新行列式表
    /// </summary>
    void UpdateDeterminantTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Determinant_Table_ReportDeterminant>();
        UnityEngine.Debug.LogFormat("Update【Determinant Table 】【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Determinant_Table_ReportDeterminant> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Determinant_Table_ReportDeterminant>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Determinant Table 】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        if (reports.Count > 0)
        {
            watch.Reset();
            watch.Start();
            reports[0].Set_ReportTip("Update Determinant Table");
            reports[0].Set_DeterminantTip(Guid.NewGuid().ToString());
            StrayFogSQLiteEntityHelper.Update(reports[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("Update【Determinant Table】SQLite Data 【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());
        }

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Determinant_Table_ReportDeterminant>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Determinant Table】SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }
    #endregion
    #endregion

    #region Delete
    /// <summary>
    /// DeleteTable
    /// </summary>
    void DeleteTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("Delete Table【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        if (reports.Count > 0)
        {
            watch.Reset();
            watch.Start();
            StrayFogSQLiteEntityHelper.Delete(reports[0]);
            watch.Stop();
            UnityEngine.Debug.LogFormat("Delete Table SQLite Data =>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());
        }

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }

    /// <summary>
    /// DeleteAllTable
    /// </summary>
    void DeleteAllTable()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("Delete Table【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        StrayFogSQLiteEntityHelper.DeleteAll<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("DeleteAll Table SQLite Data =>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());


        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }
    #endregion

    #region RefreshTable
    /// <summary>
    /// RefreshTable
    /// </summary>
    void RefreshTable()
    {       
        Stopwatch watch = new Stopwatch();
        watch.Start();

        SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
        UnityEngine.Debug.LogFormat("Refresh Table【{0}->{1}】", GetSrcData(tableAttribute), tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        if (reports.Count > 0)
        {
            watch.Reset();
            watch.Start();
            reports[0].Set_stringCol("Refresh Table");
            watch.Stop();
            UnityEngine.Debug.LogFormat("Modify Table SQLite Data =>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());
        }

        watch.Reset();
        watch.Start();
        StrayFogSQLiteEntityHelper.Reload<XLS_Report_Table_Report>();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select Table SQLite Data =>{0} , Time=>{1}", reports.JsonSerialize(), watch.Elapsed, reports.JsonSerialize());
    }
    #endregion
}
