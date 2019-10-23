using System;
/// <summary>
/// 引导命令抽象
/// </summary>
public abstract class AbsGuideCommand : AbsGuideCondition, IGuideCommand
{
    #region guideId 引导Id
    /// <summary>
    /// 引导Id
    /// </summary>
    public int guideId { get; private set; }
    #endregion

    #region guideType 引导类型
    /// <summary>
    /// 引导类型
    /// </summary>
    public int guideType { get; private set; }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    {
        guideId = _config.id;
        guideType = _config.guideType;
        OnResolveConfig(_config, _funcReferObject);
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    protected virtual void OnResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    { }
    #endregion    

    #region status 当前引导状态
    /// <summary>
    /// 当前引导状态
    /// </summary>
    public enGuideStatus status { get; private set; }
    #endregion

    #region OnExcute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    public void Excute()
    {
        OnExcute();
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    protected virtual void OnExcute() { }
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
}