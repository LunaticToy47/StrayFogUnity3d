using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour
/// </summary>
public abstract partial class AbsMonoBehaviour : ICollect
{
    #region CollectCtrl 收集组件
    /// <summary>
    /// 收集组件映射
    /// </summary>
    Dictionary<int, MonoBehaviour> mCollectMonoBehaviourMaping = new Dictionary<int, MonoBehaviour>();
    /// <summary>
    /// 收集组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    public void CollectCtrl<T>() where T : MonoBehaviour
    {
        int key = 0;
        T[] ctls = gameObject.GetComponentsInChildren<T>(true);
        if (ctls != null)
        {
            foreach (T c in ctls)
            {
                key = c.name.GetHashCode();
                if (!mCollectMonoBehaviourMaping.ContainsKey(key))
                {
                    mCollectMonoBehaviourMaping.Add(key, c);
                }
                else
                {
                    throw new UnityException(string.Format("The window 【{0}】has the same control for name 【{1}】", name, c.name));
                }
            }
        }
        T self = gameObject.GetComponent<T>();
        if (self != null)
        {
            key = self.name.GetHashCode();
            if (!mCollectMonoBehaviourMaping.ContainsKey(key))
            {
                mCollectMonoBehaviourMaping.Add(key, self);
            }
            else
            {
                throw new UnityException(string.Format("The window 【{0}】has the same control for name 【{1}】", name, self.name));
            }
        }
    }
    #endregion

    #region FindCtrlByName 根据名称查询组件
    /// <summary>
    /// 根据名称查询组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="_name">组件名称</param>
    /// <returns>组件</returns>
    public T FindCtrlByName<T>(string _name) where T : MonoBehaviour
    {
        int key = _name.GetHashCode();
        return mCollectMonoBehaviourMaping.ContainsKey(key) ? (T)mCollectMonoBehaviourMaping[key] : default;
    }
    #endregion
}
