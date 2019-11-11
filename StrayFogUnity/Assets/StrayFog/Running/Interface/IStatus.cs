using System;
/// <summary>
/// 状态接口
/// </summary>
public interface IStatus
{
    /// <summary>
    /// 切换状态之前事件
    /// Arg1:切换状态对象
    /// Arg2:切换前状态
    /// Arg3:目标状态
    /// </summary>
    event Action<IStatus, int, int> OnBeforeToggleStatus;
    /// <summary>
    /// 切换状态之后事件
    /// Arg1:切换状态对象
    /// Arg2:切换前状态
    /// Arg3:目标状态
    /// </summary>
    event Action<IStatus, int, int> OnAfterToggleStatus;
    /// <summary>
    /// 当前状态
    /// </summary>
    int currentStatus { get; }
    /// <summary>
    /// 是否是指定状态
    /// </summary>
    /// <param name="_status">指定状态</param>
    /// <returns>True:是,False:否</returns>
    bool isStatus(int _status);
    /// <summary>
    /// 切换到目标状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    void ToggleStatus(int _destStatus);
}