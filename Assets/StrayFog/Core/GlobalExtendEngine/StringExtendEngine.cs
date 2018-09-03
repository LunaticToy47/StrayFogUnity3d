using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 字符扩展
/// </summary>
public static class StringExtendEngine
{
    #region 转换路径分隔符为Unity格式
    /// <summary>
    /// 转换路径分隔符为Unity格式缓存
    /// </summary>
    static Dictionary<int, string> mDicTransPathSeparatorCharToUnityChar = new Dictionary<int, string>();
    /// <summary>
    /// 转换路径分隔符为Unity格式
    /// "\"转换成"/"
    /// </summary>
    /// <param name="_path">路径</param>
    /// <returns>转换后路径</returns>
    public static string TransPathSeparatorCharToUnityChar(this string _path)
    {
        int key = _path.UniqueHashCode();
        if (!mDicTransPathSeparatorCharToUnityChar.ContainsKey(key))
        {
            mDicTransPathSeparatorCharToUnityChar.Add(key, _path.Replace(@"\", "/"));
        }
        return mDicTransPathSeparatorCharToUnityChar[key];
    }

    /// <summary>
    /// 组合路径
    /// </summary>
    /// <param name="_src">源路径</param>
    /// <param name="_concat">要组合的路径</param>
    /// <returns>组合后的路径</returns>
    public static string CombinePath(this string _src, string _concat)
    {
        if (_src.EndsWith("/") || _src.EndsWith(@"\"))
        {
            _src = Path.Combine(_src, _concat);
        }
        else
        {
            _src = Path.Combine(_src + Path.DirectorySeparatorChar, _concat);
        }
        return _src;
    }
    #endregion

    #region 字符串转换为Vector类型
    /// <summary>
    /// 字符串转换为Vector2类型
    /// </summary>
    /// <param name="_srcText">字符串</param>
    /// <returns>Vector2</returns>
    public static Vector2 ToVector2(this string _srcText)
    {
        string[] vs = _srcText.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        Vector2 v = Vector2.zero;
        v.x = float.Parse(vs[0]);
        v.y = float.Parse(vs[1]);
        return v;
    }
    /// <summary>
    /// 字符串转换为Vector2类型
    /// </summary>
    /// <param name="_srcText">字符串</param>
    /// <returns>Vector2</returns>
    public static Vector3 ToVector3(this string _srcText)
    {
        string[] vs = _srcText.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        Vector3 v = Vector3.zero;
        v.x = float.Parse(vs[0]);
        v.y = float.Parse(vs[1]);
        v.z = float.Parse(vs[2]);
        return v;
    }
    /// <summary>
    /// 字符串转换为Vector2类型
    /// </summary>
    /// <param name="_srcText">字符串</param>
    /// <returns>Vector2</returns>
    public static Vector4 ToVector4(this string _srcText)
    {
        string[] vs = _srcText.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        Vector4 v = Vector4.zero;
        v.x = float.Parse(vs[0]);
        v.y = float.Parse(vs[1]);
        v.z = float.Parse(vs[2]);
        v.w = float.Parse(vs[3]);
        return v;
    }
    #endregion
}
