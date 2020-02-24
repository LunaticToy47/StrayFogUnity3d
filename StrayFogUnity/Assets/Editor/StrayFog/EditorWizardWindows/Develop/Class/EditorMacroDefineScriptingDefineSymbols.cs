/// <summary>
/// 宏定义
/// </summary>
public static class EditorMacroDefineScriptingDefineSymbols
{
    #region enUpdateAssetModeDefine 资源更新模式宏定义
    /// <summary>
    /// 资源更新模式宏定义
    /// </summary>
    [AliasTooltip("资源更新模式宏定义")]
    [EditorRadio()]
    public static class enUpdateAssetModeDefine
    {
        /// <summary>
        /// 网络更新【从指定地址更新资源】
        /// </summary>
        [AliasTooltip("网络更新【从指定地址更新资源】")]
        [EditorMacroScriptingDefineSymbol(enEditorMacroScriptingDefineSymbolShortcutClassify.Release)]
        public const int UPDATEFROMNETWORK = 0x1;
    }
    #endregion

    #region enLoadAssetModeDefine 资源加载模式宏定义
    /// <summary>
    /// 资源加载模式宏定义
    /// </summary>
    [AliasTooltip("资源加载模式宏定义")]
    [EditorRadio()]
    public static class enLoadAssetModeDefine
    {
        /// <summary>
        /// 从AssetBundle加载资源
        /// </summary>
        [AliasTooltip("从AssetBundle加载资源")]
        [EditorMacroScriptingDefineSymbol(enEditorMacroScriptingDefineSymbolShortcutClassify.Release)]
        public const int FROMASSETBUNDLE = 0x1;
    }
    #endregion

    #region enLoadConfigDefine 配置表数据加载模式宏定义
    /// <summary>
    /// 配置表数据加载模式宏定义
    /// </summary>
    [AliasTooltip("配置表数据加载模式宏定义")]
    [EditorRadio()]
    public static class enLoadConfigDefine
    {
        /// <summary>
        /// StreamingAssets模式
        /// </summary>
        [AliasTooltip("SQLite数据库")]
        [EditorMacroScriptingDefineSymbol(enEditorMacroScriptingDefineSymbolShortcutClassify.Release)]
        public const int SQLITE = 0x1;
    }
    #endregion

    #region enILRuntimeDefine ILRuntime热更宏定义
    /// <summary>
    /// ILRuntime热更宏定义
    /// </summary>
    [AliasTooltip("ILRuntime热更宏定义")]
    [EditorRadio()]
    public static class enILRuntimeDefine
    {
        /// <summary>
        /// ILRuntime
        /// </summary>
        [AliasTooltip("ILRuntime")]
        [EditorMacroScriptingDefineSymbol(enEditorMacroScriptingDefineSymbolShortcutClassify.Release)]
        public const int ILRUNTIME = 0x1;
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
        public const int USEECS = 0x2;
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
        [EditorMacroScriptingDefineSymbol(enEditorMacroScriptingDefineSymbolShortcutClassify.Release)]
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
