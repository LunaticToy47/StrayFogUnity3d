using UnityEngine;
/// <summary>
/// OnDestroy
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnDestroy")]
public sealed class SimulateMonoBehaviour_OnDestroy : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1212310744; } }

	/// <summary>
    /// OnDestroy
    /// </summary>
    void OnDestroy()
    {
        simulateMonoBehaviour.OnDestroy();
    }
}