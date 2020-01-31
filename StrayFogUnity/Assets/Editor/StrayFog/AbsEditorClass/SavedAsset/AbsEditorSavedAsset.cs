#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 可保存资源
/// </summary>
public abstract class AbsEditorSavedAsset : AbsScriptableObject
{
    /// <summary>
    /// 可保存资源分类
    /// </summary>
    public abstract enEditorSavedAssetClassify classify { get; }
    /// <summary>
    /// 可保存资源模式
    /// </summary>
    public virtual enEditorSavedAssetPattern pattern { get { return enEditorSavedAssetPattern.OnlyInAssets; } }

    /// <summary>
    /// 绘制GUI描述
    /// </summary>
    protected abstract string drawGUIDesc { get; }

    /// <summary>
    /// 路径组
    /// </summary>
    [AliasTooltip("路径组")]
    [HideInInspector]
    public string[] paths;

    [InvokeMethod("EditorDisplayParameter")]
    public string invoke;

    /// <summary>
    /// 临时路径组
    /// </summary>
    List<string> mTempPaths = new List<string>();
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
        if (paths != null && paths.Length > 0)
        {
            EditorGUI.LabelField(_position, classify.ToString());
            _position.y += _position.height;
            for (int i = 0; i < paths.Length; i++)
            {
                EditorGUI.LabelField(_position, (i + 1).PadLeft(paths.Length) + "." + paths[i]);
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
        mTempPaths.Clear();
        if (paths != null && paths.Length > 0)
        {
            mTempPaths.AddRange(paths);
        }

        EditorGUILayout.LabelField(drawGUIDesc);

        #region Add Path
        if (GUILayout.Button("Add " + classify.ToString()))
        {
            string path = string.Empty;
            string error = string.Empty;
            string ext = string.Empty;
            List<string> legalExts = new List<string>();
            bool isLegalFileExt = false;
            FileExtAttribute fextAttr = null;
            switch (classify)
            {
                case enEditorSavedAssetClassify.File:
                    path = EditorUtility.OpenFilePanel("Add " + classify.ToString(), EditorStrayFogApplication.assetsPath, "");
                    ext = Path.GetExtension(path);
                    int[] legalFileExts = OnLegalFileExts();
                    if (legalFileExts != null && legalFileExts.Length > 0)
                    {
                        foreach (int fext in legalFileExts)
                        {
                            fextAttr = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(fext);
                            isLegalFileExt |= fextAttr.IsExt(ext);
                            legalExts.Add(fextAttr.ext);
                        }
                    }
                    if (!isLegalFileExt)
                    {
                        error = string.Format("The file must be 【{0}】", string.Join(",", legalExts.ToArray()));
                    }
                    break;
                case enEditorSavedAssetClassify.Folder:
                    path = EditorUtility.OpenFolderPanel("Add " + classify.ToString(), EditorStrayFogApplication.assetsPath, "");
                    break;
            }
            bool isLegalPath = false;
            string errTip = string.Empty;

            #region 判定路径是否合法
            switch (pattern)
            {
                case enEditorSavedAssetPattern.OnlyInAssets:
                    isLegalPath = EditorStrayFogApplication.IsSubToAssets(path);
                    if (isLegalPath)
                    {
                        path = EditorStrayFogApplication.GetRelativeToProject(path);
                    }
                    errTip = "in";
                    break;
                case enEditorSavedAssetPattern.OnlyOutAssets:
                    isLegalPath = !EditorStrayFogApplication.IsSubToAssets(path);
                    errTip = "out";
                    break;
            }
            #endregion

            if (isLegalPath)
            {
                if (string.IsNullOrEmpty(error))
                {
                    if (!mTempPaths.Contains(path))
                    {
                        mTempPaths.Add(path);
                        mTempIsDirty = true;
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog(classify.ToString(), error, "OK");
                }
            }
            else
            {
                EditorUtility.DisplayDialog(classify.ToString(), classify.ToString() + " must be "+ errTip + " 【" + EditorStrayFogApplication.assetsPath + "】", "OK");
            }
        }
        #endregion

        #region Display and Delete
        if (mTempPaths.Count > 0)
        {
            int delIndex = -1;
            for (int i = 0; i < mTempPaths.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(
                    string.Format("{0}.{1}", (i + 1).PadLeft(mTempPaths.Count), mTempPaths[i]));
                if (GUILayout.Button("Brower"))
                {
                    EditorStrayFogApplication.PingObject(mTempPaths[i]);
                }
                if (GUILayout.Button("Reveal"))
                {
                    EditorStrayFogApplication.RevealInFinder(mTempPaths[i]);
                }
                if (GUILayout.Button("Delete"))
                {
                    if (EditorUtility.DisplayDialog("Delete "+ classify.ToString(), "Are you sure to delete "+ classify.ToString() + " 【" + mTempPaths[i] + "】", "OK", "Cancel"))
                    {
                        delIndex = i;
                        break;
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            if (delIndex >= 0)
            {
                mTempPaths.RemoveAt(delIndex);
                mTempIsDirty = true;
            }
        }
        #endregion

        if (mTempIsDirty)
        {
            paths = mTempPaths.ToArray();
        }
        OnDrawGUI();
        GUILayout.HorizontalSlider(0, 0, 0, GUILayout.Height(1));
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        if (mTempIsDirty)
        {
            EditorUtility.SetDirty(this);
        }
    }
    /// <summary>
    /// 绘制GUI
    /// </summary>
    protected virtual void OnDrawGUI() { }

    /// <summary>
    /// 合法文件后缀组
    /// </summary>
    static readonly int[] mLegalFileExts = new int[0];
    /// <summary>
    /// 合法文件后缀组
    /// </summary>
    /// <returns>合法文件后缀组</returns>
    protected virtual int[] OnLegalFileExts() { return mLegalFileExts; }
}
#endif