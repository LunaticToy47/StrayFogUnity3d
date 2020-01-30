using System.Collections.Generic;
using System.Text.RegularExpressions;
/// <summary>
/// 正则表达式枚举
/// </summary>
public enum enRegularExpression
{
    /// <summary>
    /// 以字母开头且只能是字母、数字与下划线
    /// </summary>
    [AliasTooltip("以字母开头且只能是字母、数字与下划线")]
    [RegularExpression(@"^[A-Za-z]+\w*$")]
    LetterNumUnderline,
    /// <summary>
    /// 合法的AssetBundleName名称
    /// 【以字母开头且只能是字母、数字、/、.、下划线、】
    /// </summary>
    [AliasTooltip("合法的AssetBundleName名称【以字母开头且只能是字母、数字、/、.、下划线、】")]
    [RegularExpression(@"^[A-Za-z]+(\w|\d|/|\.)+$")]
    AssetBundleName,
    /// <summary>
    /// 数字
    /// </summary>
    [AliasTooltip("数字")]
    [RegularExpression(@"^\d+$")]
    Numberic,
}
/// <summary>
/// 正则表达式扩展
/// </summary>
public static class RegularExpressionExtendEngine
{
    /// <summary>
    /// 正则属性映射
    /// </summary>
    static readonly Dictionary<int, RegularExpressionAttribute> msrRegularMaping =
        typeof(enRegularExpression).ValueToAttributeForConstField<RegularExpressionAttribute>();

    /// <summary>
    /// 是否匹配指定的规则
    /// </summary>
    /// <param name="_input">输入字符</param>
    /// <param name="_pattern">规则</param>
    /// <returns>true:匹配,false:不匹配</returns>
    public static bool IsMatch(this string _input, enRegularExpression _pattern)
    {
        return Regex.IsMatch(_input, msrRegularMaping[(int)_pattern].pattern);
    }
}