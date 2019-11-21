using UnityEngine;
/// <summary>
/// OnTriggerExit
/// </summary>
public sealed class SimulateMonoBehaviourMethod_OnTriggerExit : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override enSimulateMonoBehaviourMethod methodClassify { get { return enSimulateMonoBehaviourMethod.OnTriggerExit; } }

	/// <summary>
    /// OnTriggerExit
    /// </summary>
    void OnTriggerExit(UnityEngine.Collider other)
    {
        
    }
}