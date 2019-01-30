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

            SQLiteTableMapAttribute tableAttribute = StrayFogSQLiteEntityHelper.GetTableAttribute<XLS_Report_Table_Report>();
            List<XLS_Config_Table_TableColumnMaping> maps = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_TableColumnMaping>();            
            UnityEngine.Debug.LogFormat("Select Table【{0}->{1}】Count->{2}", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName, maps.Count);
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
        //if (GUILayout.Button("Insert 【No PK 】Table"))
        //{
        //    InsertNoPKTable();
        //}
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
        UnityEngine.Debug.LogFormat("【Insert PK Table 】【Same Key】【{0}->{1}】", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Select PK Table 】【Same Key】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        StrayFogSQLiteEntityHelper.Insert(reports[0]);
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Insert PK Table】【Same Key】SQLite Data  【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

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
        UnityEngine.Debug.LogFormat("【Insert PK Table 】【Different Key】 【{0}->{1}】", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("【Select PK Table 】【Different Key】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        XLS_Report_Table_Report insertReport = new XLS_Report_Table_Report(Guid.NewGuid().ToString().GetHashCode());
        insertReport.Set_stringCol(Guid.NewGuid().ToString());
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
        UnityEngine.Debug.LogFormat("Insert 【NoPk Table】 【{0}->{1}】", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        watch.Reset();
        watch.Start();
        List<XLS_Report_Table_ReportColumnMaping> reportColumnMapings = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_ReportColumnMaping>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【NoPk Table】SQLite Data =>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);

        watch.Reset();
        watch.Start();
        StrayFogSQLiteEntityHelper.Insert(reportColumnMapings[0]);
        watch.Stop();
        UnityEngine.Debug.LogFormat("Insert【NoPk Table】SQLite Data  =>{0} , Time=>{1}", reportColumnMapings.Count, watch.Elapsed);

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
        UnityEngine.Debug.LogFormat("Update【Normal Table 】【{0}->{1}】", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        List<XLS_Report_Table_Report> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Table_Report>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Normal Table 】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        reports[0].Set_stringCol(Guid.NewGuid().ToString());
        StrayFogSQLiteEntityHelper.Update(reports[0]);
        watch.Stop();
        UnityEngine.Debug.LogFormat("Update【Normal Table】SQLite Data 【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

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
        UnityEngine.Debug.LogFormat("Update【Determinant Table 】【{0}->{1}】", tableAttribute.xlsFilePath, tableAttribute.sqliteTableName);

        List<XLS_Report_Determinant_Table_ReportDeterminant> reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Determinant_Table_ReportDeterminant>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Determinant Table 】SQLite Data =>{0} , Time=>{1} , Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        reports[0].Set_ReportTip(Guid.NewGuid().ToString());
        reports[0].Set_DeterminantTip(Guid.NewGuid().ToString());
        StrayFogSQLiteEntityHelper.Update(reports[0]);
        watch.Stop();
        UnityEngine.Debug.LogFormat("Update【Determinant Table】SQLite Data 【Same PK】=>{0} , Time=>{1}, Data=>【{2}】", reports.Count, watch.Elapsed, reports.JsonSerialize());

        watch.Reset();
        watch.Start();
        reports = StrayFogSQLiteEntityHelper.Select<XLS_Report_Determinant_Table_ReportDeterminant>();
        watch.Stop();
        UnityEngine.Debug.LogFormat("Select【Determinant Table】SQLite Data =>{0} , Time=>{1}", reports.Count, watch.Elapsed, reports.JsonSerialize());
    }
    #endregion
    #endregion
}
