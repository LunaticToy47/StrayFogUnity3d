using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 模拟UIBehaviour方法抽象
/// </summary>
public abstract class AbsSimulateUIBehaviourMethod : UIBehaviour,ISimulateBehaviourMethod
{
    /// <summary>
    /// 方法分类
    /// </summary>
    public abstract int methodClassify { get; }
}