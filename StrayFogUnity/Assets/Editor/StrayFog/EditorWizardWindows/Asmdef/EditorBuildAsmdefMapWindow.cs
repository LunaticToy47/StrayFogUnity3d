#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成Asmdef脚本映射
/// </summary>
public class EditorBuildAsmdefMapWindow : AbsEditorWindow
{
    /// <summary>
    /// Asmdef配置
    /// </summary>
    EditorXlsFileConfigForAsmdefMap mConfig;
    /// <summary>
    /// Asmdef文件组
    /// </summary>
    List<EditorSelectionAsmdefMapSetting> mAsmdefs = new List<EditorSelectionAsmdefMapSetting>();
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setXlsFileConfigForAsmdefMap;        
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
        EditorGUILayout.LabelField("Asmdef Map Config File:");
        mConfig.DrawGUI();
        EditorGUILayout.Separator();
        if (GUILayout.Button("Load Asmdef"))
        {
            mAsmdefs.Clear();
            List<EditorSelectionAsmdefMapSetting> asmdefs = EditorStrayFogExecute.ExecuteLookPackageAsmdef();
            foreach (EditorSelectionAsmdefMapSetting s in asmdefs)
            {
                s.Resolve();
                mAsmdefs.Add(s);
            }
        }
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
        for (int i = 0; i < mAsmdefs.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Format("{0}. 【{1}】", 
                (i + 1).PadLeft(mAsmdefs.Count), mAsmdefs[i].name));
            mAsmdefs[i].assetNode.isHotfix = EditorGUILayout.ToggleLeft("isHotfix", mAsmdefs[i].assetNode.isHotfix);

            if (GUILayout.Button("Setting"))
            {
                EditorStrayFogApplication.PingObject(mAsmdefs[i].assetNode);
            }
            if (GUILayout.Button("Brower"))
            {
                EditorStrayFogApplication.PingObject(mAsmdefs[i].path);
            }
            if (GUILayout.Button("Reveal"))
            {
                EditorStrayFogApplication.RevealInFinder(mAsmdefs[i].path);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Export Asmdef Map To XLS"))
        {
            EditorStrayFogExecute.ExecuteAsmdefToXLS();
            EditorUtility.DisplayDialog("Asmdef Map", "ExportAsmdefMapToXLS successed.", "OK");
        }
    }
    #endregion
}
#endif
