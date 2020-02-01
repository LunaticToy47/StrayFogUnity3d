using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// RAM扩展
/// </summary>
public static class RAMUnitExtend
{
    /// <summary>
    /// enRAMUnit值名称映射
    /// </summary>
    static Dictionary<long, FieldInfo> smRamValueNameMaping = typeof(enRAMUnit).ValueToFieldForConstField<long>();

    #region 单位转换
    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_enRAMUnit">单位</param>
    /// <returns>转换后的大小</returns>
    public static double ToRAM(this long _byteSize, long _enRAMUnit)
    {
        return ((double)_byteSize) / _enRAMUnit;
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_enRAMUnit">单位</param>
    /// <returns>转换后的大小</returns>
    public static double ToRAM(this int _byteSize, long _enRAMUnit)
    {
        return ToRAM((long)_byteSize, _enRAMUnit);
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
        long unit = enRAMUnit.B;
        long max = unit;
        long value = max;
        foreach (KeyValuePair<long,FieldInfo> key in smRamValueNameMaping)
        {
            value = key.Key;
            if (_byteSize >= value)
            {
                max = Math.Max(max, value);
            }
        }
        unit = max;
        return ToRAMChar(_byteSize, unit);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_enRAMUnit">单位</param>
    /// <returns>内存字符</returns>
    public static string ToRAMChar(this int _byteSize, long _enRAMUnit)
    {
        return ToRAMChar((long)_byteSize, _enRAMUnit);
    }

    /// <summary>
    /// 内存大小转换
    /// </summary>
    /// <param name="_byteSize">字节</param>
    /// <param name="_enRAMUnit">单位</param>
    /// <returns>内存字符</returns>
    public static string ToRAMChar(this long _byteSize, long _enRAMUnit)
    {
        return ToRAM(_byteSize, _enRAMUnit).ToString() + smRamValueNameMaping[_enRAMUnit].ToString();
    }
    #endregion
}

/// <summary>
/// 内存单位
/// </summary>
public static class enRAMUnit
{
    /// <summary>
    /// 字节
    /// </summary>
    public const long B = 1;
    /// <summary>
    /// 千字节
    /// </summary>
    public const long KB = B << 10;
    /// <summary>
    /// 兆字节
    /// </summary>
    public const long MB = KB << 10;
    /// <summary>
    /// 十亿字节
    /// </summary>
    public const long GB = MB << 10;
    /// <summary>
    /// 万亿
    /// </summary>
    public const long TB = GB << 10;
}
