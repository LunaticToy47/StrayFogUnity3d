using UnityEngine;
/// <summary>
/// OnTriggerEnter2D
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnTriggerEnter2D")]
public sealed class SimulateMonoBehaviour_OnTriggerEnter2D : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 158098300; } }

	/// <summary>
    /// OnTriggerEnter2D
    /// </summary>
    void OnTriggerEnter2D(UnityEngine.Collider2D _collision)
    {
        simulateMonoBehaviour.OnTriggerEnter2D(_collision);
    }
}