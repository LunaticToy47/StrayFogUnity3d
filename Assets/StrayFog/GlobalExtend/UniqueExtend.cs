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
        return _str.MD5().GetHashCode();
    }
    #endregion
}