using UnityEngine;
/// <summary>
/// ISimulateMonoBehaviour接口
/// </summary>
public interface ISimulateMonoBehaviour
{
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
    /// OnAnimatorIK
    /// </summary>
    void OnAnimatorIK(System.Int32 _layerIndex);

    /// <summary>
    /// OnAnimatorMove
    /// </summary>
    void OnAnimatorMove();

    /// <summary>
    /// OnApplicationFocus
    /// </summary>
    void OnApplicationFocus(System.Boolean _focus);

    /// <summary>
    /// OnApplicationQuit
    /// </summary>
    void OnApplicationQuit();

    /// <summary>
    /// OnApplicationPause
    /// </summary>
    void OnApplicationPause(System.Boolean _pause);

    /// <summary>
    /// OnAudioFilterRead
    /// </summary>
    void OnAudioFilterRead(System.Single[] _data,System.Int32 _channels);

    /// <summary>
    /// OnBecameInvisible
    /// </summary>
    void OnBecameInvisible();

    /// <summary>
    /// OnBecameVisible
    /// </summary>
    void OnBecameVisible();

    /// <summary>
    /// OnBeforeTransformParentChanged
    /// </summary>
    void OnBeforeTransformParentChanged();

    /// <summary>
    /// OnCanvasGroupChanged
    /// </summary>
    void OnCanvasGroupChanged();

    /// <summary>
    /// OnCollisionEnter
    /// </summary>
    void OnCollisionEnter(UnityEngine.Collision _collision);

    /// <summary>
    /// OnCollisionEnter2D
    /// </summary>
    void OnCollisionEnter2D(UnityEngine.Collision2D _collision);

    /// <summary>
    /// OnCollisionExit
    /// </summary>
    void OnCollisionExit(UnityEngine.Collision _collision);

    /// <summary>
    /// OnCollisionExit2D
    /// </summary>
    void OnCollisionExit2D(UnityEngine.Collision2D _collision);

    /// <summary>
    /// OnCollisionStay
    /// </summary>
    void OnCollisionStay(UnityEngine.Collision _collision);

    /// <summary>
    /// OnCollisionStay2D
    /// </summary>
    void OnCollisionStay2D(UnityEngine.Collision2D _collision);

    /// <summary>
    /// OnConnectedToServer
    /// </summary>
    void OnConnectedToServer();

    /// <summary>
    /// OnControllerColliderHit
    /// </summary>
    void OnControllerColliderHit(UnityEngine.ControllerColliderHit _hit);

    /// <summary>
    /// OnDestroy
    /// </summary>
    void OnDestroy();

    /// <summary>
    /// OnDisable
    /// </summary>
    void OnDisable();

    /// <summary>
    /// OnDrawGizmos
    /// </summary>
    void OnDrawGizmos();

    /// <summary>
    /// OnDrawGizmosSelected
    /// </summary>
    void OnDrawGizmosSelected();

    /// <summary>
    /// OnEnable
    /// </summary>
    void OnEnable();

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI();

    /// <summary>
    /// OnJointBreak
    /// </summary>
    void OnJointBreak(System.Single _breakForce);

    /// <summary>
    /// OnJointBreak2D
    /// </summary>
    void OnJointBreak2D(UnityEngine.Joint2D _joint);

    /// <summary>
    /// OnLevelWasLoaded
    /// </summary>
    void OnLevelWasLoaded(System.Int32 _level);

    /// <summary>
    /// OnMouseDown
    /// </summary>
    void OnMouseDown();

    /// <summary>
    /// OnMouseDrag
    /// </summary>
    void OnMouseDrag();

    /// <summary>
    /// OnMouseEnter
    /// </summary>
    void OnMouseEnter();

    /// <summary>
    /// OnMouseExit
    /// </summary>
    void OnMouseExit();

    /// <summary>
    /// OnMouseOver
    /// </summary>
    void OnMouseOver();

    /// <summary>
    /// OnMouseUp
    /// </summary>
    void OnMouseUp();

    /// <summary>
    /// OnMouseUpAsButton
    /// </summary>
    void OnMouseUpAsButton();

    /// <summary>
    /// OnParticleCollision
    /// </summary>
    void OnParticleCollision(UnityEngine.GameObject _other);

    /// <summary>
    /// OnParticleTrigger
    /// </summary>
    void OnParticleTrigger();

    /// <summary>
    /// OnPostRender
    /// </summary>
    void OnPostRender();

    /// <summary>
    /// OnPreCull
    /// </summary>
    void OnPreCull();

    /// <summary>
    /// OnPreRender
    /// </summary>
    void OnPreRender();

    /// <summary>
    /// OnRectTransformDimensionsChange
    /// </summary>
    void OnRectTransformDimensionsChange();

    /// <summary>
    /// OnRectTransformRemoved
    /// </summary>
    void OnRectTransformRemoved();

    /// <summary>
    /// OnRenderImage
    /// </summary>
    void OnRenderImage(UnityEngine.RenderTexture _source,UnityEngine.RenderTexture _destination);

    /// <summary>
    /// OnRenderObject
    /// </summary>
    void OnRenderObject();

    /// <summary>
    /// OnServerInitialized
    /// </summary>
    void OnServerInitialized();

    /// <summary>
    /// OnTransformChildrenChanged
    /// </summary>
    void OnTransformChildrenChanged();

    /// <summary>
    /// OnTransformParentChanged
    /// </summary>
    void OnTransformParentChanged();

    /// <summary>
    /// OnTriggerEnter
    /// </summary>
    void OnTriggerEnter(UnityEngine.Collider _other);

    /// <summary>
    /// OnTriggerEnter2D
    /// </summary>
    void OnTriggerEnter2D(UnityEngine.Collider2D _collision);

    /// <summary>
    /// OnTriggerExit
    /// </summary>
    void OnTriggerExit(UnityEngine.Collider _other);

    /// <summary>
    /// OnTriggerExit2D
    /// </summary>
    void OnTriggerExit2D(UnityEngine.Collider2D _collision);

    /// <summary>
    /// OnTriggerStay
    /// </summary>
    void OnTriggerStay(UnityEngine.Collider _other);

    /// <summary>
    /// OnTriggerStay2D
    /// </summary>
    void OnTriggerStay2D(UnityEngine.Collider2D _collision);

    /// <summary>
    /// OnValidate
    /// </summary>
    void OnValidate();

    /// <summary>
    /// OnWillRenderObject
    /// </summary>
    void OnWillRenderObject();

    /// <summary>
    /// OnCanvasHierarchyChanged
    /// </summary>
    void OnCanvasHierarchyChanged();

    /// <summary>
    /// OnDidApplyAnimationProperties
    /// </summary>
    void OnDidApplyAnimationProperties();

}