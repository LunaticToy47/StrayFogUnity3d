using UnityEngine;
/// <summary>
/// 模拟MonoBehaviour接口
/// </summary>
public interface ISimulateMonoBehaviour
{
    /// <summary>
    /// 绑定GameObject
    /// </summary>
    /// <param name="_go">GameObject</param>
    void BindGameObject(GameObject _go);
}
