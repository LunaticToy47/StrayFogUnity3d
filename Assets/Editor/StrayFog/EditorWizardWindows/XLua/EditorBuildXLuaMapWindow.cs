#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成XLua脚本映射
/// </summary>
public class EditorBuildXLuaMapWindow : AbsEditorWindow
{
    /// <summary>
    /// XLua配置
    /// </summary>
    EditorXLuaMapConfig mConfig;    
    /// <summary>
    /// CS脚本类别组
    /// </summary>
    List<EditorXLuaMapAsset> mXLuaMaps = new List<EditorXLuaMapAsset>();
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setXLuaMapConfig;
        mXLuaMaps = EditorStrayFogGlobalVariable.CollectXLuaMapAssets();
    }

    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 搜索类全名称
    /// </summary>
    string mSearchClassFullName = string.Empty;
    
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
        EditorGUILayout.LabelField("XLua Map Config File:");
        mConfig.DrawGUI();
        EditorGUILayout.Separator();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        #region  mSearchClassFullName 搜索
        mSearchClassFullName = EditorGUILayout.TextField("Search ClassFullName", mSearchClassFullName);
        #endregion
        EditorGUILayout.Separator();
        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
        bool isDraw = false;
        for (int i = 0; i < mXLuaMaps.Count; i++)
        {
            //名称过滤
            isDraw = (string.IsNullOrEmpty(mSearchClassFullName) || Regex.IsMatch(mXLuaMaps[i].classFullName,
            string.Format(@"({0})+?\w*", mSearchClassFullName.Replace(",", "|")), RegexOptions.IgnoreCase));
            if (isDraw)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(string.Format("{0}. 【{1}】", (i+1).PadLeft(mXLuaMaps.Count), mXLuaMaps[i].classFullName));
                mXLuaMaps[i].xLuaTextAsset = (TextAsset)EditorGUILayout.ObjectField(mXLuaMaps[i].xLuaTextAsset, typeof(TextAsset), false);

                if (GUILayout.Button("Setting"))
                {
                    EditorStrayFogApplication.PingObject(mXLuaMaps[i]);
                }
                EditorUtility.SetDirty(mXLuaMaps[i]);

                if (GUILayout.Button("Brower"))
                {
                    EditorStrayFogApplication.PingObject(mXLuaMaps[i]);
                }
                if (GUILayout.Button("Reveal"))
                {
                    EditorStrayFogApplication.RevealInFinder(mXLuaMaps[i]);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Export XLua Map To XLS"))
        {
            EditorStrayFogExecute.ExportXLuaMapToXLS();
            EditorUtility.DisplayDialog("XLua Map", "ExportXLuaMapToXLS successed.", "OK");
        }
    }
    #endregion
}
#endif
