using System;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// 日志管理器
/// </summary>
public static class EP
{
    #region Log
    /// <summary>
    /// Log
    /// </summary>
    /// <param name="_message">信息</param>
    public static void Log(string _message)
    {
        UnityEngine.Debug.Log(_message);
    }

    /// <summary>
    /// Log
    /// </summary>
    /// <param name="_message">信息</param>
    /// <param name="_color">颜色</param>
    public static void Log(string _message, Color _color)
    {
        UnityEngine.Debug.Log(_message.ApplyColor(_color));
    }

    /// <summary>
    /// Log
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    public static void Log(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogFormat(_format, _args);
    }

    /// <summary>
    /// Log
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_color">颜色</param>
    /// <param name="_args">参数组</param>
    public static void Log(string _format, Color _color, params object[] _args)
    {
        UnityEngine.Debug.LogFormat(_format.FormatApplyColor(_color, _args));
    }
    #endregion

    #region Warning
    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="_message">信息</param>
    public static void Warning(string _message)
    {
        UnityEngine.Debug.LogWarning(_message);
    }

    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="_message">信息</param>
    /// <param name="_color">颜色</param>
    public static void Warning(string _message, Color _color)
    {
        UnityEngine.Debug.LogWarning(_message.ApplyColor(_color));
    }

    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    public static void Warning(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogWarningFormat(_format, _args);
    }
    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_color">颜色</param>
    /// <param name="_args">参数组</param>
    public static void Warning(string _format, Color _color, params object[] _args)
    {
        UnityEngine.Debug.LogWarningFormat(_format.FormatApplyColor(_color, _args));
    }

    #endregion

    /*======================此处是Conditional分界线==============================*/
    #region Error
    /// <summary>
    /// LogError
    /// </summary>
    /// <param name="_message">信息</param>
    public static void Error(string _message)
    {
        UnityEngine.Debug.LogError(_message);
    }

    /// <summary>
    /// LogError
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    public static void Error(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogErrorFormat(_format, _args);
    }
    #endregion

    #region Exception
    /// <summary>
    /// LogException
    /// </summary>
    /// <param name="_exception">Exception</param>
    public static void Exception(Exception _exception)
    {
        UnityEngine.Debug.LogException(_exception);
    }
    #endregion

    #region Assertion
    /// <summary>
    /// LogAssertion
    /// </summary>
    /// <param name="_message">信息</param>
    public static void Assertion(string _message)
    {
        UnityEngine.Debug.LogAssertion(_message);
    }

    /// <summary>
    /// LogAssertionFormat
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    public static void Assertion(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogAssertionFormat(_format, _args);
    }
    #endregion
}
