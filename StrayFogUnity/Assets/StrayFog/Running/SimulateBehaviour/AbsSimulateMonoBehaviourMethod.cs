using UnityEngine;
/// <summary>
/// 模拟MonoBehaviour方法抽象
/// </summary>
public abstract class AbsSimulateMonoBehaviourMethod : MonoBehaviour,ISimulateBehaviourMethod
{
    /// <summary>
    /// 方法分类
    /// </summary>
    public abstract int methodClassify { get; }

    /// <summary>
    /// 模拟MonoBehaviour对象
    /// </summary>
    public ISimulateMonoBehaviour simulateMonoBehaviour { get; private set; }

    /// <summary>
    /// 绑定ISimulateMonoBehaviour
    /// </summary>
    /// <param name="_smb">ISimulateMonoBehaviour对象</param>
    public void BindSimulateMonoBehaviour(ISimulateMonoBehaviour _smb)
    {
        simulateMonoBehaviour = _smb;
    }
}