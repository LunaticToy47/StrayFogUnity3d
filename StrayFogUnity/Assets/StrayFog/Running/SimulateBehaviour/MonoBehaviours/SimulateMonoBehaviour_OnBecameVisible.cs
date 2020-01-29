using UnityEngine;
/// <summary>
/// OnBecameVisible
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnBecameVisible")]
public sealed class SimulateMonoBehaviour_OnBecameVisible : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -238750800; } }

	/// <summary>
    /// OnBecameVisible
    /// </summary>
    void OnBecameVisible()
    {
        simulateMonoBehaviour.OnBecameVisible();
    }
}