using UnityEngine;
/// <summary>
/// OnServerInitialized
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnServerInitialized")]
public sealed class SimulateMonoBehaviour_OnServerInitialized : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -2070994414; } }

	/// <summary>
    /// OnServerInitialized
    /// </summary>
    void OnServerInitialized()
    {
        simulateMonoBehaviour.OnServerInitialized();
    }
}