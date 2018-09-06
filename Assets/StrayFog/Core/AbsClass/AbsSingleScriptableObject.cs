using UnityEngine;
/// <summary>
/// ScriptableObject单例
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AbsSingleScriptableObject : AbsScriptableObject
{
    #region 单例
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingleScriptableObject() { }
    /// <summary>
    /// 单例
    /// </summary>
    static AbsSingleScriptableObject msCurrent = null;
    /// <summary>
    /// 当前单例
    /// </summary>
    public static T current<T>()
        where T: AbsSingleScriptableObject
    {
        string assetName = typeof(T).Name;

        if (msCurrent == null)
        {
            msCurrent = Resources.Load<T>(assetName);
            msCurrent.OnAfterConstructor();
        }
        return (T)msCurrent;
    }
    #endregion

    #region 虚构函数
    /// <summary>
    /// 在构造函数之后
    /// </summary>
    protected virtual void OnAfterConstructor() { }
    #endregion
}
