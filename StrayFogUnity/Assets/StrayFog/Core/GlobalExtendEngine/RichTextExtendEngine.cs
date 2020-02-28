using UnityEngine;
/// <summary>
/// 超文本扩展
/// </summary>
public static class RichTextExtendEngine
{
    #region 将文本加上颜色标记
    /// <summary>
    /// 将文本加上颜色标记
    /// </summary>
    /// <param name="_string">文本</param>
    /// <param name="_color">颜色</param>
    /// <returns></returns>
    public static string ApplyColor(this string _text, Color _color)
    {
        return string.Format("<color={0}>{1}</color>", _color.ToRGB(), _text);
    }

    /// <summary>
    /// 将Format格式化文本加上颜色标记
    /// </summary>
    /// <param name="_format">格式化</param>
    /// <param name="_color">颜色</param>
    /// <param name="_args">参数</param>
    /// <returns></returns>
    public static string FormatApplyColor(this string _format, Color _color,params object[] _args)
    {
        return string.Format("<color={0}>{1}</color>", _color.ToRGB(), string.Format(_format, _args));
    }
    #endregion
}
