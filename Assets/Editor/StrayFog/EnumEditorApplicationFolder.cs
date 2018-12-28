#if UNITY_EDITOR
#region enEditorProjectFolder 工程目录枚举
/// <summary>
/// 应用程序目录
/// </summary>
public enum enEditorApplicationFolder
{
    #region Editor目录
    /// <summary>
    /// Editor目录
    /// </summary>
    [EditorApplicationFolder("Editor目录", "Assets/Editor", "Editor目录")]
    Editor,
    /// <summary>
    /// EditorResxTemplete目录
    /// </summary>
    [EditorApplicationFolder("EditorResxTemplete目录", "Assets/Editor/StrayFog/EditorResxTemplete", "EditorResxTemplete目录")]
    Editor_ResxTemplete,
    #endregion

    #region Game目录

    #region Game
    /// <summary>
    /// 游戏Editor目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor目录", "Assets/Game/Editor", "游戏Editor目录")]
    Game_Editor,
    /// <summary>
    /// 游戏Editor的UIWindow目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor目录", "Assets/Game/Editor/UIWindow", "游戏Editor的UIWindow目录")]
    Game_Editor_UIWindow,
    /// <summary>
    /// 游戏目录
    /// </summary>
    [EditorApplicationFolder("游戏目录", "Assets/Game", "游戏根目录")]
    Game,
    #endregion

    #region XLS
    /// <summary>
    /// XLS数据源目录
    /// </summary>
    [EditorApplicationFolder("XLS数据源目录", "Assets/Game/Editor/XLS", "XLS数据源目录")]
    XLS_TableSrc,
    /// <summary>
    /// XLS表映射目录
    /// </summary>
    [EditorApplicationFolder("XLS表字段映射目录", "Assets/Game/Editor/XLS/TableMaping", "XLS表字段映射目录")]
    XLS_TableMaping,
    #endregion

    #region Assets
    /// <summary>
    /// 游戏Assets目录
    /// </summary>
    [EditorApplicationFolder("游戏Assets目录", "Assets/Game/AssetBundles/Assets", "游戏Assets目录")]
    Game_AssetBundles_Assets,
    #endregion

    #region SQLite
    /// <summary>
    /// 游戏运行时SQLite脚本目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时SQLite脚本目录", "Assets/Game/Script/SQLite", "游戏运行时SQLite脚本目录")]
    Game_Script_SQLite,
    #endregion

    #region FMS
    /// <summary>
    /// 游戏运行时FMS脚本目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时FMS脚本目录", "Assets/Game/Script/FMS", "游戏运行时FMS脚本目录")]
    Game_Script_FMS,
    #endregion

    #region AssetDiskMaping
    /// <summary>
    /// 游戏运行时AssetDiskMaping脚本目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时AssetDiskMaping脚本目录", "Assets/Game/Script/AssetDiskMaping", "游戏运行时AssetDiskMaping脚本目录")]
    Game_Script_AssetDiskMaping,
    #endregion

    #region UIWindow
    /// <summary>
    /// 游戏UIWindow目录
    /// </summary>
    [EditorApplicationFolder("游戏UIWindow目录", "Assets/Game/AssetBundles/UIWindow", "游戏UIWindow目录")]
    Game_AssetBundles_UIWindow,

    /// <summary>
    /// 游戏运行时UIWindow脚本目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时UIWindow脚本目录", "Assets/Game/Script/UIWindow", "游戏运行时UIWindow脚本目录")]
    Game_Script_UIWindow,
    #endregion

    #endregion

    #region Project目录
    /// <summary>
    /// 工程资源目录
    /// </summary>
    [EditorApplicationFolder("工程资源目录", "Assets/Project/Resources", "工程资源目录")]
    Project_Resources,
    /// <summary>
    /// 工程Shader目录
    /// </summary>
    [EditorApplicationFolder("工程Shader目录", "Assets/Project/Shader", "工程Shader目录")]
    Project_Shader,
    #endregion
}
#endregion
#endif


