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

    /// <summary>
    /// 当前实例
    /// </summary>
    static AbsSingleMonoBehaviour msCurrent;
    #endregion

    #region 单例
    /// <summary>
    /// 单例
    /// </summary>    
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static T current<T>()
        where T : AbsSingleMonoBehaviour
    {
        if (msCurrent == null)
        {
            GameObject go = new GameObject(typeof(T).FullName);
            msCurrent = go.AddComponent<T>();
            DontDestroyOnLoad(msCurrent.gameObject);
            msCurrent.gameObject.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
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
