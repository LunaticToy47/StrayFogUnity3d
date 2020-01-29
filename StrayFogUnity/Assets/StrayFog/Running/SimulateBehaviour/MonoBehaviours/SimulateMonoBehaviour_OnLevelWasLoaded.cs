using UnityEngine;
/// <summary>
/// OnLevelWasLoaded
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnLevelWasLoaded")]
public sealed class SimulateMonoBehaviour_OnLevelWasLoaded : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 116866233; } }

	/// <summary>
    /// OnLevelWasLoaded
    /// </summary>
    void OnLevelWasLoaded(System.Int32 _level)
    {
        simulateMonoBehaviour.OnLevelWasLoaded(_level);
    }
}