#if UNITY_EDITOR
/// <summary>
/// 窗口关闭模式
/// </summary>
public enum enEditorUIWindowCloseMode
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
    WhenCloseHiddenSameLayerAndMoreThanSiblingIndex,
    /// <summary>
    /// 【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口
    /// </summary>
    [AliasTooltip("【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口")]
    WhenCloseHiddenMoreThanSiblingIndex,
}
#endif