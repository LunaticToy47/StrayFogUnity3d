using UnityEngine;
/// <summary>
/// OnTriggerStay
/// </summary>
public sealed class SimulateMonoBehaviourMethod_OnTriggerStay : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override enSimulateMonoBehaviourMethod methodClassify { get { return enSimulateMonoBehaviourMethod.OnTriggerStay; } }

	/// <summary>
    /// OnTriggerStay
    /// </summary>
    void OnTriggerStay(UnityEngine.Collider other)
    {
        
    }
}