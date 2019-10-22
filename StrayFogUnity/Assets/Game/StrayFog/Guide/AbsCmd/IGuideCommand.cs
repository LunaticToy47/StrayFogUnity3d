/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand : IRecycle
{
    /// <summary>
    /// 引导Id
    /// </summary>
    int GuideId { get; }

    /// <summary>
    /// 设置引导Id
    /// </summary>
    /// <param name="_guideId">引导Id</param>
    void SetGuideId(int _guideId);

    /// <summary>
    /// 获得当前引导状态
    /// </summary>
    enGuideStatus status { get; }

    /// <summary>
    /// 是否触发
    /// </summary>
    /// <returns>true:触发,false:不触发</returns>
    bool isTrigger();

    /// <summary>
    /// 执行触发处理
    /// </summary>
    void ExcuteTrigger();

    /// <summary>
    /// 是否通过验证
    /// </summary>
    /// <returns>true:通过,false:不通过</returns>
    bool isValidate();

    /// <summary>
    /// 执行验证处理
    /// </summary>
    void ExcuteValidate();
}
