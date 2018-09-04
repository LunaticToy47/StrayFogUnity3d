using System;
    /// <summary>
    /// 事件处理_复制
    /// </summary>
    /// <param name="_self">自身</param>
    /// <param name="_clone">克隆源</param>
    public delegate void EventHandlerCopyFrom(IClone _self, IClone _from);
    /// <summary>
    /// 事件处理_克隆
    /// </summary>
    /// <param name="_clone">克隆源</param>
    public delegate void EventHandlerClone(IClone _clone);
/// <summary>
/// 克隆接口
/// </summary>
public interface IClone : ICloneable
{
    /// <summary>
    /// 克隆之前事件
    /// </summary>
    event EventHandlerClone OnBeforeClone;
    /// <summary>
    /// 克隆之后事件
    /// </summary>
    event EventHandlerClone OnAfterClone;
    /// <summary>
    /// CopyFrom之前事件
    /// </summary>
    event EventHandlerCopyFrom OnBeforeCopyFrom;
    /// <summary>
    /// CopyFrom之后事件
    /// </summary>
    event EventHandlerCopyFrom OnAfterCopyFrom;
    /// <summary>
    /// 复制指定对象
    /// </summary>
    /// <param name="_from">指定对象</param>
    void CopyFrom(IClone _from);
}