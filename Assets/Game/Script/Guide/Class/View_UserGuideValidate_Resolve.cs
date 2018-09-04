using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
/// <summary>
/// View_UserGuideValidate配置解析
/// </summary>
public partial class View_UserGuideValidate
{
    /// <summary>
    /// 验证类型
    /// </summary>
    [AliasTooltip("验证类型")]
    public List<enGuideValidateCondition> validateCondition { get; private set; }

    /// <summary>
    /// 验证Int值
    /// </summary>
    [AliasTooltip("验证Int值")]
    public List<int> validateIntValues { get; private set; }

    /// <summary>
    /// 验证Vector2值
    /// </summary>
    [AliasTooltip("验证Int值")]
    public List<Vector2> validateVector2Values { get; private set; }
    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        validateCondition = new List<enGuideValidateCondition>();

        string[] values = Encoding.UTF8.GetString(conditions).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (values != null && values.Length > 0)
        {
            foreach (string v in values)
            {
                validateCondition.Add((enGuideValidateCondition)Enum.Parse(typeof(enGuideValidateCondition), v));
            }
        }

        validateIntValues = new List<int>();
        values = Encoding.UTF8.GetString(intValues).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (values != null && values.Length > 0)
        {
            foreach (string v in values)
            {
                validateIntValues.Add(int.Parse(v));
            }
        }

        validateVector2Values = new List<Vector2>();
        values = Encoding.UTF8.GetString(vector2Values).Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
        if (values != null && values.Length > 0)
        {
            for (int i = 0; i < values.Length; i += 2)
            {
                validateVector2Values.Add(new Vector2(float.Parse(values[i]), float.Parse(values[i + 1])));
            }
        }
    }
}
