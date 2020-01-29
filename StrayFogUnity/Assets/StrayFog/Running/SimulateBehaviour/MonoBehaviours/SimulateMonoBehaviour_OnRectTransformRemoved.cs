using UnityEngine;
/// <summary>
/// OnRectTransformRemoved
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnRectTransformRemoved")]
public sealed class SimulateMonoBehaviour_OnRectTransformRemoved : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -1932656030; } }

	/// <summary>
    /// OnRectTransformRemoved
    /// </summary>
    void OnRectTransformRemoved()
    {
        simulateMonoBehaviour.OnRectTransformRemoved();
    }
}