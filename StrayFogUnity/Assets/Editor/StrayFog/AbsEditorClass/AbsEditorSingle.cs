using System;
using System.Collections.Generic;
/// <summary>
/// 单例MonoBehaviour组件
/// </summary>
public abstract class AbsEditorSingle
{
    #region AbsSingle 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsEditorSingle() { }
    #endregion

    #region current 单例
    /// <summary>
    /// 单例对象映射
    /// </summary>
    static Dictionary<int, AbsEditorSingle> mSingleMaping = new Dictionary<int, AbsEditorSingle>();
    /// <summary>
    /// 单例
    /// </summary>
    //[MethodImpl(MethodImplOptions.Synchronized)]
    //https://www.cnblogs.com/zhuawang/archive/2013/05/27/3102834.htm
    //这里使用后线程同步锁，会超成死锁，不可以用
    public static T current<T>()
        where T : AbsEditorSingle, new()
    {
        Type t = typeof(T);
        int k = t.GetHashCode();
        if (!mSingleMaping.ContainsKey(k) || mSingleMaping[k] == null)
        {
            T ins = new T();
            ins.OnAfterConstructor();
            mSingleMaping.Add(k, ins);
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