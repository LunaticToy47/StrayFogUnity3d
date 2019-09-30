#if UNITY_EDITOR
/// <summary>
/// AsmdefMap配置生成脚本文件夹
/// </summary>
public class EditorFolderForAsmdefMap : AbsEditorSavedAsset
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
    /// 绘制GUI描述
    /// </summary>
    protected override string drawGUIDesc
    {
        get
        {
            return string.Format("Setting 【Asmdef Script 】{0}", classify);
        }
    }
}
#endif
