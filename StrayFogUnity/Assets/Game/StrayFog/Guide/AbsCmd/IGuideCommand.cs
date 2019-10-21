/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand
{
    /// <summary>
    /// 设置用户数据
    /// </summary>
    /// <param name="_userData">用户数据</param>
    void SetUserData(object _userData);

    /// <summary>
    /// 获得用户数据
    /// </summary>
    /// <returns>用户数据</returns>
    object GetUserData();

    /// <summary>
    /// 获得当前引导状态
    /// </summary>
    enGuideStatus GetGuideStatus();

    /// <summary>
    /// 是否通过验证
    /// </summary>
    /// <returns>true:通过,false:不通过</returns>
    bool isValidate();

    /// <summary>
    /// 执行处理
    /// </summary>
    void Excute();
}
