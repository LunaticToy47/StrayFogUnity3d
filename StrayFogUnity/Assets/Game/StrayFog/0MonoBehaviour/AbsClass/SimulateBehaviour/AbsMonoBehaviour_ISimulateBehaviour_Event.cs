using System;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour【模拟MonoBehaviour,UIBehaviour的事件】
/// </summary>
public abstract partial class AbsMonoBehaviour
{
    /// <summary>
    /// 模拟行为方法
    /// </summary>
    protected virtual enSimulateBehaviourMethod[] simulateBehaviourMethods { get {
            return null;
    } }

    /// <summary>
    /// MonoBehaviour默认模拟方法
    /// </summary>
    readonly enSimulateBehaviourMethod[] mMonoBehaviourDefultMethods =
        new enSimulateBehaviourMethod[2] { enSimulateBehaviourMethod.MonoBehaviour_Awake,
            enSimulateBehaviourMethod.MonoBehaviour_Start};

    /// <summary>
    /// UIBehaviour默认模拟方法
    /// </summary>
    readonly enSimulateBehaviourMethod[] mUIBehaviourDefultMethods =
        new enSimulateBehaviourMethod[2] { enSimulateBehaviourMethod.UIBehaviour_Awake,
            enSimulateBehaviourMethod.UIBehaviour_Start};

    /// <summary>
    /// 添加指定事件到GameObject
    /// </summary>
    /// <param name="_simulateMethod">模拟方法</param>
    /// <param name="_go">GameObject</param>
    void OnAddEvent(enSimulateBehaviourMethod _simulateMethod, GameObject _go)
    {
        int key = (int)_simulateMethod;
        Type type = null;
        if (mSimulateBehaviourEnumForMethodMap.TryGetValue(key, out type))
        {
            Component com = _go.GetComponent(type);
            if (null == com)
            {
                com = _go.AddComponent(type);
            }
            ISimulateBehaviourMethod result = com as ISimulateBehaviourMethod;
        }
    }

    /// <summary>
    /// 绑定模拟事件
    /// </summary>
    void OnBindSimulateBehaviourEvent()
    {
        if (hasRectTransform)
        {
            foreach (enSimulateBehaviourMethod m in mUIBehaviourDefultMethods)
            {
                OnAddEvent(m, gameObject);
            }
        }
        else
        {
            foreach (enSimulateBehaviourMethod m in mMonoBehaviourDefultMethods)
            {
                OnAddEvent(m, gameObject);
            }
        }

        if (simulateBehaviourMethods != null && simulateBehaviourMethods.Length > 0)
        {
            foreach (enSimulateBehaviourMethod m in simulateBehaviourMethods)
            {
                OnAddEvent(m, gameObject);
            }            
        }
    }
}
