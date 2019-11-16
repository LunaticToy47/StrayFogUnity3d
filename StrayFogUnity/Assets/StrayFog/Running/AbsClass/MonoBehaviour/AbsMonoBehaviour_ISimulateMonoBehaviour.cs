using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour【模拟MonoBehaviour】
/// </summary>
public abstract partial class AbsMonoBehaviour : ISimulateMonoBehaviour
{
    #region gameObject
    /// <summary>
    /// GameObject
    /// </summary>
    public GameObject gameObject { get; private set; }
    #endregion

    #region rectTransform
    /// <summary>
    /// RectTransform
    /// </summary>
    public RectTransform rectTransform { get; private set; }
    #endregion

    #region isBindGameObject
    /// <summary>
    /// 是否绑定GameObject
    /// </summary>
    public bool isBindGameObject { get { return gameObject != null; } }
    #endregion

    #region activeInHierarchy
    /// <summary>
    /// 是否在Hierarchy中激活
    /// </summary>
    public bool activeInHierarchy { get { return gameObject != null && gameObject.activeInHierarchy; } }
    #endregion

    #region coroutine
    /// <summary>
    /// 协程
    /// </summary>
    public StrayFogCoroutine coroutine { get; private set; }
    #endregion

    #region BindGameObject
    /// <summary>
    /// 绑定GameObject
    /// </summary>
    /// <param name="_go">GameObject</param>
    public void BindGameObject(GameObject _go)
    {        
        if (_go != null)
        {
            gameObject = _go;
            if (gameObject.transform is RectTransform)
            {
                rectTransform = (RectTransform)gameObject.transform;
            }
            coroutine = gameObject.AddComponent<StrayFogCoroutine>();
            OnAfterBindGameObject();
        }
        else
        {
            Debug.LogErrorFormat("【{0}】 BindGameObject is null.", GetType().FullName);
        }
    }
    /// <summary>
    /// 绑定GameObject之后
    /// </summary>
    protected virtual void OnAfterBindGameObject() { }
    #endregion

    #region Awake
    /// <summary>
    /// Awake
    /// </summary>
    public void Awake()
    {
        CollectCtrl<UIBehaviour>();
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
