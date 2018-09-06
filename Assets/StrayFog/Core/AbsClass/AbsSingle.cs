using System;
using System.Runtime.CompilerServices;
/// <summary>
/// 单例MonoBehaviour组件
/// </summary>
public abstract class AbsSingle
{
    #region AbsSingle 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingle() { }

    /// <summary>
    /// 当前实例
    /// </summary>
    static AbsSingle mCurrent;
    #endregion

    #region current 单例
    /// <summary>
    /// 单例
    /// </summary>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static T current<T>()
        where T: AbsSingle
    {
        if (mCurrent == null)
        {
            mCurrent = Activator.CreateInstance<T>();
            mCurrent.OnAfterConstructor();
        }
        return (T)mCurrent;
    }
    #endregion

    #region OnAfterConstructor 虚构函数
    /// <summary>
    /// 在构造函数之后
    /// </summary>
    protected virtual void OnAfterConstructor() { }
    #endregion
}