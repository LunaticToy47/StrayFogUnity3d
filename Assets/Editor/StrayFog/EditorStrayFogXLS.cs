#if UNITY_EDITOR
using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 编辑器XLS工具
/// </summary>
public sealed class EditorStrayFogXLS
{
    #region XLS 变量    
    /// <summary>
    /// 表列名称行索引
    /// </summary>
    static readonly int msrColumnNameRowIndex = 1;
    /// <summary>
    /// 表列类型行索引
    /// </summary>
    static readonly int msrColumnTypeRowIndex = 2;
    /// <summary>
    /// 表列描述行索引
    /// </summary>
    static readonly int msrColumnDescriptionRowIndex = 3;
    /// <summary>
    /// 表数据行起始索引
    /// </summary>
    static readonly int msrColumnDataRowStartIndex = 4;
    
    /// <summary>
    /// 行列式表列名称列索引
    /// </summary>
    static readonly int msrDeterminantColumnNameColumnIndex = 1;
    /// <summary>
    /// 行列式表列名称列值索引
    /// </summary>
    static readonly int msrDeterminantColumnDataColumnIndex = 2;
    /// <summary>
    /// 行列式表列类型行索引
    /// </summary>
    static readonly int msrDeterminantColumnTypeColumnIndex = 3;
    /// <summary>
    /// 行列式表列描述行索引
    /// </summary>
    static readonly int msrDeterminantColumnDescriptionColumnIndex = 4;
    #endregion    

    #region public readonly 变量  
    /// <summary>
    /// 分隔符说明
    /// </summary>
    public static readonly string msrSeparateDescription = "1.一维数组\"|\"竖线分隔,例:1|2|3" + System.Environment.NewLine + "2.二维数组\"|\"竖线分隔一维,\",\"逗号分隔二维,例:A0,A1,A2|B0,B1,B2";

    /// <summary>
    /// SQLiteDataTypeCS代码序列
    /// </summary>
    public static readonly string msrSQLiteDataTypeCodeSequence =
        string.Format("{1}{0}{0}{2}{0}{0}{3}", Environment.NewLine,
            StrayFogSQLiteDataTypeHelper.GetSQLiteDataTypeCSCodeColumnNameSequence(),
            StrayFogSQLiteDataTypeHelper.GetSQLiteDataTypeCSCodeColumnTypeSequence(),
            StrayFogSQLiteDataTypeHelper.GetSQLiteDataTypeCSCodeColumnDescSequence()
            );
    #endregion

    #region readonly 变量
    /// <summary>
    /// 列分隔符
    /// </summary>
    static readonly string msrColumnSeparate =",";
    /// <summary>
    /// UNION符号
    /// </summary>
    static readonly string msrUnionSymbol = "UNION";
    #endregion

    #region TableSQLiteHelper帮助类
    /// <summary>
    /// TableSQLiteHelper帮助类
    /// </summary>
    class TableSQLiteHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_table">表格架构</param>
        public TableSQLiteHelper(EditorXlsTableSchema _table)
        {
            dbKey = _table.dbKey;
            dbPath = _table.dbPath;
            dbDirectory = Path.GetDirectoryName(_table.dbPath);
            sqlite = new StrayFogSQLiteHelper(_table.dbConnectionString);
        }
        /// <summary>
        /// 数据库Key
        /// </summary>
        public int dbKey { get; private set; }
        /// <summary>
        /// 数据路径
        /// </summary>
        public string dbPath { get; private set; }
        /// <summary>
        /// 数据库目录
        /// </summary>
        public string dbDirectory { get; private set; }
        /// <summary>
        /// 数据库
        /// </summary>
        public StrayFogSQLiteHelper sqlite { get; private set; }
    }
    #endregion

    #region OnTransDescToSummary 转换描述为Summary形式
    /// <summary>
    /// 转换描述为Summary形式
    /// </summary>
    /// <param name="_desc">描述</param>
    /// <returns>描述</returns>
    static string OnTransDescToSummary(string _desc)
    {
        StringBuilder descSb = new StringBuilder();
        StringReader reader = new StringReader(_desc);
        string line = string.Empty;
        int num = 0;
        do
        {
            line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                if (num == 0)
                {
                    descSb.Append(line);
                }
                else
                {
                    descSb.Append(Environment.NewLine + "	///" + line);
                }
                num++;
            }
        } while (!string.IsNullOrEmpty(line));
        return descSb.ToString();
    }
    #endregion

    #region OnClearXlsData 清除XLS表数据
    /// <summary>
    /// 清除XLS表数据
    /// </summary>
    /// <param name="_xlsPath">XLS表路径</param>
    static void OnClearXlsData(string _xlsPath)
    {
        using (ExcelPackage pck = new ExcelPackage(new FileInfo(_xlsPath)))
        {
            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
            if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
            {
                sheet.DeleteRow(msrColumnDataRowStartIndex, sheet.Dimension.Rows);
                pck.Save();
            }
        }        
    }
    #endregion

    #region OnDeleteXlsData 删除XLS表指定数据
    /// <summary>
    /// 删除XLS表指定数据
    /// </summary>
    /// <param name="_xlsPath">XLS表路径</param>
    /// <param name="_isDeleteFunc">是否清除</param>
    static void OnDeleteXlsData(string _xlsPath, Func<ExcelWorksheet, int, bool> _isDeleteFunc)
    {
        string newXlsPath = _xlsPath + "_New";
        bool isDel = false;
        int delCount = 0;
        using (ExcelPackage pck = new ExcelPackage(new FileInfo(_xlsPath)))
        {
            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
            if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
            {
                int maxRow = sheet.Dimension.Rows;
                for (int row = msrColumnDataRowStartIndex; row <= maxRow; row++)
                {
                    if (_isDeleteFunc(sheet, row - delCount))
                    {
                        sheet.DeleteRow(row - delCount, 1, true);
                        isDel |= true;
                        delCount++;
                    }
                }
            }
            if (isDel)
            {
                pck.Save();
            }
        }
    }
    #endregion

    #region ReadXlsSchema 读取XLS表结构框架
    /// <summary>
    /// 读取XLS表结构框架
    /// </summary>
    /// <returns>XLS表结构框架</returns>
    public static List<EditorXlsTableSchema> ReadXlsSchema()
    {
        EditorStrayFogApplication.IsInternalWhenUseSQLiteInEditorForResourceLoadMode();
        List<EditorXlsTableSchema> tableSchemas = new List<EditorXlsTableSchema>();
        FileExtAttribute xlsxExt = enFileExt.Xlsx.GetAttribute<FileExtAttribute>();
        List<EditorSelectionXlsSchemaToSQLiteAsset> xlsFiles = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionXlsSchemaToSQLiteAsset>(EditorStrayFogSavedAssetConfig.setFolderConfigForSchemaToSqlite.paths,
            enEditorAssetFilterClassify.DefaultAsset, false,
            (n) => { return xlsxExt.IsExt(n.ext); });
        foreach (EditorSelectionXlsSchemaToSQLiteAsset f in xlsFiles)
        {
            f.Resolve();
            tableSchemas.Add(ReadXlsSchema(f));
        }
        return tableSchemas;
    }
    #endregion

    #region ReadXlsSchema 读取XLS表结构框架
    /// <summary>
    /// 读取XLS表结构框架
    /// </summary>
    /// <param name="_xlsAsset">XLS文件资源</param>
    /// <returns>XLS表结构框架</returns>
    public static EditorXlsTableSchema ReadXlsSchema(EditorSelectionXlsSchemaToSQLiteAsset _xlsAsset)
    {
        EditorStrayFogApplication.IsInternalWhenUseSQLiteInEditorForResourceLoadMode();
        EditorXlsTableSchema tempTable = null;
        EditorXlsTableColumnSchema tempColumn = null;
        Dictionary<string, EditorXlsTableColumnSchema> tempSrcTableColumns = new Dictionary<string, EditorXlsTableColumnSchema>();
        string tempColumnName = string.Empty;
        using (ExcelPackage pck = new ExcelPackage(new FileInfo(_xlsAsset.path)))
        {
            if (pck.Workbook.Worksheets.Count > 0)
            {
                ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                List<string> lstColumnName = new List<string>();

                #region XLS表中是否有同名列
                if (sheet.Dimension.Rows >= msrColumnNameRowIndex)
                {
                    for (int i = 1; i <= sheet.Dimension.Columns; i++)
                    {
                        tempColumnName = sheet.GetValue<string>(msrColumnNameRowIndex, i).ToUpper();
                        if (!lstColumnName.Contains(tempColumnName))
                        {
                            lstColumnName.Add(tempColumnName);
                        }
                        else
                        {
                            throw new UnityException(string.Format("There are same column【{0}】 in 【{1}】",
                                sheet.GetValue<string>(msrColumnNameRowIndex, i), _xlsAsset.path));
                        }
                    }
                }
                #endregion

                tempTable = (EditorXlsTableSchema)_xlsAsset.tableAssetConfig.engineAsset;
                tempTable.fileName = _xlsAsset.path;
                tempTable.dbPath = _xlsAsset.dbPath;
                tempTable.tableName = _xlsAsset.nameWithoutExtension;
                tempTable.tableSchemaAssetPath = _xlsAsset.tableAssetConfig.fileName;
                tempSrcTableColumns = new Dictionary<string, EditorXlsTableColumnSchema>();

                #region 收集已有的列
                if (tempTable.columns != null && tempTable.columns.Length > 0)
                {
                    foreach (EditorXlsTableColumnSchema col in tempTable.columns)
                    {
                        if (!string.IsNullOrEmpty(col.columnName))
                        {
                            tempColumnName = col.columnName.ToUpper();
                            tempSrcTableColumns.Add(tempColumnName, col);
                        }
                    }
                }
                #endregion

                List<EditorXlsTableColumnSchema> targetColumns = new List<EditorXlsTableColumnSchema>();
                if (sheet.Dimension.Rows >= msrColumnNameRowIndex)
                {
                    for (int i = 1; i <= sheet.Dimension.Columns; i++)
                    {
                        tempColumnName = sheet.GetValue<string>(msrColumnNameRowIndex, i).ToString().ToUpper();
                        if (tempSrcTableColumns.ContainsKey(tempColumnName))
                        {
                            tempColumn = tempSrcTableColumns[tempColumnName];
                        }
                        else
                        {
                            tempColumn = new EditorXlsTableColumnSchema();
                        }
                        tempColumn.xlsColumnIndex = i;
                        tempColumn.columnName = sheet.GetValue<string>(msrColumnNameRowIndex, i).ToString();
                        tempColumn.sqliteColumnName = tempColumn.columnName;
                        tempColumn.desc = sheet.GetValue<string>(msrColumnDescriptionRowIndex, i).ToString();
                        tempColumn.dataType = enSQLiteDataType.String;
                        tempColumn.arrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                        StrayFogSQLiteDataTypeHelper.ResolveCSDataType(sheet.GetValue<string>(msrColumnTypeRowIndex, i).ToString(), ref tempColumn.dataType, ref tempColumn.arrayDimension);
                        targetColumns.Add(tempColumn);
                    }
                }
                tempTable.columns = targetColumns.ToArray();
                EditorUtility.SetDirty(tempTable);
            }
        }
        return tempTable;
    }
    #endregion

    #region ExportXlsSchemaToSqlite 生成Xls表结构到Sqlite数据库    
    /// <summary>
    /// 生成Xls表结构到Sqlite数据库
    /// </summary>
    public static void ExportXlsSchemaToSQLite()
    {
        EditorStrayFogApplication.IsInternalWhenUseSQLiteInEditorForResourceLoadMode();
        List<EditorXlsTableSchema> tables = ReadXlsSchema();
        Dictionary<int, TableSQLiteHelper> dicHelper = OnCreateTableSchemaToSQLite(tables);
        OnCreateScriptFromSQLite(tables, dicHelper);
        OnClearUnusedMapAsset(tables);
    }

    /// <summary>
    /// 创建表结构到SQLite数据库
    /// </summary>
    /// <param name="_tables">表结构</param>
    static Dictionary<int, TableSQLiteHelper> OnCreateTableSchemaToSQLite(List<EditorXlsTableSchema> _tables)
    {
        string sqliteCreateTableTemplete = EditorResxTemplete.SQLiteCreateTableTemplete;
        string sqliteView_DeterminantVTTemplete = EditorResxTemplete.SQLiteCreateDeterminantViewTemplete;
        Dictionary<int, TableSQLiteHelper> dicDbHelper = new Dictionary<int, TableSQLiteHelper>();
        Dictionary<int, List<string>> dicExcuteSql = new Dictionary<int, List<string>>();
        FileExtAttribute attSqlExt = enFileExt.TextAsset.GetAttribute<FileExtAttribute>();

        #region #Column# Templete
        string columnMark = "#Column#";
        string columnReplaceTemplete = string.Empty;
        string columnTemplete = string.Empty;
        StringBuilder sbColumnReplace = new StringBuilder();
        columnTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(sqliteCreateTableTemplete, columnMark, out columnReplaceTemplete);
        #endregion

        #region #PrimaryKey# Templete
        string primaryKeyMark = "#PrimaryKey#";
        string primaryKeyReplaceTemplete = string.Empty;
        string primaryKeyTemplete = string.Empty;
        StringBuilder sbPrimaryKeyReplace = new StringBuilder();
        primaryKeyTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(sqliteCreateTableTemplete, primaryKeyMark, out primaryKeyReplaceTemplete);
        #endregion

        #region #PKS# Templete
        string pksMark = "#PKS#";
        string pksReplaceTemplete = string.Empty;
        string pksTemplete = string.Empty;
        StringBuilder sbPksReplace = new StringBuilder();
        pksTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(primaryKeyTemplete, pksMark, out pksReplaceTemplete);
        #endregion

        #region #View_Determinant# Templete
        string view_DeterminantMark = "#View_Determinant#";
        string view_DeterminantReplaceTemplete = string.Empty;
        string view_DeterminantTemplete = string.Empty;
        StringBuilder sbView_DeterminantReplace = new StringBuilder();
        view_DeterminantTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(sqliteView_DeterminantVTTemplete, view_DeterminantMark, out view_DeterminantReplaceTemplete);
        #endregion

        List<string> columnCodes = new List<string>();
        List<string> pksCodes = new List<string>();
        Dictionary<int, List<string>> determinantTables = new Dictionary<int, List<string>>();
        float progress = 0;

        #region 初始化数据
        foreach (EditorXlsTableSchema table in _tables)
        {
            progress++;
            if (!dicDbHelper.ContainsKey(table.dbKey))
            {
                dicDbHelper.Add(table.dbKey, new TableSQLiteHelper(table));
            }
            if (!dicExcuteSql.ContainsKey(table.dbKey))
            {
                dicExcuteSql.Add(table.dbKey, new List<string>());
            }
            if (!determinantTables.ContainsKey(table.dbKey))
            {
                determinantTables.Add(table.dbKey, new List<string>());
            }
            EditorUtility.DisplayProgressBar("Init SQLite Data",
                    string.Format("【{0}】=>{1}", table.tableName, table.dbConnectionString), progress / dicDbHelper.Count);
        }
        #endregion

        #region 清理数据库SQL语句
        progress = 0;
        SqliteDataReader reader = null;
        foreach (KeyValuePair<int, TableSQLiteHelper> key in dicDbHelper)
        {
            progress++;
            reader = key.Value.sqlite.ReadSQLiteTableSchema();
            while (reader.Read())
            {
                dicExcuteSql[key.Key].Add(string.Format("DROP {0} '{1}'", reader.GetString(reader.GetOrdinal("type")), reader.GetString(reader.GetOrdinal("name"))));
            }
            reader.Close();
            reader = null;

            reader = key.Value.sqlite.ReadSQLiteViewSchema();
            while (reader.Read())
            {
                dicExcuteSql[key.Key].Add(string.Format("DROP {0} '{1}'", reader.GetString(reader.GetOrdinal("type")), reader.GetString(reader.GetOrdinal("name"))));
            }
            reader.Close();
            reader = null;

            key.Value.sqlite.Close();
            EditorUtility.DisplayProgressBar("Collect Clear SQLite SQL",
                    key.Value.sqlite.connectionString, progress / dicDbHelper.Count);
        }
        #endregion

        #region 创建表SQL语句
        progress = 0;
        foreach (EditorXlsTableSchema table in _tables)
        {
            progress++;
            #region 创建表SQL语句
            sbColumnReplace.Length = 0;
            sbPrimaryKeyReplace.Length = 0;
            sbPksReplace.Length = 0;
            columnCodes = new List<string>();
            pksCodes = new List<string>();
            if (table.columns != null && table.columns.Length > 0)
            {
                foreach (EditorXlsTableColumnSchema c in table.columns)
                {
                    columnCodes.Add(
                       columnTemplete
                       .Replace("#NotNull#", c.isNull ? "" : "NOT NULL")
                       .Replace("#Name#", c.columnName)
                       .Replace("#DataType#", StrayFogSQLiteDataTypeHelper.GetSQLiteDataTypeName(c.dataType, c.arrayDimension))
                    );
                    if (c.isPK)
                    {
                        pksCodes.Add(
                            pksTemplete
                            .Replace("#Name#", c.columnName));
                    }
                }
            }

            sbColumnReplace.Append(string.Join(msrColumnSeparate, columnCodes.ToArray()));
            if (pksCodes.Count > 0)
            {
                sbColumnReplace.Append(msrColumnSeparate);
                sbPrimaryKeyReplace.Append(
                primaryKeyTemplete
                .Replace(pksReplaceTemplete, string.Join(msrColumnSeparate, pksCodes.ToArray()))
                );
            }

            dicExcuteSql[table.dbKey].Add(
                sqliteCreateTableTemplete
                .Replace("#TableName#", table.tableName)
                .Replace(columnReplaceTemplete, sbColumnReplace.ToString())
                .Replace(primaryKeyReplaceTemplete, sbPrimaryKeyReplace.ToString())
                );
            #endregion

            #region 收集Determinant表
            if (table.isDeterminant)
            {
                determinantTables[table.dbKey].Add(view_DeterminantTemplete.Replace("#Name#", table.name));
            }
            #endregion

            EditorUtility.DisplayProgressBar("Build Table SQL",
                    string.Format("【{0}】=>{1}",table.tableName,table.dbConnectionString), progress / _tables.Count);
        }

        #region 创建View_DeterminantVT语句
        progress = 0;
        foreach (int key in determinantTables.Keys)
        {
            progress++;
            sbView_DeterminantReplace.Length = 0;
            if (determinantTables[key].Count > 0)
            {
                sbView_DeterminantReplace.Append(string.Join(msrUnionSymbol, determinantTables[key].ToArray()));
            }
            else
            {
                sbView_DeterminantReplace.Append(view_DeterminantTemplete.Replace("#Name#", Guid.NewGuid().ToString().UniqueHashCode().ToString()));
            }
            dicExcuteSql[key].Add(
                sqliteView_DeterminantVTTemplete
                .Replace(view_DeterminantReplaceTemplete, sbView_DeterminantReplace.ToString())
                );
            EditorUtility.DisplayProgressBar("Create View_Determinant SQL",dicDbHelper[key].sqlite.connectionString, progress / _tables.Count);
        }
        #endregion

        #endregion

        #region 创建视图SQL语句
        foreach (KeyValuePair<int, TableSQLiteHelper> key in dicDbHelper)
        {
            List<EditorSelectionAsset> sqlAssets = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsset>(new string[1] { key.Value.dbDirectory }, enEditorAssetFilterClassify.TextAsset, false, (node) => { return node.ext.ToUpper().Equals(attSqlExt.ext.ToUpper()); });
            if (sqlAssets != null && sqlAssets.Count > 0)
            {
                progress = 0;
                foreach (EditorSelectionAsset n in sqlAssets)
                {
                    progress++;
                    dicExcuteSql[key.Key].Add(File.ReadAllText(n.path));
                    EditorUtility.DisplayProgressBar("Build View SQL", string.Format("【{0}】=>{1}",n.path, dicDbHelper[key.Key].sqlite.connectionString), progress / sqlAssets.Count);
                }
            }
        }
        #endregion

        #region 创建数据库
        progress = 0;
        foreach (KeyValuePair<int, List<string>> key in dicExcuteSql)
        {
            progress++;
            for (int i = 0; i < key.Value.Count; i++)
            {
                dicDbHelper[key.Key].sqlite.ExecuteNonQuery(key.Value[i]);
                EditorUtility.DisplayProgressBar("Build SQLite Schema",
                    dicDbHelper[key.Key].sqlite.connectionString,
                    (progress / dicExcuteSql.Count + (i + 1) / key.Value.Count) * 0.5f);
            }
            dicDbHelper[key.Key].sqlite.Close();
        }
        #endregion

        EditorUtility.ClearProgressBar();

        return dicDbHelper;
    }

    /// <summary>
    /// 从SQLite创建脚本
    /// </summary>
    /// <param name="_tables">要生成的表</param>
    /// <param name="_dbHelper">数据库</param>
    static void OnCreateScriptFromSQLite(List<EditorXlsTableSchema> _tables, Dictionary<int, TableSQLiteHelper> _dbHelper)
    {
        SqliteDataReader reader = null;
        float progress = 0;

        List<string> viewNames = new List<string>();
        string tempName = string.Empty;
        string tempType = string.Empty;
        string schemaColumnOrdinalName = "name";
        string schemaColumnOrdinalType = "type";
        enSQLiteDataType tempDataType = enSQLiteDataType.String;
        enSQLiteDataTypeArrayDimension tempDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;

        EditorXlsTableSchema tempTable = null;
        EditorXlsTableColumnSchema tempTableColumn = null;
        List<EditorXlsTableColumnSchema> tempColumns = new List<EditorXlsTableColumnSchema>();
        Dictionary<int, string> dicSQLiteClassifyEnum = new Dictionary<int, string>();
        foreach (KeyValuePair<int, TableSQLiteHelper> db in _dbHelper)
        {
            #region 搜索要生成的视图
            viewNames.Clear();
            reader = db.Value.sqlite.ReadSQLiteViewSchema();
            while (reader.Read())
            {
                tempName = reader.GetString(reader.GetOrdinal(schemaColumnOrdinalName));
                if (!viewNames.Contains(tempName))
                {
                    viewNames.Add(tempName);
                }
            }
            reader.Close();
            reader = null;
            db.Value.sqlite.Close();
            #endregion

            #region 收集视图类信息
            progress = 0;
            foreach (string tn in viewNames)
            {
                progress++;
                tempTable = new EditorXlsTableSchema();
                tempTable.tableName = tn;
                tempTable.dbPath =db.Value.dbPath;
                tempTable.classify = enSQLiteEntityClassify.View;
                tempColumns = new List<EditorXlsTableColumnSchema>();
                reader = db.Value.sqlite.ReadPragmaTableInfo(tn);
                while (reader.Read())
                {
                    tempName = reader.GetString(reader.GetOrdinal(schemaColumnOrdinalName));
                    tempType = reader.GetString(reader.GetOrdinal(schemaColumnOrdinalType));
                    tempDataType = enSQLiteDataType.String;
                    tempDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                    StrayFogSQLiteDataTypeHelper.ResolveSQLiteDataType(tempType, ref tempDataType, ref tempDataTypeArrayDimension);
                    tempTableColumn = new EditorXlsTableColumnSchema();
                    tempTableColumn.columnName = tempName;
                    tempTableColumn.dataType = tempDataType;
                    tempTableColumn.arrayDimension = tempDataTypeArrayDimension;
                    tempTableColumn.desc = tempName;
                    tempColumns.Add(tempTableColumn);
                }
                reader.Close();
                reader = null;
                db.Value.sqlite.Close();
                tempTable.columns = tempColumns.ToArray();
                _tables.Add(tempTable);
                EditorUtility.DisplayProgressBar("Collection View",
                       string.Format("【{0}】=>{1}", tn, db.Value.sqlite.connectionString), progress / viewNames.Count);
            }
            #endregion          
        }

        foreach (EditorXlsTableSchema t in _tables)
        {
            if (!dicSQLiteClassifyEnum.ContainsKey(t.dbKey))
            {
                dicSQLiteClassifyEnum.Add(t.dbKey, t.dbEnumName);
            }
        }

        #region 行列式表整理
        progress = 0;
        List<string> tempSameColumnNames = new List<string>();
        foreach (EditorXlsTableSchema t in _tables)
        {
            progress++;
            OnResolveTableSchema(t);
            if (t.isDeterminant)
            {
                tempSameColumnNames.Clear();
                foreach (EditorXlsTableColumnSchema c in t.columns)
                {
                    if (!tempSameColumnNames.Contains(c.columnName.ToUpper()))
                    {
                        tempSameColumnNames.Add(c.columnName.ToUpper());
                    }
                    else
                    {
                        EditorUtility.ClearProgressBar();
                        throw new UnityException(string.Format("The Determinant Table has same value【{0}】 in column index 【{1}】in 【{2}】",
                                c.columnName, msrDeterminantColumnNameColumnIndex,t.fileName));
                    }
                }                
            }
            EditorUtility.DisplayProgressBar("Resolve Table",
                   string.Format("【{0}】Is Determinant【{1}】=>{2}", t.tableName, t.isDeterminant, t.dbConnectionString), progress / _tables.Count);
        }
        #endregion

        #region 生成表脚本
        progress = 0;
        int xlsColumnNameIndex = 0;
        int xlsColumnDataIndex = 0;
        int xlsColumnTypeIndex = 0;
        int xlsDataStartRowIndex = msrColumnDataRowStartIndex;
        string entityScriptTemplete = EditorResxTemplete.SQLiteEntityScriptTemplete;

        #region #Properties#
        string propertyMark = "#Properties#";
        string propertyReplaceTemplete = string.Empty;
        string propertyTemplete = string.Empty;
        StringBuilder sbPropertyReplace = new StringBuilder();
        propertyTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, propertyMark, out propertyReplaceTemplete);
        #endregion

        #region #SetProperties#
        string setPropertyMark = "#SetProperties#";
        string setPropertyReplaceTemplete = string.Empty;
        string setPropertyTemplete = string.Empty;
        StringBuilder sbSetPropertyReplace = new StringBuilder();
        setPropertyTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, setPropertyMark, out setPropertyReplaceTemplete);
        #endregion

        #region #TableConstructor#
        string tableConstructorMark = "#TableConstructor#";
        string tableConstructorReplaceTemplete = string.Empty;
        string tableConstructorTemplete = string.Empty;
        StringBuilder sbTableConstructorReplace = new StringBuilder();
        tableConstructorTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, tableConstructorMark, out tableConstructorReplaceTemplete);
        #endregion

        #region #ConstructorParamSummary#
        string constructorParamSummaryMark = "#ConstructorParamSummary#";
        string constructorParamSummaryReplaceTemplete = string.Empty;
        string constructorParamSummaryTemplete = string.Empty;
        StringBuilder sbConstructorParamSummaryReplace = new StringBuilder();
        constructorParamSummaryTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(tableConstructorTemplete, constructorParamSummaryMark, out constructorParamSummaryReplaceTemplete);
        #endregion

        #region #ConstructorFormalParams#
        string constructorFormalParamsMark = "#ConstructorFormalParams#";
        string constructorFormalParamsReplaceTemplete = string.Empty;
        string constructorFormalParamsTemplete = string.Empty;
        StringBuilder sbConstructorFormalParamsReplace = new StringBuilder();
        constructorFormalParamsTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(tableConstructorTemplete, constructorFormalParamsMark, out constructorFormalParamsReplaceTemplete);
        #endregion

        #region #ConstructorSetParams#
        string constructorSetParamsMark = "#ConstructorSetParams#";
        string constructorSetParamsReplaceTemplete = string.Empty;
        string constructorSetParamsTemplete = string.Empty;
        StringBuilder sbConstructorSetParamsReplace = new StringBuilder();
        constructorSetParamsTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(tableConstructorTemplete, constructorSetParamsMark, out constructorSetParamsReplaceTemplete);
        #endregion


        string sqliteFolder = Path.GetFullPath(enEditorApplicationFolder.Game_Script_SQLite.GetAttribute<EditorApplicationFolderAttribute>().path);

        Dictionary<int, string> dicSqliteEntityFolder = new Dictionary<int, string>();
        Dictionary<int, string> dicSqliteDeterminantEntitiesFolder = new Dictionary<int, string>();
        foreach (KeyValuePair<int, TableSQLiteHelper> key in _dbHelper)
        {
            dicSqliteEntityFolder.Add(key.Key, Path.Combine(sqliteFolder, Path.GetFileNameWithoutExtension(key.Value.dbPath) + "_Entities"));
            dicSqliteDeterminantEntitiesFolder.Add(key.Key, Path.Combine(sqliteFolder, Path.GetFileNameWithoutExtension(key.Value.dbPath) + "_DeterminantEntities"));
            EditorStrayFogUtility.cmd.DeleteFolder(dicSqliteEntityFolder[key.Key]);
            EditorStrayFogUtility.cmd.DeleteFolder(dicSqliteDeterminantEntitiesFolder[key.Key]);
        }
        EditorTextAssetConfig cfgEntityScript = new EditorTextAssetConfig("", "", enFileExt.CS, "");
        List<string> tempConstructorParamSummary = new List<string>();
        List<string> tempConstructorFormalParams = new List<string>();
        List<string> tempConstructorSetParams = new List<string>();
        bool hasPK = false;
        foreach (EditorXlsTableSchema t in _tables)
        {
            progress++;
            if (t.isDeterminant)
            {
                xlsColumnNameIndex = msrDeterminantColumnNameColumnIndex;
                xlsColumnDataIndex = msrDeterminantColumnDataColumnIndex;
                xlsColumnTypeIndex = msrDeterminantColumnTypeColumnIndex;
            }
            else
            {
                xlsColumnNameIndex = msrColumnNameRowIndex;
                xlsColumnDataIndex = msrColumnDataRowStartIndex;
                xlsColumnTypeIndex = msrColumnTypeRowIndex;
            }         
            sbPropertyReplace.Length = 0;
            sbSetPropertyReplace.Length = 0;
            sbTableConstructorReplace.Length = 0;
            sbConstructorParamSummaryReplace.Length = 0;
            sbConstructorFormalParamsReplace.Length = 0;
            sbConstructorSetParamsReplace.Length = 0;
            tempConstructorParamSummary.Clear();
            tempConstructorFormalParams.Clear();
            tempConstructorSetParams.Clear();
            hasPK = false;
            foreach (EditorXlsTableColumnSchema c in t.columns)
            {
                sbPropertyReplace.Append(
                    propertyTemplete
                    .Replace("#Name#", c.columnName)
                    .Replace("#Desc#", OnTransDescToSummary(c.desc))
                    .Replace("#Type#", StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(c.dataType, c.arrayDimension))
                    .Replace("#DataType#", c.dataType.ToString())
                    .Replace("#ArrayDimension#", c.arrayDimension.ToString())
                    .Replace("#XlsColumnIndex#", c.xlsColumnIndex.ToString())
                    .Replace("#SqliteColumnName#", c.sqliteColumnName)
                    .Replace("#SqliteColumnValue#", c.sqliteColumnValue)
                    .Replace("#SqliteParameterName#", c.sqliteParameterName)
                    .Replace("#IsPK#", c.isPK.ToString().ToLower())
                    );
                hasPK |= c.isPK;
                if (t.isDeterminant)
                {
                    sbSetPropertyReplace.Append(
                            setPropertyTemplete
                            .Replace("#Name#", c.columnName)
                            .Replace("#Type#", StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(c.dataType, c.arrayDimension))
                        );
                }
                else
                {
                    if (c.isPK)
                    {
                        tempConstructorParamSummary.Add(
                        constructorParamSummaryTemplete
                            .Replace("#Name#", c.columnName)
                        );
                        tempConstructorFormalParams.Add(
                        constructorFormalParamsTemplete
                            .Replace("#Name#", c.columnName)
                            .Replace("#Type#", StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(c.dataType, c.arrayDimension))
                        );
                        tempConstructorSetParams.Add(
                        constructorSetParamsTemplete
                            .Replace("#Name#", c.columnName)
                        );
                    }
                    else
                    {
                        sbSetPropertyReplace.Append(
                            setPropertyTemplete
                            .Replace("#Name#", c.columnName)
                            .Replace("#Type#", StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(c.dataType, c.arrayDimension))
                        );
                    }
                }
            }

            if (tempConstructorParamSummary.Count > 0)
            {
                sbConstructorParamSummaryReplace.Append(string.Join("", tempConstructorParamSummary.ToArray()));
            }
            if (tempConstructorFormalParams.Count > 0)
            {
                sbConstructorFormalParamsReplace.Append(string.Join(msrColumnSeparate, tempConstructorFormalParams.ToArray()));
            }
            if (tempConstructorSetParams.Count > 0)
            {
                sbConstructorSetParamsReplace.Append(string.Join("", tempConstructorSetParams.ToArray()));
            }

            if (hasPK)
            {
                sbTableConstructorReplace.Append(
                    tableConstructorTemplete
                    .Replace(constructorParamSummaryReplaceTemplete, sbConstructorParamSummaryReplace.ToString())
                    .Replace(constructorFormalParamsReplaceTemplete, sbConstructorFormalParamsReplace.ToString())
                    .Replace(constructorSetParamsReplaceTemplete, sbConstructorSetParamsReplace.ToString())
                    );
            }

            if (!t.canModifyData)
            {
                sbSetPropertyReplace.Length = 0;
                sbTableConstructorReplace.Length = 0;
            }

            cfgEntityScript.SetName(t.className);
            cfgEntityScript.SetText(entityScriptTemplete

                .Replace(tableConstructorReplaceTemplete, sbTableConstructorReplace.ToString())
                .Replace(propertyReplaceTemplete, sbPropertyReplace.ToString())
                .Replace(setPropertyReplaceTemplete, sbSetPropertyReplace.ToString())

                .Replace("#ClassName#", t.className)
                .Replace("#EntityName#", t.tableName)
                
                .Replace("#classHashCode#", t.className.UniqueHashCode().ToString())
                .Replace("#xlsFilePath#", t.fileName)
                .Replace("#sqliteTableName#", t.tableName)
                .Replace("#sqliteTableType#", t.classify.ToString())
                .Replace("#isDeterminant#", Convert.ToString(t.isDeterminant).ToLower())
                .Replace("#xlsColumnNameIndex#", xlsColumnNameIndex.ToString())
                .Replace("#xlsColumnValueIndex#", xlsColumnDataIndex.ToString())
                .Replace("#xlsColumnTypeIndex#", xlsColumnTypeIndex.ToString())
                .Replace("#xlsDataStartRowIndex#", xlsDataStartRowIndex.ToString())
                .Replace("#dbSQLitePath#", t.dbPath.ToString())
                .Replace("#dbSQLiteAssetBundleName#", t.assetBundleDbName)
                .Replace("#hasPKColumn#", Convert.ToString(hasPK).ToLower())
                .Replace("#canModifyData#", Convert.ToString(t.canModifyData).ToLower())
                );

            if (t.isDeterminant)
            {
                cfgEntityScript.SetDirectory(dicSqliteDeterminantEntitiesFolder[t.dbKey]);
            }
            else
            {
                cfgEntityScript.SetDirectory(dicSqliteEntityFolder[t.dbKey]);
            }
            Debug.LogFormat("【{0}->{1}】【{2}】=>{3}", t.tableName, t.className, cfgEntityScript.directory, cfgEntityScript.text);
            cfgEntityScript.CreateAsset();
            EditorUtility.DisplayProgressBar("Build Table Script",
                   string.Format("【{0}】=>{1}", t.tableName, t.dbConnectionString), progress / _tables.Count);
        }
        #endregion

        EditorUtility.ClearProgressBar();
    }

    /// <summary>
    /// 解析表
    /// </summary>
    /// <param name="_table">表</param>
    static EditorXlsTableSchema OnResolveTableSchema(EditorXlsTableSchema _table)
    {
        if (_table.isDeterminant)
        {
            List<EditorXlsTableColumnSchema> columns = new List<EditorXlsTableColumnSchema>();
            EditorXlsTableColumnSchema tempColumn = null;
            enSQLiteDataType tempDataType = enSQLiteDataType.String;
            enSQLiteDataTypeArrayDimension tempDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(_table.fileName)))
            {
                if (pck.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
                    {
                        for (int i = msrColumnDataRowStartIndex; i <= sheet.Dimension.Rows; i++)
                        {
                            tempColumn = new EditorXlsTableColumnSchema();
                            tempColumn.xlsColumnIndex = i;
                            tempColumn.columnName = sheet.GetValue<string>(i, msrDeterminantColumnNameColumnIndex).ToString();
                            tempColumn.sqliteColumnName = sheet.GetValue<string>(msrColumnNameRowIndex, msrDeterminantColumnNameColumnIndex).ToString();
                            tempColumn.sqliteColumnValue = sheet.GetValue<string>(msrColumnNameRowIndex, msrDeterminantColumnDataColumnIndex).ToString();
                            tempDataType = enSQLiteDataType.String;
                            tempDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                            StrayFogSQLiteDataTypeHelper.ResolveCSDataType(sheet.GetValue<string>(i, msrDeterminantColumnTypeColumnIndex).ToString(), ref tempDataType, ref tempDataTypeArrayDimension);
                            tempColumn.dataType = tempDataType;
                            tempColumn.arrayDimension = tempDataTypeArrayDimension;
                            tempColumn.desc = sheet.GetValue<string>(i, msrDeterminantColumnDescriptionColumnIndex).ToString();
                            columns.Add(tempColumn);
                        }
                    }
                }
            }
            _table.columns = columns.ToArray();
        }
        return _table;
    }

    /// <summary>
    /// 清除未使用的映射资源
    /// </summary>
    /// <param name="_tables">要生成的表</param>
    static void OnClearUnusedMapAsset(List<EditorXlsTableSchema> _tables)
    {
        List<string> tableSchemaAssetFolders = new List<string>();
        string tempFolder = string.Empty;
        List<string> xlsTableSchemaPaths = new List<string>();
        foreach (EditorXlsTableSchema t in _tables)
        {
            tempFolder = Path.GetDirectoryName(t.tableSchemaAssetPath);
            if (!string.IsNullOrEmpty(tempFolder) && !tableSchemaAssetFolders.Contains(tempFolder))
            {
                tableSchemaAssetFolders.Add(tempFolder);
            }
            if (!xlsTableSchemaPaths.Contains(t.tableSchemaAssetPath))
            {
                xlsTableSchemaPaths.Add(t.tableSchemaAssetPath);
            }
        }
        FileExtAttribute assetExt = enFileExt.Asset.GetAttribute<FileExtAttribute>();
        List<EditorSelectionAsset> assetFiles = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsset>(tableSchemaAssetFolders.ToArray(),
            enEditorAssetFilterClassify.Object, false,
            (n) => { return assetExt.IsExt(n.ext) && !xlsTableSchemaPaths.Contains(n.path); });

        foreach (EditorSelectionAsset af in assetFiles)
        {
            Debug.LogFormat("Delete Unused Asset 【{0}】", af.path);
            File.Delete(af.path);
        }
    }
    #endregion

    #region ExportXlsDataToSqlite
    /// <summary>
    /// 导出XLS数据到SQLite
    /// </summary>
    /// <param name="_progressCallback">进度回调</param>
    public static void ExportXlsDataToSqlite(Action<string, string, float> _progressCallback)
    {
        List<EditorXlsTableSchema> tables = ReadXlsSchema();
        Dictionary<int, Dictionary<string, Dictionary<string, List<SqliteParameter>>>> tempInsertTable = new Dictionary<int, Dictionary<string, Dictionary<string, List<SqliteParameter>>>>();
        StringBuilder tempInsertSql = new StringBuilder();
        List<string> tempSPName = new List<string>();
        List<string> tempValueSql = new List<string>();
        List<SqliteParameter> tempSPS = new List<SqliteParameter>();
        Dictionary<int, TableSQLiteHelper> dicDbHelper = new Dictionary<int, TableSQLiteHelper>();
        for (int i = 0; i < tables.Count; i++)
        {
            _progressCallback("Import Table To Sqlite", tables[i].fileName, (i + 1) / (float)tables.Count);

            if (!dicDbHelper.ContainsKey(tables[i].dbKey))
            {
                dicDbHelper.Add(tables[i].dbKey, new TableSQLiteHelper(tables[i]));
            }
            if (!tempInsertTable.ContainsKey(tables[i].dbKey))
            {
                tempInsertTable.Add(tables[i].dbKey, new Dictionary<string, Dictionary<string, List<SqliteParameter>>>());
            }

            tempInsertTable[tables[i].dbKey].Add(tables[i].tableName, new Dictionary<string, List<SqliteParameter>>());
            tempInsertSql.Length = 0;
            tempValueSql = new List<string>();

            tempInsertTable[tables[i].dbKey][tables[i].tableName].Add(string.Format("DELETE FROM {0}", tables[i].tableName), new List<SqliteParameter>());
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(tables[i].fileName)))
            {
                ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                bool tempIsAllValueNull = false;
                object tempValue = null;
                string tempName = string.Empty;

                if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
                {
                    for (int row = msrColumnDataRowStartIndex; row <= sheet.Dimension.Rows; row++)
                    {
                        tempIsAllValueNull = true;
                        _progressCallback(string.Format("Read Table【{0}】", tables[i].tableName), string.Format("Row 【 {0}】 Data", row), (row - msrColumnDataRowStartIndex + 1) / (float)tables.Count);

                        tempSPName = new List<string>();
                        tempSPS = new List<SqliteParameter>();
                        tempValueSql = new List<string>();
                        tempInsertSql.Length = 0;
                        tempInsertSql.AppendFormat("INSERT INTO {0} VALUES", tables[i].tableName);

                        for (int col = 1; col <= sheet.Dimension.Columns; col++)
                        {
                            tempName = sheet.GetValue<string>(msrColumnNameRowIndex, col).Trim();
                            tempValue = sheet.GetValue<string>(row, col);
                            tempIsAllValueNull &= (tempValue == null);
                            tempSPName.Add("@" + tempName + row + col);
                            tempSPS.Add(new SqliteParameter("@" + tempName + row + col, tempValue));
                            _progressCallback(string.Format("Read 【{0}】 Column Data", tables[i].tableName), string.Format("Row【{0}】Col【{1}->{2}】", row, col, tempName), col / (float)sheet.Dimension.Columns);
                        }
                        if (tempIsAllValueNull)
                        {//如果所有列为空，则认为是数据结束
                            break;
                        }
                        else
                        {
                            tempValueSql.Add(string.Format("({0})", string.Join(",", tempSPName.ToArray())));
                            tempInsertSql.Append(string.Join(",", tempValueSql.ToArray()));
                            tempInsertTable[tables[i].dbKey][tables[i].tableName].Add(tempInsertSql.ToString(), tempSPS);
                        }
                    }
                }
            }
        }

        float progress = 0;
        foreach (KeyValuePair<int, Dictionary<string, Dictionary<string, List<SqliteParameter>>>> db in tempInsertTable)
        {
            progress++;
            foreach (KeyValuePair<string, Dictionary<string, List<SqliteParameter>>> key in db.Value)
            {
                _progressCallback(string.Format("Update SQLite 【{0}】", dicDbHelper[db.Key].dbPath), string.Format("Insert Table【{0}】Data Count 【{1}】",  key.Key, key.Value.Count - 1), progress / tempInsertTable.Count);
                dicDbHelper[db.Key].sqlite.ExecuteTransaction(key.Value);
            }
        }
    }
    #endregion

    #region AssetDiskMaping表操作
    #region InsertDataToAssetDiskMapingFolder 插入数据到AssetDiskMapingFolder表
    /// <summary>
    /// 插入数据到AssetDiskMapingFolder表
    /// </summary>
    /// <param name="_nodes">节点</param>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertDataToAssetDiskMapingFolder(List<EditorSelectionAssetDiskMaping> _nodes, Action<string, float> _progressCallback)
    {
        EditorXlsFileConfigForSetAssetDiskMapingFolder cfg = EditorStrayFogSavedAssetConfig.setXlsFileConfigForSetAssetDiskMapingFolder;
        if (cfg.paths.Length > 0)
        {
            foreach (string file in cfg.paths)
            {
                OnClearXlsData(file);
                List<int> saveIds = new List<int>();
                int sameRows = 0;
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(file)))
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    for (int i = 0; i < _nodes.Count; i++)
                    {
                        if (!saveIds.Contains(_nodes[i].folderId))
                        {
                            saveIds.Add(_nodes[i].folderId);
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 1].Value = _nodes[i].folderId;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 2].Value = _nodes[i].folderInSide;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 3].Value = _nodes[i].folderOutSide;
                        }
                        else
                        {
                            sameRows++;
                        }
                        _progressCallback(_nodes[i].name, (i + 1) / (float)_nodes.Count);
                    }
                    pck.Save();
                }
            }
        }
        else
        {
            string error = "AssetDiskMapingFolder.xlsx file is not set,please set one.";
            EditorUtility.DisplayDialog("Error", error, "Yes", "No");
            throw new UnityException(error);
        }
    }
    #endregion

    #region InsertDataToAssetDiskMapingFile 插入数据到AssetDiskMapingFile表
    /// <summary>
    /// 插入数据到AssetDiskMapingFile表
    /// </summary>
    /// <param name="_nodes">节点</param>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertDataToAssetDiskMapingFile(List<EditorSelectionAssetDiskMaping> _nodes, Action<string, float> _progressCallback)
    {
        EditorXlsFileConfigForSetAssetDiskMapingFile cfg = EditorStrayFogSavedAssetConfig.setXlsFileConfigForSetAssetDiskMapingFile;
        if (cfg.paths.Length > 0)
        {
            foreach (string file in cfg.paths)
            {
                OnClearXlsData(file);
                List<int> saveIds = new List<int>();
                int sameRows = 0;
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(file)))
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    for (int i = 0; i < _nodes.Count; i++)
                    {
                        if (!saveIds.Contains(_nodes[i].guidHashCode))
                        {
                            saveIds.Add(_nodes[i].guidHashCode);
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 1].Value = _nodes[i].fileId;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 2].Value = _nodes[i].folderId;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 3].Value = _nodes[i].fileInSide;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 4].Value = _nodes[i].ext;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 5].Value = _nodes[i].fileOutSide;
                            sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 6].Value = _nodes[i].fileExtEnumValue;
                        }
                        else
                        {
                            sameRows++;
                        }
                        _progressCallback(_nodes[i].name, (i + 1) / (float)_nodes.Count);
                    }
                    pck.Save();
                }
            }
        }
        else
        {
            string error = "AssetDiskMapingFile.xlsx file is not set,please set one.";
            EditorUtility.DisplayDialog("Error", error, "Yes", "No");
            throw new UnityException(error);
        }
    }
    #endregion

    #endregion

    #region UIWindowSetting表操作

    #region DeleteUIWindowSetting 删除指定窗口设置
    /// <summary>
    /// 删除指定窗口设置
    /// </summary>
    /// <param name="_winId">窗口id</param>
    public static void DeleteUIWindowSetting(int _winId)
    {
        EditorXlsFileConfigForUIWindowSetting wfg = EditorStrayFogSavedAssetConfig.setXlsFileConfigForUIWindowSetting;
        if (wfg.paths.Length > 0)
        {
            foreach (string file in wfg.paths)
            {
                OnDeleteXlsData(file, (sheet, row) => { return sheet.GetValue<int>(row, 1) == _winId; });
            }
        }       
    }
    #endregion

    #region InsertUIWindowSetting 插入窗口设置
    /// <summary>
    /// 插入窗口设置
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertUIWindowSetting(List<EditorSelectionUIWindowSetting> _windows, Action<string, float> _progressCallback)
    {
        EditorXlsFileConfigForUIWindowSetting wfg = EditorStrayFogSavedAssetConfig.setXlsFileConfigForUIWindowSetting;
        if (wfg.paths.Length > 0)
        {
            foreach (string file in wfg.paths)
            {
                OnClearXlsData(file);
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(file)))
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    for (int i = 0; i < _windows.Count; i++)
                    {
                        sheet.Cells[msrColumnDataRowStartIndex + i, 1].Value = _windows[i].winId;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 2].Value = _windows[i].nameWithoutExtension;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 3].Value = _windows[i].fileId;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 4].Value = _windows[i].folderId;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 5].Value = (int)_windows[i].assetNode.renderMode;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 6].Value = (int)_windows[i].assetNode.layer;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 7].Value = (int)_windows[i].assetNode.openMode;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 8].Value = (int)_windows[i].assetNode.closeMode;
                        sheet.Cells[msrColumnDataRowStartIndex + i, 9].Value = Convert.ToInt32(_windows[i].assetNode.isIgnoreOpenCloseMode);
                        sheet.Cells[msrColumnDataRowStartIndex + i, 10].Value = Convert.ToInt32(_windows[i].assetNode.isNotAutoRestoreSequenceWindow);
                        sheet.Cells[msrColumnDataRowStartIndex + i, 11].Value = Convert.ToInt32(_windows[i].assetNode.isDonotDestroyInstance);
                        sheet.Cells[msrColumnDataRowStartIndex + i, 12].Value = Convert.ToInt32(_windows[i].assetNode.isImmediateDisplay);
                        sheet.Cells[msrColumnDataRowStartIndex + i, 13].Value = Convert.ToInt32(_windows[i].assetNode.isManualCloseWhenGotoScene);
                        sheet.Cells[msrColumnDataRowStartIndex + i, 14].Value = Convert.ToInt32(_windows[i].assetNode.isGuideWindow);
                        _progressCallback(_windows[i].path, (i + 1) / (float)_windows.Count);
                    }
                    pck.Save();
                }
            }
        }
        else
        {
            string error = "UIWindowSetting.xlsx file is not set,please set one.";
            EditorUtility.DisplayDialog("Error", error, "Yes", "No");
            throw new UnityException(error);
        }
    }
    #endregion
    #endregion

    #region XLuaMap表操作
    #region InsertXLuaMap 插入XLua映射
    /// <summary>
    /// 插入XLua映射
    /// </summary>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertXLuaMap(Action<string, float> _progressCallback)
    {
        List<EditorSelectionXLuaMapSetting> xLuaScripts = EditorStrayFogGlobalVariable.CollectionXLua<EditorSelectionXLuaMapSetting>();

        EditorXlsFileConfigForXLuaMap wfg = EditorStrayFogSavedAssetConfig.setXlsFileConfigForXLuaMap;
        if (wfg.paths.Length > 0)
        {
            foreach (string file in wfg.paths)
            {
                OnClearXlsData(file);
                using (ExcelPackage pck = new ExcelPackage(new FileInfo(file)))
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    int rowIndex = 0;
                    for (int i = 0; i < xLuaScripts.Count; i++)
                    {
                        //if (xLuaScripts[i].xLuaTextAsset != null)
                        //{
                            //EditorSelectionXLuaMapSetting set = new EditorSelectionXLuaMapSetting(AssetDatabase.GetAssetPath(xLuaMaps[i].xLuaTextAsset));
                            //set.Resolve();
                            //sheet.Cells[msrColumnDataRowStartIndex + i - rowIndex, 1].Value = xLuaMaps[i].xLuaId;
                            //sheet.Cells[msrColumnDataRowStartIndex + i - rowIndex, 2].Value = set.fileId;
                            //sheet.Cells[msrColumnDataRowStartIndex + i - rowIndex, 3].Value = set.folderId;
                        //}
                        //else
                        //{
                        //    rowIndex++;
                        //}
                        //if (_progressCallback != null)
                        //{
                        //    _progressCallback(xLuaMaps[i].classFullName, (i + 1) / (float)xLuaMaps.Count);
                        //}
                    }
                    pck.Save();
                }
            }
        }
        else
        {
            string error = "XLuaMap.xlsx file is not set,please set one.";
            EditorUtility.DisplayDialog("Error", error, "Yes", "No");
            throw new UnityException(error);
        }
    }
    #endregion
    #endregion
}
#endif
