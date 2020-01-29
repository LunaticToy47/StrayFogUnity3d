using UnityEngine;
/// <summary>
/// OnBeforeTransformParentChanged
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnBeforeTransformParentChanged")]
public sealed class SimulateMonoBehaviour_OnBeforeTransformParentChanged : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -798240424; } }

	/// <summary>
    /// OnBeforeTransformParentChanged
    /// </summary>
    void OnBeforeTransformParentChanged()
    {
        simulateMonoBehaviour.OnBeforeTransformParentChanged();
    }
}