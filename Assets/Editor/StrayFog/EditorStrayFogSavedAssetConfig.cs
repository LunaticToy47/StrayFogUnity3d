#if UNITY_EDITOR
/// <summary>
/// 可保存的资源配置
/// </summary>
public sealed class EditorStrayFogSavedAssetConfig
{
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    [AliasTooltip("Setting 【AssetBundleName】")]
    public static EditorFolderConfigForSetAssetBundleName setAssetBundleName = new EditorFolderConfigForSetAssetBundleName();
    /// <summary>
    /// 设置SpritePackingTag
    /// </summary>
    [AliasTooltip("Setting 【SpritePackingTag】")]
    public static EditorFolderConfigForSetSpritePackingTag setSpritePackingTag = new EditorFolderConfigForSetSpritePackingTag();
    /// <summary>
    /// 设置Animator FMS Maping
    /// </summary>
    [AliasTooltip("Setting 【Animator FMS Maping】")]
    public static EditorFolderConfigForAnimatorControllerFMSMaping setAnimatorControllerFMSMaping = new EditorFolderConfigForAnimatorControllerFMSMaping();
    /// <summary>
    /// 设置XlsSchemaToSqlite
    /// </summary>
    [AliasTooltip("Setting 【XlsSchema To Sqlite】")]
    public static EditorFolderConfigForSchemaToSqlite setXlsSchemaToSqlite = new EditorFolderConfigForSchemaToSqlite();
    /// <summary>
    /// 设置UIWindowConfig
    /// </summary>
    [AliasTooltip("Setting 【UIWindowConfig】")]
    public static EditorXlsFileConfigForUIWindowSetting setUIWindowConfig = new EditorXlsFileConfigForUIWindowSetting();
    /// <summary>
    /// 设置AssetDiskMapingFileXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFileXlsMapingConfig】")]
    public static EditorXlsFileConfigForSetAssetDiskMapingFile setAssetDiskMapingFileXlsMapingConfig = new EditorXlsFileConfigForSetAssetDiskMapingFile();
    /// <summary>
    /// 设置AssetDiskMapingFolderXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFolderXlsMapingConfig】")]
    public static EditorXlsFileConfigForSetAssetDiskMapingFolder setAssetDiskMapingFolderXlsMapingConfig = new EditorXlsFileConfigForSetAssetDiskMapingFolder();
    /// <summary>
    /// 设置XLuaMapConfig
    /// </summary>
    [AliasTooltip("Setting 【XLuaMapConfig】")]
    public static EditorXlsFileConfigForXLuaMap setXLuaMapConfig = new EditorXlsFileConfigForXLuaMap();
}
#endif