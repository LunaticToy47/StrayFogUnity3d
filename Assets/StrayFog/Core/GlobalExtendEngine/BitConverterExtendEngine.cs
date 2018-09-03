using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 比特转换扩展
/// </summary>
public static class BitConverterExtendEngine
{
    #region GetBytes  

    #region Vector2
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this Vector2 _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this Vector2 _value, bool _hiloSwap)
    {
        return _value.GetBytes((v) =>
        {
            List<byte> bts = new List<byte>();
            bts.AddRange(v.x.GetBytes());
            bts.AddRange(v.y.GetBytes());
            return bts.ToArray();
        }, _hiloSwap);
    }
    #endregion

    #region Vector3
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this Vector3 _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this Vector3 _value, bool _hiloSwap)
    {
        return _value.GetBytes((v) =>
        {
            List<byte> bts = new List<byte>();
            bts.AddRange(_value.x.GetBytes());
            bts.AddRange(_value.y.GetBytes());
            bts.AddRange(_value.z.GetBytes());
            return bts.ToArray();
        }, _hiloSwap);
    }
    #endregion

    #region Vector4
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this Vector4 _value)
    {
        return _value.GetBytes(false);
    }
    /// <summary>
    /// 获得byte数组
    /// </summary>
    /// <param name="_value">值</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>byte数组</returns>
    public static byte[] GetBytes(this Vector4 _value, bool _hiloSwap)
    {
        return _value.GetBytes((v) =>
        {
            List<byte> bts = new List<byte>();
            bts.AddRange(_value.x.GetBytes());
            bts.AddRange(_value.y.GetBytes());
            bts.AddRange(_value.z.GetBytes());
            bts.AddRange(_value.w.GetBytes());
            return bts.ToArray();
        }, _hiloSwap);
    }
    #endregion

    #endregion

    #region ToXXX   

    #region ToVector2
    /// <summary>
    /// 获得Vector2值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Vector2值</returns>
    public static Vector2 ToVector2(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToVector2(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Vector2值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Vector2值</returns>
    public static Vector2 ToVector2(this byte[] _value, ref long _startIndex)
    {
        return _value.ToVector2(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Vector2值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Vector2值</returns>
    public static Vector2 ToVector2(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToVector2(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Vector2值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Vector2值</returns>
    public static Vector2 ToVector2(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        Vector2 vec = Vector2.zero;
        int size = sizeof(float);
        byte[] result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.x = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.y = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        return vec;
    }
    #endregion

    #region ToVector3
    /// <summary>
    /// 获得Vector3值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Vector3值</returns>
    public static Vector3 ToVector3(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToVector3(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Vector3值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Vector3值</returns>
    public static Vector3 ToVector3(this byte[] _value, ref long _startIndex)
    {
        return _value.ToVector3(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Vector3值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Vector3值</returns>
    public static Vector3 ToVector3(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToVector3(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Vector3值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Vector3值</returns>
    public static Vector3 ToVector3(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        Vector3 vec = Vector3.zero;
        int size = sizeof(float);
        byte[] result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.x = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.y = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.z = BitConverter.ToSingle(result, 0);
        _startIndex += size;
        return vec;
    }
    #endregion

    #region ToVector4
    /// <summary>
    /// 获得Vector4值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <returns>Vector4值</returns>
    public static Vector4 ToVector4(this byte[] _value)
    {
        long _startIndex = 0;
        return _value.ToVector4(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Vector4值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <returns>Vector4值</returns>
    public static Vector4 ToVector4(this byte[] _value, ref long _startIndex)
    {
        return _value.ToVector4(ref _startIndex, false);
    }
    /// <summary>
    /// 获得Vector4值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Vector4值</returns>
    public static Vector4 ToVector4(this byte[] _value, bool _hiloSwap)
    {
        long _startIndex = 0;
        return _value.ToVector4(ref _startIndex, _hiloSwap);
    }
    /// <summary>
    /// 获得Vector4值
    /// </summary>
    /// <param name="_value">byte数组源</param>
    /// <param name="_startIndex">起始位置</param>
    /// <param name="_hiloSwap">是否高低位互换</param>
    /// <returns>Vector4值</returns>
    public static Vector4 ToVector4(this byte[] _value, ref long _startIndex, bool _hiloSwap)
    {
        Vector4 vec = Vector4.zero;
        int size = sizeof(float);
        byte[] result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.x = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.y = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.z = BitConverter.ToSingle(result, 0);
        _startIndex += size;

        result = _value.CopyBuffer(_startIndex, size, _hiloSwap);
        vec.w = BitConverter.ToSingle(result, 0);
        _startIndex += size;
        return vec;
    }
    #endregion

    #endregion
}