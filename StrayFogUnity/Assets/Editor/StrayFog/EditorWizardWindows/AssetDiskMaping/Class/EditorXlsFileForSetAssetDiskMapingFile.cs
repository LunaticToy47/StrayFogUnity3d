#if UNITY_EDITOR
using System.IO;
/// <summary>
/// SetAssetDiskMaping配置资源File表映射
/// </summary>
public class EditorXlsFileForSetAssetDiskMapingFile : AbsEditorSavedAsset
{
    /// <summary>
    /// 文件后缀
    /// </summary>
    static FileExtAttribute msFileExt = typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.Xlsx);

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
            return string.Format("Setting 【AssetDiskMapingFile{0} Maping File 】{1}", msFileExt.ext, classify);
        }
    }

    /// <summary>
    /// 合法文件后缀组
    /// </summary>
    /// <returns>合法文件后缀组</returns>
    protected override int[] OnLegalFileExts() { return new int[1] { enFileExt.Xlsx }; }
}
#endif
