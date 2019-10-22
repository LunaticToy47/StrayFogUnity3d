using System;
/// <summary>
/// 引导命令抽象
/// </summary>
public abstract class AbsGuideCommand : IGuideCommand
{
    #region GuideId 引导Id
    /// <summary>
    /// 引导Id
    /// </summary>
    public int GuideId { get; private set; }
    #endregion

    #region SetGuideId 设置引导Id
    /// <summary>
    /// 设置引导Id
    /// </summary>
    /// <param name="_guideId">引导Id</param>
    public void SetGuideId(int _guideId)
    {
        GuideId = _guideId;
    }
    #endregion

    #region status 当前引导状态
    /// <summary>
    /// 当前引导状态
    /// </summary>
    public enGuideStatus status { get; private set; }
    #endregion

    #region isTrigger 是否触发
    /// <summary>
    /// 是否触发
    /// </summary>
    /// <returns>true:触发,false:不触发</returns>
    public bool isTrigger()
    {
        return OnIsTrigger();
    }
    /// <summary>
    /// 是否触发
    /// </summary>
    /// <returns>true:触发,false:不触发</returns>
    protected virtual bool OnIsTrigger() { return false; }
    #endregion

    #region ExcuteTrigger 执行触发处理
    /// <summary>
    /// 执行触发处理
    /// </summary>
    public void ExcuteTrigger()
    {
        OnExcuteTrigger();
    }
    /// <summary>
    /// 执行触发处理
    /// </summary>
    protected virtual void OnExcuteTrigger() { }
    #endregion

    #region isValidate 是否通过验证
    /// <summary>
    /// 是否通过验证
    /// </summary>
    /// <returns>true:通过,false:不通过</returns>
    public bool isValidate()
    {
        return OnIsValidate();
    }
    /// <summary>
    /// 是否通过验证
    /// </summary>
    /// <returns>true:通过,false:不通过</returns>
    protected virtual bool OnIsValidate() { return false; }
    #endregion

    #region OnExcute 执行处理
    /// <summary>
    /// 执行验证处理
    /// </summary>
    public void ExcuteValidate()
    {
        OnExcuteValidate();
    }

    /// <summary>
    /// 执行验证处理
    /// </summary>
    protected virtual void OnExcuteValidate() { }
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