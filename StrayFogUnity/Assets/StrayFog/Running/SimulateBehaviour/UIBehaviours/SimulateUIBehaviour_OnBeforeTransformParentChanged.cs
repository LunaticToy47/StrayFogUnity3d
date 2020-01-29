using UnityEngine;
/// <summary>
/// OnBeforeTransformParentChanged
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnBeforeTransformParentChanged")]
public sealed class SimulateUIBehaviour_OnBeforeTransformParentChanged : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -1011944863; } }

	/// <summary>
    /// OnBeforeTransformParentChanged
    /// </summary>
    protected override void OnBeforeTransformParentChanged()
    {
        simulateMonoBehaviour.OnBeforeTransformParentChanged();
    }
}