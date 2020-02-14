#if UNITY_EDITOR
using System.Text.RegularExpressions;
/// <summary>
/// 正则表达式工具
/// </summary>
public class EditorUtility_Regex : AbsEditorSingle
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
}
#endif
