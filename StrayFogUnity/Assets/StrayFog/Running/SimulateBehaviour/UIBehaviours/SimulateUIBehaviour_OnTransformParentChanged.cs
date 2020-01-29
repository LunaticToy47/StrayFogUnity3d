using UnityEngine;
/// <summary>
/// OnTransformParentChanged
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnTransformParentChanged")]
public sealed class SimulateUIBehaviour_OnTransformParentChanged : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1700757761; } }

	/// <summary>
    /// OnTransformParentChanged
    /// </summary>
    protected override void OnTransformParentChanged()
    {
        simulateMonoBehaviour.OnTransformParentChanged();
    }
}