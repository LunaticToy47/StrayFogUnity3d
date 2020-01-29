using UnityEngine;
/// <summary>
/// OnEnable
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnEnable")]
public sealed class SimulateMonoBehaviour_OnEnable : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1051452101; } }

	/// <summary>
    /// OnEnable
    /// </summary>
    void OnEnable()
    {
        simulateMonoBehaviour.OnEnable();
    }
}