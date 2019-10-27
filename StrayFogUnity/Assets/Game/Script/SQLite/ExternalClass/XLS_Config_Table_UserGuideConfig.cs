using System;
/// <summary>
/// XLS_Config_Table_UserGuideConfig 扩展
/// </summary>
public partial class XLS_Config_Table_UserGuideConfig
{
    /// <summary>
    /// 强引导窗口显示类型
    /// </summary>
    public enUserGuideConfig_StrongGuidDisplayType enStrongGuideDisplayType { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        enStrongGuideDisplayType = (enUserGuideConfig_StrongGuidDisplayType)strongGuidDisplayType;             
        base.OnResolve();
    }
}
