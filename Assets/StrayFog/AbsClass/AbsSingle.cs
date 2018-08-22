using System;
using System.Runtime.CompilerServices;
/// <summary>
/// 单例MonoBehaviour组件
/// </summary>
public abstract class AbsSingle<T>
    where T : class
{
    #region AbsSingle 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingle() { }

    /// <summary>
    /// 当前实例
    /// </summary>
    static T mCurrent;
    #endregion

    #region current 单例
    /// <summary>
    /// 单例
    /// </summary>
    public static T current
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            if (mCurrent == null)
            {
                mCurrent = Activator.CreateInstance<T>();
                (mCurrent as AbsSingle<T>).OnAfterConstructor();
            }
            return mCurrent;
        }
    }
    #endregion

    #region OnAfterConstructor 虚构函数
    /// <summary>
    /// 在构造函数之后
    /// </summary>
    protected virtual void OnAfterConstructor() { }
    #endregion
}