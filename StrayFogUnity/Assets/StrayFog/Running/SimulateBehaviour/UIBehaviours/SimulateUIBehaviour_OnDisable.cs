using UnityEngine;
/// <summary>
/// OnDisable
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnDisable")]
public sealed class SimulateUIBehaviour_OnDisable : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -151319268; } }

	/// <summary>
    /// OnDisable
    /// </summary>
    protected override void OnDisable()
    {
        simulateMonoBehaviour.OnDisable();
    }
}