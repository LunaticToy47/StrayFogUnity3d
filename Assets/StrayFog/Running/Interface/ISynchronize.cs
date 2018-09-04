    /// <summary>
    /// 导出同步对象处理
    /// </summary>
    /// <param name="_Synchronize">同步对象</param>
    /// <param name="_export">导出数据</param>
    public delegate void EventHandlerExportSynchronize(ISynchronize _Synchronize, byte[] _export);

    /// <summary>
    /// 导入同步对象处理
    /// </summary>
    /// <param name="_Synchronize">同步对象</param>
    /// <param name="_data">同步数据</param>
    /// <param name="_startIndex">起始索引</param>
    public delegate void EventHandlerImportSynchronize(ISynchronize _Synchronize, byte[] _data, long _startIndex);

/// <summary>
/// 同步接口
/// </summary>
public interface ISynchronize
{
    /// <summary>
    /// 导出同步之前事件处理
    /// </summary>
    event EventHandlerExportSynchronize OnBeforeExportSynchronize;
    /// <summary>
    /// 导出同步之后事件处理
    /// </summary>
    event EventHandlerExportSynchronize OnAfterExportSynchronize;

    /// <summary>
    /// 导入同步之前事件处理
    /// </summary>
    event EventHandlerImportSynchronize OnBeforeImportSynchronize;
    /// <summary>
    /// 导入同步之后事件处理
    /// </summary>
    event EventHandlerImportSynchronize OnAfterImportSynchronize;

    /// <summary>
    /// 导出同步数据
    /// </summary>
    /// <returns>同步数据</returns>
    byte[] ExportSynchronize();

    /// <summary>
    /// 导入同步数据
    /// </summary>
    /// <param name="_data">同步数据</param>
    /// <param name="_startIndex">起始索引</param>
    /// <returns>结束索引</returns>
    long ImportSynchronize(byte[] _data, long _startIndex);
}
