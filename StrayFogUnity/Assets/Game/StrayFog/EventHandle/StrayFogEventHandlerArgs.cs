using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 事件句柄参数
/// </summary>
public class StrayFogEventHandlerArgs
{    
    /// <summary>
    /// 事件类型
    /// </summary>
    public int eventId { get; private set; }

    /// <summary>
    /// 事件聚合参数
    /// </summary>
    /// <param name="_eventId">事件ID</param>
    public StrayFogEventHandlerArgs(int _eventId)
    {
        eventId = _eventId;
    }

    /// <summary>
    /// 参数值映射
    /// </summary>
    Dictionary<int, Dictionary<int, object>> mArgValueMaping = new Dictionary<int, Dictionary<int, object>>();
    
    #region SetValue
    /// <summary>
    /// 设置值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="_value">值</param>
    public void SetValue<T>(T _value)
    {
        SetValue(0, _value);
    }

    /// <summary>
    /// 设置值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="_index">存储索引</param>
    /// <param name="_value">值</param>
    public void SetValue<T>(int _index, T _value)
    {
        Type t = typeof(T);
        int tkey = t.GetHashCode();
        if (!mArgValueMaping.ContainsKey(tkey))
        {
            mArgValueMaping.Add(tkey, new Dictionary<int, object>());
        }
        if (!mArgValueMaping[tkey].ContainsKey(_index))
        {
            mArgValueMaping[tkey].Add(_index, default(T));
        }
        mArgValueMaping[tkey][_index] = _value;
    }
    #endregion

    #region GetValue
    /// <summary>
    /// 获得值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <returns>值</returns>
    public T GetValue<T>()
    {
        return GetValue<T>(0);
    }
    /// <summary>
    /// 获得值
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="_index">存储索引</param>
    /// <returns>值</returns>
    public T GetValue<T>(int _index)
    {
        Type t = typeof(T);
        int tkey = t.GetHashCode();
        T result = default(T);
        if (mArgValueMaping.ContainsKey(tkey) && mArgValueMaping[tkey].ContainsKey(_index))
        {
            result = (T)mArgValueMaping[tkey][_index];
        }
        return result;
    }
    #endregion

    #region ToString
    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>String</returns>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Dictionary<int, object> key in mArgValueMaping.Values)
        {
            foreach (KeyValuePair<int, object> val in key)
            {
                sb.AppendLine(string.Format("Index【{0}】,Value【{1}】", val.Key, val.Value));
            }
        }
        return sb.ToString();
    }
    #endregion
}
