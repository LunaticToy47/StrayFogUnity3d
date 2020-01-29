using UnityEngine;
/// <summary>
/// OnCollisionEnter
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCollisionEnter")]
public sealed class SimulateMonoBehaviour_OnCollisionEnter : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 299299344; } }

	/// <summary>
    /// OnCollisionEnter
    /// </summary>
    void OnCollisionEnter(UnityEngine.Collision _collision)
    {
        simulateMonoBehaviour.OnCollisionEnter(_collision);
    }
}