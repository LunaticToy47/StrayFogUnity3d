using UnityEngine;
/// <summary>
/// OnControllerColliderHit
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnControllerColliderHit")]
public sealed class SimulateMonoBehaviour_OnControllerColliderHit : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -852449126; } }

	/// <summary>
    /// OnControllerColliderHit
    /// </summary>
    void OnControllerColliderHit(UnityEngine.ControllerColliderHit _hit)
    {
        simulateMonoBehaviour.OnControllerColliderHit(_hit);
    }
}