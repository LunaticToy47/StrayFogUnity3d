using System.Diagnostics;
/// <summary>
/// 日志
/// </summary>
public sealed class StrayFogLog
{
    /// <summary>
    /// 编译条件
    /// </summary>
    const enSystemDefine mDebugLogConditional = enSystemDefine.DEBUGLOG;
    /// <summary>
    /// Debug日志
    /// </summary>
    /// <param name="message"></param>
    [Conditional("DEBUGLOG")]
    public static void D(object message)
    {
        UnityEngine.Debug.Log(message);
    }
}
