using ExcelLibrary.SpreadSheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 编辑器XLS工具
/// </summary>
public sealed class EditorXLSUtility
{
    #region 变量
    /// <summary>
    /// 列描述行索引
    /// </summary>
    static readonly int msrColumnDescriptionRowIndex = 0;
    /// <summary>
    /// 列名称行索引
    /// </summary>
    static readonly int msrColumnNameRowIndex = 1;
    /// <summary>
    /// 表数据行起始索引
    /// </summary>
    static readonly int msrColumnDataRowStartIndex = msrColumnNameRowIndex + 1;
    /// <summary>
    /// 语言包属性键值起始索引
    /// </summary>
    static readonly int msrColumnDataLangPackRowStartIndex = 1;
    /// <summary>
    /// 类名后缀
    /// </summary>
    public static readonly string msrClassNameSuffix = "Xls";
    #endregion

    #region 映射文件变量
    /// <summary>
    /// XLS表源文件
    /// </summary>
    public static readonly EditorEngineAssetConfig editorXlsTableSrcRoot = new EditorEngineAssetConfig("",
        enEditorApplicationFolder.XLS_TableSrc.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Xls, "");
    #endregion

    //Schema

}
