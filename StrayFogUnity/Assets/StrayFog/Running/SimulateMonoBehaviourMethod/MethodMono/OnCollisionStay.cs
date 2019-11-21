using UnityEngine;
/// <summary>
/// OnCollisionStay
/// </summary>
public sealed class SimulateMonoBehaviourMethod_OnCollisionStay : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override enSimulateMonoBehaviourMethod methodClassify { get { return enSimulateMonoBehaviourMethod.OnCollisionStay; } }

	/// <summary>
    /// OnCollisionStay
    /// </summary>
    void OnCollisionStay(UnityEngine.Collision collision)
    {
        
    }
}