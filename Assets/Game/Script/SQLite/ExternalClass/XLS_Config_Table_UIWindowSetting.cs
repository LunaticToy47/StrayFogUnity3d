using UnityEngine;
/// <summary>
/// UIWindowSetting实体
/// </summary>
public partial class XLS_Config_Table_UIWindowSetting
{
    /// <summary>
    /// 窗口绘制模式
    /// </summary>
    public RenderMode winRenderMode { get; private set; }
    /// <summary>
    /// 窗口打开模式
    /// </summary>
    public enUIWindowOpenMode winOpenMode { get; private set; }
    /// <summary>
    /// 窗口关闭模式
    /// </summary>
    public enUIWindowCloseMode winCloseMode { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        winRenderMode = (RenderMode)renderMode;
        winOpenMode = (enUIWindowOpenMode)openMode;
        winCloseMode = (enUIWindowCloseMode)closeMode;
    }
}
