using UnityEngine;
/// <summary>
/// OnEnable
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnEnable")]
public sealed class SimulateUIBehaviour_OnEnable : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1108966551; } }

	/// <summary>
    /// OnEnable
    /// </summary>
    protected override void OnEnable()
    {
        simulateMonoBehaviour.OnEnable();
    }
}