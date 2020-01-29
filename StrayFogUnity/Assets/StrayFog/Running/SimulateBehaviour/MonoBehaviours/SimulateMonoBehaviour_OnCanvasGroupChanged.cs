using UnityEngine;
/// <summary>
/// OnCanvasGroupChanged
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnCanvasGroupChanged")]
public sealed class SimulateMonoBehaviour_OnCanvasGroupChanged : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1964185384; } }

	/// <summary>
    /// OnCanvasGroupChanged
    /// </summary>
    void OnCanvasGroupChanged()
    {
        simulateMonoBehaviour.OnCanvasGroupChanged();
    }
}