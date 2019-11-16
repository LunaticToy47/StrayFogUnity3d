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
    /// 配置脚本
    /// </summary>
    EditorTextAssetConfig cfgEntityScript = new EditorTextAssetConfig("", 
        enEditorApplicationFolder.StrayFog_Running_LikeMonoBehaviour.GetAttribute<EditorApplicationFolderAttribute>().path, 
        enFileExt.CS, "");

    /// <summary>
    /// Txt脚本模板
    /// </summary>
    string mTxtScriptTemplete = EditorResxTemplete.EditorLikeMonoBehaviourScriptTemplete;

    /// <summary>
    /// 模拟MonoBehaviour方法
    /// </summary>
    Dictionary<MethodInfo, SimulateMonoBehaviourAttribute> mSimulateMonoBehaviourMethodMaping = new Dictionary<MethodInfo, SimulateMonoBehaviourAttribute>();

    /// <summary>
    /// DeclaringType
    /// </summary>
    Type mDeclaringType = typeof(ISimulateMonoBehaviour);
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mSimulateMonoBehaviourMethodMaping = EditorStrayFogExecute.CollectSimulateMonoBehaviour();
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
        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
       
        EditorGUILayout.EndScrollView();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
    }
    #endregion
}
#endif