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
    public static EditorFolderConfigForSetAssetBundleName setFolderConfigForSetAssetBundleName = new EditorFolderConfigForSetAssetBundleName();
    /// <summary>
    /// 设置SpritePackingTag
    /// </summary>
    [AliasTooltip("Setting 【SpritePackingTag】")]
    public static EditorFolderConfigForSetSpritePackingTag setFolderConfigForSetSpritePackingTag = new EditorFolderConfigForSetSpritePackingTag();
    /// <summary>
    /// 设置Animator FMS Maping
    /// </summary>
    [AliasTooltip("Setting 【Animator FMS Maping】")]
    public static EditorFolderConfigForAnimatorControllerFMSMaping setFolderConfigForAnimatorControllerFMSMaping = new EditorFolderConfigForAnimatorControllerFMSMaping();
    /// <summary>
    /// 设置XlsSchemaToSqlite
    /// </summary>
    [AliasTooltip("Setting 【XlsSchema To Sqlite】")]
    public static EditorFolderConfigForSchemaToSqlite setFolderConfigForSchemaToSqlite = new EditorFolderConfigForSchemaToSqlite();
    /// <summary>
    /// 设置UIWindowPrefab
    /// </summary>
    [AliasTooltip("Setting 【UIWindowPrefab】")]
    public static EditorFolderConfigForUIWindowPrefab setFolderConfigForUIWindowPrefab = new EditorFolderConfigForUIWindowPrefab();
    /// <summary>
    /// 设置UIWindowScript
    /// </summary>
    [AliasTooltip("Setting 【UIWindowScript】")]
    public static EditorFolderConfigForUIWindowScript setFolderConfigForUIWindowScript = new EditorFolderConfigForUIWindowScript();
    /// <summary>
    /// 设置UIWindowConfig
    /// </summary>
    [AliasTooltip("Setting 【UIWindowConfig】")]
    public static EditorXlsFileConfigForUIWindowSetting setXlsFileConfigForUIWindowSetting = new EditorXlsFileConfigForUIWindowSetting();
    /// <summary>
    /// 设置AssetDiskMapingFileXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFileXlsMapingConfig】")]
    public static EditorXlsFileConfigForSetAssetDiskMapingFile setXlsFileConfigForSetAssetDiskMapingFile = new EditorXlsFileConfigForSetAssetDiskMapingFile();
    /// <summary>
    /// 设置AssetDiskMapingFolderXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFolderXlsMapingConfig】")]
    public static EditorXlsFileConfigForSetAssetDiskMapingFolder setXlsFileConfigForSetAssetDiskMapingFolder = new EditorXlsFileConfigForSetAssetDiskMapingFolder();
    /// <summary>
    /// 设置XLuaMapXlsConfig
    /// </summary>
    [AliasTooltip("Setting 【XLuaMapXlsConfig】")]
    public static EditorXlsFileConfigForXLuaMap setXlsFileConfigForXLuaMap = new EditorXlsFileConfigForXLuaMap();
    /// <summary>
    /// 设置AsmdefMapXlsConfig
    /// </summary>
    [AliasTooltip("Setting 【AsmdefMapXlsConfig】")]
    public static EditorXlsFileConfigForAsmdefMap setXlsFileConfigForAsmdefMap = new EditorXlsFileConfigForAsmdefMap();
    /// <summary>
    /// 设置XLuaMapFolder
    /// </summary>
    [AliasTooltip("Setting 【XLuaMapFolder】")]
    public static EditorFolderConfigForXLuaMap setFolderConfigForXLuaMap = new EditorFolderConfigForXLuaMap();
}
#endif