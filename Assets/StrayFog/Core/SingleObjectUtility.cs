/// <summary>
/// 单例对象工具
/// </summary>
public static class SingleObjectUtility
{
    /// <summary>
    /// 单例对象扩展
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public static T Single<T>()
        where T : AbsSingle
    {
        return AbsSingle.current<T>();
    }
}
