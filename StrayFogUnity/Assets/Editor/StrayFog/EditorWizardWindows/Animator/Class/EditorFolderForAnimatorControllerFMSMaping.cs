#if UNITY_EDITOR
/// <summary>
/// AnimatorControllerFMSMaping配置资源文件夹
/// </summary>
public class EditorFolderForAnimatorControllerFMSMaping : AbsEditorSavedAsset
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
            return string.Format("Setting 【Animator FMS Maping】 {0}", classify);
        }
    }
}
#endif