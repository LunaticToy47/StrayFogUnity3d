using System;
/// <summary>
/// StrayFogSQLite实体
/// </summary>
public abstract class AbsStrayFogSQLiteEntity
{
    /// <summary>
    /// 主键序列值
    /// </summary>
    public virtual int pkSequenceId { get; private set; }
    /// <summary>
    /// 行索引
    /// </summary>
    public int rowIndex { get; private set; }
    /// <summary>
    /// 行索引属性名称
    /// </summary>
    public readonly string rowIndexPropertyName = "rowIndex";
    /// <summary>
    /// 解析pkSequenceId值
    /// </summary>
    /// <returns>pkSequenceId值</returns>
    protected virtual int OnResolvePkSequenceId() { return Guid.NewGuid().ToString().UniqueHashCode(); }
    /// <summary>
    /// 解析数据
    /// </summary>
    public void Resolve()
    {
        pkSequenceId = OnResolvePkSequenceId();
        OnResolve();
    }

    /// <summary>
    /// 解析数据
    /// </summary>
    protected virtual void OnResolve() { }
}
