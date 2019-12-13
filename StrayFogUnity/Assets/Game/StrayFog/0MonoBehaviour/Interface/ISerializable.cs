using System;
/// <summary>
/// 序列化接口
/// </summary>
public interface ISerializable
{
    /// <summary>
    /// 导出序列化之前事件处理
    /// Arg1:序列化对象
    /// Arg2:导出数据
    /// </summary>
    event Action<ISerializable, byte[]> OnBeforeExportSerializable;
    /// <summary>
    /// 导出序列化之后事件处理
    /// Arg1:序列化对象
    /// Arg2:导出数据
    /// </summary>
    event Action<ISerializable, byte[]> OnAfterExportSerializable;

    /// <summary>
    /// 导入序列化之前事件处理
    /// Arg1:序列化对象
    /// Arg2:序列化数据
    /// Arg3:起始索引
    /// </summary>
    event Action<ISerializable, byte[], long> OnBeforeImportSerializable;
    /// <summary>
    /// 导入序列化之后事件处理
    /// </summary>
    event Action<ISerializable, byte[], long> OnAfterImportSerializable;

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