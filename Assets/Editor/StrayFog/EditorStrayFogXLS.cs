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

    #region 内部 readonly 变量
    /// <summary>
    /// XLS表架构文件
    /// </summary>
    static readonly EditorEngineAssetConfig msrXlsTableMapingAsset = new EditorEngineAssetConfig("",
        enEditorApplicationFolder.XLS_TableMaping.GetAttribute<EditorApplicationFolderAttribute>().path,
        enFileExt.Asset, "");

    /// <summary>
    /// XLS表架构文件
    /// </summary>
    static readonly EditorEngineAssetConfig msrXlsTableSrcAsset = new EditorEngineAssetConfig("",
        enEditorApplicationFolder.XLS_TableSrc.GetAttribute<EditorApplicationFolderAttribute>().path,
        enFileExt.Xlsx, "");
    #endregion

    #region OnClearXlsData 清除XLS表数据
    /// <summary>
    /// 清除XLS表数据
    /// </summary>
    /// <param name="_tableName">表名</param>
    static void OnClearXlsData(string _tableName)
    {
        msrXlsTableSrcAsset.SetName(_tableName);
        string newXlsPath = msrXlsTableSrcAsset.fileName + "." + msrXlsTableSrcAsset.ext;
        using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        {
            ExcelPackage pck = new ExcelPackage(fs);
            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
            if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
            {
                sheet.DeleteRow(msrColumnDataRowStartIndex, sheet.Dimension.Rows);
                pck.SaveAs(new FileInfo(newXlsPath));
            }
        }

        if (File.Exists(newXlsPath))
        {
            File.Delete(msrXlsTableSrcAsset.fileName);
            File.Move(newXlsPath, msrXlsTableSrcAsset.fileName);
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
        List<EditorXlsTableSchema> tableSchemas = new List<EditorXlsTableSchema>();
        string[] xlsFolders = new string[1] { msrXlsTableSrcAsset.directory };
        string extXlsx = msrXlsTableSrcAsset.ext.GetAttribute<FileExtAttribute>().ext;
        List<EditorSelectionAsset> xlsFiles = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsset>(xlsFolders, 
            enEditorAssetFilterClassify.DefaultAsset, false, 
            (n) => { return n.ext.ToUpper() == extXlsx.ToUpper(); });

        EditorXlsTableSchema tempTable = null;
        EditorXlsTableColumnSchema tempTableCell = null;
        
        string tempColumnName = string.Empty;
        foreach (EditorSelectionAsset f in xlsFiles)
        {
            using (FileStream fs = new FileStream(f.path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ExcelPackage pck = new ExcelPackage(fs);
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
                                throw new UnityException(string.Format("There are same column【{0}】 in xls【{1}】",
                                    sheet.GetValue<string>(msrColumnNameRowIndex, i), f.path));
                            }
                        }
                    }
                    #endregion

                    #region 读取已保存的表架构
                    msrXlsTableMapingAsset.SetName(f.nameWithoutExtension);
                    msrXlsTableMapingAsset.SetType(typeof(EditorXlsTableSchema).FullName);
                    if (!msrXlsTableMapingAsset.Exists())
                    {
                        msrXlsTableMapingAsset.CreateAsset();
                    }
                    msrXlsTableMapingAsset.LoadAsset();
                    tempTable = (EditorXlsTableSchema)msrXlsTableMapingAsset.engineAsset;
                    #endregion

                    #region 保存原始列架构
                    Dictionary<string, EditorXlsTableColumnSchema> srcEditorXlsTableColumnSchemaMaping = new Dictionary<string, EditorXlsTableColumnSchema>();
                    if (tempTable.columns != null && tempTable.columns.Length > 0)
                    {
                        foreach (EditorXlsTableColumnSchema c in tempTable.columns)
                        {
                            tempColumnName = c.name.ToUpper();
                            if (!srcEditorXlsTableColumnSchemaMaping.ContainsKey(tempColumnName))
                            {
                                srcEditorXlsTableColumnSchemaMaping.Add(tempColumnName, c);
                            }
                        }
                    }
                    #endregion

                    tempTable.fileName = f.path;
                    tempTable.tableName = f.nameWithoutExtension;
                    if (sheet.Dimension.Rows >= msrColumnNameRowIndex)
                    {
                        tempTable.columns = new EditorXlsTableColumnSchema[sheet.Dimension.Columns];
                        for (int i = 1; i <= sheet.Dimension.Columns; i++)
                        {
                            tempTableCell = new EditorXlsTableColumnSchema();
                            tempTableCell.name = sheet.GetValue<string>(msrColumnNameRowIndex, i).ToString();
                            tempTableCell.desc = sheet.GetValue<string>(msrColumnDescriptionRowIndex, i).ToString();
                            tempTableCell.type = enSQLiteDataType.String;
                            tempTableCell.arrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                            tempColumnName = tempTableCell.name.ToUpper();
                            if (srcEditorXlsTableColumnSchemaMaping.ContainsKey(tempColumnName))
                            {
                                tempTableCell.isPK = srcEditorXlsTableColumnSchemaMaping[tempColumnName].isPK;
                                tempTableCell.isNull = srcEditorXlsTableColumnSchemaMaping[tempColumnName].isNull;
                            }
                            StrayFogSQLiteDataTypeHelper.ResolveCSDataType(sheet.GetValue<string>(msrColumnTypeRowIndex, i).ToString(), ref tempTableCell.type, ref tempTableCell.arrayDimension);
                            tempTable.columns[i-1] = tempTableCell;
                        }
                    }
                    tableSchemas.Add(tempTable);
                }
            }
        }
        return tableSchemas;
    }
    #endregion

    #region ExportXlsSchemaToSqlite 生成Xls表结构到Sqlite数据库
    /// <summary>
    /// 生成Xls表结构到Sqlite数据库
    /// </summary>
    /// <returns>true:成功,false:失败</returns>
    public static bool ExportXlsSchemaToSqlite()
    {
        List<EditorXlsTableSchema> tableSchemas = ReadXlsSchema();
        return OnCreateSqliteSchema(tableSchemas) && OnCreateEntityScript(tableSchemas);
    }

    /// <summary>
    /// 创建SQLite数据库结构
    /// </summary>
    /// <param name="_tableSchemas">表架构</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnCreateSqliteSchema(List<EditorXlsTableSchema> _tableSchemas)
    {
        bool result = false;
        List<string> sbExcuteSql = new List<string>();
        StringBuilder sbSql = new StringBuilder();
        string entitySqlTemplete = EditorResxTemplete.SQLiteCreateTableTemplete;
        string determinantSqlTemplete = EditorResxTemplete.SQLiteCreateDeterminantViewTemplete;
        float progress = 0;
        #region #Column# Templete
        string columnMark = "#Column#";
        string columnReplaceTemplete = string.Empty;
        string columnTemplete = string.Empty;

        StringBuilder sbColumnReplace = new StringBuilder();
        columnTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entitySqlTemplete, columnMark, out columnReplaceTemplete);
        #endregion

        #region #PK# Templete
        string pkMark = "#PK#";
        string pkReplaceTemplete = string.Empty;
        string pkTemplete = string.Empty;

        StringBuilder sbPkReplace = new StringBuilder();
        pkTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entitySqlTemplete, pkMark, out pkReplaceTemplete);
        #endregion

        #region #PRIMARYKEY# Templete
        string primarykeyMark = "#PRIMARYKEY#";
        string primarykeyReplaceTemplete = string.Empty;
        string primarykeyTemplete = string.Empty;

        StringBuilder sbPrimarykeyReplace = new StringBuilder();
        primarykeyTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entitySqlTemplete, primarykeyMark, out primarykeyReplaceTemplete);
        #endregion

        #region #Determinant# Templete
        string determinantMark = "#Determinant#";
        string determinantReplaceTemplete = string.Empty;
        string determinantTemplete = string.Empty;

        StringBuilder sbDeterminantReplace = new StringBuilder();
        determinantTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(determinantSqlTemplete, determinantMark, out determinantReplaceTemplete);
        #endregion        

        #region 生成表        
        int index = 0;
        progress = 0;
        foreach (EditorXlsTableSchema t in _tableSchemas)
        {
            progress++;
            sbColumnReplace.Length = 0;
            sbPkReplace.Length = 0;
            sbPrimarykeyReplace.Length = 0;
            index = 0;
            foreach (EditorXlsTableColumnSchema c in t.columns)
            {
                index++;
                if (c.isPK)
                {
                    sbPkReplace.Append(
                            pkTemplete.Replace("#Name#", c.name)
                    );
                }
                sbColumnReplace.Append(
                    columnTemplete
                    .Replace("#NotNull#", c.isNull ? "" : "NOT NULL")
                    .Replace("#Name#", c.name)
                    .Replace("#DataType#", StrayFogSQLiteDataTypeHelper.GetSQLiteDataTypeName(c.type, c.arrayDimension))
                    .Replace("#Dot#", index == t.columns.Length && sbPkReplace.Length == 0 ? "" : ",")
                );
            }
            if (sbPkReplace.Length > 0)
            {
                sbPkReplace = sbPkReplace.Remove(sbPkReplace.Length - 1, 1);

                sbPrimarykeyReplace.Append(primarykeyTemplete.Replace(pkReplaceTemplete, sbPkReplace.ToString()));

                sbExcuteSql.Add(entitySqlTemplete
                .Replace("#TableName#", t.name)
                .Replace(columnReplaceTemplete, sbColumnReplace.ToString())
                .Replace(primarykeyReplaceTemplete, sbPrimarykeyReplace.ToString())
                );
            }
            else
            {
                if (sbColumnReplace.Length > 0)
                {
                    sbColumnReplace = sbColumnReplace.Remove(sbColumnReplace.Length - 1, 1);
                }
                sbExcuteSql.Add(entitySqlTemplete
                .Replace("#TableName#", t.name)
                .Replace(columnReplaceTemplete, sbColumnReplace.ToString())
                .Replace(primarykeyReplaceTemplete, sbPrimarykeyReplace.ToString())
                );
            }

            if (t.isDeterminant)
            {
                sbDeterminantReplace.Append(determinantTemplete.Replace("#Name#", t.name));
            }

            EditorUtility.DisplayProgressBar("Collection Table", t.name, progress / _tableSchemas.Count);
        }

        if (sbDeterminantReplace.Length > 0)
        {
            int ri = sbDeterminantReplace.ToString().LastIndexOf("UNION");
            sbDeterminantReplace = sbDeterminantReplace.Remove(ri, sbDeterminantReplace.Length - ri);
            sbExcuteSql.Add(determinantSqlTemplete.Replace(determinantReplaceTemplete, sbDeterminantReplace.ToString()));
        }
        result = SQLiteHelper.sqlHelper.ExecuteTransaction(sbExcuteSql.ToArray());
        #endregion

        #region 生成视图
        sbExcuteSql.Clear();
        progress = 0;
        List<EditorSelectionAsset> views = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsset>(new string[1] { EditorResxTemplete.SqliteViewSqlRoot }, enEditorAssetFilterClassify.TextAsset);
        foreach (EditorSelectionAsset v in views)
        {
            TextAsset ta = AssetDatabase.LoadAssetAtPath<TextAsset>(v.path);
            sbExcuteSql.Add(ta.text);
            EditorUtility.DisplayProgressBar("Collection View", v.nameWithoutExtension, progress / views.Count);
        }
        result = SQLiteHelper.sqlHelper.ExecuteTransaction(sbExcuteSql.ToArray());
        #endregion
        return result;
    }

    /// <summary>
    /// 创建实体脚本
    /// </summary>
    /// <param name="_tableSchemas">表架构</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnCreateEntityScript(List<EditorXlsTableSchema> _tableSchemas)
    {
        string sqliteFolder = Path.GetFullPath(enEditorApplicationFolder.Game_Script_SQLite.GetAttribute<EditorApplicationFolderAttribute>().path);
        string sqliteEntityFolder = Path.Combine(sqliteFolder, "Entities");
        string sqliteDeterminantEntitiesFolder = Path.Combine(sqliteFolder, "DeterminantEntities");

        EditorStrayFogUtility.cmd.DeleteFolder(sqliteEntityFolder);
        EditorStrayFogUtility.cmd.DeleteFolder(sqliteDeterminantEntitiesFolder);

        StringBuilder sbLog = new StringBuilder();
        List<SQLiteEntity> entities = new List<SQLiteEntity>();
        SQLiteEntity tempEntity = null;        
        string tempEntityName = string.Empty;
        string tempEntityType = string.Empty;
        string tempEntityFileName = string.Empty;
        bool tempIsDetermainant = false;        
        Dictionary<string, enSQLiteEntityClassify> classifyMaping = typeof(enSQLiteEntityClassify).NameToEnum<enSQLiteEntityClassify>();
        enSQLiteEntityClassify tempEntityClassify = enSQLiteEntityClassify.Table;
        float progress = 0;
        Dictionary<string, Dictionary<string, string>> tempColumnDescMaping = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, EditorXlsTableSchema> tempTableMaping = new Dictionary<string, EditorXlsTableSchema>();
        foreach (EditorXlsTableSchema t in _tableSchemas)
        {
            if (!tempColumnDescMaping.ContainsKey(t.name))
            {
                tempColumnDescMaping.Add(t.name, new Dictionary<string, string>());
            }
            if (!tempTableMaping.ContainsKey(t.name))
            {
                tempTableMaping.Add(t.name, t);
            }
            if (t.columns != null && t.columns.Length > 0)
            {
                foreach (EditorXlsTableColumnSchema c in t.columns)
                {
                    if (!tempColumnDescMaping[t.name].ContainsKey(c.name))
                    {
                        tempColumnDescMaping[t.name].Add(c.name, c.desc);
                    }
                }
            }
        }

        #region 收集实体            
        Int64 count = SQLiteHelper.sqlHelper.ReadEntityNamesCount();
        SqliteDataReader tableNameReader = SQLiteHelper.sqlHelper.ReadEntityNames();
        while (tableNameReader.Read())
        {
            progress++;
            tempEntityName = tableNameReader.GetString(tableNameReader.GetOrdinal("tbl_name"));
            tempEntityType = tableNameReader.GetString(tableNameReader.GetOrdinal("type"));
            tempIsDetermainant = tableNameReader.GetInt32(tableNameReader.GetOrdinal("isDetermainant")) > 0;
            foreach (KeyValuePair<string, enSQLiteEntityClassify> key in classifyMaping)
            {
                if (key.Key.ToLower().Equals(tempEntityType.ToLower()))
                {
                    tempEntityClassify = key.Value;
                    break;
                }
            }
            tempEntityFileName = string.Empty;
            if (tempTableMaping.ContainsKey(tempEntityName))
            {
                tempEntityFileName = tempTableMaping[tempEntityName].fileName;
            }
            tempEntity = new SQLiteEntity(tempEntityName, tempEntityFileName, tempEntityClassify, tempIsDetermainant);
            OnResolveEntityProperty(tempEntity, tempColumnDescMaping.ContainsKey(tempEntity.name) ? tempColumnDescMaping[tempEntity.name] : new Dictionary<string, string>());          
            entities.Add(tempEntity);
            EditorUtility.DisplayProgressBar("Collection Entity", tempEntity.name, progress / count);
        }
        #endregion

        #region 生成实体对象
        EditorTextAssetConfig cfgEntityScript = new EditorTextAssetConfig("", sqliteEntityFolder, enFileExt.CS, "");
        progress = 0;
        foreach (SQLiteEntity t in entities)
        {
            progress++;
            string entityScriptTemplete = EditorResxTemplete.SQLiteEntityScriptTemplete;

            #region #Properties#
            string propertyMark = "#Properties#";
            string propertyReplaceTemplete = string.Empty;
            string propertyTemplete = string.Empty;
            StringBuilder sbPropertyReplace = new StringBuilder();
            propertyTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, propertyMark, out propertyReplaceTemplete);
            #endregion

            #region #PK#
            string pkMark = "#PK#";
            string pkReplaceTemplete = string.Empty;
            string pkTemplete = string.Empty;
            StringBuilder sbPkReplace = new StringBuilder();
            pkTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, pkMark, out pkReplaceTemplete);
            #endregion

            #region 生成属性
            foreach (SQLiteEntityProperty p in t.properties)
            {
                sbPropertyReplace.Append(
                    propertyTemplete
                    .Replace("#Name#", p.name)
                    .Replace("#Desc#", p.desc)
                    .Replace("#Type#", p.typeName)
                    );
                if (p.isPK)
                {
                    sbPkReplace.Append(pkTemplete.Replace("#Name#", p.name));
                }
            }
            #endregion

            #region 生成脚本
            cfgEntityScript.SetName(t.className);
            if (t.isDetermainant)
            {
                cfgEntityScript.SetDirectory(sqliteDeterminantEntitiesFolder);               
            }
            else
            {
                cfgEntityScript.SetDirectory(sqliteEntityFolder);
            }
            entityScriptTemplete = entityScriptTemplete
                .Replace("#EntityName#", t.name)
                .Replace("#ClassName#", cfgEntityScript.name)
                .Replace(pkReplaceTemplete, sbPkReplace.ToString())
                .Replace(propertyReplaceTemplete, sbPropertyReplace.ToString());

            cfgEntityScript.SetText(entityScriptTemplete);
            cfgEntityScript.CreateAsset();
            #endregion

            sbLog.AppendLine(cfgEntityScript.fileName);

            EditorUtility.DisplayProgressBar("Build Entity", t.name, progress / entities.Count);
        }
        #endregion

        #region 生成实体操作扩展
        EditorTextAssetConfig cfgHeplerExtendScript = new EditorTextAssetConfig("SQLiteEntityHelperExtend", sqliteFolder, enFileExt.CS, "");
        string helperScriptTemplete = EditorResxTemplete.SQLiteEntityHelperExtendTemplete;

        #region #EntityMaping#
        string entityMapingMark = "#EntityMaping#";
        string entityMapingReplaceTemplete = string.Empty;
        string entityMapingTemplete = string.Empty;
        StringBuilder sbEntityMapingReplace = new StringBuilder();
        entityMapingTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(helperScriptTemplete, entityMapingMark, out entityMapingReplaceTemplete);
        #endregion

        progress = 0;
        int xlsColumnNameIndex = 0;
        int xlsColumnDataIndex = 0;
        int xlsColumnTypeIndex = 0;
        int xlsDataStartRowIndex = msrColumnDataRowStartIndex;
        foreach (SQLiteEntity t in entities)
        {
            progress++;
            if (t.isDetermainant)
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
            sbEntityMapingReplace.Append(
                entityMapingTemplete
                .Replace("#ClassName#", t.className)
                .Replace("#TableName#", t.name)                
                .Replace("#XlsFileName#", t.fileName)
                .Replace("#IsDeterminant#",Convert.ToString(t.isDetermainant).ToLower())
                .Replace("#Classify#", t.classify.ToString())
                .Replace("#xlsColumnNameIndex#", xlsColumnNameIndex.ToString())
                .Replace("#xlsColumnDataIndex#", xlsColumnDataIndex.ToString())
                .Replace("#xlsColumnTypeIndex#", xlsColumnTypeIndex.ToString())
                .Replace("#xlsDataStartRowIndex#", xlsDataStartRowIndex.ToString())
                );
            EditorUtility.DisplayProgressBar("Build Entity Extend", t.name, progress / entities.Count);
        }
        cfgHeplerExtendScript.SetText(helperScriptTemplete.Replace(entityMapingReplaceTemplete, sbEntityMapingReplace.ToString()));
        cfgHeplerExtendScript.CreateAsset();
        #endregion

        SQLiteHelper.sqlHelper.Close();
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log(sbLog.ToString());
        Debug.Log("BuildSQLiteEntity Succeed!");
        return true;
    }

    /// <summary>
    /// 解析实体属性
    /// </summary>
    /// <param name="_entity">实体</param>
    /// <param name="_propertyDescMaping">属性描述映射</param>
    static void OnResolveEntityProperty(SQLiteEntity _entity, Dictionary<string, string> _propertyDescMaping)
    {
        SqliteDataReader pragmaReader = null;
        SqliteDataReader schemaReader = null;
        SQLiteEntityProperty tempEntityProperty = null;
        Type tempPropertyType = null;
        bool tempMatchPropertyType = false;
        enSQLiteDataType tempSQLiteDataType = enSQLiteDataType.String;
        enSQLiteDataTypeArrayDimension tempSQLiteDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;

        if (_entity.isDetermainant)
        {
            List<string> columnNames = new List<string>();
            msrXlsTableSrcAsset.SetName(_entity.name);
            using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ExcelPackage pck = new ExcelPackage(fs);
                _entity.properties.Clear();
                if (pck.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
                    {
                        for (int i = msrColumnDataRowStartIndex; i <= sheet.Dimension.Rows; i++)
                        {
                            tempEntityProperty = new SQLiteEntityProperty(sheet.GetValue<string>(i, msrDeterminantColumnNameColumnIndex).ToString());
                            tempSQLiteDataType = enSQLiteDataType.String;
                            tempSQLiteDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                            StrayFogSQLiteDataTypeHelper.ResolveCSDataType(sheet.GetValue<string>(i, msrDeterminantColumnTypeColumnIndex).ToString(), ref tempSQLiteDataType, ref tempSQLiteDataTypeArrayDimension);
                            tempEntityProperty.sqliteDataTypeName = StrayFogSQLiteDataTypeHelper.GetSQLiteDataTypeName(tempSQLiteDataType, tempSQLiteDataTypeArrayDimension);
                            tempEntityProperty.typeName = StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(tempSQLiteDataType, tempSQLiteDataTypeArrayDimension);
                            tempEntityProperty.desc = sheet.GetValue<string>(i, msrDeterminantColumnDescriptionColumnIndex).ToString();
                            _entity.properties.Add(tempEntityProperty);
                        }
                    }
                }
            }
        }
        else
        {
            pragmaReader = SQLiteHelper.sqlHelper.ReadTablePragma(_entity.name);
            schemaReader = SQLiteHelper.sqlHelper.ReadTableSchema(_entity.name);
            //收集列名
            while (pragmaReader.Read())
            {
                tempEntityProperty = new SQLiteEntityProperty(pragmaReader.GetString(pragmaReader.GetOrdinal("name")));
                tempEntityProperty.isPK = pragmaReader.GetInt64(pragmaReader.GetOrdinal("pk")) > 0;
                tempEntityProperty.sqliteDataTypeName = pragmaReader.GetString(pragmaReader.GetOrdinal("type"));
                _entity.properties.Add(tempEntityProperty);
            }
            //收集列类型
            foreach (SQLiteEntityProperty c in _entity.properties)
            {
                tempMatchPropertyType = false;
                tempSQLiteDataType = enSQLiteDataType.String;
                tempSQLiteDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                tempPropertyType = schemaReader.GetFieldType(schemaReader.GetOrdinal(c.name));
                c.typeName = StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(tempSQLiteDataType, tempSQLiteDataTypeArrayDimension);
                if (_propertyDescMaping.ContainsKey(c.name))
                {
                    c.desc = _propertyDescMaping[c.name];
                }
                else
                {
                    c.desc = c.name;
                }
                if (!string.IsNullOrEmpty(c.sqliteDataTypeName))
                {
                    tempMatchPropertyType = StrayFogSQLiteDataTypeHelper.ResolveSQLiteDataType(c.sqliteDataTypeName, ref tempSQLiteDataType, ref tempSQLiteDataTypeArrayDimension);
                    if (tempMatchPropertyType)
                    {
                        c.typeName = StrayFogSQLiteDataTypeHelper.GetCSDataTypeName(tempSQLiteDataType, tempSQLiteDataTypeArrayDimension);
                    }
                    else
                    {
                        c.typeName = tempPropertyType.FullName;
                    }
                }
            }
        }        
    }

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

    #region AssetDiskMaping表操作
    /// <summary>
    /// AssetDiskMapingFolder表
    /// </summary>
    static readonly string msrXlsName_AssetDiskMapingFolder = "AssetDiskMapingFolder";

    /// <summary>
    /// AssetDiskMapingFileExt表
    /// </summary>
    static readonly string msrXlsName_AssetDiskMapingFileExt = "AssetDiskMapingFileExt";

    /// <summary>
    /// AssetDiskMapingFile表
    /// </summary>
    static readonly string msrXlsName_AssetDiskMapingFile = "AssetDiskMapingFile";

    #region InsertDataToAssetDiskMapingFolder 插入数据到AssetDiskMapingFolder表
    /// <summary>
    /// 插入数据到AssetDiskMapingFolder表
    /// </summary>
    /// <param name="_nodes">节点</param>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertDataToAssetDiskMapingFolder(List<EditorSelectionAssetDiskMaping> _nodes,Action<string,float> _progressCallback)
    {
        msrXlsTableSrcAsset.SetName(msrXlsName_AssetDiskMapingFolder);
        OnClearXlsData(msrXlsTableSrcAsset.name);
        string newXlsPath = msrXlsTableSrcAsset.fileName + "." + msrXlsTableSrcAsset.ext;
        List<int> saveIds = new List<int>();
        int sameRows = 0;
        using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        {
            ExcelPackage pck = new ExcelPackage(fs);
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
            pck.SaveAs(new FileInfo(newXlsPath));
        }
        if (File.Exists(newXlsPath))
        {
            File.Delete(msrXlsTableSrcAsset.fileName);
            File.Move(newXlsPath, msrXlsTableSrcAsset.fileName);
        }
    }
    #endregion

    #region InsertDataToAssetDiskMapingFileExt 插入数据到AssetDiskMapingFileExt表
    /// <summary>
    /// 插入数据到AssetDiskMapingFileExt表
    /// </summary>
    /// <param name="_nodes">节点</param>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertDataToAssetDiskMapingFileExt(List<EditorSelectionAssetDiskMaping> _nodes, Action<string, float> _progressCallback)
    {
        msrXlsTableSrcAsset.SetName(msrXlsName_AssetDiskMapingFileExt);
        OnClearXlsData(msrXlsTableSrcAsset.name);
        string newXlsPath = msrXlsTableSrcAsset.fileName + "." + msrXlsTableSrcAsset.ext;
        List<int> saveIds = new List<int>();
        int sameRows = 0;
        using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        {
            ExcelPackage pck = new ExcelPackage(fs);
            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (!saveIds.Contains(_nodes[i].fileExtHashCode))
                {
                    saveIds.Add(_nodes[i].fileExtHashCode);
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 1].Value = _nodes[i].fileExtHashCode;
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 2].Value = _nodes[i].ext;
                }
                else
                {
                    sameRows++;
                }
                _progressCallback(_nodes[i].name, (i + 1) / (float)_nodes.Count);
            }
            pck.SaveAs(new FileInfo(newXlsPath));
        }
        if (File.Exists(newXlsPath))
        {
            File.Delete(msrXlsTableSrcAsset.fileName);
            File.Move(newXlsPath, msrXlsTableSrcAsset.fileName);
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
        msrXlsTableSrcAsset.SetName(msrXlsName_AssetDiskMapingFile);
        OnClearXlsData(msrXlsTableSrcAsset.name);
        string newXlsPath = msrXlsTableSrcAsset.fileName + "." + msrXlsTableSrcAsset.ext;
        List<int> saveIds = new List<int>();
        int sameRows = 0;
        using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        {
            ExcelPackage pck = new ExcelPackage(fs);
            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
            for (int i = 0; i < _nodes.Count; i++)
            {
                if (!saveIds.Contains(_nodes[i].guidHashCode))
                {
                    saveIds.Add(_nodes[i].guidHashCode);
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 1].Value = _nodes[i].fileId;
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 2].Value = _nodes[i].folderId;
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 3].Value = _nodes[i].fileInSide;
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 4].Value = _nodes[i].fileOutSide;
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 5].Value = _nodes[i].fileExtHashCode;
                    sheet.Cells[msrColumnDataRowStartIndex + i - sameRows, 6].Value = _nodes[i].fileExtEnumValue;
                }
                else
                {
                    sameRows++;
                }
                _progressCallback(_nodes[i].name, (i + 1) / (float)_nodes.Count);
            }
            pck.SaveAs(new FileInfo(newXlsPath));
        }
        if (File.Exists(newXlsPath))
        {
            File.Delete(msrXlsTableSrcAsset.fileName);
            File.Move(newXlsPath, msrXlsTableSrcAsset.fileName);
        }
    }
    #endregion

    #endregion

    #region UIWindowSetting表操作
    /// <summary>
    /// UIWindowSetting表
    /// </summary>
    static readonly string msrXlsName_UIWindowSetting = "UIWindowSetting";

    #region DeleteAllUIWindowSetting 删除所有窗口设置
    /// <summary>
    /// 删除所有窗口设置
    /// </summary>
    public static void DeleteAllUIWindowSetting()
    {
        OnClearXlsData(msrXlsName_UIWindowSetting);
    }
    #endregion

    #region DeleteUIWindowSetting 删除指定窗口设置
    /// <summary>
    /// 删除所有窗口设置
    /// </summary>
    /// <param name="_winId">窗口id</param>
    public static void DeleteUIWindowSetting(int _winId)
    {
        msrXlsTableSrcAsset.SetName(msrXlsName_UIWindowSetting);
        string newXlsPath = msrXlsTableSrcAsset.fileName + "." + msrXlsTableSrcAsset.ext;
        bool isDel = false;
        int delCount = 0;
        using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        {
            ExcelPackage pck = new ExcelPackage(fs);
            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
            if (sheet.Dimension.Rows >= msrColumnDataRowStartIndex)
            {
                int maxRow = sheet.Dimension.Rows;
                for (int row = msrColumnDataRowStartIndex; row <= maxRow; row++)
                {
                    if (sheet.GetValue<int>(row - delCount, 1) == _winId)
                    {
                        sheet.DeleteRow(row - delCount, 1, true);
                        isDel |= true;
                        delCount++;
                    }
                }
                if (isDel)
                {
                    pck.SaveAs(new FileInfo(newXlsPath));
                }                
            }
        }
        if (File.Exists(newXlsPath))
        {
            File.Delete(msrXlsTableSrcAsset.fileName);
            File.Move(newXlsPath, msrXlsTableSrcAsset.fileName);
        }
    }
    #endregion

    #region InsertUIWindowSetting 插入窗口设置
    /// <summary>
    /// 删除所有窗口设置
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_progressCallback">进度回调</param>
    public static void InsertUIWindowSetting(List<EditorSelectionUIWindowSetting> _windows, Action<string, float> _progressCallback)
    {
        DeleteAllUIWindowSetting();
        msrXlsTableSrcAsset.SetName(msrXlsName_UIWindowSetting);
        string newXlsPath = msrXlsTableSrcAsset.fileName + "." + msrXlsTableSrcAsset.ext;
        using (FileStream fs = new FileStream(msrXlsTableSrcAsset.fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        {
            ExcelPackage pck = new ExcelPackage(fs);
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
            pck.SaveAs(new FileInfo(newXlsPath));
        }
        if (File.Exists(newXlsPath))
        {
            File.Delete(msrXlsTableSrcAsset.fileName);
            File.Move(newXlsPath, msrXlsTableSrcAsset.fileName);
        }
    }
    #endregion
    #endregion
}
