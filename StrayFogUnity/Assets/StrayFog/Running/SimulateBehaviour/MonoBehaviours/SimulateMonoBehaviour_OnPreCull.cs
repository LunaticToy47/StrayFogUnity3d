using UnityEngine;
/// <summary>
/// OnPreCull
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnPreCull")]
public sealed class SimulateMonoBehaviour_OnPreCull : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1560628184; } }

	/// <summary>
    /// OnPreCull
    /// </summary>
    void OnPreCull()
    {
        simulateMonoBehaviour.OnPreCull();
    }
}