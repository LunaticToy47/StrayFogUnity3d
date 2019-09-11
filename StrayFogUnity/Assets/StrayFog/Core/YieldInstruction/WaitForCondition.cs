using System;
using UnityEngine;
/// <summary>
/// 条件等待事件处理
/// </summary>
/// <param name="_parameters">参数</param>
/// <returns>true:等待,false:不等待</returns>
public delegate bool WaitForConditionEventHandler(object[] _parameters);
/// <summary>
/// 条件等待
/// </summary>
public class WaitForCondition : CustomYieldInstruction
{
    /// <summary>
    /// 等待处理
    /// </summary>
    WaitForConditionEventHandler mWaitFor = null;
    /// <summary>
    /// 参数
    /// </summary>
    object[] mParameters = null;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_waitFor">等待处理</param>
    /// <param name="_parameters">参数</param>
    public WaitForCondition(WaitForConditionEventHandler _waitFor,params object[] _parameters)
    {
        mWaitFor = _waitFor;
        mParameters = _parameters;
    }

    /// <summary>
    /// 是否保持等待
    /// </summary>
    public override bool keepWaiting
    {
        get
        {
            return mWaitFor(mParameters);
        }
    }
}
