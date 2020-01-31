using System;

#region enDeveloperDefine 开发者宏定义
/// <summary>
/// 开发者宏定义
/// </summary>
[Serializable]
[AliasTooltip("开发者宏定义")]
public static class enDeveloperDefine
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
    /// 使用Entity-Component-System
    /// </summary>
    [AliasTooltip("使用Entity-Component-System")]
    public const int USEENTITYCOMPONENTSYSTEM = 0x8;
}
#endregion

#region enSystemDefine 系统宏定义
/// <summary>
/// 系统宏定义
/// </summary>
[Serializable]
[AliasTooltip("系统宏定义")]
public static class enSystemDefine
{
    /// <summary>
    /// 调试日志
    /// </summary>
    [AliasTooltip("调试日志")]
    public const int DEBUGLOG = 0x1;
    /// <summary>
    /// 秒表时间测定
    /// </summary>
    [AliasTooltip("秒表时间测定")]
    public const int STOPWATCH = 0x2;
    /// <summary>
    /// 强制外部资源加载
    /// </summary>
    [AliasTooltip("强制外部资源加载")]
    public const int FORCEEXTERNALLOADASSET = 0x4;
    /// <summary>
    /// 强制使用数据库
    /// </summary>
    [AliasTooltip("强制使用数据库")]
    public const int FORCEUSESQLITE = 0x8;
}
#endregion

#region enXLuaDefine xLua宏定义
/// <summary>
/// xLua宏定义
/// </summary>
[Serializable]
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