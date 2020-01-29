using UnityEngine;
/// <summary>
/// OnTriggerStay
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnTriggerStay")]
public sealed class SimulateMonoBehaviour_OnTriggerStay : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1200575787; } }

	/// <summary>
    /// OnTriggerStay
    /// </summary>
    void OnTriggerStay(UnityEngine.Collider _other)
    {
        simulateMonoBehaviour.OnTriggerStay(_other);
    }
}