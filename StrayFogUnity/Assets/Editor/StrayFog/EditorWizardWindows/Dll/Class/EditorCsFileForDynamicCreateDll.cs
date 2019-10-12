#if UNITY_EDITOR
/// <summary>
/// 动态收集CS文件并创建Dll
/// </summary>
public class EditorCsFileForDynamicCreateDll : AbsEditorSavedAsset
{
    /// <summary>
    /// 文件后缀
    /// </summary>
    static FileExtAttribute msFileExt = enFileExt.CS.GetAttribute<FileExtAttribute>();

    /// <summary>
    /// 可保存资源分类
    /// </summary>
    public override enEditorSavedAssetClassify classify
    {
        get
        {
            return enEditorSavedAssetClassify.File;
        }
    }

    /// <summary>
    /// 绘制GUI描述
    /// </summary>
    protected override string drawGUIDesc
    {
        get
        {
            return string.Format("Setting 【DynamicCreateDll{0} CS File 】{1}", msFileExt.ext, classify);
        }
    }

    /// <summary>
    /// 合法文件后缀组
    /// </summary>
    /// <returns>合法文件后缀组</returns>
    protected override enFileExt[] OnLegalFileExts() { return new enFileExt[1] { enFileExt.CS }; }
}
#endif
