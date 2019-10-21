/// <summary>
/// 引导抽象
/// </summary>
public abstract class AbsGuideCommand : IGuideCommand
{
    #region SetUserData 设置用户数据
    /// <summary>
    /// 设置用户数据
    /// </summary>
    /// <param name="_userData">用户数据</param>
    public void SetUserData(object _userData)
    {
        OnSetUserData(_userData);
    }

    /// <summary>
    /// 设置用户数据
    /// </summary>
    /// <param name="_userData">用户数据</param>
    protected abstract void OnSetUserData(object _userData);
    #endregion

    #region GetUserData 设置用户数据
    /// <summary>
    /// 设置用户数据
    /// </summary>
    public object GetUserData()
    {
        return OnGetUserData();
    }

    /// <summary>
    /// 设置用户数据
    /// </summary>
    protected abstract object OnGetUserData();
    #endregion

    #region GetGuideStatus 获得当前引导状态
    /// <summary>
    /// 获得当前引导状态
    /// </summary>
    public enGuideStatus GetGuideStatus()
    {
        return OnGetGuideStatus();
    }

    /// <summary>
    /// 获得当前引导状态
    /// </summary>
    /// <returns></returns>
    protected abstract enGuideStatus OnGetGuideStatus();
    #endregion

    #region OnIsValidate 是否通过验证
    /// <summary>
    /// 是否通过验证
    /// </summary>
    /// <returns>true:通过,false:不通过</returns>
    protected abstract bool OnIsValidate();
    /// <summary>
    /// 是否通过验证
    /// </summary>
    /// <returns>true:通过,false:不通过</returns>
    public bool isValidate()
    {
        return OnIsValidate();
    }
    #endregion

    #region OnExcute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    protected abstract void OnExcute();
    /// <summary>
    /// 执行处理
    /// </summary>
    public void Excute()
    {
        OnExcute();
    }
    #endregion

}