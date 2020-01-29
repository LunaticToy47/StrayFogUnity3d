using UnityEngine;
/// <summary>
/// OnCanvasGroupChanged
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCanvasGroupChanged")]
public sealed class SimulateUIBehaviour_OnCanvasGroupChanged : AbsSimulateUIBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 386261764; } }

	/// <summary>
    /// OnCanvasGroupChanged
    /// </summary>
    protected override void OnCanvasGroupChanged()
    {
        simulateMonoBehaviour.OnCanvasGroupChanged();
    }
}