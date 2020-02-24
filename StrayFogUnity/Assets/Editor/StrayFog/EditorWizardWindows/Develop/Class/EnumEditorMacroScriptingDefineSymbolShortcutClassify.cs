#if UNITY_EDITOR
using System;
/// <summary>
/// 脚本宏定义使用分类
/// </summary>
[Flags]
public enum enEditorMacroScriptingDefineSymbolShortcutClassify
{
    /// <summary>
    /// 开发环境
    /// </summary>
    [AliasTooltip("开发环境")]
    Developer = 0x1,
    /// <summary>
    /// 发布环境
    /// </summary>
    [AliasTooltip("发布环境")]
    Release = 0x2,
}
#endif
