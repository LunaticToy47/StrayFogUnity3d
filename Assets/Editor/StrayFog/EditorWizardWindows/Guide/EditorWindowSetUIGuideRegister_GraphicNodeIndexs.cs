#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置UIGuideRegister的GraphicNodeIndexs参数值
/// </summary>
public class EditorWindowSetUIGuideRegister_GraphicNodeIndexs : AbsEditorWindow
{
    /// <summary>
    /// 滚动视图
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 引导注册器Graphics
    /// </summary>
    List<EditorUIGuideRegisterSetGraphic> mGraphics = new List<EditorUIGuideRegisterSetGraphic>();
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        GameObject[] gos = Selection.gameObjects;
        if (gos != null && gos.Length > 0)
        {
            mGraphics.Clear();
            EditorUIGuideRegisterSetGraphic register = null;
            foreach (GameObject g in gos)
            {
                register = new EditorUIGuideRegisterSetGraphic(g);
                register.Resolve();
                mGraphics.Add(register);
            }
        }
        else
        {
            Debug.LogError("Can't find any GameObject be selected!");
        }
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        if (mGraphics != null && mGraphics.Count > 0)
        {
            mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
            foreach (EditorUIGuideRegisterSetGraphic g in mGraphics)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(g.register, typeof(UIGuideRegister), true);
                EditorGUILayout.ObjectField(g.gameObject, typeof(GameObject), true);
                if (g.isFoundRegister)
                {
                    if (GUILayout.Button("Set GraphicsNodeIndexs"))
                    {
                        g.register.graphicsNodeIndexs = g.graphicsIndexs;
                        EditorUtility.SetDirty(g.register);
                        AssetDatabase.SaveAssets();
                    }
                }
                else
                {
                    EditorGUILayout.LabelField(string.Format("Can't found UIGuideRegister from parents."));
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
        }
    }
}
#endif