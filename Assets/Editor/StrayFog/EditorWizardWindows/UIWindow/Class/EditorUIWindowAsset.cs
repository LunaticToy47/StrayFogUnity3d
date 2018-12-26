#if UNITY_EDITOR
using UnityEngine;
/// <summary>
/// 编辑器窗口资源
/// </summary>
public class EditorUIWindowAsset : AbsScriptableObject
{
    /// <summary>
    /// 画布绘制模式
    /// </summary>
    [AliasTooltip("画布绘制模式")]
    public RenderMode renderMode;
    /// <summary>
    /// 窗口Layer
    /// </summary>
    [AliasTooltip("窗口Layer")]
    public enUIWindowLayer layer;
    /// <summary>
    /// 打开模式
    /// </summary>
    [AliasTooltip("打开模式")]
    public enUIWindowOpenMode openMode;
    /// <summary>
    /// 关闭模式
    /// </summary>
    [AliasTooltip("关闭模式")]
    public enUIWindowCloseMode closeMode;
    /// <summary>
    /// 是否忽略开启关闭模式
    /// </summary>
    [AliasTooltip("是否忽略开启关闭模式")]
    public bool isIgnoreOpenCloseMode;
    /// <summary>
    /// 是否是不可自动恢复序列窗口
    /// </summary>
    [AliasTooltip("是否是不可自动恢复序列窗口")]
    public bool isNotAutoRestoreSequenceWindow;
    /// <summary>
    /// 是否是不可销毁实例
    /// </summary>
    [AliasTooltip("是否是不可销毁实例")]
    public bool isDonotDestroyInstance;
    /// <summary>
    /// 是否立即显示
    /// </summary>
    [AliasTooltip("是否立即显示")]
    public bool isImmediateDisplay;
    /// <summary>
    /// 跳转场景时是否手动关闭
    /// </summary>
    [AliasTooltip("跳转场景时是否手动关闭")]
    public bool isManualCloseWhenGotoScene;
    /// <summary>
    /// 是否是引导窗口
    /// </summary>
    [AliasTooltip("是否是引导窗口")]
    public bool isGuideWindow;
}
#endif