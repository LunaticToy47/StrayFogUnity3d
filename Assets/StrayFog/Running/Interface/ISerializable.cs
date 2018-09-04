    /// <summary>
    /// 导出序列化对象处理
    /// </summary>
    /// <param name="_serializable">序列化对象</param>
    /// <param name="_export">导出数据</param>
    public delegate void EventHandlerExportSerializable(ISerializable _serializable, byte[] _export);

    /// <summary>
    /// 导入序列化对象处理
    /// </summary>
    /// <param name="_serializable">序列化对象</param>
    /// <param name="_data">序列化数据</param>
    /// <param name="_startIndex">起始索引</param>
    public delegate void EventHandlerImportSerializable(ISerializable _serializable, byte[] _data, long _startIndex);

/// <summary>
/// 序列化接口
/// </summary>
public interface ISerializable
{
    /// <summary>
    /// 导出序列化之前事件处理
    /// </summary>
    event EventHandlerExportSerializable OnBeforeExportSerializable;
    /// <summary>
    /// 导出序列化之后事件处理
    /// </summary>
    event EventHandlerExportSerializable OnAfterExportSerializable;

    /// <summary>
    /// 导入序列化之前事件处理
    /// </summary>
    event EventHandlerImportSerializable OnBeforeImportSerializable;
    /// <summary>
    /// 导入序列化之后事件处理
    /// </summary>
    event EventHandlerImportSerializable OnAfterImportSerializable;

    /// <summary>
    /// 导出序列化数据
    /// </summary>
    /// <returns>序列化数据</returns>
    byte[] ExportSerializable();

    /// <summary>
    /// 导入序列化数据
    /// </summary>
    /// <param name="_data">序列化数据</param>
    /// <param name="_startIndex">起始索引</param>
    /// <returns>结束索引</returns>
    long ImportSerializable(byte[] _data, long _startIndex);
}