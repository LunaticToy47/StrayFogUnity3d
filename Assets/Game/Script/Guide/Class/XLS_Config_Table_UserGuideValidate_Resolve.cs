using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// Table_UserGuideValidate配置解析
/// </summary>
public partial class XLS_Config_Table_UserGuideValidate
{
    /// <summary>
    /// 验证类型
    /// </summary>
    [AliasTooltip("验证类型")]
    public List<enGuideValidateCondition> validateCondition { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        validateCondition = new List<enGuideValidateCondition>();
        if (conditions != null && conditions.Length > 0)
        {
            foreach (int v in conditions)
            {
                validateCondition.Add((enGuideValidateCondition)v);
            }
        }
    }
}
