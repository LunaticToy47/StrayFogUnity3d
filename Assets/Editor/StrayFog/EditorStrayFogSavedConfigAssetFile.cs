#if UNITY_EDITOR
/// <summary>
/// 可保存的配置资源文件
/// </summary>
public sealed class EditorStrayFogSavedConfigAssetFile
{
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    [AliasTooltip("Setting 【AssetBundleName】")]
    public static EditorSetAssetBundleNameConfig setAssetBundleName = new EditorSetAssetBundleNameConfig();
    /// <summary>
    /// 设置SpritePackingTag
    /// </summary>
    [AliasTooltip("Setting 【SpritePackingTag】")]
    public static EditorSetSpritePackingTagConfig setSpritePackingTag = new EditorSetSpritePackingTagConfig();
    /// <summary>
    /// 设置Animator FMS Maping
    /// </summary>
    [AliasTooltip("Setting 【Animator FMS Maping】")]
    public static EditorAnimatorControllerFMSMapingConfig setAnimatorControllerFMSMaping = new EditorAnimatorControllerFMSMapingConfig();
    /// <summary>
    /// 设置XlsSchemaToSqlite
    /// </summary>
    [AliasTooltip("Setting 【XlsSchema To Sqlite】")]
    public static EditorXlsSchemaToSqliteConfig setXlsSchemaToSqlite = new EditorXlsSchemaToSqliteConfig();
    /// <summary>
    /// 设置UIWindowConfig
    /// </summary>
    [AliasTooltip("Setting 【UIWindowConfig】")]
    public static EditorUIWinodwConfig setUIWindowConfig = new EditorUIWinodwConfig();
    /// <summary>
    /// 设置SetAssetDiskMapingFileXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFileXlsMapingConfig】")]
    public static EditorSetAssetDiskMapingFileXlsMapingConfig setAssetDiskMapingFileXlsMapingConfig = new EditorSetAssetDiskMapingFileXlsMapingConfig();
    /// <summary>
    /// 设置SetAssetDiskMapingFolderXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFolderXlsMapingConfig】")]
    public static EditorSetAssetDiskMapingFolderXlsMapingConfig setAssetDiskMapingFolderXlsMapingConfig = new EditorSetAssetDiskMapingFolderXlsMapingConfig();
}
#endif