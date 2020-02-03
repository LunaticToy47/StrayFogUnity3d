/// <summary>
/// enUIWindowCloseMode
/// </summary>
public static class enUIWindowCloseMode
{

    /// <summary>
    /// 【关闭模式】默认
    /// </summary>
    public const int Default = 0;

    /// <summary>
    /// 【关闭模式】关闭时隐藏相同Layer层并且大于当前SiblingIndex的窗口
    /// </summary>
    public const int WhenCloseHiddenSameLayerAndMoreThanSiblingIndex = 1;

    /// <summary>
    /// 【关闭模式】关闭时隐藏大于当前SiblingIndex的窗口
    /// </summary>
    public const int WhenCloseHiddenMoreThanSiblingIndex = 2;

}
