using System;
using System.Collections.Generic;
/// <summary>
/// 事件回调句柄参数
/// </summary>
public class StrayFogCallbackHandlerArgs : StrayFogEventHandlerArgs
{    
    /// <summary>
    /// 发送参数
    /// </summary>
    public StrayFogEventHandlerArgs senderArgs { get; private set; }

    /// <summary>
    /// 事件聚合参数
    /// </summary>
    /// <param name="_senderArgs">发送者参数</param>
    public StrayFogCallbackHandlerArgs(StrayFogEventHandlerArgs _senderArgs)
        :base(_senderArgs.eventId)
    {
        senderArgs = _senderArgs;
    }
}
