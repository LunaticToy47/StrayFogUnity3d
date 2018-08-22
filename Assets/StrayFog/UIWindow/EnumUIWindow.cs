#region enUIWindowLayer 窗口层级
/// <summary>
/// 窗口层级
/// </summary>
public enum enUIWindowLayer
{
    /// <summary>
    /// 背景层【Layer:0】
    /// </summary>
    [AliasTooltip("背景层【Layer:0】")]
    Background,
    /// <summary>
    /// 固定层【Layer:100】
    /// </summary>
    [AliasTooltip("固定层【Layer:100】")]
    Fixed = 100,
    /// <summary>
    /// 动态层【Layer:200】
    /// </summary>
    [AliasTooltip("动态层【Layer:200】")]
    Dynamic = 200,
    /// <summary>
    /// 提示框层【Layer:300】"
    /// </summary>
    [AliasTooltip("提示框层【Layer:300】")]
    Tooltip = 300,
    /// <summary>
    /// 弹出框层【Layer:400】"
    /// </summary>
    [AliasTooltip("弹出框层【Layer:400】")]
    Popup = 400,
    /// <summary>
    /// 顶级层【Layer:500】"
    /// </summary>
    [AliasTooltip("顶级层【Layer:500】")]
    Highest = 500,
}
#endregion

#region enUIWindowOpenMode
/// <summary>
/// 窗口打开模式
/// </summary>
public enum enUIWindowOpenMode
{
    /// <summary>
    /// 【开启模式】默认
    /// </summary>
    [AliasTooltip("【开启模式】默认")]
    Default,
    /// <summary>
    /// 【开启模式】开启时隐藏相同Layer层并且小于当前SiblingIndex的窗口，关闭时恢复隐藏的窗口
    /// </summary>
    [AliasTooltip("【开启模式】开启时隐藏相同Layer层并且小于当前SiblingIndex的窗口，关闭时恢复隐藏的窗口")]
    WhenDisplayHiddenSameLayerAndLessThanSiblingIndex = 100,
    /// <summary>
    /// 【开启模式】开启时隐藏小于当前SiblingIndex的窗口，关闭时恢复隐藏的窗口
    /// </summary>
    [AliasTooltip("【开启模式】开启时隐藏小于当前SiblingIndex的窗口，关闭时恢复隐藏的窗口")]
    WhenDisplayHiddenLessThanSiblingIndex = 200,
}
#endregion

#region enUIWindowCloseMode
/// <summary>
/// 窗口关闭模式
/// </summary>
public enum enUIWindowCloseMode
{
    /// <summary>
    /// 【关闭模式】默认
    /// </summary>
    [AliasTooltip("【关闭模式】默认")]
    Default,
    /// <summary>
    /// 【关闭模式】关闭时隐藏相同Layer层并且大于当前SiblingIndex的窗口
    /// </summary>
    [AliasTooltip("【关闭模式】关闭时隐藏相同Layer层并且大于当前SiblingIndex的窗口")]
    WhenCloseHiddenSameLayerAndMoreThanSiblingIndex = 100,
    /// <summary>
    /// 【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口
    /// </summary>
    [AliasTooltip("【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口")]
    WhenCloseHiddenMoreThanSiblingIndex = 200,
}
#endregion