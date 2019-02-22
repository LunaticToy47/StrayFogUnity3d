#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 导出XLS表架构到Sqlite数据库
/// </summary>
public class EditorBuildXlsSchemaToSqliteWindow : AbsEditorWindow
{
    /// <summary>
    /// 配置
    /// </summary>
    EditorFolderConfigForSchemaToSqlite mConfig;

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setFolderConfigForSchemaToSqlite;
    }

    /// <summary>
    /// 表格架构
    /// </summary>
    List<EditorXlsTableSchema> mXlsTableSchemas = new List<EditorXlsTableSchema>();

    

    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    
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
        EditorGUILayout.LabelField("XlsSchemaToSqlite Folders:");
        mConfig.DrawGUI();
        EditorGUILayout.Separator();
        EditorGUILayout.HelpBox(EditorStrayFogXLS.msrSeparateDescription, MessageType.None);
        if (GUILayout.Button("SQLiteDataType Code Sequence"))
        {
            EditorStrayFogApplication.CopyToClipboard(EditorStrayFogXLS.msrSQLiteDataTypeCodeSequence);
            Debug.Log(EditorStrayFogXLS.msrSQLiteDataTypeCodeSequence);
        }
        EditorGUILayout.Separator();
        if (GUILayout.Button("Load XLS"))
        {
            mXlsTableSchemas = EditorStrayFogXLS.ReadXlsSchema();
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
            EditorGUILayout.LabelField(string.Format("{0}. 【{1}】{2}", (i + 1).PadLeft(mXlsTableSchemas.Count), mXlsTableSchemas[i].dbName ,mXlsTableSchemas[i].tableName));

            if (GUILayout.Button("Setting"))
            {
                EditorStrayFogApplication.PingObject(mXlsTableSchemas[i].tableSchemaAssetPath);
            }
            
            mXlsTableSchemas[i].isDeterminant = EditorGUILayout.ToggleLeft("是否是行列式表", mXlsTableSchemas[i].isDeterminant);
            mXlsTableSchemas[i].canModifyData = EditorGUILayout.ToggleLeft("是否可修改数据", mXlsTableSchemas[i].canModifyData);

            EditorUtility.SetDirty(mXlsTableSchemas[i]);            
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
            EditorUtility.DisplayDialog("XlsSchema", "ExecuteExportXlsSchemaToSqlite successed.", "OK");
        }
    }
    #endregion
}
#endif
