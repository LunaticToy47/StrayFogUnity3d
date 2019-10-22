/// <summary>
/// XLS_Config_Table_UserGuideConfig 扩展
/// </summary>
public partial class XLS_Config_Table_UserGuideConfig
{
    /// <summary>
    /// 引导类型
    /// </summary>
    public enUserGuideConfig_GuideType enGuideType { get; private set; }
    /// <summary>
    /// 强引导窗口显示类型
    /// </summary>
    public enUserGuideConfig_StrongGuidDisplayType enStrongGuideDisplayType { get; private set; }
    /// <summary>
    /// 触发条件类型
    /// </summary>
    public enUserGuideConfig_TriggerConditionType enTriggerConditionType { get; private set; }
    /// <summary>
    /// 验证条件类型
    /// </summary>
    public enUserGuideConfig_ValidateConditionType enValidateConditionType { get; private set; }
    
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        enGuideType = (enUserGuideConfig_GuideType)guideType;
        enStrongGuideDisplayType = (enUserGuideConfig_StrongGuidDisplayType)strongGuidDisplayType;
        enTriggerConditionType = (enUserGuideConfig_TriggerConditionType) triggerConditionType;
        enValidateConditionType = (enUserGuideConfig_ValidateConditionType) validateConditionType;
        base.OnResolve();
    }
}
