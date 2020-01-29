using UnityEngine;
/// <summary>
/// OnCanvasHierarchyChanged
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCanvasHierarchyChanged")]
public sealed class SimulateUIBehaviour_OnCanvasHierarchyChanged : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1014311360; } }

	/// <summary>
    /// OnCanvasHierarchyChanged
    /// </summary>
    protected override void OnCanvasHierarchyChanged()
    {
        simulateMonoBehaviour.OnCanvasHierarchyChanged();
    }
}