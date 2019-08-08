using UnityEngine;
/// <summary>
/// 唯一扩展
/// </summary>
public static class UniqueExtend
{
    #region  UniqueHashCode 字符串唯一HashCode值
    /*
    * DebugLog.Log("hash: " + "8@".GetHashCode().ToString() + ", " + "7_".GetHashCode().ToString())
    * 小概率事件，两个字符串HashCode值一致         
    */
    /// <summary>
    /// 唯一HashCode值
    /// </summary>
    /// <param name="_str">字符</param>
    /// <returns>HashCode</returns>
    public static int UniqueHashCode(this string _str)
    {
        //int h = _str.MD5().GetHashCode();
        //return (string.Format("{0}{1}",_str, _str.GetHashCode())).GetHashCode();
        return _str.GetHashCode();
    }
    #endregion
}