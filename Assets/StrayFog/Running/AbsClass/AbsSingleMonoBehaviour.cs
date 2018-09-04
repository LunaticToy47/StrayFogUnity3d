using System.Runtime.CompilerServices;
using UnityEngine;
/// <summary>
/// 单例MonoBehaviour组件
/// </summary>
/// <typeparam name="T">组件类型</typeparam>
public abstract class AbsSingleMonoBehaviour<T> : AbsMonoBehaviour
where T : AbsMonoBehaviour
{
    #region 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    protected AbsSingleMonoBehaviour() { }

    /// <summary>
    /// 当前实例
    /// </summary>
    static T msCurrent;
    #endregion

    #region 单例
    /// <summary>
    /// 单例
    /// </summary>    
    public static T current
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            if (msCurrent == null)
            {
                GameObject go = new GameObject(typeof(T).FullName);
                msCurrent = go.AddComponent<T>();
                DontDestroyOnLoad(msCurrent.gameObject);
                msCurrent.gameObject.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
                (msCurrent as AbsSingleMonoBehaviour<T>).OnAfterConstructor();
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
