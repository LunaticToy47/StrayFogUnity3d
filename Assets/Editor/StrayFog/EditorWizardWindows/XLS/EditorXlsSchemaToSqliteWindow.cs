using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 导出XLS表架构到Sqlite数据库
/// </summary>
public class EditorXlsSchemaToSqliteWindow : AbsEditorWindow
{
    /// <summary>
    /// 表格架构
    /// </summary>
    List<EditorXlsTableSchema> mXlsTableSchemas = new List<EditorXlsTableSchema>();

    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;

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
        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
        for (int i = 0; i < mXlsTableSchemas.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Format("{0}. {1}", (i + 1).PadLeft(mXlsTableSchemas.Count), mXlsTableSchemas[i].tableName));            
            if (GUILayout.Button("Setting"))
            {
                EditorStrayFogApplication.PingObject(mXlsTableSchemas[i]);
            }
            if (GUILayout.Button("Brower"))
            {
                EditorStrayFogApplication.PingObject(mXlsTableSchemas[i].fileName);
            }
            if (GUILayout.Button("Reveal"))
            {
                EditorStrayFogApplication.RevealInFinder(mXlsTableSchemas[i].fileName);
            }
            if (GUILayout.Button("Open"))
            {
                EditorStrayFogApplication.OpenFile(Path.GetFullPath(mXlsTableSchemas[i].fileName));
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Export Xls Schema To Sqlite"))
        {
            EditorStrayFogExecute.ExecuteExportXlsSchemaToSqlite();
        }
    }
    #endregion
}
