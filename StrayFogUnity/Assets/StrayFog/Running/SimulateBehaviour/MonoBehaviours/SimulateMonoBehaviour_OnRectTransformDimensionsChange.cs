using UnityEngine;
/// <summary>
/// OnRectTransformDimensionsChange
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnRectTransformDimensionsChange")]
public sealed class SimulateMonoBehaviour_OnRectTransformDimensionsChange : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -663253104; } }

	/// <summary>
    /// OnRectTransformDimensionsChange
    /// </summary>
    void OnRectTransformDimensionsChange()
    {
        simulateMonoBehaviour.OnRectTransformDimensionsChange();
    }
}