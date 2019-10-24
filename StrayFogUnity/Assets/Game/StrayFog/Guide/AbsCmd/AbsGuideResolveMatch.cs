using System;
using System.Collections.Generic;
/// <summary>
/// 引导解析匹配抽象
/// </summary>
public abstract class AbsGuideResolveMatch : IGuideMatchCondition, IGuideResolveConfig, IRecycle
{
    /// <summary>
    /// 引导配置
    /// </summary>
    public XLS_Config_Table_UserGuideConfig guideConfig { get; private set; }

    /// <summary>
    /// 参考对象配置
    /// </summary>
    public XLS_Config_Table_UserGuideReferObject referObjectConfig { get; private set; }

    #region isMatchCondition 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    public bool isMatchCondition(params object[] _parameters)
    {
        return OnIsMatchCondition(_parameters);
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected virtual bool OnIsMatchCondition(params object[] _parameters) { return true; }
    #endregion

    #region Excute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    public void Excute(params object[] _parameters)
    {
        OnExcute(_parameters);
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    protected virtual void OnExcute(params object[] _parameters) { }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _index, enGuideStatus _status)
    {
        guideConfig = _config;
        OnResolveConfig(_config, _index, _status);
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    protected virtual void OnResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _index, enGuideStatus _status) { }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _status)
    {
        referObjectConfig = _config;
        OnResolveConfig(_config, _index, _status);
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    protected virtual void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _status) { }
    #endregion

    #region Recycle 回收
    /// <summary>
    /// 回收之前事件
    /// </summary>
    public event EventHandlerRecycle OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件
    /// </summary>
    public event EventHandlerRecycle OnAfterRecycle;

    /// <summary>
    /// 回收
    /// </summary>
    public void Recycle()
    {
        OnBeforeRecycle?.Invoke(this);
        OnRecycle();
        OnAfterRecycle?.Invoke(this);
    }

    /// <summary>
    /// 回收
    /// </summary>
    protected virtual void OnRecycle() { }

    /// <summary>
    /// 延时回收
    /// </summary>
    /// <param name="_delay">延时时间</param>
    [Obsolete("Use Recycle() instead. Delay is not use.")]
    public void Recycle(float _delay)
    {
        Recycle();
    }
    #endregion

    #region OnSegmentationGroup 将源字符串按组分隔
    /// <summary>
    /// 将源字符串按组分隔
    /// </summary>
    /// <param name="_source">源字符</param>
    /// <returns>组字符</returns>
    protected string[] OnSegmentationGroup(string _source)
    {
        return string.IsNullOrEmpty(_source) ? new string[0] : _source.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries);
    }
    #endregion

    #region OnSegmentationValue 将源字符串按值分隔
    /// <summary>
    /// 将源字符串按值分隔
    /// </summary>
    /// <param name="_source">源字符</param>
    /// <returns>值字符</returns>
    protected string[] OnSegmentationValue(string _source)
    {
        return string.IsNullOrEmpty(_source) ? new string[0] : _source.Split(new string[1] { "_" }, StringSplitOptions.RemoveEmptyEntries);
    }
    #endregion
}
