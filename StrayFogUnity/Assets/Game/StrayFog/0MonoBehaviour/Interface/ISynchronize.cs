using System;
/// <summary>
/// 同步接口
/// </summary>
public interface ISynchronize
{
    /// <summary>
    /// 导出同步之前事件处理
    /// Arg1:同步对象
    /// Arg2:导出数据
    /// </summary>
    event Action<ISynchronize, byte[]> OnBeforeExportSynchronize;
    /// <summary>
    /// 导出同步之后事件处理
    /// Arg1:同步对象
    /// Arg2:导出数据
    /// </summary>
    event Action<ISynchronize, byte[]> OnAfterExportSynchronize;

    /// <summary>
    /// 导入同步之前事件处理
    /// Arg1:同步对象
    /// Arg2:导出数据
    /// Arg3:起始索引
    /// </summary>
    event Action<ISynchronize, byte[], long> OnBeforeImportSynchronize;
    /// <summary>
    /// 导入同步之后事件处理
    /// Arg1:同步对象
    /// Arg2:导出数据
    /// Arg3:起始索引
    /// </summary>
    event Action<ISynchronize, byte[], long> OnAfterImportSynchronize;

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
