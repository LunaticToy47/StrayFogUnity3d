using UnityEngine;
/// <summary>
/// MonoBehaviour模拟
/// </summary>
public interface ISimulateMonoBehaviour
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
    StrayFogCoroutine coroutine { get; }
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
    /// <summary>
    /// Awake
    /// </summary>
    [SimulateMonoBehaviour("Awake")]
    void Awake();
    /// <summary>
    /// Start
    /// </summary>
    [SimulateMonoBehaviour("Start")]
    void Start();
    /// <summary>
    /// Update
    /// </summary>
    [SimulateMonoBehaviour("Update")]
    void Update();
    /// <summary>
    /// FixedUpdate
    /// </summary>
    [SimulateMonoBehaviour("FixedUpdate")]
    void FixedUpdate();
    /// <summary>
    /// LateUpdate
    /// </summary>
    [SimulateMonoBehaviour("LateUpdate")]
    void LateUpdate();
    /// <summary>
    /// Disable
    /// </summary>
    [SimulateMonoBehaviour("OnDisable")]
    void Disable();
    /// <summary>
    /// Enable
    /// </summary>
    [SimulateMonoBehaviour("OnEnable")]
    void Enable();
    /// <summary>
    /// Destroy
    /// </summary>
    [SimulateMonoBehaviour("OnDestroy")]
    void Destroy();
    /// <summary>
    /// GUI
    /// </summary>
    [SimulateMonoBehaviour("OnGUI")]
    void GUI();
}

