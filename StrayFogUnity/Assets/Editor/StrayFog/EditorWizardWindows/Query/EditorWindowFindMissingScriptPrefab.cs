#if UNITY_EDITOR
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 查找丢失脚本的Prefab
/// </summary>
public class EditorWindowFindMissingScriptPrefab : AbsEditorWindow
{
    /// <summary>
    /// 过滤项映射
    /// </summary>
    static readonly Dictionary<enEditorAssetFilterClassify, EditorAssetFilterAttribute> mEditorAssetFilterClassifyMaping =
         typeof(enEditorAssetFilterClassify).EnumToAttribute<enEditorAssetFilterClassify, EditorAssetFilterAttribute>();
    /// <summary>
    /// 丢失脚本的预置
    /// </summary>
    List<GameObject> mMissingScriptPrefabs = new List<GameObject>();
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
        if (GUILayout.Button("Start Find Missing Script Prefab"))
        {
            OnFindMissingScriptPrefab();
        }
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        if (mMissingScriptPrefabs.Count > 0)
        {
            mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
            foreach (GameObject g in mMissingScriptPrefabs)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField("Missing Script", g, typeof(GameObject), false);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
        }
    }
    #endregion

    #region OnFindMissingScriptPrefab
    /// <summary>
    /// 查找丢失脚本的预置
    /// </summary>
    void OnFindMissingScriptPrefab()
    {
        mMissingScriptPrefabs.Clear();
        string filter = mEditorAssetFilterClassifyMaping[enEditorAssetFilterClassify.Prefab].filter;
        string[] guids = AssetDatabase.FindAssets(filter);
        if (guids != null && guids.Length > 0)
        {
            GameObject prefab = null;
            MonoBehaviour[] coms = null;
            bool isMissingScript = false;
            float progress = 0;
            string path = string.Empty;
            foreach (string id in guids)
            {
                progress++;
                path = AssetDatabase.GUIDToAssetPath(id);
                EditorUtility.DisplayProgressBar("Find Missing Script", path, progress / guids.Length);
                prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                coms = prefab.GetComponents<MonoBehaviour>();
                isMissingScript = false;
                if (coms != null && coms.Length > 0)
                {
                    for (int i = 0; i < coms.Length; i++)
                    {
                        isMissingScript |= coms[i] == null;
                        if (isMissingScript)
                        {
                            mMissingScriptPrefabs.Add(prefab);
                            break;
                        }
                    }
                }
                if (!isMissingScript)
                {
                    coms = prefab.GetComponentsInChildren<MonoBehaviour>(true);
                    if (coms != null && coms.Length > 0)
                    {
                        for (int i = 0; i < coms.Length; i++)
                        {
                            isMissingScript |= coms[i] == null;
                            if (isMissingScript)
                            {
                                mMissingScriptPrefabs.Add(prefab);
                                break;
                            }
                        }
                    }
                }
            }
            EditorUtility.ClearProgressBar();
        }
    }
    #endregion
}
#endif