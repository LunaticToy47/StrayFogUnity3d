using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ScriptableObject单例
/// </summary>
public abstract class AbsSingleScriptableObject : AbsScriptableObject
{
    #region 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingleScriptableObject() { }
    #endregion

    #region 单例
    /// <summary>
    /// 单例对象映射
    /// </summary>
    static Dictionary<int, AbsSingleScriptableObject> mSingleMaping = new Dictionary<int, AbsSingleScriptableObject>();
    /// <summary>
    /// 当前单例
    /// </summary>
    //[MethodImpl(MethodImplOptions.Synchronized)]
    //https://www.cnblogs.com/zhuawang/archive/2013/05/27/3102834.htm
    //这里使用后线程同步锁，会超成死锁，不可以用
    public static T current<T>()
        where T: AbsSingleScriptableObject
    {
        Type t = typeof(T);
        int k = t.GetHashCode();
        if (!mSingleMaping.ContainsKey(k) || mSingleMaping[k] == null)
        {
            string assetName = typeof(T).Name;
            T ins = Resources.Load<T>(assetName);
            ins.OnAfterConstructor();
            mSingleMaping.Add(k, ins);                      
        }
        return (T)mSingleMaping[k];
    }
    #endregion

    #region 虚构函数
    /// <summary>
    /// 在构造函数之后
    /// </summary>
    protected virtual void OnAfterConstructor() { }    
    #endregion
}
