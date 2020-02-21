/// <summary>
/// 宏定义
/// </summary>
public static class EditorMacroDefineScriptingDefineSymbols
{
    #region enLoadAssetModeDefine 资源加载模式宏定义
    /// <summary>
    /// 资源加载模式宏定义
    /// </summary>
    [AliasTooltip("资源加载模式宏定义")]
    public static class enLoadAssetModeDefine
    {
        /// <summary>
        /// StreamingAssets模式【整包】
        /// </summary>        
        [AliasTooltip("StreamingAssets模式【整包】")]
        public const int STREAMINGASSETS = 0x1;
        /// <summary>
        /// AssetBundle模式【热更包】
        /// </summary>
        [AliasTooltip("AssetBundle模式【热更包】")]
        public const int ASSETBUNDLE = 0x2;
    }
    #endregion

    #region enLoadConfigDefine 加载配置表模式宏定义
    /// <summary>
    /// 加载配置表模式宏定义
    /// </summary>
    [AliasTooltip("加载配置表模式宏定义")]
    public static class enLoadConfigDefine
    {
        /// <summary>
        /// XLS表
        /// </summary>
        [AliasTooltip("XLS表")]
        public const int XLS = 0x1;
        /// <summary>
        /// StreamingAssets模式
        /// </summary>
        [AliasTooltip("SQLite数据库")]
        public const int SQLITE = 0x2;
    }
    #endregion

    #region enSystemDefine 系统宏定义
    /// <summary>
    /// 系统宏定义
    /// </summary>
    [AliasTooltip("系统宏定义")]
    public static class enSystemDefine
    {
        /// <summary>
        /// 秒表时间测定
        /// </summary>
        [AliasTooltip("秒表时间测定")]
        public const int STOPWATCH = 0x1;
        /// <summary>
        /// 使用Entity-Component-System
        /// </summary>
        [AliasTooltip("使用Entity-Component-System")]
        public const int USEENTITYCOMPONENTSYSTEM = 0x2;
    }
    #endregion

    #region enLogDefine 日志宏定义
    /// <summary>
    /// 日志宏定义
    /// </summary>
    [AliasTooltip("日志宏定义")]
    public static class enLogDefine
    {
        /// <summary>
        /// UGUI日志
        /// </summary>
        [AliasTooltip("UGUI日志")]
        public const int UGUILOG = 0x1;
        /// <summary>
        /// 网络日志
        /// </summary>
        [AliasTooltip("网络日志")]
        public const int NETWORKLOG = 0x2;
        /// <summary>
        /// Config日志
        /// </summary>
        [AliasTooltip("Config日志")]
        public const int CONFIGLOG = 0x4;
        /// <summary>
        /// Debug日志
        /// </summary>
        [AliasTooltip("Debug日志")]
        public const int DEBUGLOG = 0x8;        
    }
    #endregion        

    #region enXLuaDefine xLua宏定义
    /// <summary>
    /// xLua宏定义
    /// </summary>
    [AliasTooltip("xLua宏定义")]
    public static class enXLuaDefine
    {
        /// <summary>
        /// 打开hotfix功能
        /// </summary>
        [AliasTooltip("打开hotfix功能")]
        public const int HOTFIX_ENABLE = 0x1;
        /// <summary>
        /// 采用内嵌到编辑器的方式注入
        /// </summary>
        [AliasTooltip("采用内嵌到编辑器的方式注入")]
        public const int INJECT_WITHOUT_TOOL = 0x2;
        /// <summary>
        /// 反射时打印warning
        /// </summary>
        [AliasTooltip("反射时打印warning")]
        public const int NOT_GEN_WARNING = 0x4;
        /// <summary>
        /// 以偏向减少代码段的方式生成代码
        /// </summary>
        [AliasTooltip("以偏向减少代码段的方式生成代码")]
        public const int GEN_CODE_MINIMIZE = 0x8;
    }
    #endregion
}
