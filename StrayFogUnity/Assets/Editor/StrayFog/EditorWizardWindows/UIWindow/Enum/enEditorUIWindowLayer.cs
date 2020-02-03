#if UNITY_EDITOR
/// <summary>
/// UI窗口层级
/// </summary>
public enum enEditorUIWindowLayer
{
    /// <summary>
    /// 背景层【Layer:0】
    /// </summary>
    [AliasTooltip("背景层【Layer:0】")]
    Background = 0,
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
    /// 引导层【Layer:500】"
    /// </summary>
    [AliasTooltip("引导层【Layer:500】")]
    Guide = 500,
    /// <summary>
    /// 顶级层【Layer:Max】"
    /// </summary>
    [AliasTooltip("顶级层【Layer:Max】")]
    Highest = int.MaxValue,
}
#endif