using System;
using System.Collections.Generic;
/// <summary>
/// 抽象MonoBehaviour【ISerializable接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : ISerializable
{
    #region ISerializable
    /// <summary>
    /// 空序列化数据
    /// </summary>
    readonly byte[] mrEmptySerializable = new byte[0];
    /// <summary>
    /// 导出序列化之前事件处理
    /// </summary>
    public event Action<ISerializable, byte[]> OnBeforeExportSerializable;
    /// <summary>
    /// 导出序列化之后事件处理
    /// </summary>
    public event Action<ISerializable, byte[]> OnAfterExportSerializable;
    /// <summary>
    /// 导入序列化之前事件处理
    /// </summary>
    public event Action<ISerializable, byte[], long> OnBeforeImportSerializable;
    /// <summary>
    /// 导入序列化之后事件处理
    /// </summary>
    public event Action<ISerializable, byte[], long> OnAfterImportSerializable;
    /// <summary>
    /// 导出序列化数据
    /// </summary>
    /// <returns>序列化数据</returns>
    public byte[] ExportSerializable()
    {
        OnBeforeExportSerializable?.Invoke(this, mrEmptySerializable);
        List<byte> sers = new List<byte>();
        sers.AddRange(mGlobalId.GetBytes());
        sers.AddRange(OnExportSerializable());
        byte[] result = sers.ToArray();
        OnAfterExportSerializable?.Invoke(this, result);
        return result;
    }

    /// <summary>
    /// 导出序列化数据
    /// </summary>
    /// <returns>序列化数据</returns>
    protected virtual byte[] OnExportSerializable() { return mrEmptySerializable; }

    /// <summary>
    /// 导入序列化数据
    /// </summary>
    /// <param name="_data">序列化数据</param>
    /// <param name="_startIndex">起始索引</param>
    /// <returns>结束索引</returns>
    public long ImportSerializable(byte[] _data, long _startIndex)
    {
        OnBeforeImportSerializable?.Invoke(this, _data, _startIndex);
        mGlobalId = _data.ToInt32(ref _startIndex);
        _startIndex = OnImportSerializable(_data, _startIndex);
        OnAfterImportSerializable?.Invoke(this, _data, _startIndex);
        return _startIndex;
    }

    /// <summary>
    /// 导入序列化数据
    /// </summary>
    /// <param name="_data">序列化数据</param>
    /// <param name="_startIndex">起始索引</param>
    /// <returns>结束索引</returns>
    protected virtual long OnImportSerializable(byte[] _data, long _startIndex) { return _startIndex; }
    #endregion
}
