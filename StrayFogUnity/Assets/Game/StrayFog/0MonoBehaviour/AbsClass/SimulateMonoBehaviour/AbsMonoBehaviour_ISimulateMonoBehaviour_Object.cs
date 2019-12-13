using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour【模拟MonoBehaviour】
/// </summary>
public abstract partial class AbsMonoBehaviour
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
    public SimulateMonoBehaviour_Coroutine coroutine { get; private set; }
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
            coroutine = gameObject.AddComponent<SimulateMonoBehaviour_Coroutine>();
            OnAfterBindGameObject();
            CollectCtrl<UIBehaviour>();
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
}
