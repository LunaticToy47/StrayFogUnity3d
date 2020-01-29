/// <summary>
/// 模拟Behaviour方法接口
/// </summary>
public interface ISimulateBehaviourMethod
{
    /// <summary>
    /// 方法分类
    /// </summary>
    int methodClassify { get; }
    /// <summary>
    /// 模拟MonoBehaviour对象
    /// </summary>
    ISimulateMonoBehaviour simulateMonoBehaviour { get; }
    /// <summary>
    /// 绑定ISimulateMonoBehaviour
    /// </summary>
    /// <param name="_smb">ISimulateMonoBehaviour对象</param>
    void BindSimulateMonoBehaviour(ISimulateMonoBehaviour _smb);
}
