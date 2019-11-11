using System;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// MonoBehaviour扩展
/// </summary>
public static class MonoBehaviourExtend
{
    /// <summary>
    /// 添加动态组件
    /// </summary>
    /// <typeparam name="T">组件</typeparam>
    /// <param name="_go">GameObject</param>
    /// <returns>组件</returns>
    public static T AddDynamicComponent<T>(this GameObject _go)
        where T : AbsMonoBehaviour, new()
    {
        T result = new T();
        result.BindGameObject(_go);
        return result;
    }

    /// <summary>
    /// 添加动态组件
    /// </summary>
    /// <typeparam name="T">组件</typeparam>
    /// <param name="_go">GameObject</param>
    /// <param name="_type">组件类别</param>
    /// <returns>组件</returns>
    public static T AddDynamicComponent<T>(this GameObject _go, Type _type)
        where T : AbsMonoBehaviour
    {
        T result = (T)Activator.CreateInstance(_type);
        result.BindGameObject(_go);
        return result;
    }

    /// <summary>
    /// 添加动态EventTrigger组件
    /// </summary>
    /// <typeparam name="T">组件</typeparam>
    /// <param name="_go">GameObject</param>
    /// <returns>组件</returns>
    public static T AddUIDynamicEventTrigger<T>(this GameObject _go)
        where T : EventTrigger
    {
        return _go.AddComponent<T>();
    }
}
