using UnityEngine;
/// <summary>
/// OnCollisionExit
/// </summary>
public sealed class SimulateMonoBehaviourMethod_OnCollisionExit : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override enSimulateMonoBehaviourMethod methodClassify { get { return enSimulateMonoBehaviourMethod.OnCollisionExit; } }

	/// <summary>
    /// OnCollisionExit
    /// </summary>
    void OnCollisionExit(UnityEngine.Collision collision)
    {
        
    }
}