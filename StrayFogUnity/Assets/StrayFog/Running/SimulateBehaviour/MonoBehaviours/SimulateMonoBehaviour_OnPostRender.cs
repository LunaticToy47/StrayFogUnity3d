using UnityEngine;
/// <summary>
/// OnPostRender
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnPostRender")]
public sealed class SimulateMonoBehaviour_OnPostRender : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1973065654; } }

	/// <summary>
    /// OnPostRender
    /// </summary>
    void OnPostRender()
    {
        simulateMonoBehaviour.OnPostRender();
    }
}