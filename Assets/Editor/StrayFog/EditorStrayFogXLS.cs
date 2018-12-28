using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
/// <summary>
/// 编辑器XLS工具
/// </summary>
public sealed class EditorStrayFogXLS
{
    #region XLS 变量
    /// <summary>
    /// 列描述行索引
    /// </summary>
    static readonly int msrColumnDescriptionRowIndex = 0;
    /// <summary>
    /// 列名称行索引
    /// </summary>
    static readonly int msrColumnNameRowIndex = 2;
    /// <summary>
    /// 列类型行索引
    /// </summary>
    static readonly int msrColumnTypeRowIndex = 1;
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
    /// Xls表格列类型代码序列说明
    /// </summary>
    public static readonly string msrXlsTableColumnTypeCodeSequenceDescription = "参考TableColumnMaping.xls表，将列类型代码序列复制到CellType页的第一行，做为TableData页的列类型序列数据源";
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

    /// <summary>
    /// Xls表格列类型代码序列
    /// </summary>
    public static readonly string msrXlsTableColumnTypeCodeSequence = OnBuilderXlsTableColumnTypeCodeSequence();
    #endregion

    #region OnBuilderXlsTableColumnTypeCodeSequence 生成XLS配置表列类别代码序列
    /// <summary>
    /// 生成XLS配置表列类别代码序列
    /// </summary>
    /// <returns></returns>
    static string OnBuilderXlsTableColumnTypeCodeSequence()
    {
        StringBuilder sbSeq = new StringBuilder();
        foreach (CodeAttribute a in msrSQLiteDataTypeArrayDimensionMaping.Values)
        {
            foreach (CodeAttribute t in msrSQLiteDataTypeMaping.Values)
            {
                sbSeq.AppendFormat("{0}{1}\t", t.csTypeName, a.csTypeName);
            }
        }
        if (sbSeq.Length > 0)
        {
            sbSeq = sbSeq.Remove(sbSeq.Length - 1, 1);
        }
        return sbSeq.ToString();
    }
    #endregion

    #region ReadXlsSchema 读取XLS表结构框架
    /// <summary>
    /// 读取XLS表结构框架
    /// </summary>
    /// <returns>XLS表结构框架</returns>
    public static List<EditorXlsTableSchema> ReadXlsSchema()
    {
        List<EditorXlsTableSchema> tableSchema = new List<EditorXlsTableSchema>();
        string[] xlsFolders = new string[1] { enEditorApplicationFolder.XLS_TableSrc.GetAttribute<EditorApplicationFolderAttribute>().path };
        FileExtAttribute fileExt = enFileExt.Xls.GetAttribute<FileExtAttribute>();
        List<EditorSelectionAsset> xlsFiles = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAsset>(xlsFolders, enEditorAssetFilterClassify.DefaultAsset, false, (n) => { return n.ext.ToUpper() == fileExt.ext.ToUpper(); });
        EditorXlsTableSchema tempTable = null;
        EditorXlsTableColumnSchema tempTableCell = null;
        string typeValue = string.Empty;
        string dimValue = string.Empty;
        foreach (EditorSelectionAsset f in xlsFiles)
        {
            Workbook book = Workbook.Open(f.path);
            if (book.Worksheets.Count > 0)
            {
                Worksheet sheet = book.Worksheets[0];
                tempTable = new EditorXlsTableSchema();
                tempTable.fileName = f.path;
                tempTable.tableName = f.nameWithoutExtension;
                if (sheet.Cells.LastRowIndex >= msrColumnNameRowIndex)
                {
                    tempTable.columns = new EditorXlsTableColumnSchema[sheet.Cells.LastColIndex + 1];
                    for (int i = 0; i <= sheet.Cells.LastColIndex; i++)
                    {
                        tempTableCell = new EditorXlsTableColumnSchema();
                        tempTableCell.name = sheet.Cells[msrColumnNameRowIndex, i].StringValue;
                        tempTableCell.desc = TransDescToSummary(sheet.Cells[msrColumnDescriptionRowIndex, i].StringValue);
                        tempTableCell.type = enSQLiteDataType.String;
                        tempTableCell.arrayDimension = enSQLiteDataTypeArrayDimension.NoArray;

                        typeValue = dimValue = sheet.Cells[msrColumnTypeRowIndex, i].StringValue;
                        foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionMaping)
                        {
                            if (!string.IsNullOrEmpty(key.Value.csTypeName))
                            {
                                typeValue = typeValue.Replace(key.Value.csTypeName, "");
                            }
                        }

                        dimValue = dimValue.Replace(typeValue, "");

                        foreach (KeyValuePair<enSQLiteDataType, CodeAttribute> key in msrSQLiteDataTypeMaping)
                        {
                            if (typeValue.ToUpper().Equals(key.Value.csTypeName.ToUpper()))
                            {
                                tempTableCell.type = key.Key;                          
                                break;
                            }
                        }
                        foreach (KeyValuePair<enSQLiteDataTypeArrayDimension, CodeAttribute> key in msrSQLiteDataTypeArrayDimensionMaping)
                        {
                            if (string.IsNullOrEmpty(dimValue) || dimValue.ToUpper().Equals(key.Value.csTypeName.ToUpper()))
                            {
                                tempTableCell.arrayDimension = key.Key;
                                break;
                            }
                        }
                        tempTable.columns[i] = tempTableCell;
                    }
                }
                tableSchema.Add(tempTable);
            }
        }
        return tableSchema;
    }

    /// <summary>
    /// 转换描述为Summary形式
    /// </summary>
    /// <param name="_desc">描述</param>
    /// <returns>描述</returns>
    static string TransDescToSummary(string _desc)
    {
        StringBuilder descSb = new StringBuilder();
        StringReader reader = new StringReader(_desc);
        string line = string.Empty;
        int num = 0;
        descSb.AppendLine("/// <summary>");
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
        descSb.AppendLine("/// </summary>");
        return descSb.ToString();
    }
    #endregion
}
