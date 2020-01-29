using UnityEngine;
/// <summary>
/// Update
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_Update")]
public sealed class SimulateMonoBehaviour_Update : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1349629597; } }

	/// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        simulateMonoBehaviour.Update();
    }
}