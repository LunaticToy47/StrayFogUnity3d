/// <summary>
/// 窗口关闭模式
/// </summary>
public static class enUIWindowCloseMode
{
    /// <summary>
    /// 【关闭模式】默认
    /// </summary>
    [AliasTooltip("【关闭模式】默认")]
    public const int Default = 0;
    /// <summary>
    /// 【关闭模式】关闭时隐藏相同Layer层并且大于当前SiblingIndex的窗口
    /// </summary>
    [AliasTooltip("【关闭模式】关闭时隐藏相同Layer层并且大于当前SiblingIndex的窗口")]
    public const int WhenCloseHiddenSameLayerAndMoreThanSiblingIndex = 100;
    /// <summary>
    /// 【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口
    /// </summary>
    [AliasTooltip("【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口")]
    public const int WhenCloseHiddenMoreThanSiblingIndex = 200;
}