using UnityEngine;
/// <summary>
/// OnRectTransformDimensionsChange
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnRectTransformDimensionsChange")]
public sealed class SimulateUIBehaviour_OnRectTransformDimensionsChange : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -217345500; } }

	/// <summary>
    /// OnRectTransformDimensionsChange
    /// </summary>
    protected override void OnRectTransformDimensionsChange()
    {
        simulateMonoBehaviour.OnRectTransformDimensionsChange();
    }
}