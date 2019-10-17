using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour
/// </summary>
public abstract partial class AbsMonoBehaviour : ILifeCycle
{
    /// <summary>
    /// 处理数据之前
    /// </summary>
    public event EventHandlerLifeCycleBeforeProcessData OnBeforeLifeCycleProcessData;
    /// <summary>
    /// 处理数据之后
    /// </summary>
    public event EventHandlerLifeCycleAfterProcessData OnAfterLifeCycleProcessData;
    /// <summary>
    /// 处理预置之前
    /// </summary>
    public event EventHandlerLifeCycleBeforeProcessPrefab OnBeforeLifeCycleProcessPrefab;
    /// <summary>
    /// 处理预置之后
    /// </summary>
    public event EventHandlerLifeCycleAfterProcessPrefab OnAfterLifeCycleProcessPrefab;
    /// <summary>
    /// 处理其他之前
    /// </summary>
    public event EventHandlerLifeCycleBeforeProcessOther OnBeforeLifeCycleProcessOther;
    /// <summary>
    /// 处理其他之后
    /// </summary>
    public event EventHandlerLifeCycleAfterProcessOther OnAfterLifeCycleProcessOther;
    #region ProcessData 处理数据   
    /// <summary>
    /// 处理数据
    /// </summary>
    public void ProcessData()
    {
        OnBeforeLifeCycleProcessData?.Invoke(this);
        OnProcessData();
        OnAfterLifeCycleProcessData?.Invoke(this);
    }
    /// <summary>
    /// 处理数据
    /// </summary>
    protected virtual void OnProcessData() { }
    #endregion

    #region ProcessPrefab 处理预置
    /// <summary>
    /// 处理预置
    /// </summary>
    public void ProcessPrefab()
    {
        OnBeforeLifeCycleProcessPrefab?.Invoke(this);
        OnProcessPrefab();
        OnAfterLifeCycleProcessPrefab?.Invoke(this);
    }
    /// <summary>
    /// 处理预置
    /// </summary>
    protected virtual void OnProcessPrefab() { }
    #endregion

    #region ProcessOther 处理其他
    /// <summary>
    /// 处理其他
    /// </summary>
    public void ProcessOther()
    {
        OnBeforeLifeCycleProcessOther?.Invoke(this);
        OnProcessOther();
        OnAfterLifeCycleProcessOther?.Invoke(this);
    }
    /// <summary>
    /// 处理其他
    /// </summary>
    protected virtual void OnProcessOther() { }
    #endregion
}
