using UnityEngine;
/// <summary>
/// MonoBehaviour模拟【对象】
/// </summary>
public partial interface ISimulateMonoBehaviour
{
    /// <summary>
    /// GameObject
    /// </summary>
    GameObject gameObject { get; }
    /// <summary>
    /// RectTransform
    /// </summary>
    RectTransform rectTransform { get; }
    /// <summary>
    /// 协程
    /// </summary>
    SimulateMonoBehaviour_Coroutine coroutine { get; }
    /// <summary>
    /// 是否绑定GameObject
    /// </summary>
    bool isBindGameObject { get; }
    /// <summary>
    /// 是否在Hierarchy中激活
    /// </summary>
    bool activeInHierarchy { get; }
    /// <summary>
    /// 绑定GameObject
    /// </summary>
    /// <param name="_go">GameObject</param>
    void BindGameObject(GameObject _go);
}

