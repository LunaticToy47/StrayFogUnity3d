using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Table_UserGuideTrigger配置解析
/// </summary>
public partial class XLS_Config_Table_UserGuideTrigger
{
    /// <summary>
    /// 触发条件组
    /// </summary>
    [AliasTooltip("触发条件组")]
    public List<enGuideTriggerCondition> triggerCondition { get; private set; }
    /// <summary>
    /// 引导类型
    /// </summary>
    [AliasTooltip("引导类型")]
    public enGuideTriggerType triggerGuideType { get; private set; }
    /// <summary>
    /// 触发显示类型
    /// </summary>
    [AliasTooltip("触发显示类型")]
    public enGuideDisplayType triggerDisplayType { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        triggerCondition = new List<enGuideTriggerCondition>();
        if (conditions != null && conditions.Length > 0)
        {
            foreach (int v in conditions)
            {
                triggerCondition.Add((enGuideTriggerCondition)v);
            }
        }
        triggerGuideType = (enGuideTriggerType)guideType;
        triggerDisplayType = (enGuideDisplayType)displayType;
    }
}
