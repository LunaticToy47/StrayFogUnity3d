using UnityEngine;
/// <summary>
/// Reset
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_Reset")]
public sealed class SimulateUIBehaviour_Reset : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -635453696; } }

	/// <summary>
    /// Reset
    /// </summary>
    protected override void Reset()
    {
        simulateMonoBehaviour.Reset();
    }
}