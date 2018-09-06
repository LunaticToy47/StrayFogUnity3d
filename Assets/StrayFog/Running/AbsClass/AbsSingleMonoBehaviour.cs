using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/// <summary>
/// 单例MonoBehaviour组件
/// </summary>
public abstract class AbsSingleMonoBehaviour : AbsMonoBehaviour
{
    #region 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingleMonoBehaviour() { }
    #endregion

    #region 单例
    /// <summary>
    /// 单例对象映射
    /// </summary>
    static Dictionary<int, AbsSingleMonoBehaviour> mSingleMaping = new Dictionary<int, AbsSingleMonoBehaviour>();
    /// <summary>
    /// 单例
    /// </summary>    
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static T current<T>()
        where T : AbsSingleMonoBehaviour
    {
        Type t = typeof(T);
        int k = t.GetHashCode();
        if (!mSingleMaping.ContainsKey(k))
        {
            GameObject go = new GameObject(typeof(T).FullName);            
            DontDestroyOnLoad(mSingleMaping[k].gameObject);
            mSingleMaping[k].gameObject.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
            mSingleMaping[k].OnAfterConstructor();
            mSingleMaping.Add(k, go.AddComponent<T>());
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
