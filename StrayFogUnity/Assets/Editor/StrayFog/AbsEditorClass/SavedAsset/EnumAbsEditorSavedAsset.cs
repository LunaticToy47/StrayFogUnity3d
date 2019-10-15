#if UNITY_EDITOR
/// <summary>
/// 可保存资源分类
/// </summary>
public enum enEditorSavedAssetClassify
{
    /// <summary>
    /// 文件夹
    /// </summary>
    [AliasTooltip("文件夹")]
    Folder,
    /// <summary>
    /// 文件
    /// </summary>
    [AliasTooltip("文件")]
    File,
}

/// <summary>
/// 可保存资源模式
/// </summary>
public enum enEditorSavedAssetPattern
{
    /// <summary>
    /// 只保存Assets内
    /// </summary>
    [AliasTooltip("只保存Assets内")]
    OnlyInAssets,
    /// <summary>
    /// 只保存Assets外
    /// </summary>
    [AliasTooltip("只保存Assets外")]
    OnlyOutAssets,
}
#endif
