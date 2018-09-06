using System;
using System.Collections.Generic;
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
    #endregion

    #region current 单例
    /// <summary>
    /// 单例对象映射
    /// </summary>
    static Dictionary<int, AbsSingle> mSingleMaping = new Dictionary<int, AbsSingle>();
    /// <summary>
    /// 单例
    /// </summary>
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static T current<T>()
        where T: AbsSingle
    {
        Type t = typeof(T);
        int k = t.GetHashCode();
        if (!mSingleMaping.ContainsKey(k))
        {            
            mSingleMaping[k].OnAfterConstructor();
            mSingleMaping.Add(k, Activator.CreateInstance<T>());
        }
        return (T)mSingleMaping[k];
    }
    #endregion

    #region OnAfterConstructor 虚构函数
    /// <summary>
    /// 在构造函数之后
    /// </summary>
    protected virtual void OnAfterConstructor() { }
    #endregion
}