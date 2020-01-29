using UnityEngine;
/// <summary>
/// OnCollisionStay2D
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCollisionStay2D")]
public sealed class SimulateMonoBehaviour_OnCollisionStay2D : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -335812640; } }

	/// <summary>
    /// OnCollisionStay2D
    /// </summary>
    void OnCollisionStay2D(UnityEngine.Collision2D _collision)
    {
        simulateMonoBehaviour.OnCollisionStay2D(_collision);
    }
}