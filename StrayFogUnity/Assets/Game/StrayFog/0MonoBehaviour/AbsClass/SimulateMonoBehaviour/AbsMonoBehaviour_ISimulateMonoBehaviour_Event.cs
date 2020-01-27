using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour【模拟MonoBehaviour,UIBehaviour的事件】
/// </summary>
public abstract partial class AbsMonoBehaviour
{
    /// <summary>
    /// 模拟行为事件
    /// </summary>
    protected virtual enSimulateBehaviourMethod[] simulateBehaviourEvent { get {
            return null;
    } }

    /// <summary>
    /// 绑定模拟事件
    /// </summary>
    void OnBindSimulateBehaviourEvent()
    {

    }
}
