#if UNITY_EDITOR
using UnityEngine;
/// <summary>
/// 可保存资源配置
/// </summary>
public abstract class AbsEditorSavedAssetConfig<C, F> : EditorEngineAssetConfig, IEditorSavedAssetDrawUI
    where C : AbsEditorSavedAssetConfig<C, F>
    where F : AbsEditorSavedAsset
{
    /// <summary>
    /// 资源
    /// </summary>
    F mAsset = null;
    /// <summary>
    /// 构造函数
    /// </summary>
    public AbsEditorSavedAssetConfig()
        : base(typeof(C).Name,
              enEditorApplicationFolder.Game_Editor_PublishSetting.GetAttribute<EditorApplicationFolderAttribute>().path,
              enFileExt.Asset, typeof(F).FullName)
    {
        if (!Exists())
        {
            CreateAsset();
        }
        LoadAsset();
        mAsset = (F)engineAsset;
    }

    /// <summary>
    /// 空路径组
    /// </summary>
    readonly static string[] mEmptyPaths = new string[0];

    /// <summary>
    /// 获得保存资源路径组
    /// </summary>
    public string[] paths { get { return mAsset.paths == null ? mEmptyPaths : mAsset.paths; } }

    /// <summary>
    /// 分类
    /// </summary>
    public enEditorSavedAssetClassify classify { get { return mAsset.classify; } }

    /// <summary>
    /// 绘制GUI
    /// </summary>
    public void DrawGUI()
    {
        if (engineAsset != null) {
            mAsset.DrawGUI();
        }
    }   
}
#endif