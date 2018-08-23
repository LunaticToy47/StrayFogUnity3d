using System;
/// <summary>
/// 高低位互换扩展
/// </summary>
public static class HiloSwapExtend
{
    #region ToHiloSwap byte数组高低位互换
    /// <summary>
    /// byte数组高低位互换
    /// </summary>
    /// <param name="_value">byte数组</param>
    /// <returns>高低位互换后byte数组</returns>
    public static byte[] ToHiloSwap(this byte[] _value)
    {
        Array.Reverse(_value);
        return _value;
    }
    #endregion

    #region bool
    /// <summary>
    /// bool高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static bool ToHiloSwap(this bool _value)
    {
        return _value.GetBytes(true).ToBoolean();
    }
    #endregion

    #region char
    /// <summary>
    /// char高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static char ToHiloSwap(this char _value)
    {
        return _value;
    }
    #endregion

    #region short
    /// <summary>
    /// short高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static short ToHiloSwap(this short _value)
    {
        return _value;
    }
    #endregion

    #region int
    /// <summary>
    /// int高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static int ToHiloSwap(this int _value)
    {
        return _value;
    }
    #endregion

    #region long
    /// <summary>
    /// long高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static long ToHiloSwap(this long _value)
    {
        return _value;
    }
    #endregion

    #region float
    /// <summary>
    /// float高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static float ToHiloSwap(this float _value)
    {
        return _value;
    }
    #endregion

    #region double
    /// <summary>
    /// double高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static double ToHiloSwap(this double _value)
    {
        return _value;
    }
    #endregion

    #region ushort
    /// <summary>
    /// ushort高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static ushort ToHiloSwap(this ushort _value)
    {
        return _value;
    }
    #endregion

    #region uint
    /// <summary>
    /// uint高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static uint ToHiloSwap(this uint _value)
    {
        return _value;
    }
    #endregion

    #region ulong
    /// <summary>
    /// ulong高低位互换
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static ulong ToHiloSwap(this ulong _value)
    {
        return _value;
    }
    #endregion
}
