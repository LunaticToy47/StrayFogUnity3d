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
    /// <summary>
    /// 游戏Editor目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor目录", "Assets/Game/Editor", "游戏Editor目录")]
    Game_Editor,
    /// <summary>
    /// 游戏目录
    /// </summary>
    [EditorApplicationFolder("游戏目录", "Assets/Game", "游戏根目录")]
    Game,
    /// <summary>
    /// 游戏UIWindow目录
    /// </summary>
    [EditorApplicationFolder("游戏UIWindow目录", "Assets/Game/AssetBundles/UIWindow", "游戏UIWindow目录")]
    Game_AssetBundles_UIWindow,
    /// <summary>
    /// 游戏Assets目录
    /// </summary>
    [EditorApplicationFolder("游戏UIWindow目录", "Assets/Game/AssetBundles/Assets", "游戏Assets目录")]
    Game_AssetBundles_Assets,    
    /// <summary>
    /// 游戏运行时SQLite目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时SQLite目录", "Assets/Game/SQLite", "游戏运行时SQLite目录")]
    Game_SQLite,
    /// <summary>
    /// 游戏运行时FMS目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时FMS目录", "Assets/Game/FMS", "游戏运行时FMS目录")]
    Game_FMS,
    /// <summary>
    /// 游戏运行时AssetDiskMaping目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时AssetDiskMaping目录", "Assets/Game/AssetDiskMaping", "游戏运行时AssetDiskMaping目录")]
    Game_AssetDiskMaping,
    /// <summary>
    /// 游戏运行时UIWindow目录
    /// </summary>
    [EditorApplicationFolder("游戏运行时UIWindow目录", "Assets/Game/UIWindow", "游戏运行时UIWindow目录")]
    Game_UIWindow,
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


