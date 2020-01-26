using System;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// 加密解密扩展
/// </summary>
public static class CryptionExtend
{
    /// <summary>
    /// md5转换器
    /// </summary>
    readonly static MD5 mMD5CryptoServiceProvider = new MD5CryptoServiceProvider();

    #region MD5加密
    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="_str">要加密的字符</param>
    /// <returns>加密后的字符</returns>
    public static string MD5(this string _str)
    {
        return BitConverter.ToString(_str.MD5Hash());
    }

    /// <summary>
    /// MD5Hash流
    /// </summary>
    /// <param name="_str">字符串</param>
    /// <returns>MD5Hash流</returns>
    public static byte[] MD5Hash(this string _str)
    {
        return mMD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(_str));
    }
    #endregion
}
