#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// 编辑器设定保存资源
/// </summary>
public abstract class AbsEditorSavedAssetFolderConfig<C, F> : EditorEngineAssetConfig, IEditorSavedAssetDrawUI
    where C : AbsEditorSavedAssetFolderConfig<C, F>
    where F : AbsEditorSavedAssetFolder
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public AbsEditorSavedAssetFolderConfig()
        : base(typeof(C).Name,
              enEditorApplicationFolder.Editor.GetAttribute<EditorApplicationFolderAttribute>().path,
              enFileExt.Asset, typeof(F).FullName)
    {
    }

    /// <summary>
    /// 绘制GUI
    /// </summary>
    public void DrawGUI()
    {
        if (folder != null) { folder.DrawGUI(); }
    }

    /// <summary>
    /// 文件夹
    /// </summary>
    public F folder { get { if (mFolder == null) { mFolder = OnLoadFolderAsset(); } return mFolder; } }

    /// <summary>
    /// 文件夹
    /// </summary>
    F mFolder;
    /// <summary>
    /// 加载文件夹资源
    /// </summary>
    /// <returns>文件夹资源</returns>
    F OnLoadFolderAsset()
    {
        if (!Exists())
        {
            CreateAsset();
        }
        return AssetDatabase.LoadAssetAtPath<F>(fileName);
    }
}
#endif