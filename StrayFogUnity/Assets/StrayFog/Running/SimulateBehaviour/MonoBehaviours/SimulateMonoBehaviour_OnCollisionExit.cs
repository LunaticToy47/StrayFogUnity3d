using UnityEngine;
/// <summary>
/// OnCollisionExit
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCollisionExit")]
public sealed class SimulateMonoBehaviour_OnCollisionExit : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1607437773; } }

	/// <summary>
    /// OnCollisionExit
    /// </summary>
    void OnCollisionExit(UnityEngine.Collision _collision)
    {
        simulateMonoBehaviour.OnCollisionExit(_collision);
    }
}