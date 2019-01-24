#if UNITY_EDITOR
/// <summary>
/// XlsSchemaToSqlite配置资源文件夹
/// </summary>
public class EditorXlsSchemaToSqliteFolder : AbsEditorSavedAsset
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
            return string.Format("Setting 【XlsSchemaToSqlite 】{0}", classify);
        }
    }
}
#endif
