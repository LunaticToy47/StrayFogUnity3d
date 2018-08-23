using Assets.Editor.StrayFog.EditorResxTemplete;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 创建UI窗口
/// </summary>
public class EditorWindowCreateNewUIWindow : AbsEditorWindow
{
    /// <summary>
    /// UI窗口视图脚本目录
    /// </summary>
    static readonly string mUIWindowViewScriptFolder = EditorStrayFogGlobalVariable.uiWindowViewScriptFolder;
    /// <summary>
    /// UI窗口视图脚本
    /// </summary>
    static readonly EditorTextAssetConfig mUIWindowViewScript = EditorStrayFogGlobalVariable.uiWindowViewScript;
    /// <summary>
    /// UI窗口预置目录
    /// </summary>
    static readonly string mUIWindowPrefabFolder = EditorStrayFogGlobalVariable.uiWindowPrefabFolder;
    /// <summary>
    /// UI窗口预置
    /// </summary>
    static readonly EditorEngineAssetConfig mUIWindowPrefab = EditorStrayFogGlobalVariable.uiWindowPrefab;
    /// <summary>
    /// 窗口名称
    /// </summary>
    string mWindowName = string.Empty;
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
        #region 浏览资源映射文件
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("1." + mUIWindowViewScriptFolder);
        if (GUILayout.Button("Brower"))
        {
            EditorUtility.RevealInFinder(mUIWindowViewScriptFolder);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("2." + mUIWindowPrefabFolder);
        if (GUILayout.Button("Brower"))
        {
            EditorStrayFogApplication.PingObject(mUIWindowPrefabFolder);
        }
        EditorGUILayout.EndHorizontal();
        #endregion
        EditorGUILayout.Separator();
    }
    #endregion

    #region DrawAssetNodes 绘制节点
    /// <summary>
    /// 绘制节点
    /// </summary>
    void DrawAssetNodes()
    {
        mWindowName = EditorGUILayout.TextField("Window Name", mWindowName);

        mUIWindowViewScript.SetDirectory(Path.Combine(mUIWindowViewScriptFolder, mWindowName));
        mUIWindowViewScript.SetName(mWindowName + "Window");

        mUIWindowPrefab.SetDirectory(Path.Combine(mUIWindowPrefabFolder, mWindowName));
        mUIWindowPrefab.SetName(mWindowName + "Window");

        EditorGUILayout.Separator();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(string.Format("1. {0}", mUIWindowViewScript.fileName));
        if (GUILayout.Button("Brower"))
        {
            EditorUtility.RevealInFinder(mUIWindowViewScript.fileName);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(string.Format("2. {0}", mUIWindowPrefab.fileName));
        if (GUILayout.Button("Brower"))
        {
            EditorStrayFogApplication.PingObject(mUIWindowPrefab.fileName);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Separator();
        if (!string.IsNullOrEmpty(mWindowName))
        {
            if (GUILayout.Button("Create Script"))
            {
                CreateScript(mUIWindowViewScript);
            }
            else if (File.Exists(mUIWindowViewScript.fileName) && GUILayout.Button("Create Prefab"))
            {
                if (!string.IsNullOrEmpty(mWindowName))
                {
                    CreatePrefab(mUIWindowPrefab);
                }
            }
        }
    }

    #region CreateScript 创建脚本
    /// <summary>
    /// 创建脚本
    /// </summary>
    /// <param name="_viewScript">视图脚本</param>
    void CreateScript(EditorTextAssetConfig _viewScript)
    {
        if (!EditorStrayFogUtility.assetBundleName.IsIllegalFile(_viewScript.name))
        {
            bool isCreate = true;
            if (File.Exists(_viewScript.fileName))
            {
                isCreate = EditorUtility.DisplayDialog("Exists Script", "The script '" + _viewScript.fileName + "' already exists,are you sure want to cover it?", "Yes", "No");
            }
            string windowTemplate = EditorResxTemplete.UIWindowViewTemplete;
            windowTemplate = windowTemplate.Replace("#NAME#", _viewScript.name);
            _viewScript.SetText(windowTemplate);
            _viewScript.CreateAsset();
            EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
            EditorUtility.DisplayDialog("Create New Window Script", "Create window scripts is complete.", "OK");
        }
        else
        {
            EditorUtility.DisplayDialog("Illegal Name", "Window Name is not legal.", "OK");
        }
    }
    #endregion

    #region CreatePrefab 创建预置
    /// <summary>
    /// 创建预置
    /// </summary>
    /// <param name="_prefab">prefab配置</param>
    void CreatePrefab(EditorEngineAssetConfig _prefab)
    {
        if (!EditorStrayFogUtility.assetBundleName.IsIllegalFile(_prefab.name))
        {
            bool isCreate = true;
            if (File.Exists(_prefab.fileName))
            {
                isCreate = EditorUtility.DisplayDialog("Exists Prefab", "The prefab '" + _prefab.fileName + "' already exists,are you sure want to cover it?", "Yes", "No");
            }
            if (isCreate)
            {
                _prefab.CreateAsset();
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(_prefab.fileName);
                prefab.layer = LayerMask.NameToLayer("UI"); ;
                prefab.AddComponent<RectTransform>();
                AssetDatabase.SaveAssets();
                EditorStrayFogApplication.PingObject(prefab);
                EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
                EditorUtility.DisplayDialog("Create New Window Prefab", "Create window prefab is complete.", "OK");
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Illegal Name", "Window Name is not legal.", "OK");
        }
    }
    #endregion
    #endregion
}
