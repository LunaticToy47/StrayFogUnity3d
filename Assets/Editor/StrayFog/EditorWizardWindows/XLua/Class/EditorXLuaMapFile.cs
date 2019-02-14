#if UNITY_EDITOR
/// <summary>
/// XLuaMap配置资源文件
/// </summary>
public class EditorXLuaMapFile : AbsEditorSavedAsset
{
    /// <summary>
    /// 文件后缀
    /// </summary>
    static FileExtAttribute msFileExt = enFileExt.Xlsx.GetAttribute<FileExtAttribute>();
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
            return string.Format("Setting 【XLuaMap{0} 】{1}", msFileExt.ext, classify);
        }
    }

    /// <summary>
    /// 合法文件后缀组
    /// </summary>
    /// <returns>合法文件后缀组</returns>
    protected override enFileExt[] OnLegalFileExts() { return new enFileExt[1] { enFileExt.Xlsx }; }
}
#endif
