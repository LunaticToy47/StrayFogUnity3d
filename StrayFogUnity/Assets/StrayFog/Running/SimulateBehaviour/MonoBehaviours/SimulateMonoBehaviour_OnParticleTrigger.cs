using UnityEngine;
/// <summary>
/// OnParticleTrigger
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnParticleTrigger")]
public sealed class SimulateMonoBehaviour_OnParticleTrigger : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 401202895; } }

	/// <summary>
    /// OnParticleTrigger
    /// </summary>
    void OnParticleTrigger()
    {
        simulateMonoBehaviour.OnParticleTrigger();
    }
}