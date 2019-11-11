using System;
/// <summary>
/// 抽象MonoBehaviour【IClone接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IClone
{
    #region IClone
    /// <summary>
    /// 克隆之前事件
    /// </summary>
    public event Action<IClone> OnBeforeClone;
    /// <summary>
    /// 克隆之后事件
    /// </summary>
    public event Action<IClone> OnAfterClone;
    /// <summary>
    /// CopyFrom之前事件
    /// </summary>
    public event Action<IClone, IClone> OnBeforeCopyFrom;
    /// <summary>
    /// CopyFrom之后事件
    /// </summary>
    public event Action<IClone, IClone> OnAfterCopyFrom;
    /// <summary>
    /// 复制指定对象
    /// </summary>
    /// <param name="_from">指定对象</param>
    public void CopyFrom(IClone _from)
    {
        OnBeforeCopyFrom?.Invoke(this, _from);
        OnCopyFrom(_from);
        OnAfterCopyFrom?.Invoke(this, _from);
    }

    /// <summary>
    /// 克隆
    /// </summary>
    /// <returns>克隆后对象</returns>
    public object Clone()
    {
        OnBeforeClone?.Invoke(this);
        object result = OnClone();
        OnAfterClone?.Invoke(this);
        return result;
    }

    /// <summary>
    /// 复制对象
    /// </summary>
    /// <param name="_from">源对象</param>
    protected virtual void OnCopyFrom(IClone _from) { }
    /// <summary>
    /// 克隆对象
    /// </summary>
    protected virtual object OnClone() { return null; }
    #endregion
}
