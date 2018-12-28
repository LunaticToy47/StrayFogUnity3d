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
        mXlsTableSchemas = EditorStrayFogXLS.ReadXlsSchema();
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        DrawBrower();
        DrawAssetNodes();        
    }

    #region DrawBrower
    /// <summary>
    /// DrawBrower
    /// </summary>
    void DrawBrower()
    {
        EditorGUILayout.Separator();
        EditorGUILayout.HelpBox(EditorStrayFogXLS.msrSeparateDescription, MessageType.None);
        EditorGUILayout.Separator();
        if (GUILayout.Button(EditorStrayFogXLS.msrXlsTableColumnTypeCodeSequenceDescription))
        {
            EditorStrayFogApplication.CopyToClipboard(EditorStrayFogXLS.msrXlsTableColumnTypeCodeSequence);
            Debug.Log(EditorStrayFogXLS.msrXlsTableColumnTypeCodeSequence);
        }
        EditorGUILayout.Separator();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        if (GUILayout.Button("ExportXlsToSqlite"))
        {

        }
    }
    #endregion
}
