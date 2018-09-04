    /// <summary>
    /// 运行状态切换事件处理
    /// </summary>
    /// <param name="_self">切换状态对象</param>
    /// <param name="_from">切换前状态</param>
    /// <param name="_to">目标状态</param>
    public delegate void EventHandlerToggleStatus(IStatus _self, int _from, int _to);
/// <summary>
/// 状态接口
/// </summary>
public interface IStatus
{
    /// <summary>
    /// 切换状态之前事件
    /// </summary>
    event EventHandlerToggleStatus OnBeforeToggleStatus;
    /// <summary>
    /// 切换状态之后事件
    /// </summary>
    event EventHandlerToggleStatus OnAfterToggleStatus;
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
    /// <summary>
    /// 延时指定时间后，切换到指定状态
    /// </summary>
    /// <param name="_destStatus">目标状态</param>
    /// <param name="_delay">延时</param>
    void ToggleStatus(int _destStatus, float _delay);
}