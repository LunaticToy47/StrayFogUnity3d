using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour
/// </summary>
public abstract partial class AbsMonoBehaviour : ICollect
{
    #region CollectCtrl 收集组件
    /// <summary>
    /// 收集组件映射
    /// </summary>
    Dictionary<int, Dictionary<int, UIBehaviour>> mCollectMonoBehaviourMaping = new Dictionary<int, Dictionary<int, UIBehaviour>>();
    /// <summary>
    /// 收集组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    public void CollectCtrl<T>() where T : UIBehaviour
    {
        OnCollectCtrl(gameObject.GetComponentsInChildren<T>(true));
        OnCollectCtrl(gameObject.GetComponents<T>());       
    }

    /// <summary>
    /// 搜索指定类型控件
    /// </summary>
    /// <typeparam name="T">控件类型</typeparam>
    /// <param name="_ctls">控件组件</param>
    void OnCollectCtrl<T>(T[] _ctls) where T : UIBehaviour
    {
        int nameKey = 0;
        int typeKey = 0;
        foreach (T c in _ctls)
        {
            nameKey = c.name.GetHashCode();
            typeKey = c.GetType().GetHashCode();
            if (!mCollectMonoBehaviourMaping.ContainsKey(nameKey))
            {
                mCollectMonoBehaviourMaping.Add(nameKey, new Dictionary<int, UIBehaviour>());
            }
            if (!mCollectMonoBehaviourMaping[nameKey].ContainsKey(typeKey))
            {
                mCollectMonoBehaviourMaping[nameKey].Add(typeKey, c);
            }
            else
            {
                throw new UnityException(string.Format("{0} has the same control for {1}_{2}", this, c.name, c.GetType()));
            }
        }
    }
    #endregion

    #region FindCtrlByName 查询指定名称组件
    /// <summary>
    /// 查询指定名称组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="_name">组件名称</param>
    /// <returns>组件</returns>
    public T FindCtrlByName<T>(string _name) where T : UIBehaviour
    {
        int nameKey = _name.GetHashCode();
        int typeKey = typeof(T).GetHashCode();
        T result = default;
        if (mCollectMonoBehaviourMaping.ContainsKey(nameKey) && mCollectMonoBehaviourMaping[nameKey].ContainsKey(typeKey))
        {
            result = (T)mCollectMonoBehaviourMaping[nameKey][typeKey];
        }
        return result;
    }
    #endregion

    #region FindCtrlByNameIsSelfOrParent 查询指定名称组件【组件类型是指定类型或父类型】
    /// <summary>
    /// 查询指定名称组件【组件类型是指定类型或父类型】
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="_name">组件名称</param>
    /// <returns>组件</returns>
    public T FindCtrlByNameIsSelfOrParent<T>(string _name) where T : UIBehaviour
    {
        int nameKey = _name.GetHashCode();
        T result = default;
        if (mCollectMonoBehaviourMaping.ContainsKey(nameKey))
        {
            foreach (UIBehaviour b in mCollectMonoBehaviourMaping[nameKey].Values)
            {
                if (b is T)
                {
                    result = (T)b;
                    break;
                }
            }
        }
        return result;
    }
    #endregion
}
