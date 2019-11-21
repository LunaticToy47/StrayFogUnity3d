using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour【模拟MonoBehaviour】
/// </summary>
public abstract partial class AbsMonoBehaviour : ISimulateMonoBehaviour
{
    #region Awake
    /// <summary>
    /// Awake
    /// </summary>
    public void Awake()
    {        
        OnAwake();
        OnAfterAwake();
    }

    /// <summary>
    /// OnAwake
    /// </summary>
    protected virtual void OnAwake() { }

    /// <summary>
    /// OnAfterAwake
    /// </summary>
    protected virtual void OnAfterAwake() { }
    #endregion

    #region Start
    /// <summary>
    /// Start
    /// </summary>
    public void Start()
    {
        OnStart();
    }
    /// <summary>
    /// OnStart
    /// </summary>
    protected virtual void OnStart() { }
    #endregion

    #region Update
    /// <summary>
    /// Update
    /// </summary>
    public void Update()
    {
        OnUpdate();
    }
    /// <summary>
    /// OnUpdate
    /// </summary>
    protected virtual void OnUpdate() { }
    #endregion

    #region FixedUpdate
    /// <summary>
    /// FixedUpdate
    /// </summary>
    public void FixedUpdate()
    {
        OnFixedUpdate();
    }
    /// <summary>
    /// OnFixedUpdate
    /// </summary>
    protected virtual void OnFixedUpdate() { }
    #endregion

    #region LateUpdate
    /// <summary>
    /// LateUpdate
    /// </summary>
    public void LateUpdate()
    {
        OnLateUpdate();
    }
    /// <summary>
    /// OnLateUpdate
    /// </summary>
    protected virtual void OnLateUpdate() { }
    #endregion

    #region Disable
    /// <summary>
    /// Disable
    /// </summary>
    public void Disable()
    {
        OnDisable();
    }
    /// <summary>
    /// OnDisable
    /// </summary>
    protected virtual void OnDisable() { }
    #endregion

    #region Enable
    /// <summary>
    /// Enable
    /// </summary>
    public void Enable()
    {
        OnEnable();
    }
    /// <summary>
    /// OnEnable
    /// </summary>
    protected virtual void OnEnable() { }
    #endregion

    #region Destroy
    /// <summary>
    /// Destroy
    /// </summary>
    public void Destroy()
    {
        OnDestroy();
    }
    /// <summary>
    /// OnDestroy
    /// </summary>
    protected virtual void OnDestroy() { }
    #endregion

    #region GUI
    /// <summary>
    /// GUI
    /// </summary>
    public void GUI() {
        OnGUI();
    }
    /// <summary>
    /// OnGUI
    /// </summary>
    protected virtual void OnGUI() { }
    #endregion
}
