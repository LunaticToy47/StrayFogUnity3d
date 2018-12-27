using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 导出XLS表到Sqlite数据库
/// </summary>
public class EditorExportXlsToSqliteWindow : AbsEditorWindow
{
    /// <summary>
    /// 表格架构
    /// </summary>
    List<EditorXlsTableSchema> mXlsTableSchemas = new List<EditorXlsTableSchema>();

    /// <summary>
    /// OnFocus
    /// </summary>
    private void OnFocus()
    {
        mXlsTableSchemas = EditorXLSUtility.ReadXlsSchema();
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        
    }
}
