using UnityEngine;
/// <summary>
/// OnParticleCollision
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnParticleCollision")]
public sealed class SimulateMonoBehaviour_OnParticleCollision : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return -680716310; } }

	/// <summary>
    /// OnParticleCollision
    /// </summary>
    void OnParticleCollision(UnityEngine.GameObject _other)
    {
        simulateMonoBehaviour.OnParticleCollision(_other);
    }
}