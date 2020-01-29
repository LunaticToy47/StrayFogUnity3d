using UnityEngine;
/// <summary>
/// OnMouseEnter
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnMouseEnter")]
public sealed class SimulateMonoBehaviour_OnMouseEnter : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -524311380; } }

	/// <summary>
    /// OnMouseEnter
    /// </summary>
    void OnMouseEnter()
    {
        simulateMonoBehaviour.OnMouseEnter();
    }
}