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
    /// 游戏Editor/Bat目录
    /// </summary>
    [EditorApplicationFolder("游戏Editor/Bat目录", "Assets/Game/Editor/Bat", "游戏Editor/Bat目录")]
    Game_Editor_Bat,
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

    #region Hotfix_SimulateBehaviour
    /// <summary>
    /// Hotfix模拟Behaviour目录
    /// </summary>
    [EditorApplicationFolder("Hotfix模拟Behaviour目录", "Assets/Game/StrayFog/0MonoBehaviour/AbsClass/SimulateBehaviour", "Hotfix模拟Behaviour目录")]
    Hotfix_SimulateBehaviour,
    #endregion

    #endregion

    #region Game/StrayFog目录
    #region UIWindowMgr
    /// <summary>
    /// UI窗口管理器目录
    /// </summary>
    [EditorApplicationFolder("UI窗口管理器目录", "Assets/Game/StrayFog/UIWindowMgr", "UI窗口管理器目录")]
    Game_StrayFog_UIWindowMgr,
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

    #region StrayFogRunning目录
    /// <summary>
    /// StrayFog运行时SimulateBehaviour目录
    /// </summary>
    [EditorApplicationFolder("StrayFog运行时SimulateBehaviour目录", "Assets/StrayFog/Running/SimulateBehaviour", "StrayFog运行时SimulateBehaviour目录")]
    StrayFog_Running_SimulateBehaviour,
    #endregion
}
#endregion
#endif


