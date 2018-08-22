using System;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// 加密解密扩展
/// </summary>
public static class CryptionExtend
{
    #region MD5加密
    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="_str">要加密的字符</param>
    /// <returns>加密后的字符</returns>
    public static string MD5(this string _str)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(_str)));
    }
    #endregion
}
