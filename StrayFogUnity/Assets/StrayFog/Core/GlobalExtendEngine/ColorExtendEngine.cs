using UnityEngine;
/// <summary>
/// 颜色扩展
/// </summary>
public static class ColorExtendEngine
{
    #region 颜色转字十六进制表示法
    /// <summary>
    /// 将颜色转换成十六进制表示法
    /// </summary>
    /// <param name="_color">颜色</param>
    /// <returns>标签值</returns>
    public static string ToRGB(this Color _color)
    {
        return _color.ToRGB(false);
    }

    /// <summary>
    /// 将颜色转换成十六进制表示法
    /// </summary>
    /// <param name="_color">颜色</param>
    /// <returns>标签值</returns>
    public static string ToRGBA(this Color _color)
    {
        return _color.ToRGBA(false);
    }

    /// <summary>
    /// 将颜色转换成十六进制表示法
    /// </summary>
    /// <param name="_color">颜色</param>
    /// <param name="_symbol">是否带#</param>
    /// <returns>标签值</returns>
    public static string ToRGB(this Color _color, bool _symbol)
    {
        Color32 col = _color;
        return _symbol ? "#" : "" + col.r.ToString("X2") + col.g.ToString("X2") + col.b.ToString("X2");
    }

    /// <summary>
    /// 将颜色转换成十六进制表示法
    /// </summary>
    /// <param name="_color">颜色</param>
    /// <param name="_symbol">是否带#</param>
    /// <returns>标签值</returns>
    public static string ToRGBA(this Color _color, bool _symbol)
    {
        Color32 col = _color;
        return _symbol ? "#" : "" + col.r.ToString("X2") + col.g.ToString("X2") + col.b.ToString("X2") + col.a.ToString("X2");
    }

    /// <summary>
    /// 改变颜色亮度
    /// 因子<0变间
    /// >0变亮
    /// </summary>
    /// <param name="color">颜色</param>
    /// <param name="factor">因子(-1,1)</param>
    /// <returns>改变后的颜色</returns>
    public static Color ToColorBrightness(this Color _color, float _factor)
    {
        Color32 c = _color;
        float red = (float)c.r;
        float green = (float)c.g;
        float blue = (float)c.b;
        _factor = Mathf.Clamp(_factor, -1, 1);
        if (_factor < 0)
        {
            _factor = 1 + _factor;
            red *= _factor;
            green *= _factor;
            blue *= _factor;
        }
        else
        {
            red = (255 - red) * _factor + red;
            green = (255 - green) * _factor + green;
            blue = (255 - blue) * _factor + blue;
        }
        c.r = (byte)Mathf.Clamp((int)red, 0, 255);
        c.g = (byte)Mathf.Clamp((int)green, 0, 255);
        c.b = (byte)Mathf.Clamp((int)blue, 0, 255);
        return c;
    }
    #endregion    
}
