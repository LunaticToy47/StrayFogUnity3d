using UnityEngine;
/// <summary>
/// OnTriggerExit
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnTriggerExit")]
public sealed class SimulateMonoBehaviour_OnTriggerExit : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -1054648354; } }

	/// <summary>
    /// OnTriggerExit
    /// </summary>
    void OnTriggerExit(UnityEngine.Collider _other)
    {
        simulateMonoBehaviour.OnTriggerExit(_other);
    }
}