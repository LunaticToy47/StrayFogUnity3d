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
}
