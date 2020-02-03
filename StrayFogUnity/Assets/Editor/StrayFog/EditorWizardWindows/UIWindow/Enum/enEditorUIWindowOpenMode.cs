#if UNITY_EDITOR
/// <summary>
/// 窗口打开模式
/// </summary>
public enum enEditorUIWindowOpenMode
{
    /// <summary>
    /// 【开启模式】默认
    /// </summary>
    [AliasTooltip("【开启模式】默认")]
    Default = 0,
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
#endif