using UnityEngine;
/// <summary>
/// OnCollisionStay
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCollisionStay")]
public sealed class SimulateMonoBehaviour_OnCollisionStay : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -1765579245; } }

	/// <summary>
    /// OnCollisionStay
    /// </summary>
    void OnCollisionStay(UnityEngine.Collision _collision)
    {
        simulateMonoBehaviour.OnCollisionStay(_collision);
    }
}