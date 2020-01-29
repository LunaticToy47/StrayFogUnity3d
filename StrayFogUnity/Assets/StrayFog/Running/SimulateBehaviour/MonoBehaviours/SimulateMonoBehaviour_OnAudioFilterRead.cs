using UnityEngine;
/// <summary>
/// OnAudioFilterRead
/// </summary>
[AddComponentMenu("StrayFog/Game/SimulateMonoBehaviour/SimulateMonoBehaviour_OnAudioFilterRead")]
public sealed class SimulateMonoBehaviour_OnAudioFilterRead : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override int methodClassify { get { return 1898342584; } }

	/// <summary>
    /// OnAudioFilterRead
    /// </summary>
    void OnAudioFilterRead(System.Single[] _data,System.Int32 _channels)
    {
        simulateMonoBehaviour.OnAudioFilterRead(_data,_channels);
    }
}