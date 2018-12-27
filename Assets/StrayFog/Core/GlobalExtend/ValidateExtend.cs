using System.Text.RegularExpressions;
/// <summary>
/// 验证扩展
/// </summary>
public static class ValidateExtend
{
    #region 字符串验证
    /// <summary>
    /// 以字母开头且只能是字母、数字与下划线
    /// </summary>
    static Regex sRegLetterNumUnderline = new Regex(@"^[A-Za-z]+\w*$");
    /// <summary>
    /// 是否以字母开头且只能是字母、数字与下划线
    /// </summary>
    /// <param name="_input">要搜索匹配项的字符串</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsLetterNumUnderline(this string _input)
    {
        return sRegLetterNumUnderline.IsMatch(_input);
    }

    /// <summary>
    /// 合法的AssetBundleName字符,以字母开头且只能是字母、数字、下划线、右斜杠、小数点
    /// </summary>
    static Regex sRegLegalUnityAssetBundleName = new Regex(@"^(\w|\d|/|\.|_)+$");
    /// <summary>
    /// 是否以字母开头且只能是字母、数字与下划线
    /// </summary>
    /// <param name="_input">要搜索匹配项的字符串</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsLegalUnityAssetBundleName(this string _input)
    {
        return sRegLegalUnityAssetBundleName.IsMatch(_input);
    }
    #endregion
}
