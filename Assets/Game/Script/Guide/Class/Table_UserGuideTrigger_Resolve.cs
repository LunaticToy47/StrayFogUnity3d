using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Table_UserGuideTrigger配置解析
/// </summary>
public partial class Table_UserGuideTrigger
{
    /// <summary>
    /// 触发条件组
    /// </summary>
    [AliasTooltip("触发条件组")]
    public List<enGuideTriggerCondition> triggerCondition { get; private set; }
    /// <summary>
    /// 触发Int值组
    /// </summary>
    [AliasTooltip("触发Int值组")]
    public List<int> triggerIntValues { get; private set; }
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
        triggerIntValues = new List<int>();
        string[] values = Encoding.UTF8.GetString(conditions).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (values != null && values.Length > 0)
        {
            foreach (string v in values)
            {
                triggerCondition.Add((enGuideTriggerCondition)Enum.Parse(typeof(enGuideTriggerCondition), v));
            }
        }

        values = Encoding.UTF8.GetString(intValues).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (values != null && values.Length > 0)
        {
            foreach (string v in values)
            {
                triggerIntValues.Add(int.Parse(v));
            }
        }

        triggerGuideType = (enGuideTriggerType)guideType;
        triggerDisplayType = (enGuideDisplayType)displayType;
    }
}
