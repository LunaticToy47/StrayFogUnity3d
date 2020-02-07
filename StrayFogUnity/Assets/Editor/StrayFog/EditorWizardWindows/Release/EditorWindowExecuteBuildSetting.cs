#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成UI窗口映射
/// </summary>
public class EditorWindowExecuteBuildSetting : AbsEditorWindow
{
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    
    /// <summary>
    /// OnFocus
    /// </summary>
    private void OnFocus()
    {
        
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
    }
    #endregion

    #region DrawAssetNodes 绘制节点
    /// <summary>
    /// 绘制节点
    /// </summary>
    void DrawAssetNodes()
    {

    }
    #endregion
}
#endif
