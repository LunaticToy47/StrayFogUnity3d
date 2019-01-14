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
    /// 目录组
    /// </summary>
    [AliasTooltip("目录组")]
    [HideInInspector]
    public string[] folders;

    [InvokeMethod("EditorDisplayParameter")]
    public string invoke;

    /// <summary>
    /// 临时文件夹组
    /// </summary>
    List<string> mTempFolders = new List<string>();
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
        if (folders != null && folders.Length > 0)
        {
            EditorGUI.LabelField(_position, "folders：");
            _position.y += _position.height;
            for (int i = 0; i < folders.Length; i++)
            {
                EditorGUI.LabelField(_position, (i + 1).PadLeft(folders.Length) + "." + folders[i]);
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
        mTempFolders.Clear();
        if (folders != null && folders.Length > 0)
        {
            mTempFolders.AddRange(folders);
        }

        #region Add Folder
        if (GUILayout.Button("Add Folder"))
        {
            string folder = EditorUtility.OpenFolderPanel("Add Folder", EditorStrayFogApplication.assetsPath, "");
            if (EditorStrayFogApplication.IsSubToProject(folder))
            {
                folder = EditorStrayFogApplication.GetRelativeToProject(folder);
                if (!mTempFolders.Contains(folder))
                {
                    mTempFolders.Add(folder);
                    mTempIsDirty = true;
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Folder", "Folder must be in 【" + EditorStrayFogApplication.assetsPath + "】", "OK");
            }
        }
        #endregion

        #region Display and Delete
        if (mTempFolders.Count > 0)
        {
            int delIndex = -1;
            for (int i = 0; i < mTempFolders.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(
                    string.Format("{0}.{1}", (i + 1).PadLeft(mTempFolders.Count), mTempFolders[i]));
                if (GUILayout.Button("Brower"))
                {
                    EditorStrayFogApplication.PingObject(mTempFolders[i]);
                }
                if (GUILayout.Button("Reveal"))
                {
                    EditorStrayFogApplication.RevealInFinder(mTempFolders[i]);
                }
                if (GUILayout.Button("Delete"))
                {
                    if (EditorUtility.DisplayDialog("Delete Folder", "Are you sure to delete folder 【" + mTempFolders[i] + "】", "OK", "Cancel"))
                    {
                        delIndex = i;
                        break;
                    }
                }                
                EditorGUILayout.EndHorizontal();
            }
            if (delIndex >= 0)
            {
                mTempFolders.RemoveAt(delIndex);
                mTempIsDirty = true;
            }
        }
        #endregion
        if (mTempIsDirty)
        {
            folders = mTempFolders.ToArray();
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