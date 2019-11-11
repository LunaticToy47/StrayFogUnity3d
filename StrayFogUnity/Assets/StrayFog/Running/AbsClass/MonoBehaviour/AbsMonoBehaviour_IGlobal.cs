using System;
/// <summary>
/// 抽象MonoBehaviour【IGlobal接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IGlobal
{
    #region IGlobal
    /// <summary>
    /// 修改GlobalId之前事件
    /// </summary>
    public event Action<IGlobal, int, int> OnBeforeModifyGlobalId;
    /// <summary>
    /// 修改GlobalId之后事件
    /// </summary>
    public event Action<IGlobal, int, int> OnAfterModifyGlobalId;
    /// <summary>
    /// 全局唯一ID
    /// </summary>
    int mGlobalId = 0;
    /// <summary>
    /// 全局唯一ID
    /// </summary>
    public int globalId
    {
        get
        {
            if (mGlobalId == 0)
            {
                mGlobalId = StrayFogRunningUtility.NewGlobalUniqueId();
            }
            return mGlobalId;
        }
    }
    /// <summary>
    /// 修改GlobalId
    /// </summary>
    /// <param name="_toId">要修改的Id</param>
    public void ModifyGlobalId(int _toId)
    {
        int fromId = mGlobalId;
        OnBeforeModifyGlobalId?.Invoke(this, fromId, _toId);
        mGlobalId = _toId;
        OnAfterModifyGlobalId?.Invoke(this, fromId, _toId);
    }
    #endregion
}
