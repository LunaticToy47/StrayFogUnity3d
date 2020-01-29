using UnityEngine;
/// <summary>
/// OnTriggerStay2D
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnTriggerStay2D")]
public sealed class SimulateMonoBehaviour_OnTriggerStay2D : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -808789687; } }

	/// <summary>
    /// OnTriggerStay2D
    /// </summary>
    void OnTriggerStay2D(UnityEngine.Collider2D _collision)
    {
        simulateMonoBehaviour.OnTriggerStay2D(_collision);
    }
}