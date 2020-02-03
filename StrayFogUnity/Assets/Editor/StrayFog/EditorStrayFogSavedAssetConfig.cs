#if UNITY_EDITOR
/// <summary>
/// 可保存的资源配置
/// </summary>
public sealed class EditorStrayFogSavedAssetConfig
{
    #region EditorFolderConfigForSetAssetBundleName
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    static EditorFolderConfigForSetAssetBundleName mEditorFolderConfigForSetAssetBundleName;
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    [AliasTooltip("Setting 【AssetBundleName】")]
    public static EditorFolderConfigForSetAssetBundleName setFolderConfigForSetAssetBundleName {
        get {
            if (mEditorFolderConfigForSetAssetBundleName == null)
            {
                mEditorFolderConfigForSetAssetBundleName = new EditorFolderConfigForSetAssetBundleName();
            } 
            return mEditorFolderConfigForSetAssetBundleName;
        }
    }
    #endregion

    #region EditorFolderConfigForSetSpritePackingTag
    /// <summary>
    /// 设置SpritePackingTag
    /// </summary>
    static EditorFolderConfigForSetSpritePackingTag mEditorFolderConfigForSetSpritePackingTag;
    /// <summary>
    /// 设置SpritePackingTag
    /// </summary>
    [AliasTooltip("Setting 【SpritePackingTag】")]
    public static EditorFolderConfigForSetSpritePackingTag setFolderConfigForSetSpritePackingTag
    {
        get
        {
            if (mEditorFolderConfigForSetSpritePackingTag == null)
            {
                mEditorFolderConfigForSetSpritePackingTag = new EditorFolderConfigForSetSpritePackingTag();
            }
            return mEditorFolderConfigForSetSpritePackingTag;
        }
    }
    #endregion

    #region EditorFolderConfigForAnimatorControllerFMSMaping
    /// <summary>
    /// 设置Animator FMS Maping
    /// </summary>
    static EditorFolderConfigForAnimatorControllerFMSMaping mEditorFolderConfigForAnimatorControllerFMSMaping;
    /// <summary>
    /// 设置Animator FMS Maping
    /// </summary>
    [AliasTooltip("Setting 【Animator FMS Maping】")]
    public static EditorFolderConfigForAnimatorControllerFMSMaping setFolderConfigForAnimatorControllerFMSMaping
    {
        get {
            if (mEditorFolderConfigForAnimatorControllerFMSMaping == null)
            {
                mEditorFolderConfigForAnimatorControllerFMSMaping = new EditorFolderConfigForAnimatorControllerFMSMaping();
            }
            return mEditorFolderConfigForAnimatorControllerFMSMaping;
        }
    }
    #endregion

    #region EditorFolderConfigForSchemaToSqlite
    /// <summary>
    /// 设置XlsSchemaToSqlite
    /// </summary>
    static EditorFolderConfigForSchemaToSqlite mEditorFolderConfigForSchemaToSqlite;
    /// <summary>
    /// 设置XlsSchemaToSqlite
    /// </summary>
    [AliasTooltip("Setting 【XlsSchema To Sqlite】")]
    public static EditorFolderConfigForSchemaToSqlite setFolderConfigForSchemaToSqlite
    {
        get {
            if (mEditorFolderConfigForSchemaToSqlite == null)
            {
                mEditorFolderConfigForSchemaToSqlite = new EditorFolderConfigForSchemaToSqlite();
            }
            return mEditorFolderConfigForSchemaToSqlite;
        }
    }
    #endregion

    #region EditorFolderConfigForUIWindowPrefab
    /// <summary>
    /// 设置UIWindowPrefab
    /// </summary>
    static EditorFolderConfigForUIWindowPrefab mEditorFolderConfigForUIWindowPrefab;
    /// <summary>
    /// 设置UIWindowPrefab
    /// </summary>
    [AliasTooltip("Setting 【UIWindowPrefab】")]
    public static EditorFolderConfigForUIWindowPrefab setFolderConfigForUIWindowPrefab
    {
        get {
            if (mEditorFolderConfigForUIWindowPrefab == null)
            {
                mEditorFolderConfigForUIWindowPrefab = new EditorFolderConfigForUIWindowPrefab();
            }
            return mEditorFolderConfigForUIWindowPrefab;
        }
    }
    #endregion

    #region EditorFolderConfigForUIWindowScript
    /// <summary>
    /// 设置UIWindowScript
    /// </summary>
    static EditorFolderConfigForUIWindowScript mEditorFolderConfigForUIWindowScript;
    /// <summary>
    /// 设置UIWindowScript
    /// </summary>
    [AliasTooltip("Setting 【UIWindowScript】")]
    public static EditorFolderConfigForUIWindowScript setFolderConfigForUIWindowScript
    {
        get {
            if (null == mEditorFolderConfigForUIWindowScript)
            {
                mEditorFolderConfigForUIWindowScript = new EditorFolderConfigForUIWindowScript();
            }
            return mEditorFolderConfigForUIWindowScript;
        }
    }
    #endregion

    #region EditorXlsFileConfigForUIWindowSetting
    /// <summary>
    /// 设置UIWindowConfig
    /// </summary>
    static EditorXlsFileConfigForUIWindowSetting mEditorXlsFileConfigForUIWindowSetting;
    /// <summary>
    /// 设置UIWindowConfig
    /// </summary>
    [AliasTooltip("Setting 【UIWindowConfig】")]
    public static EditorXlsFileConfigForUIWindowSetting setXlsFileConfigForUIWindowSetting
    {
        get {
            if (null == mEditorXlsFileConfigForUIWindowSetting)
            {
                mEditorXlsFileConfigForUIWindowSetting = new EditorXlsFileConfigForUIWindowSetting();
            }
            return mEditorXlsFileConfigForUIWindowSetting;
        }
    }
    #endregion

    #region EditorXlsFileConfigForSetAssetDiskMapingFile
    /// <summary>
    /// 设置AssetDiskMapingFileXlsMapingConfig
    /// </summary>
    static EditorXlsFileConfigForSetAssetDiskMapingFile mEditorXlsFileConfigForSetAssetDiskMapingFile;
    /// <summary>
    /// 设置AssetDiskMapingFileXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFileXlsMapingConfig】")]
    public static EditorXlsFileConfigForSetAssetDiskMapingFile setXlsFileConfigForSetAssetDiskMapingFile
    {
        get {
            if (null == mEditorXlsFileConfigForSetAssetDiskMapingFile)
            {
                mEditorXlsFileConfigForSetAssetDiskMapingFile = new EditorXlsFileConfigForSetAssetDiskMapingFile();
            }
            return mEditorXlsFileConfigForSetAssetDiskMapingFile;
        }
    }
    #endregion

    #region EditorXlsFileConfigForSetAssetDiskMapingFolder
    /// <summary>
    /// 设置AssetDiskMapingFolderXlsMapingConfig
    /// </summary>
    static EditorXlsFileConfigForSetAssetDiskMapingFolder mEditorXlsFileConfigForSetAssetDiskMapingFolder;
    /// <summary>
    /// 设置AssetDiskMapingFolderXlsMapingConfig
    /// </summary>
    [AliasTooltip("Setting 【AssetDiskMapingFolderXlsMapingConfig】")]
    public static EditorXlsFileConfigForSetAssetDiskMapingFolder setXlsFileConfigForSetAssetDiskMapingFolder
    {
        get {
            if (null == mEditorXlsFileConfigForSetAssetDiskMapingFolder)
            {
                mEditorXlsFileConfigForSetAssetDiskMapingFolder = new EditorXlsFileConfigForSetAssetDiskMapingFolder();
            }
            return mEditorXlsFileConfigForSetAssetDiskMapingFolder;
        }
    }
    #endregion

    #region EditorXlsFileConfigForXLuaMap
    /// <summary>
    /// 设置XLuaMapXlsConfig
    /// </summary>
    static EditorXlsFileConfigForXLuaMap mEditorXlsFileConfigForXLuaMap;
    /// <summary>
    /// 设置XLuaMapXlsConfig
    /// </summary>
    [AliasTooltip("Setting 【XLuaMapXlsConfig】")]
    public static EditorXlsFileConfigForXLuaMap setXlsFileConfigForXLuaMap
    {
        get {
            if (null == mEditorXlsFileConfigForXLuaMap)
            {
                mEditorXlsFileConfigForXLuaMap = new EditorXlsFileConfigForXLuaMap();
            }
            return mEditorXlsFileConfigForXLuaMap;
        }
    }
    #endregion

    #region EditorXlsFileConfigForAsmdefMap
    /// <summary>
    /// 设置AsmdefMapXlsConfig
    /// </summary>
    static EditorXlsFileConfigForAsmdefMap mEditorXlsFileConfigForAsmdefMap;
    /// <summary>
    /// 设置AsmdefMapXlsConfig
    /// </summary>
    [AliasTooltip("Setting 【AsmdefMapXlsConfig】")]
    public static EditorXlsFileConfigForAsmdefMap setXlsFileConfigForAsmdefMap
    {
        get {
            if (null == mEditorXlsFileConfigForAsmdefMap)
            {
                mEditorXlsFileConfigForAsmdefMap = new EditorXlsFileConfigForAsmdefMap();
            }
            return mEditorXlsFileConfigForAsmdefMap;
        }
    }
    #endregion

    #region EditorFolderConfigForXLuaMap
    /// <summary>
    /// 设置XLuaMapFolder
    /// </summary>
    static EditorFolderConfigForXLuaMap mEditorFolderConfigForXLuaMap;
    /// <summary>
    /// 设置XLuaMapFolder
    /// </summary>
    [AliasTooltip("Setting 【XLuaMapFolder】")]
    public static EditorFolderConfigForXLuaMap setFolderConfigForXLuaMap
    {
        get {
            if (null == mEditorFolderConfigForXLuaMap)
            {
                mEditorFolderConfigForXLuaMap = new EditorFolderConfigForXLuaMap();
            }
            return mEditorFolderConfigForXLuaMap;
        }
    }
    #endregion

    #region EditorCsFileConfigForDynamicCreateDll
    /// <summary>
    /// 设置CsFileConfigForDynamicCreateDll
    /// </summary>
    static EditorCsFileConfigForDynamicCreateDll mEditorCsFileConfigForDynamicCreateDll;
    /// <summary>
    /// 设置CsFileConfigForDynamicCreateDll
    /// </summary>
    [AliasTooltip("Setting 【CsFileConfigForDynamicCreateDll】")]
    public static EditorCsFileConfigForDynamicCreateDll setCsFileConfigForDynamicCreateDll
    {
        get {
            if (null == mEditorCsFileConfigForDynamicCreateDll)
            {
                mEditorCsFileConfigForDynamicCreateDll = new EditorCsFileConfigForDynamicCreateDll();
            }
            return mEditorCsFileConfigForDynamicCreateDll;
        }
    }
    #endregion

    #region EditorDllSaveFolderConfigForDynamicCreateDll
    /// <summary>
    /// 设置DllSaveFolderConfigForDynamicCreateDll
    /// </summary>
    static EditorDllSaveFolderConfigForDynamicCreateDll mEditorDllSaveFolderConfigForDynamicCreateDll;
    /// <summary>
    /// 设置DllSaveFolderConfigForDynamicCreateDll
    /// </summary>
    [AliasTooltip("Setting 【DllSaveFolderConfigForDynamicCreateDll】")]
    public static EditorDllSaveFolderConfigForDynamicCreateDll setDllSaveFolderConfigForDynamicCreateDll
    {
        get {
            if (null == mEditorDllSaveFolderConfigForDynamicCreateDll)
            {
                mEditorDllSaveFolderConfigForDynamicCreateDll = new EditorDllSaveFolderConfigForDynamicCreateDll();
            }
            return mEditorDllSaveFolderConfigForDynamicCreateDll;
        }
    }
    #endregion
}
#endif