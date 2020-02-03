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
    /// enUIWindowLayer窗口Layer
    /// </summary>
    [AliasTooltip("窗口Layer")]
    public enEditorUIWindowLayer layer;
    /// <summary>
    /// 打开模式enUIWindowOpenMode
    /// </summary>
    [AliasTooltip("打开模式")]
    public enEditorUIWindowOpenMode openMode;
    /// <summary>
    /// 关闭模式enUIWindowCloseMode
    /// </summary>
    [AliasTooltip("关闭模式")]
    public enEditorUIWindowCloseMode closeMode;
    /// <summary>
    /// 是否忽略开启关闭模式
    /// </summary>
    [AliasTooltip("是否忽略开启关闭模式")]
    public bool isIgnoreOpenCloseMode;
    /// <summary>
    /// 是否是自动恢复序列窗口
    /// </summary>
    [AliasTooltip("是否是自动恢复序列窗口")]
    public bool isAutoRestoreSequenceWindow;
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