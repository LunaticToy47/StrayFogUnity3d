using System;
using System.Collections.Generic;

/// <summary>
/// RAM扩展
/// </summary>
public static class RAMUnitExtend
{
    /// <summary>
    /// enRAMUnit枚举
    /// </summary>
    static List<enRAMUnit> smRamNames = typeof(enRAMUnit).ToEnums<enRAMUnit>();

    #region 单位转换
    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_unit">单位</param>
    /// <returns>转换后的大小</returns>
    public static double ToRAM(this long _byteSize, enRAMUnit _unit)
    {
        return ((double)_byteSize) / ((long)_unit);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_unit">单位</param>
    /// <returns>转换后的大小</returns>
    public static double ToRAM(this int _byteSize, enRAMUnit _unit)
    {
        return ToRAM((long)_byteSize, _unit);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <returns>转换后的大小</returns>
    public static string ToRAMChar(this int _byteSize)
    {
        return ToRAMChar((long)_byteSize);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <returns>转换后的大小</returns>
    public static string ToRAMChar(this long _byteSize)
    {
        enRAMUnit unit = enRAMUnit.B;
        long max = (long)unit;
        long value = max;
        foreach (enRAMUnit u in smRamNames)
        {
            value = (long)u;
            if (_byteSize >= value)
            {
                max = Math.Max(max, value);
            }
        }
        unit = (enRAMUnit)max;
        return ToRAMChar(_byteSize, unit);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_unit">单位</param>
    /// <returns>内存字符</returns>
    public static string ToRAMChar(this int _byteSize, enRAMUnit _unit)
    {
        return ToRAMChar((long)_byteSize, _unit);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_unit">单位</param>
    /// <returns>内存字符</returns>
    public static string ToRAMChar(this long _byteSize, enRAMUnit _unit)
    {
        return ToRAM(_byteSize, _unit).ToString() + _unit.ToString();
    }
    #endregion
}

/// <summary>
/// 内存单位
/// </summary>
public enum enRAMUnit : long
{
    /// <summary>
    /// 字节
    /// </summary>
    B = 1,
    /// <summary>
    /// 千字节
    /// </summary>
    KB = B << 10,
    /// <summary>
    /// 兆字节
    /// </summary>
    MB = KB << 10,
    /// <summary>
    /// 十亿字节
    /// </summary>
    GB = MB << 10,
    /// <summary>
    /// 万亿
    /// </summary>
    TB = GB << 10,
}
