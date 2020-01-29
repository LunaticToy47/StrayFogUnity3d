using UnityEngine;
/// <summary>
/// OnMouseDrag
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnMouseDrag")]
public sealed class SimulateMonoBehaviour_OnMouseDrag : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -920000814; } }

	/// <summary>
    /// OnMouseDrag
    /// </summary>
    void OnMouseDrag()
    {
        simulateMonoBehaviour.OnMouseDrag();
    }
}