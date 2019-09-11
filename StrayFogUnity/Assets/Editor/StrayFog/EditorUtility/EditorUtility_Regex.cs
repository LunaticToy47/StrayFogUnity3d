#if UNITY_EDITOR
using System.Text.RegularExpressions;
/// <summary>
/// 正则表达式工具
/// </summary>
public class EditorUtility_Regex : AbsSingle
{
    #region MatchPairMarkTemplete 匹配成对标签
    /// <summary>
    /// 匹配成对标签
    /// </summary>
    /// <param name="_input">要匹配的字符</param>
    /// <param name="_mark">匹配的标签</param>
    /// <param name="_containMarkString">包含标签的字符</param>
    /// <returns>不包含标签的字符</returns>
    public string MatchPairMarkTemplete(string _input, string _mark, out string _containMarkString)
    {
        string patten = string.Format(@"({0})([\s|\S]*)({0})", _mark);
        Regex regex = new Regex(patten);
        Match match = regex.Match(_input);
        string result = _containMarkString = string.Empty;
        if (match.Success)
        {
            result = match.Groups[2].Value;
            _containMarkString = match.Value;
        }
        return result;
    }
    #endregion

    #region ClearRepeatCRLF 清除重复的回车换行符
    /// <summary>
    /// 清除字符串中重复的回车换行符
    /// </summary>
    /// <param name="_str">字符串</param>
    /// <returns>字符串</returns>
    public string ClearRepeatCRLF(string _str)
    {
        _str = Regex.Replace(_str, @"(\r\n[\r\n\t]*?\r\n)", "\r\n");
        _str = Regex.Replace(_str, @"(\r\n){2,}", "\r\n");
        return _str;
    }
    #endregion

    #region ClearCRLF 清除回车换行符
    /// <summary>
    /// 清除回车换行符
    /// </summary>
    /// <param name="_str">字符串</param>
    /// <returns>字符串</returns>
    public string ClearCRLF(string _str)
    {
        return Regex.Replace(_str, @"\r|\n", "");
    }
    #endregion
}
#endif
