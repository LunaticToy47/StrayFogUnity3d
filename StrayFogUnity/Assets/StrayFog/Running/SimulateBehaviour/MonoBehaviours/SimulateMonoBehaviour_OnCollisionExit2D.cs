using UnityEngine;
/// <summary>
/// OnCollisionExit2D
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCollisionExit2D")]
public sealed class SimulateMonoBehaviour_OnCollisionExit2D : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1207636450; } }

	/// <summary>
    /// OnCollisionExit2D
    /// </summary>
    void OnCollisionExit2D(UnityEngine.Collision2D _collision)
    {
        simulateMonoBehaviour.OnCollisionExit2D(_collision);
    }
}