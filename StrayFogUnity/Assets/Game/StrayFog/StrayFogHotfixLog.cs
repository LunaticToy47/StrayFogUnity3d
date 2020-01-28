using System;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// 资源管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Log/StrayFogHotfixLog")]
public static class P
{
    /// <summary>
    /// 编译条件
    /// </summary>
#if DEBUGLOG
    const string mDebugLogConditional = "DEBUGLOG";//enSystemDefine.DEBUGLOG;
#else
    const string mDebugLogConditional = "UNITY_EDITOR";//enSystemDefine.DEBUGLOG;    
#endif

    /// <summary>
    /// Log
    /// </summary>
    /// <param name="_message">信息</param>
    [Conditional(mDebugLogConditional)]
    public static void I(string _message)
    {
        UnityEngine.Debug.Log(_message);
    }

    /// <summary>
    /// Log
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    [Conditional(mDebugLogConditional)]
    public static void I(string _format,params object[] _args)
    {
        UnityEngine.Debug.LogFormat(_format, _args);
    }

    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="_message">信息</param>
    [Conditional(mDebugLogConditional)]
    public static void W(string _message)
    {
        UnityEngine.Debug.LogWarning(_message);
    }

    /// <summary>
    /// LogWarning
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    [Conditional(mDebugLogConditional)]
    public static void W(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogWarningFormat(_format, _args);
    }

    /*======================此处是Conditional分界线==============================*/
    /// <summary>
    /// LogError
    /// </summary>
    /// <param name="_message">信息</param>
    public static void E(string _message)
    {
        UnityEngine.Debug.LogError(_message);
    }

    /// <summary>
    /// LogError
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    public static void E(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogErrorFormat(_format, _args);
    }

    /// <summary>
    /// LogException
    /// </summary>
    /// <param name="_exception">Exception</param>
    public static void C(Exception _exception)
    {
        UnityEngine.Debug.LogException(_exception);
    }

    /// <summary>
    /// LogAssertion
    /// </summary>
    /// <param name="_message">信息</param>
    public static void A(string _message)
    {
        UnityEngine.Debug.LogAssertion(_message);
    }

    /// <summary>
    /// LogAssertionFormat
    /// </summary>
    /// <param name="_format">格式符</param>
    /// <param name="_args">参数组</param>
    public static void A(string _format, params object[] _args)
    {
        UnityEngine.Debug.LogAssertionFormat(_format, _args);
    }    
}
