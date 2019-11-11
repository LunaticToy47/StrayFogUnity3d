using System;
/// <summary>
/// 克隆接口
/// </summary>
public interface IClone : ICloneable
{
    /// <summary>
    /// 克隆之前事件
    /// Arg1:自身
    /// </summary>
    event Action<IClone> OnBeforeClone;
    /// <summary>
    /// 克隆之后事件  
    /// Arg1:自身
    /// </summary>
    event Action<IClone> OnAfterClone;
    /// <summary>
    /// CopyFrom之前事件
    /// Arg1:自身
    /// Arg2:克隆源
    /// </summary>
    event Action<IClone, IClone> OnBeforeCopyFrom;
    /// <summary>
    /// CopyFrom之后事件
    /// Arg1:自身
    /// Arg2:克隆源
    /// </summary>
    event Action<IClone, IClone> OnAfterCopyFrom;
    /// <summary>
    /// 复制指定对象
    /// </summary>
    /// <param name="_from">指定对象</param>
    void CopyFrom(IClone _from);
}