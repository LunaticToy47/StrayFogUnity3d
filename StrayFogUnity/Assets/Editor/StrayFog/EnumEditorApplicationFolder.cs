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
    /// <summary>
    /// EditorResxTemplete_Shader目录
    /// </summary>
    [EditorApplicationFolder("EditorResxTemplete_Shader目录", "Assets/Editor/StrayFog/EditorResxTemplete/Shader", "EditorResxTemplete目录")]
    Editor_ResxTemplete_Shader,
    #endregion

    #region Game目录

    #region Game
    /// <summary>
    /// 游戏Editor目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor目录", "Assets/Game/Editor", "游戏Editor目录")]
    Game_Editor,
    /// <summary>
    /// 游戏Editor的Asmdef目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor的Asmdef目录", "Assets/Game/Editor/Asmdef", "游戏Editor的Asmdef目录")]
    Game_Editor_Asmdef,
    /// <summary>
    /// 游戏Editor的UIWindow目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor的UIWindow目录", "Assets/Game/Editor/UIWindow", "游戏Editor的UIWindow目录")]
    Game_Editor_UIWindow,
    /// <summary>
    /// 游戏Editor的PublishSetting目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor的PublishSetting目录", "Assets/Game/Editor/PublishSetting", "游戏Editor的PublishSetting目录")]
    Game_Editor_PublishSetting,
    /// <summary>
    /// 游戏Editor的XLua目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor的XLua目录", "Assets/Game/Editor/XLua", "游戏Editor的XLua目录")]
    Game_Editor_XLua,
    /// <summary>
    /// 游戏目录
    /// </summary>
    [EditorApplicationFolder("游戏目录", "Assets/Game", "游戏目录")]
    Game,
    #endregion

    #region XLS
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
    /// <summary>
    /// 工程SQLite脚本目录
    /// </summary>
    [EditorApplicationFolder("工程SQLite脚本目录", "Assets/Project/Script/SQLite", "工程SQLite脚本目录")]
    Project_Script_SQLite,
    #endregion
}
#endregion
#endif


