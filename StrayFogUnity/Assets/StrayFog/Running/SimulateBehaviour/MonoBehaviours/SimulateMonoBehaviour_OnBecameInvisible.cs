using UnityEngine;
/// <summary>
/// OnBecameInvisible
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnBecameInvisible")]
public sealed class SimulateMonoBehaviour_OnBecameInvisible : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 144818331; } }

	/// <summary>
    /// OnBecameInvisible
    /// </summary>
    void OnBecameInvisible()
    {
        simulateMonoBehaviour.OnBecameInvisible();
    }
}