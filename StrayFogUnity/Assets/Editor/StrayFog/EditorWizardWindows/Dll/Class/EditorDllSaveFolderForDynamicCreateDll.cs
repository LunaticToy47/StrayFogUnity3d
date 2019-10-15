#if UNITY_EDITOR
using System.IO;
/// <summary>
/// CS动态生成Dll保存文件夹
/// </summary>
public class EditorDllSaveFolderForDynamicCreateDll : AbsEditorSavedAsset
{
    /// <summary>
    /// 可保存资源分类
    /// </summary>
    public override enEditorSavedAssetClassify classify
    {
        get
        {
            return enEditorSavedAssetClassify.Folder;
        }
    }

    /// <summary>
    /// 可保存资源模式
    /// </summary>
    public override enEditorSavedAssetPattern pattern => enEditorSavedAssetPattern.OnlyOutAssets;

    /// <summary>
    /// 绘制GUI描述
    /// </summary>
    protected override string drawGUIDesc
    {
        get
        {
            return string.Format("Setting 【CsFolderForDynamicCreateDll 】{0}", classify);
        }
    }
}
#endif
