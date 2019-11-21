#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 构建MonoBehaviour事件监听
/// </summary>
public class EditorWindowBuildMonoBehaviourEventListening : AbsEditorWindow
{
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;

    /// <summary>
    /// 模拟MonoBehaviour方法
    /// </summary>
    MethodInfo[] mSimulateMonoBehaviourMethodMaping = null;

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mSimulateMonoBehaviourMethodMaping = EditorStrayFogExecute.CollectSimulateMonoBehaviourMethods();
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
        
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        EditorGUILayout.LabelField("Mapper to MonoBehaviour");
        if (mSimulateMonoBehaviourMethodMaping != null)
        {
            mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
            int index = 0;
            int count = mSimulateMonoBehaviourMethodMaping.Length;
            foreach (MethodInfo key in mSimulateMonoBehaviourMethodMaping)
            {
                index++;
                EditorGUILayout.LabelField(string.Format("{0}.【{1}】", index.PadLeft(count), key.Name));
            }
            EditorGUILayout.EndScrollView();
        }        
        if (GUILayout.Button("Build SimulateMonoBehaviour"))
        {
            EditorStrayFogExecute.ExecuteBuildSimulateMonoBehaviour();
        }
    }
    #endregion
}
#endif