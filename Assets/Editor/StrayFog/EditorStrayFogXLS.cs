using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
/// <summary>
/// 编辑器XLS工具
/// </summary>
public sealed class EditorStrayFogXLS
{
    #region XLS 变量    
    /// <summary>
    /// 列名称行索引
    /// </summary>
    static readonly int msrColumnNameRowIndex = 0;
    /// <summary>
    /// 列类型行索引
    /// </summary>
    static readonly int msrColumnTypeRowIndex = 1;
    /// <summary>
    /// 列描述行索引
    /// </summary>
    static readonly int msrColumnDescriptionRowIndex = 2;
    /// <summary>
    /// 表数据行起始索引
    /// </summary>
    static readonly int msrColumnDataRowStartIndex = 3;
    /// <summary>
    /// 语言包属性键值起始索引
    /// </summary>
    static readonly int msrColumnDataLangPackRowStartIndex = 1;
    /// <summary>
    /// 类名后缀
    /// </summary>
    public static readonly string msrClassNameSuffix = "Xls";
    #endregion

    #region 内部 readonly 变量
    /// <summary>
    /// 一维数组分隔符
    /// </summary>
    static readonly string[] msrOneArraySeparate = new string[] { @"|" };
    /// <summary>
    /// 元素分隔符
    /// </summary>
    static readonly string[] msrElementSeparate = new string[] { @"," };
    #endregion

    #region public readonly 变量  
    /// <summary>
    /// 分隔符说明
    /// </summary>
    public static readonly string msrSeparateDescription = "1.一维数组\"|\"竖线分隔,例:1|2|3" + System.Environment.NewLine + "2.二维数组\"|\"竖线分隔一维,\",\"逗号分隔二维,例:A0,A1,A2|B0,B1,B2";

    /// <summary>
    /// SQLite数据类别映射
    /// </summary>
    public static readonly Dictionary<enSQLiteDataType, CodeAttribute> msrSQLiteDataTypeMaping =
                        typeof(enSQLiteDataType).EnumToAttribute<enSQLiteDataType, CodeAttribute>();
    /// <summary>
    /// SQLite数据类别数组维度映射
    /// </summary>
    public static readonly Dictionary<enSQLiteDataTypeArrayDimension, CodeAttribute> msrSQLiteDataTypeArrayDimensionMaping =
                        typeof(enSQLiteDataTypeArrayDimension).EnumToAttribute<enSQLiteDataTypeArrayDimension, CodeAttribute>();
    #endregion    

    #region ReadXlsSchema 读取XLS表结构框架
    /// <summary>
    /// XLS表架构文件
    /// </summary>
    static readonly EditorEngineAssetConfig msrXlsTableMapingAsset = new EditorEngineAssetConfig("",
        enEditorApplicationFolder.XLS_TableMaping.GetAttribute<EditorApplicationFolderAttribute>().path,
        enFileExt.Asset,"");

    /// <summary>
    /// 读取XLS表结构框架
    /// </summary>
    /// <returns>XLS表结构框架</returns>
    public static List<EditorXlsTableSchema> ReadXlsSchema()
    {
        List<EditorXlsTableSchema> tableSchemas = new List<EditorXlsTableSchema>();
        string[] xlsFolders = new string[1] { enEditorApplicationFolder.XLS_TableSrc.GetAttribute<EditorApplicationFolderAttribute>().path };
        FileExtAttribute fileExt = enFileExt.Xls.GetAttribute<FileExtAttribute>();
        List<EditorSelectionAsset> xlsFiles = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsset>(xlsFolders, enEditorAssetFilterClassify.DefaultAsset, false, (n) => { return n.ext.ToUpper() == fileExt.ext.ToUpper(); });
        EditorXlsTableSchema tempTable = null;
        EditorXlsTableColumnSchema tempTableCell = null;
        
        string tempColumnName = string.Empty;
        foreach (EditorSelectionAsset f in xlsFiles)
        {
            Workbook book = Workbook.Open(f.path);
            if (book.Worksheets.Count > 0)
            {
                Worksheet sheet = book.Worksheets[0];
                List<string> lstColumnName = new List<string>();

                #region XLS表中是否有同名列
                if (sheet.Cells.LastRowIndex >= msrColumnNameRowIndex)
                {
                    for (int i = 0; i <= sheet.Cells.LastColIndex; i++)
                    {
                        tempColumnName = sheet.Cells[msrColumnNameRowIndex, i].StringValue.ToUpper();
                        if (!lstColumnName.Contains(tempColumnName))
                        {
                            lstColumnName.Add(tempColumnName);
                        }
                        else
                        {
                            throw new UnityException(string.Format("There are same column【{0}】 in xls【{1}】", 
                                sheet.Cells[msrColumnNameRowIndex, i].StringValue, f.path));
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
                if (sheet.Cells.LastRowIndex >= msrColumnNameRowIndex)
                {
                    tempTable.columns = new EditorXlsTableColumnSchema[sheet.Cells.LastColIndex + 1];
                    for (int i = 0; i <= sheet.Cells.LastColIndex; i++)
                    {
                        tempTableCell = new EditorXlsTableColumnSchema();
                        tempTableCell.name = sheet.Cells[msrColumnNameRowIndex, i].StringValue;
                        tempTableCell.desc = sheet.Cells[msrColumnDescriptionRowIndex, i].StringValue;
                        tempTableCell.type = enSQLiteDataType.String;
                        tempTableCell.arrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                        tempColumnName = tempTableCell.name.ToUpper();
                        if (srcEditorXlsTableColumnSchemaMaping.ContainsKey(tempColumnName))
                        {
                            tempTableCell.isPK = srcEditorXlsTableColumnSchemaMaping[tempColumnName].isPK;
                        }
                        ResolveCSDataType(sheet.Cells[msrColumnTypeRowIndex, i].StringValue,ref tempTableCell.type,ref tempTableCell.arrayDimension);                        
                        tempTable.columns[i] = tempTableCell;
                    }
                }
                tableSchemas.Add(tempTable);
            }
        }
        return tableSchemas;
    }
    #endregion

    #region ExecuteExportXlsSchemaToSqlite 生成Xls表结构到Sqlite数据库
    /// <summary>
    /// 生成Xls表结构到Sqlite数据库
    /// </summary>
    public static void ExecuteExportXlsSchemaToSqlite()
    {
        List<EditorXlsTableSchema> tableSchemas = ReadXlsSchema();
        StringBuilder sbSql = new StringBuilder();
        foreach (EditorXlsTableSchema t in tableSchemas)
        {

        }
        //msrSQLiteDataTypeMaping
        //msrSQLiteDataTypeArrayDimensionMaping
    }
    #endregion

    #region TransDescToSummary 转换描述为Summary形式
    /// <summary>
    /// 转换描述为Summary形式
    /// </summary>
    /// <param name="_desc">描述</param>
    /// <returns>描述</returns>
    public static string TransDescToSummary(string _desc)
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

    #region ResolveCSDataType 解析列CS数据类型
    /// <summary>
    /// CSDataType映射
    /// </summary>
    static Dictionary<int, enSQLiteDataType> msCSDataTypeMaping = new Dictionary<int, enSQLiteDataType>();
    /// <summary>
    /// CSDataTypeArrayDimension映射
    /// </summary>
    static Dictionary<int, enSQLiteDataTypeArrayDimension> msCSDataTypeArrayDimensionMaping = new Dictionary<int, enSQLiteDataTypeArrayDimension>();
    /// <summary>
    /// 解析列CS数据类型
    /// </summary>
    /// <param name="_csTypeValue">cs列类型值</param>
    /// <param name="_dataType">数据类型</param>
    /// <param name="_dataTypeArrayDimension">数据数组类型</param>
    public static void ResolveCSDataType(string _csTypeValue, ref enSQLiteDataType _dataType, ref enSQLiteDataTypeArrayDimension _dataTypeArrayDimension)
    {
        int hashCode = _csTypeValue.GetHashCode();
        string typeValue = string.Empty;
        string dimValue = string.Empty;
        typeValue = dimValue = _csTypeValue;
        foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionMaping)
        {
            if (!string.IsNullOrEmpty(key.Value.csTypeName))
            {
                typeValue = typeValue.Replace(key.Value.csTypeName, "");
            }
        }
        dimValue = dimValue.Replace(typeValue, "");

        if (!msCSDataTypeMaping.ContainsKey(hashCode))
        {
            foreach (KeyValuePair<enSQLiteDataType, CodeAttribute> key in msrSQLiteDataTypeMaping)
            {
                if (typeValue.ToUpper().Equals(key.Value.csTypeName.ToUpper()))
                {
                    _dataType = key.Key;
                    msCSDataTypeMaping.Add(hashCode, key.Key);
                    break;
                }
            }
        }
        else
        {
            _dataType = msCSDataTypeMaping[hashCode];
        }

        if (!msCSDataTypeArrayDimensionMaping.ContainsKey(hashCode))
        {
            foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionMaping)
            {
                if (string.IsNullOrEmpty(dimValue) || dimValue.ToUpper().Equals(key.Value.csTypeName.ToUpper()))
                {
                    _dataTypeArrayDimension = key.Key;
                    msCSDataTypeArrayDimensionMaping.Add(hashCode, key.Key);
                    break;
                }
            }
        }
        else
        {
            _dataTypeArrayDimension = msCSDataTypeArrayDimensionMaping[hashCode];
        }
    }
    #endregion
}
