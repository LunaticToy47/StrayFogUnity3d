#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 创建UI窗口
/// </summary>
public class EditorWindowCreateNewUIWindow : AbsEditorWindow
{
    /// <summary>
    /// 窗口预置配置
    /// </summary>
    EditorFolderConfigForUIWindowPrefab mPrefabConfig;
    /// <summary>
    /// 窗口脚本配置
    /// </summary>
    EditorFolderConfigForUIWindowScript mScriptConfig;
    /// <summary>
    /// UI窗口视图脚本
    /// </summary>
    EditorTextAssetConfig mUIWindowViewScript = new EditorTextAssetConfig("", "", enFileExt.CS, "");
    /// <summary>
    /// UI窗口预置
    /// </summary>
    EditorEngineAssetConfig mUIWindowPrefab = new EditorEngineAssetConfig("", "", enFileExt.Prefab, typeof(GameObject).FullName);
    /// <summary>
    /// 临时UI窗口视图脚本
    /// </summary>
    EditorTextAssetConfig mTempUIWindowViewScript = new EditorTextAssetConfig("", "", enFileExt.CS, "");
    /// <summary>
    /// 窗口名称
    /// </summary>
    string mWindowName = string.Empty;
    /// <summary>
    /// 配置选择索引
    /// </summary>
    int mSelectConfigIndex = 0;
    /// <summary>
    /// 配置索引组
    /// </summary>
    List<string> mConfigIndexs = new List<string>();
    /// <summary>
    /// 有效配置
    /// </summary>
    bool mValidateConfig = false;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mPrefabConfig = EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab;
        mScriptConfig = EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowScript;
        mConfigIndexs.Clear();
        if (mPrefabConfig.paths != null && mPrefabConfig.paths.Length > 0)
        {
            for (int i = 0; i < mPrefabConfig.paths.Length; i++)
            {
                mConfigIndexs.Add(mPrefabConfig.paths[i].TransPathSeparatorCharToPopupChar());
            }
        }
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
        mPrefabConfig.DrawGUI();
        mScriptConfig.DrawGUI();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        mSelectConfigIndex = EditorGUILayout.Popup("Select Config", mSelectConfigIndex, mConfigIndexs.ToArray());
        mWindowName = EditorGUILayout.TextField("Window Name", mWindowName);

        EditorGUILayout.Separator();
        mValidateConfig = false;

        if (mPrefabConfig.paths != null && mPrefabConfig.paths.Length > mSelectConfigIndex)
        {
            mUIWindowPrefab.SetDirectory(OnGetDirectory(mPrefabConfig.paths[mSelectConfigIndex], mWindowName));
            mUIWindowPrefab.SetName(OnGetName(mWindowName));
            mValidateConfig = true;
        }

        if (mScriptConfig.paths != null && mScriptConfig.paths.Length > mSelectConfigIndex)
        {
            mUIWindowViewScript.SetDirectory(OnGetDirectory(mScriptConfig.paths[mSelectConfigIndex], mWindowName));
            mUIWindowViewScript.SetName(OnGetName(mWindowName));
            mValidateConfig &= true;
        }

        if (mValidateConfig)
        {
            #region 浏览按钮
            EditorGUILayout.Separator();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Format("1. {0}", mUIWindowViewScript.fileName));
            if (GUILayout.Button("Brower"))
            {
                EditorStrayFogApplication.PingObject(mUIWindowViewScript.fileName);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(string.Format("2. {0}", mUIWindowPrefab.fileName));
            if (GUILayout.Button("Brower"))
            {
                EditorStrayFogApplication.PingObject(mUIWindowPrefab.fileName);
            }
            EditorGUILayout.EndHorizontal();
            #endregion

            EditorGUILayout.Separator();
            if (!string.IsNullOrEmpty(mWindowName))
            {
                if (!OnSameScript(mUIWindowViewScript, mWindowName))
                {
                    if (GUILayout.Button("Create Script"))
                    {
                        OnCreateScript(mUIWindowViewScript);
                    }
                    else if (File.Exists(mUIWindowViewScript.fileName) && GUILayout.Button("Create Prefab"))
                    {
                        if (!string.IsNullOrEmpty(mWindowName))
                        {
                            OnCreatePrefab(mUIWindowPrefab);
                        }
                    }
                }
            }
        }
        else
        {
            EditorGUILayout.HelpBox(string.Format("There is no script config for 【{0}】", mPrefabConfig.paths[mSelectConfigIndex]), MessageType.Info);
        }
    }

    /// <summary>
    /// 获取目录
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="_name">目录</param>
    /// <returns>目录</returns>
    string OnGetDirectory(string _path, string _name)
    {
        return Path.Combine(_path, _name);
    }
    /// <summary>
    /// 获取名称
    /// </summary>
    /// <param name="_name">名称</param>
    /// <returns>名称</returns>
    string OnGetName(string _name)
    {
        return _name + "Window";
    }
    #endregion

    #region 是否有相同的脚本
    /// <summary>
    /// 是否有相同的脚本
    /// </summary>
    /// <param name="_script">脚本</param>
    /// <param name="_winName">窗口名称</param>
    /// <returns>true:是,false:否</returns>
    bool OnSameScript(EditorTextAssetConfig _script,string _winName)
    {
        bool hasSame = false;
        if (mScriptConfig.paths != null && mScriptConfig.paths.Length > 0)
        {
            string directory = string.Empty;
            string name = string.Empty;
            string path = string.Empty;
            foreach (string p in mScriptConfig.paths)
            {
                name = OnGetName(_winName);
                directory = OnGetDirectory(p, _winName).TransPathSeparatorCharToUnityChar();
                path = Path.Combine(directory, name + _script.extAttribute.ext).TransPathSeparatorCharToUnityChar();
                if (!_script.directory.Equals(directory) && File.Exists(path))
                {
                    hasSame = true;
                    EditorGUILayout.HelpBox("The same script in =>" + path, MessageType.Error);
                    EditorStrayFogApplication.PingObject(path);
                    break;
                }
            }
        }
        return hasSame;
    }
    #endregion

    #region OnCreateScript 创建脚本
    /// <summary>
    /// 创建脚本
    /// </summary>
    /// <param name="_viewScript">视图脚本</param>
    void OnCreateScript(EditorTextAssetConfig _viewScript)
    {
        if (!EditorStrayFogUtility.assetBundleName.IsIllegalFile(_viewScript.name))
        {
            bool hasScript = false;
            string hasScriptPath = string.Empty;
            if (mScriptConfig.paths != null && mScriptConfig.paths.Length > 0)
            {
                for (int i = 0; i < mScriptConfig.paths.Length; i++)
                {
                    mTempUIWindowViewScript.SetDirectory(
                        OnGetDirectory(mScriptConfig.paths[i], Path.GetFileName(_viewScript.directory)));
                    mTempUIWindowViewScript.SetName(_viewScript.name);
                    hasScript |= File.Exists(mTempUIWindowViewScript.fileName);
                    hasScriptPath = mTempUIWindowViewScript.fileName;
                    if (hasScript)
                    {
                        break;
                    }
                }
            }

            if (hasScript)
            {
                EditorUtility.DisplayDialog("Exists Script",
                    "The script 【" + _viewScript.name + "】 already exists in 【"+ hasScriptPath + "】.", 
                    "OK");
            }
            else
            {
                string windowTemplate = EditorResxTemplete.UIWindowViewTemplete;
                windowTemplate = windowTemplate.Replace("#NAME#", _viewScript.name);
                _viewScript.SetText(windowTemplate);
                _viewScript.CreateAsset();
                EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
                EditorUtility.DisplayDialog("Create New Window Script", "Create window scripts is complete.", "OK");
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Illegal Name", "Window Name is not legal.", "OK");
        }
    }
    #endregion

    #region OnCreatePrefab 创建预置
    /// <summary>
    /// 创建预置
    /// </summary>
    /// <param name="_prefab">prefab配置</param>
    void OnCreatePrefab(EditorEngineAssetConfig _prefab)
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
                prefab.layer = LayerMask.NameToLayer("UI");
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
}
#endif