using System.Collections;
using UnityEngine;
/// <summary>
/// MonoBehaviour生命周期
/// </summary>
public interface IMonoBehaviourLifeCycle
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
    void Awake();
    /// <summary>
    /// Start
    /// </summary>
    void Start();
    /// <summary>
    /// Update
    /// </summary>
    void Update();
    /// <summary>
    /// FixedUpdate
    /// </summary>
    void FixedUpdate();
    /// <summary>
    /// LateUpdate
    /// </summary>
    void LateUpdate();
    /// <summary>
    /// Destroy
    /// </summary>
    void Destroy();
    /// <summary>
    /// DrawGUI
    /// </summary>
    void DrawGUI();
}

