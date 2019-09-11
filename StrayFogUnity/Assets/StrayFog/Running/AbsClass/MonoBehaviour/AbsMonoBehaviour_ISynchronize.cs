using System.Collections.Generic;
/// <summary>
/// 抽象MonoBehaviour【ISynchronize接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : ISynchronize
{
    #region ISynchronize
    /// <summary>
    /// 导出同步之前事件处理
    /// </summary>
    public event EventHandlerExportSynchronize OnBeforeExportSynchronize;
    /// <summary>
    /// 导出同步之后事件处理
    /// </summary>
    public event EventHandlerExportSynchronize OnAfterExportSynchronize;

    /// <summary>
    /// 导入同步之前事件处理
    /// </summary>
    public event EventHandlerImportSynchronize OnBeforeImportSynchronize;
    /// <summary>
    /// 导入同步之后事件处理
    /// </summary>
    public event EventHandlerImportSynchronize OnAfterImportSynchronize;

    /// <summary>
    /// 空同步数据
    /// </summary>
    readonly byte[] mrEmptySynchronize = new byte[0];
    /// <summary>
    /// 导出同步数据
    /// </summary>
    /// <returns>同步数据</returns>
    public byte[] ExportSynchronize()
    {
        if (OnBeforeExportSynchronize != null)
        {
            OnBeforeExportSynchronize(this, mrEmptySynchronize);
        }
        List<byte> sers = new List<byte>();
        sers.AddRange(OnExportSynchronize());
        byte[] result = sers.ToArray();
        if (OnAfterExportSynchronize != null)
        {
            OnAfterExportSynchronize(this, result);
        }
        return result;
    }
    /// <summary>
    /// 导出同步数据
    /// </summary>
    /// <returns>同步数据</returns>
    protected virtual byte[] OnExportSynchronize() { return mrEmptySynchronize; }

    /// <summary>
    /// 导入同步数据
    /// </summary>
    /// <param name="_data">同步数据</param>
    /// <param name="_startIndex">起始索引</param>
    /// <returns>结束索引</returns>
    public long ImportSynchronize(byte[] _data, long _startIndex)
    {
        if (OnBeforeImportSynchronize != null)
        {
            OnBeforeImportSynchronize(this, _data, _startIndex);
        }
        mGlobalId = _data.ToInt32(ref _startIndex);
        _startIndex = OnImportSynchronize(_data, _startIndex);
        if (OnAfterImportSynchronize != null)
        {
            OnAfterImportSynchronize(this, _data, _startIndex);
        }
        return _startIndex;
    }

    /// <summary>
    /// 导入同步数据
    /// </summary>
    /// <param name="_data">同步数据</param>
    /// <param name="_startIndex">起始索引</param>
    /// <returns>结束索引</returns>
    protected virtual long OnImportSynchronize(byte[] _data, long _startIndex) { return _startIndex; }
    #endregion
}
