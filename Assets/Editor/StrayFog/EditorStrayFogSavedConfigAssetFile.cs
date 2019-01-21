#if UNITY_EDITOR
/// <summary>
/// 可保存的配置资源文件
/// </summary>
public sealed class EditorStrayFogSavedConfigAssetFile
{
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    public static EditorSetAssetBundleNameConfig setAssetBundleName = new EditorSetAssetBundleNameConfig();
    /// <summary>
    /// 设置SpritePackingTag
    /// </summary>
    public static EditorSetSpritePackingTagConfig setSpritePackingTag = new EditorSetSpritePackingTagConfig();
    /// <summary>
    /// 设置Animator
    /// </summary>
    public static EditorAnimatorControllerFMSMapingConfig setAnimatorControllerFMSMaping = new EditorAnimatorControllerFMSMapingConfig();
    /// <summary>
    /// 设置XlsSchemaToSqlite
    /// </summary>
    public static EditorXlsSchemaToSqliteConfig setXlsSchemaToSqlite = new EditorXlsSchemaToSqliteConfig();
    /// <summary>
    /// 设置UIWindowConfig
    /// </summary>
    public static EditorUIWinodwConfig setUIWindowConfig = new EditorUIWinodwConfig();
    
}
#endif