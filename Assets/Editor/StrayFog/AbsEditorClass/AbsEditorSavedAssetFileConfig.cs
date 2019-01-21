#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// 编辑器设定保存资源
/// </summary>
public abstract class AbsEditorSavedAssetFileConfig<C, F> : EditorEngineAssetConfig
    where C : AbsEditorSavedAssetFileConfig<C, F>
    where F : AbsEditorSavedAssetFile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public AbsEditorSavedAssetFileConfig()
        : base(typeof(C).Name,
              enEditorApplicationFolder.Editor.GetAttribute<EditorApplicationFolderAttribute>().path,
              enFileExt.Asset, typeof(F).FullName)
    {
    }

    /// <summary>
    /// 文件
    /// </summary>
    public F file { get { if (mFile == null) { mFile = OnLoadFile(); } return mFile; } }
    /// <summary>
    /// 文件
    /// </summary>
    F mFile;
    /// <summary>
    /// 加载文件
    /// </summary>
    /// <returns>文件</returns>
    F OnLoadFile()
    {
        if (!Exists())
        {
            CreateAsset();
        }
        return AssetDatabase.LoadAssetAtPath<F>(fileName);
    }
}
#endif