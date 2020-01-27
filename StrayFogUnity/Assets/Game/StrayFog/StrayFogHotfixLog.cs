using System;
using UnityEngine;
/// <summary>
/// 资源管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Log/StrayFogHotfixLog")]
public sealed partial class StrayFogHotfixLog : AbsSingleMonoBehaviour, ILogHandler
{
    public void LogException(Exception exception, UnityEngine.Object context)
    {
        throw new NotImplementedException();
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        throw new NotImplementedException();
    }
}
