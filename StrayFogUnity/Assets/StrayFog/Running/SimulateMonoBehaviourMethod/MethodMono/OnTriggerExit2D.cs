using UnityEngine;
/// <summary>
/// OnTriggerExit2D
/// </summary>
public sealed class SimulateMonoBehaviourMethod_OnTriggerExit2D : AbsSimulateMonoBehaviourMethod
{
	/// <summary>
    /// 方法分类
    /// </summary>
    public override enSimulateMonoBehaviourMethod methodClassify { get { return enSimulateMonoBehaviourMethod.OnTriggerExit2D; } }

	/// <summary>
    /// OnTriggerExit2D
    /// </summary>
    void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        
    }
}