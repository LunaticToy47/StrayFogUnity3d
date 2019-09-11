#if UNITY_EDITOR
/// <summary>
/// UI窗口预置资源文件夹
/// </summary>
public class EditorFolderForUIWindowPrefab : AbsEditorSavedAsset
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
            return string.Format("Setting 【UIWindowPrefab 】{0}", classify);
        }
    }
}
#endif
