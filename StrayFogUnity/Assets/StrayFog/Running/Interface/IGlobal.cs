    /// <summary>
    /// 修改GlobalId事件处理
    /// </summary>
    /// <param name="_self">修改对象</param>
    /// <param name="_from">修改前id</param>
    /// <param name="_to">修改后id</param>
    public delegate void EventHandlerModifyGlobalId(IGlobal _self, int _from, int _to);
/// <summary>
/// 全局对象接口
/// </summary>
public interface IGlobal
{
    /// <summary>
    /// 修改GlobalId之前事件
    /// </summary>
    event EventHandlerModifyGlobalId OnBeforeModifyGlobalId;
    /// <summary>
    /// 修改GlobalId之后事件
    /// </summary>
    event EventHandlerModifyGlobalId OnAfterModifyGlobalId;

    /// <summary>
    /// 全局Id
    /// </summary>
    int globalId { get; }

    /// <summary>
    /// 修改GlobalId
    /// </summary>
    /// <param name="_modifyId">修改的Id</param>
    void ModifyGlobalId(int _modifyId);
}