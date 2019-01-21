#if UNITY_EDITOR 
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 可保存的资源文本
/// </summary>
public abstract class AbsEditorSavedAssetFile : AbsScriptableObject
{
    /// <summary>
    /// 文件组
    /// </summary>
    [AliasTooltip("文件组")]
    [HideInInspector]
    public string[] files;

    [InvokeMethod("EditorDisplayParameter")]
    public string invoke;

    /// <summary>
    /// 临时文件组
    /// </summary>
    List<string> mTempFiles = new List<string>();
    /// <summary>
    /// 是否有变更
    /// </summary>
    bool mTempIsDirty = false;
    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    protected virtual float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;
        if (files != null && files.Length > 0)
        {
            EditorGUI.LabelField(_position, "files：");
            _position.y += _position.height;
            for (int i = 0; i < files.Length; i++)
            {
                EditorGUI.LabelField(_position, (i + 1).PadLeft(files.Length) + "." + files[i]);
                _position.y += _position.height;
            }
        }
        return _position.y - y;
    }
    /// <summary>
    /// 绘制GUI
    /// </summary>
    public void DrawGUI()
    {
        mTempIsDirty = false;
        mTempFiles.Clear();
        if (files != null && files.Length > 0)
        {
            mTempFiles.AddRange(files);
        }

        #region Add File
        if (GUILayout.Button("Add File"))
        {
            string file = EditorUtility.OpenFilePanel("Add File", EditorStrayFogApplication.assetsPath, "");
            if (EditorStrayFogApplication.IsSubToProject(file))
            {
                file = EditorStrayFogApplication.GetRelativeToProject(file);
                if (!mTempFiles.Contains(file))
                {
                    mTempFiles.Add(file);
                    mTempIsDirty = true;
                }
            }
            else
            {
                EditorUtility.DisplayDialog("File", "File must be in 【" + EditorStrayFogApplication.assetsPath + "】", "OK");
            }
        }
        #endregion

        #region Display and Delete
        if (mTempFiles.Count > 0)
        {
            int delIndex = -1;
            for (int i = 0; i < mTempFiles.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(
                    string.Format("{0}.{1}", (i + 1).PadLeft(mTempFiles.Count), mTempFiles[i]));
                if (GUILayout.Button("Brower"))
                {
                    EditorStrayFogApplication.PingObject(mTempFiles[i]);
                }
                if (GUILayout.Button("Reveal"))
                {
                    EditorStrayFogApplication.RevealInFinder(mTempFiles[i]);
                }
                if (GUILayout.Button("Delete"))
                {
                    if (EditorUtility.DisplayDialog("Delete Folder", "Are you sure to delete folder 【" + mTempFiles[i] + "】", "OK", "Cancel"))
                    {
                        delIndex = i;
                        break;
                    }
                }                
                EditorGUILayout.EndHorizontal();
            }
            if (delIndex >= 0)
            {
                mTempFiles.RemoveAt(delIndex);
                mTempIsDirty = true;
            }
        }
        #endregion
        if (mTempIsDirty)
        {
            files = mTempFiles.ToArray();
        }
        OnDrawGUI();
        if (mTempIsDirty)
        {
            EditorUtility.SetDirty(this);
        }
    }
    /// <summary>
    /// 绘制GUI
    /// </summary>
    protected virtual void OnDrawGUI() { }
}
#endif