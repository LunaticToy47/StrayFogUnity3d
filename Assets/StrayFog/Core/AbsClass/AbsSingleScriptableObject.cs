using UnityEngine;
/// <summary>
/// ScriptableObject单例
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class AbsSingleScriptableObject<T> : AbsScriptableObject
where T : AbsSingleScriptableObject<T>
{
    /// <summary>
    /// 资源名称
    /// </summary>
    public static readonly string assetName = typeof(T).Name;

    #region 单例
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingleScriptableObject() { }
    /// <summary>
    /// 单例
    /// </summary>
    static T msCurrent = null;
    /// <summary>
    /// 当前单例
    /// </summary>
    public static T current
    {
        get
        {
            if (msCurrent == null)
            {
                msCurrent = Resources.Load<T>(assetName);
                (msCurrent as AbsSingleScriptableObject<T>).OnAfterConstructor();
            }
            return msCurrent;
        }
    }
    #endregion

    #region 虚构函数
    /// <summary>
    /// 在构造函数之后
    /// </summary>
    protected virtual void OnAfterConstructor() { }
    #endregion
}
