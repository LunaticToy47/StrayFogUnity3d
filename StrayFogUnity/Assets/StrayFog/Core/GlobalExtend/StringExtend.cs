using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// 字符扩展
/// </summary>
public static class StringExtend
{
    #region 数字转中文大写
    /// <summary>
    /// 数字中文大写
    /// </summary>
    static string[] mSuperNum = new string[10] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
    /// <summary>
    /// 数字转成大写
    /// </summary>
    /// <param name="_num">数字</param>
    /// <returns>大写表示</returns>
    public static string ToSuperChinese(this int _num)
    {
        string d = _num.ToString();
        string r = string.Empty;

        for (int i = 0; i < d.Length; i++)
        {
            r += mSuperNum[int.Parse(d[i].ToString())];
        }
        return r;
    }
    #endregion

    #region 字符转十六制进表示
    /// <summary>
    /// 将指定字符串转为十六进制表示法
    /// </summary>
    /// <param name="_str">要转换的字符串</param>
    /// <returns>十六进制字符</returns>
    public static string ToHex(this string _str)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(_str));

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("x2"));
        }
        return result.ToString();
    }
    #endregion

    #region 文字长度
    /// <summary>
    /// 获得当前包括汉字文字长度
    /// </summary>
    /// <param name="_str">字符</param>
    /// <returns>长度</returns>
    public static int LengthChinese(this string _str)
    {
        if (_str.Length == 0) return 0;
        ASCIIEncoding ascii = new ASCIIEncoding();
        int tempLen = 0;
        byte[] s = ascii.GetBytes(_str);
        for (int i = 0; i < s.Length; i++)
        {
            if ((int)s[i] == 63)
            {
                tempLen += 2;
            }
            else
            {
                tempLen += 1;
            }
        }
        return tempLen;
    }
    #endregion

    #region 名称更改
    /// <summary>
    /// 移除路径后缀
    /// </summary>
    /// <param name="_path">路径</param>
    /// <returns>去除后缀的路径</returns>
    public static string RemoveFileExtension(this string _path)
    {
        return _path.Replace(Path.GetExtension(_path), "");
    }

    /// <summary>
    /// 更改路径文件名称
    /// </summary>
    /// <param name="_path">路径</param>
    /// <param name="_newname">新名称</param>
    /// <returns>更改后的路径</returns>
    public static string ReplaceFileName(this string _path, string _newname)
    {
        return string.Format("{0}/{1}{2}", Path.GetDirectoryName(_path), _newname, Path.GetExtension(_path));
    }

    /// <summary>
    /// 强制转为相对路径
    /// 移除路径前的\,/和空白符号
    /// </summary>
    /// <param name="_path">要转换的路径</param>
    /// <returns>相对路径</returns>
    public static string ForceRelativePath(this string _path)
    {
        return Regex.Replace(_path, @"^([\\|/|\s])?(.*)", "$2");
    }
    #endregion

    #region 数字对齐
    /// <summary>
    /// 右对齐此字符串中的字符，在左边用0填充以达到指定的总长度
    /// </summary>
    /// <param name="num">要对齐的数字</param>
    /// <param name="maxNum">最大数字</param>
    /// <returns>对齐后的字符</returns>
    public static string PadLeft(this int num, int maxNum)
    {
        return num.PadLeft(maxNum, '0');
    }
    /// <summary>
    /// 右对齐此字符串中的字符，在左边用指定的Unicode字符填充以达到指定的总长度
    /// </summary>
    /// <param name="num">要对齐的数字</param>
    /// <param name="maxNum">最大数字</param>
    /// <param name="paddingChar">填充字符</param>
    /// <returns>对齐后的字符</returns>
    public static string PadLeft(this int num, int maxNum, char paddingChar)
    {
        return num.ToString().PadLeft(maxNum.ToString().Length, paddingChar);
    }

    /// <summary>
    /// 左对齐此字符串中的字符，在右边用0填充以达到指定的总长度
    /// </summary>
    /// <param name="num">要对齐的数字</param>
    /// <param name="maxNum">最大数字</param>
    /// <returns>对齐后的字符</returns>
    public static string PadRight(this int num, int maxNum)
    {
        return num.PadRight(maxNum, '0');
    }
    /// <summary>
    /// 左对齐此字符串中的字符，在右边用指定的Unicode字符填充以达到指定的总长度
    /// </summary>
    /// <param name="num">要对齐的数字</param>
    /// <param name="maxNum">最大数字</param>
    /// <param name="paddingChar">填充字符</param>
    /// <returns>对齐后的字符</returns>
    public static string PadRight(this int num, int maxNum, char paddingChar)
    {
        return num.ToString().PadRight(maxNum.ToString().Length, paddingChar);
    }
    #endregion

    #region 清除字符串所有空白字符
    /// <summary>
    /// 清除所有不可见的空白字符
    /// </summary>
    /// <param name="_srcString"></param>
    /// <returns></returns>
    public static string TrimSpace(this string _srcString)
    {
        if (string.IsNullOrEmpty(_srcString)) { return ""; }
        return _srcString.Replace("\t", "").Replace(" ", "").Replace(" ", "").Replace("\n", "").Replace("\r", "");
    }
    #endregion

    #region Split 将源字符串按组分隔
    /// <summary>
    /// 分隔符映射
    /// </summary>
    static Dictionary<int, string[]> mSplitSymbolMaping = typeof(enSplitSymbol).ValueToAttributeSpecifyValueForConstField<AliasTooltipAttribute,string[]>((attr)=> {
        return new string[1] { attr.alias };
    });

    /// <summary>
    /// 将源字符串按组分隔
    /// </summary>
    /// <param name="_source">源字符</param>
    /// <param name="_enSplitSymbol">分割符enSplitSymbol</param>
    /// <returns>组字符</returns>
    public static string[] Split(this string _source, int _enSplitSymbol)
    {
        return string.IsNullOrEmpty(_source) ? new string[0] : _source.Split(mSplitSymbolMaping[_enSplitSymbol], StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// 将源字符串按组分隔
    /// </summary>
    /// <param name="_source">源字符</param>
    /// <param name="_enSplitSymbol">分割符enSplitSymbol</param>
    /// <returns>组字符</returns>
    public static T[] Split<T>(this string _source, int _enSplitSymbol)
    {
        Type t = typeof(T);
        T v = default;
        if (t.IsValueType)
        {
            throw new InvalidCastException("T must be ValueType");
        }
        string[] values = _source.Split(_enSplitSymbol);
        Func<string, T> fun = (arg) => { return (T)Convert.ChangeType(arg, t); };
        if (v is bool)
        {
            fun = (arg) => { return (T)Convert.ChangeType(Convert.ToByte(arg), t); };
        }
        T[] result = new T[0];
        if (values != null)
        {
            result = new T[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = fun(values[i]);
            }
        }
        return result;
    }
    #endregion

    #region Join 用默认连接符连接字符串
    /// <summary>
    /// 用默认连接符连接字符串
    /// </summary>
    /// <param name="_source">字符组</param>
    /// <returns>字符</returns>
    public static string Join(this List<string> _source)
    {
        return _source.Join(enSplitSymbol.Comma);
    }

    /// <summary>
    /// 按指定连接符连接字符串
    /// </summary>
    /// <param name="_source">字符组</param>
    /// <param name="_enSplitSymbol">连接符enSplitSymbol</param>
    /// <returns>字符</returns>
    public static string Join(this List<string> _source, int _enSplitSymbol)
    {
        return _source.ToArray().Join(_enSplitSymbol);
    }

    /// <summary>
    /// 用默认连接符连接字符串
    /// </summary>
    /// <param name="_source">字符组</param>
    /// <returns>字符</returns>
    public static string Join(this string[] _source)
    {
        return _source.Join(enSplitSymbol.Comma);
    }

    /// <summary>
    /// 按指定连接符连接字符串
    /// </summary>
    /// <param name="_source">字符组</param>
    /// <param name="_enSplitSymbol">连接符enSplitSymbol</param>
    /// <returns>字符</returns>
    public static string Join(this string[] _source, int _enSplitSymbol)
    {
        return string.Join(mSplitSymbolMaping[_enSplitSymbol][0], _source);
    }
    #endregion

    #region TransDescToSummary 转换描述为Summary形式
    /// <summary>
    /// 转换描述为Summary形式
    /// </summary>
    /// <param name="_desc">描述</param>
    /// <returns>描述</returns>
    public static string TransDescToSummary(this string _desc)
    {
        StringBuilder descSb = new StringBuilder();
        StringReader reader = new StringReader(_desc);
        string line = string.Empty;
        int num = 0;
        do
        {
            line = reader.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                if (num == 0)
                {
                    descSb.Append(line);
                }
                else
                {
                    descSb.Append(Environment.NewLine + "	///" + line);
                }
                num++;
            }
        } while (!string.IsNullOrEmpty(line));
        return descSb.ToString();
    }
    #endregion
}

/// <summary>
/// 分隔符
/// </summary>
public static class enSplitSymbol
{
    /// <summary>
    /// 逗号
    /// </summary>
    [AliasTooltip(",")]
    public const int Comma = 0x1;
    /// <summary>
    /// 下划线
    /// </summary>
    [AliasTooltip("_")]
    public const int Underline = 0x2;
    /// <summary>
    /// | 线
    /// </summary>
    [AliasTooltip("|")]
    public const int VerticalBar = 0x4;
    /// <summary>
    /// ;冒号
    /// </summary>
    [AliasTooltip(";")]
    public const int Colon = 0x8;
}
