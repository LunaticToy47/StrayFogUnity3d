using UnityEngine;
/// <summary>
/// OnDrawGizmos
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnDrawGizmos")]
public sealed class SimulateMonoBehaviour_OnDrawGizmos : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -1551939301; } }

	/// <summary>
    /// OnDrawGizmos
    /// </summary>
    void OnDrawGizmos()
    {
        simulateMonoBehaviour.OnDrawGizmos();
    }
}