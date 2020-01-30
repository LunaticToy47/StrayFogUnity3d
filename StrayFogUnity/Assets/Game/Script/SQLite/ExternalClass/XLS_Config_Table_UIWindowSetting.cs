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
    public int winOpenMode { get; private set; }
    /// <summary>
    /// 窗口关闭模式
    /// </summary>
    public int winCloseMode { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        winRenderMode = (RenderMode)renderMode;
    }
}
