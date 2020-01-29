using UnityEngine;
/// <summary>
/// OnDisable
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnDisable")]
public sealed class SimulateMonoBehaviour_OnDisable : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -1423022320; } }

	/// <summary>
    /// OnDisable
    /// </summary>
    void OnDisable()
    {
        simulateMonoBehaviour.OnDisable();
    }
}