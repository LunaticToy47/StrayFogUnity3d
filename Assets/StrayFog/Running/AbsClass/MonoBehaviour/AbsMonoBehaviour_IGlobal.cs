/// <summary>
/// 抽象MonoBehaviour【IGlobal接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IGlobal
{
    #region IGlobal
    /// <summary>
    /// 修改GlobalId之前事件
    /// </summary>
    public event EventHandlerModifyGlobalId OnBeforeModifyGlobalId;
    /// <summary>
    /// 修改GlobalId之后事件
    /// </summary>
    public event EventHandlerModifyGlobalId OnAfterModifyGlobalId;
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
                mGlobalId = StrayFogUtility.NewGlobalUniqueId();
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
        if (OnBeforeModifyGlobalId != null)
        {
            OnBeforeModifyGlobalId(this, fromId, _toId);
        }
        mGlobalId = _toId;
        if (OnAfterModifyGlobalId != null)
        {
            OnAfterModifyGlobalId(this, fromId, _toId);
        }
    }
    #endregion
}
