using UnityEngine;
/// <summary>
/// Awake
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_Awake")]
public sealed class SimulateUIBehaviour_Awake : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -2139564909; } }

	/// <summary>
    /// Awake
    /// </summary>
    protected override void Awake()
    {
        simulateMonoBehaviour.Awake();
    }
}