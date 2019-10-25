/// <summary>
/// 事件句柄参数接口
/// </summary>
public interface IStrayFogEventHandlerArgs
{
    #region eventId 事件Id
    /// <summary>
    /// 事件类型
    /// </summary>
    int eventId { get; }
    #endregion

    #region SetValue
    /// <summary>
    /// 设置值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="_value">值</param>
    void SetValue<T>(T _value);

    /// <summary>
    /// 设置值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="_index">存储索引</param>
    /// <param name="_value">值</param>
    void SetValue<T>(int _index, T _value);
    #endregion

    #region GetValue
    /// <summary>
    /// 获得值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <returns>值</returns>
    T GetValue<T>();
    /// <summary>
    /// 获得值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="_index">存储索引</param>
    /// <returns>值</returns>
    T GetValue<T>(int _index);
    #endregion
}
