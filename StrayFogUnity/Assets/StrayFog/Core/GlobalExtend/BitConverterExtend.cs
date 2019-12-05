using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 比特转换扩展
/// </summary>
public static class BitConverterExtend
{
    #region GetBytes
    #region bool
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this bool _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this bool _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region char
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this char _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this char _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region short
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this short _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this short _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region int
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this int _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this int _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region long
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this long _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this long _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region float
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this float _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this float _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region double
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this double _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this double _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region ushort
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this ushort _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this ushort _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region uint
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this uint _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this uint _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region ulong
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this ulong _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this ulong _value, bool _hiloSwap)
    {
        return GetBytes(_value, (v) => { return BitConverter.GetBytes(v); }, _hiloSwap);
    }
    #endregion

    #region string
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this string _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this string _value, bool _hiloSwap)
    {
        List<byte> result = new List<byte>();
        byte[] bytes = GetBytes(_value, (v) => {
            return Encoding.UTF8.GetBytes(v);
        }, _hiloSwap);
        result.AddRange(bytes.Length.GetBytes());
        result.AddRange(bytes);
        return result.ToArray();
    }
    #endregion

    #region GetBytes
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_func">执行函数</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes<T>(this T _value, Func<T, byte[]> _func, bool _hiloSwap)
    {
        byte[] result = _func(_value);
        if (_hiloSwap)
        {
            result = result.ToHiloSwap();
        }
        return result;
    }
    #endregion
    #endregion

    #region ToXXX

    #region ToBoolean
    /// <summary>
    /// 获得bool值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>bool值</returns>
    public static bool ToBoolean(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToBoolean(ref _startIndex, false);
    }
    /// <summary>
    /// 获得bool值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>bool值</returns>
    public static bool ToBoolean(this byte[] _value, ref long _startIndex)
    {
        return _value.ToBoolean(ref _startIndex, false);
    }
    /// <summary>
    /// 获得bool值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>bool值</returns>
    public static bool ToBoolean(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToBoolean(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得bool值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>bool值</returns>
    public static bool ToBoolean(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(bool);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToBoolean(result, 0);
    }
    #endregion

    #region ToChar
    /// <summary>
    /// 获得char值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>char值</returns>
    public static char ToChar(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToChar(ref _startIndex, false);
    }
    /// <summary>
    /// 获得char值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>char值</returns>
    public static char ToChar(this byte[] _value, ref long _startIndex)
    {
        return _value.ToChar(ref _startIndex, false);
    }
    /// <summary>
    /// 获得char值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>char值</returns>
    public static char ToChar(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToChar(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得char值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>char值</returns>
    public static char ToChar(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(char);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToChar(result, 0);
    }
    #endregion

    #region ToByte
    /// <summary>
    /// 获得Byte值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Byte值</returns>
    public static byte ToByte(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToByte(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Byte值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Byte值</returns>
    public static byte ToByte(this byte[] _value, ref long _startIndex)
    {
        return _value.ToByte(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Byte值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Byte值</returns>
    public static byte ToByte(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToByte(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Byte值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Byte值</returns>
    public static byte ToByte(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(byte);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return result[0];
    }
    #endregion

    #region ToInt16
    /// <summary>
    /// 获得Int16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Int16值</returns>
    public static short ToInt16(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToInt16(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Int16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Int16值</returns>
    public static short ToInt16(this byte[] _value, ref long _startIndex)
    {
        return _value.ToInt16(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Int16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Int16值</returns>
    public static short ToInt16(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToInt16(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Int16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Int16值</returns>
    public static short ToInt16(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(short);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToInt16(result, 0);
    }
    #endregion

    #region ToInt32
    /// <summary>
    /// 获得Int32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Int32值</returns>
    public static int ToInt32(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToInt32(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Int32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Int32值</returns>
    public static int ToInt32(this byte[] _value, ref long _startIndex)
    {
        return _value.ToInt32(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Int32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Int32值</returns>
    public static int ToInt32(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToInt32(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Int32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Int32值</returns>
    public static int ToInt32(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(int);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToInt32(result, 0);
    }
    #endregion

    #region ToInt64
    /// <summary>
    /// 获得Int64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Int64值</returns>
    public static long ToInt64(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToInt64(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Int64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Int64值</returns>
    public static long ToInt64(this byte[] _value, ref long _startIndex)
    {
        return _value.ToInt64(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Int64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Int64值</returns>
    public static long ToInt64(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToInt64(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Int64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Int64值</returns>
    public static long ToInt64(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(long);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToInt64(result, 0);
    }
    #endregion

    #region ToSingle
    /// <summary>
    /// 获得Single值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Single值</returns>
    public static float ToSingle(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToSingle(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Single值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Single值</returns>
    public static float ToSingle(this byte[] _value, ref long _startIndex)
    {
        return _value.ToSingle(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Single值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Single值</returns>
    public static float ToSingle(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToSingle(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Single值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Single值</returns>
    public static float ToSingle(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(float);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToSingle(result, 0);
    }
    #endregion

    #region ToDouble
    /// <summary>
    /// 获得Double值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Double值</returns>
    public static double ToDouble(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToDouble(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Double值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Double值</returns>
    public static double ToDouble(this byte[] _value, ref long _startIndex)
    {
        return _value.ToDouble(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Double值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Double值</returns>
    public static double ToDouble(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToDouble(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Double值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Double值</returns>
    public static double ToDouble(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(double);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToDouble(result, 0);
    }
    #endregion

    #region ToUInt16
    /// <summary>
    /// 获得UInt16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>UInt16值</returns>
    public static ushort ToUInt16(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToUInt16(ref _startIndex, false);
    }
    /// <summary>
    /// 获得UInt16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>UInt16值</returns>
    public static ushort ToUInt16(this byte[] _value, ref long _startIndex)
    {
        return _value.ToUInt16(ref _startIndex, false);
    }
    /// <summary>
    /// 获得UInt16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>UInt16值</returns>
    public static ushort ToUInt16(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToUInt16(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得UInt16值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>UInt16值</returns>
    public static ushort ToUInt16(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(ushort);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToUInt16(result, 0);
    }
    #endregion

    #region ToUInt32
    /// <summary>
    /// 获得UInt32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>UInt32值</returns>
    public static uint ToUInt32(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToUInt32(ref _startIndex, false);
    }
    /// <summary>
    /// 获得UInt32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>UInt32值</returns>
    public static uint ToUInt32(this byte[] _value, ref long _startIndex)
    {
        return _value.ToUInt32(ref _startIndex, false);
    }
    /// <summary>
    /// 获得UInt32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>UInt32值</returns>
    public static uint ToUInt32(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToUInt32(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得UInt32值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>UInt32值</returns>
    public static uint ToUInt32(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(uint);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToUInt32(result, 0);
    }
    #endregion

    #region ToUInt64
    /// <summary>
    /// 获得UInt64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>UInt64值</returns>
    public static ulong ToUInt64(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToUInt64(ref _startIndex, false);
    }
    /// <summary>
    /// 获得UInt64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>UInt64值</returns>
    public static ulong ToUInt64(this byte[] _value, ref long _startIndex)
    {
        return _value.ToUInt64(ref _startIndex, false);
    }
    /// <summary>
    /// 获得UInt64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>UInt64值</returns>
    public static ulong ToUInt64(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToUInt64(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得UInt64值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>UInt64值</returns>
    public static ulong ToUInt64(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = sizeof(ulong);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return BitConverter.ToUInt64(result, 0);
    }
    #endregion

    #region ByteToString
    /// <summary>
    /// 获得ByteToString值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>ByteToString</returns>
    public static string ByteToString(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ByteToString(ref _startIndex, false);
    }
    /// <summary>
    /// 获得ByteToString值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>ByteToString</returns>
    public static string ByteToString(this byte[] _value, ref long _startIndex)
    {
        return _value.ByteToString(ref _startIndex, false);
    }
    /// <summary>
    /// 获得ByteToString值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>ByteToString</returns>
    public static string ByteToString(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ByteToString(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得ByteToString值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>ByteToString</returns>
    public static string ByteToString(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        int size = _value.ToInt32(ref _startIndex, _hiloSwap);
        byte[] result = CopyBuffer(_value, _startIndex, size, _hiloSwap);
        _startIndex += size;
        return Encoding.UTF8.GetString(result);
    }
    #endregion

    #region CopyBuffer
    /// <summary>
    /// 复制数据缓存
    /// </summary>
    /// <param name="_source">源数据</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_length">长度</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] CopyBuffer(this byte[] _source, long _startIndex, long _length, bool _hiloSwap)
    {
        byte[] result = new byte[_length];
        Array.Copy(_source, _startIndex, result, 0, _length);
        if (_length > 0 && _hiloSwap)
        {
            result = result.ToHiloSwap();
        }
        return result;
    }
    #endregion

    #endregion
}