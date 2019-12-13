using System;
/// <summary>
/// 全局对象接口
/// </summary>
public interface IGlobal
{
    /// <summary>
    /// 修改GlobalId之前事件
    /// Arg1:修改对象
    /// Arg2:修改前id
    /// Arg3:修改后id
    /// </summary>
    event Action<IGlobal, int, int> OnBeforeModifyGlobalId;
    /// <summary>
    /// 修改GlobalId之后事件
    /// Arg1:修改对象
    /// Arg2:修改前id
    /// Arg3:修改后id
    /// </summary>
    event Action<IGlobal, int, int> OnAfterModifyGlobalId;

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