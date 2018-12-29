using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 导出XLS表到Sqlite数据库
/// </summary>
public class EditorExportXlsDataToSqliteWindow : AbsEditorWindow
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
            mXlsTableSchemas[i].isDeterminant = EditorGUILayout.ToggleLeft("是否是行列式表",mXlsTableSchemas[i].isDeterminant);
            if (mXlsTableSchemas[i].isDeterminant && mXlsTableSchemas[i].columns.Length != 2)
            {
                mXlsTableSchemas[i].isDeterminant = false;
                EditorUtility.DisplayDialog("Determinant", "Determinant table must be only two columns.", "OK");
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

        if (GUILayout.Button("Export Xls Data To Sqlite"))
        {
            EditorStrayFogExecute.ExecuteExportXlsDataToSqlite();
        }
    }
    #endregion
}
