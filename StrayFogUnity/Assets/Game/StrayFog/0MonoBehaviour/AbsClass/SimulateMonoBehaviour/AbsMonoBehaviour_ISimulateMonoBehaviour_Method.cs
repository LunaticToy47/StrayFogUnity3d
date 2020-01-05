using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 抽象MonoBehaviour【模拟MonoBehaviour】
/// </summary>
public abstract partial class AbsMonoBehaviour
{

    #region Awake
    /// <summary>
    /// Awake
    /// </summary>
    public void Awake()
    {        
        OnRunAwake();
    }
    /// <summary>
    /// OnAwake
    /// </summary>
    protected virtual void OnRunAwake() { }
    #endregion

    #region Start
    /// <summary>
    /// Start
    /// </summary>
    public void Start()
    {        
        OnRunStart();
    }
    /// <summary>
    /// OnStart
    /// </summary>
    protected virtual void OnRunStart() { }
    #endregion

    #region Update
    /// <summary>
    /// Update
    /// </summary>
    public void Update()
    {        
        OnRunUpdate();
    }
    /// <summary>
    /// OnUpdate
    /// </summary>
    protected virtual void OnRunUpdate() { }
    #endregion

    #region FixedUpdate
    /// <summary>
    /// FixedUpdate
    /// </summary>
    public void FixedUpdate()
    {        
        OnRunFixedUpdate();
    }
    /// <summary>
    /// OnFixedUpdate
    /// </summary>
    protected virtual void OnRunFixedUpdate() { }
    #endregion

    #region LateUpdate
    /// <summary>
    /// LateUpdate
    /// </summary>
    public void LateUpdate()
    {        
        OnRunLateUpdate();
    }
    /// <summary>
    /// OnLateUpdate
    /// </summary>
    protected virtual void OnRunLateUpdate() { }
    #endregion

    #region OnAnimatorIK
    /// <summary>
    /// OnAnimatorIK
    /// </summary>
    public void OnAnimatorIK(System.Int32 _layerIndex)
    {        
        OnRunAnimatorIK(_layerIndex);
    }
    /// <summary>
    /// OnOnAnimatorIK
    /// </summary>
    protected virtual void OnRunAnimatorIK(System.Int32 _layerIndex) { }
    #endregion

    #region OnAnimatorMove
    /// <summary>
    /// OnAnimatorMove
    /// </summary>
    public void OnAnimatorMove()
    {        
        OnRunAnimatorMove();
    }
    /// <summary>
    /// OnOnAnimatorMove
    /// </summary>
    protected virtual void OnRunAnimatorMove() { }
    #endregion

    #region OnApplicationFocus
    /// <summary>
    /// OnApplicationFocus
    /// </summary>
    public void OnApplicationFocus(System.Boolean _focus)
    {        
        OnRunApplicationFocus(_focus);
    }
    /// <summary>
    /// OnOnApplicationFocus
    /// </summary>
    protected virtual void OnRunApplicationFocus(System.Boolean _focus) { }
    #endregion

    #region OnApplicationQuit
    /// <summary>
    /// OnApplicationQuit
    /// </summary>
    public void OnApplicationQuit()
    {        
        OnRunApplicationQuit();
    }
    /// <summary>
    /// OnOnApplicationQuit
    /// </summary>
    protected virtual void OnRunApplicationQuit() { }
    #endregion

    #region OnApplicationPause
    /// <summary>
    /// OnApplicationPause
    /// </summary>
    public void OnApplicationPause(System.Boolean _pause)
    {        
        OnRunApplicationPause(_pause);
    }
    /// <summary>
    /// OnOnApplicationPause
    /// </summary>
    protected virtual void OnRunApplicationPause(System.Boolean _pause) { }
    #endregion

    #region OnAudioFilterRead
    /// <summary>
    /// OnAudioFilterRead
    /// </summary>
    public void OnAudioFilterRead(System.Single[] _data,System.Int32 _channels)
    {        
        OnRunAudioFilterRead(_data,_channels);
    }
    /// <summary>
    /// OnOnAudioFilterRead
    /// </summary>
    protected virtual void OnRunAudioFilterRead(System.Single[] _data,System.Int32 _channels) { }
    #endregion

    #region OnBecameInvisible
    /// <summary>
    /// OnBecameInvisible
    /// </summary>
    public void OnBecameInvisible()
    {        
        OnRunBecameInvisible();
    }
    /// <summary>
    /// OnOnBecameInvisible
    /// </summary>
    protected virtual void OnRunBecameInvisible() { }
    #endregion

    #region OnBecameVisible
    /// <summary>
    /// OnBecameVisible
    /// </summary>
    public void OnBecameVisible()
    {        
        OnRunBecameVisible();
    }
    /// <summary>
    /// OnOnBecameVisible
    /// </summary>
    protected virtual void OnRunBecameVisible() { }
    #endregion

    #region OnBeforeTransformParentChanged
    /// <summary>
    /// OnBeforeTransformParentChanged
    /// </summary>
    public void OnBeforeTransformParentChanged()
    {        
        OnRunBeforeTransformParentChanged();
    }
    /// <summary>
    /// OnOnBeforeTransformParentChanged
    /// </summary>
    protected virtual void OnRunBeforeTransformParentChanged() { }
    #endregion

    #region OnCanvasGroupChanged
    /// <summary>
    /// OnCanvasGroupChanged
    /// </summary>
    public void OnCanvasGroupChanged()
    {        
        OnRunCanvasGroupChanged();
    }
    /// <summary>
    /// OnOnCanvasGroupChanged
    /// </summary>
    protected virtual void OnRunCanvasGroupChanged() { }
    #endregion

    #region OnCollisionEnter
    /// <summary>
    /// OnCollisionEnter
    /// </summary>
    public void OnCollisionEnter(UnityEngine.Collision _collision)
    {        
        OnRunCollisionEnter(_collision);
    }
    /// <summary>
    /// OnOnCollisionEnter
    /// </summary>
    protected virtual void OnRunCollisionEnter(UnityEngine.Collision _collision) { }
    #endregion

    #region OnCollisionEnter2D
    /// <summary>
    /// OnCollisionEnter2D
    /// </summary>
    public void OnCollisionEnter2D(UnityEngine.Collision2D _collision)
    {        
        OnRunCollisionEnter2D(_collision);
    }
    /// <summary>
    /// OnOnCollisionEnter2D
    /// </summary>
    protected virtual void OnRunCollisionEnter2D(UnityEngine.Collision2D _collision) { }
    #endregion

    #region OnCollisionExit
    /// <summary>
    /// OnCollisionExit
    /// </summary>
    public void OnCollisionExit(UnityEngine.Collision _collision)
    {        
        OnRunCollisionExit(_collision);
    }
    /// <summary>
    /// OnOnCollisionExit
    /// </summary>
    protected virtual void OnRunCollisionExit(UnityEngine.Collision _collision) { }
    #endregion

    #region OnCollisionExit2D
    /// <summary>
    /// OnCollisionExit2D
    /// </summary>
    public void OnCollisionExit2D(UnityEngine.Collision2D _collision)
    {        
        OnRunCollisionExit2D(_collision);
    }
    /// <summary>
    /// OnOnCollisionExit2D
    /// </summary>
    protected virtual void OnRunCollisionExit2D(UnityEngine.Collision2D _collision) { }
    #endregion

    #region OnCollisionStay
    /// <summary>
    /// OnCollisionStay
    /// </summary>
    public void OnCollisionStay(UnityEngine.Collision _collision)
    {        
        OnRunCollisionStay(_collision);
    }
    /// <summary>
    /// OnOnCollisionStay
    /// </summary>
    protected virtual void OnRunCollisionStay(UnityEngine.Collision _collision) { }
    #endregion

    #region OnCollisionStay2D
    /// <summary>
    /// OnCollisionStay2D
    /// </summary>
    public void OnCollisionStay2D(UnityEngine.Collision2D _collision)
    {        
        OnRunCollisionStay2D(_collision);
    }
    /// <summary>
    /// OnOnCollisionStay2D
    /// </summary>
    protected virtual void OnRunCollisionStay2D(UnityEngine.Collision2D _collision) { }
    #endregion

    #region OnConnectedToServer
    /// <summary>
    /// OnConnectedToServer
    /// </summary>
    public void OnConnectedToServer()
    {        
        OnRunConnectedToServer();
    }
    /// <summary>
    /// OnOnConnectedToServer
    /// </summary>
    protected virtual void OnRunConnectedToServer() { }
    #endregion

    #region OnControllerColliderHit
    /// <summary>
    /// OnControllerColliderHit
    /// </summary>
    public void OnControllerColliderHit(UnityEngine.ControllerColliderHit _hit)
    {        
        OnRunControllerColliderHit(_hit);
    }
    /// <summary>
    /// OnOnControllerColliderHit
    /// </summary>
    protected virtual void OnRunControllerColliderHit(UnityEngine.ControllerColliderHit _hit) { }
    #endregion

    #region OnDestroy
    /// <summary>
    /// OnDestroy
    /// </summary>
    public void OnDestroy()
    {        
        OnRunDestroy();
    }
    /// <summary>
    /// OnOnDestroy
    /// </summary>
    protected virtual void OnRunDestroy() { }
    #endregion

    #region OnDisable
    /// <summary>
    /// OnDisable
    /// </summary>
    public void OnDisable()
    {        
        OnRunDisable();
    }
    /// <summary>
    /// OnOnDisable
    /// </summary>
    protected virtual void OnRunDisable() { }
    #endregion

    #region OnDrawGizmos
    /// <summary>
    /// OnDrawGizmos
    /// </summary>
    public void OnDrawGizmos()
    {        
        OnRunDrawGizmos();
    }
    /// <summary>
    /// OnOnDrawGizmos
    /// </summary>
    protected virtual void OnRunDrawGizmos() { }
    #endregion

    #region OnDrawGizmosSelected
    /// <summary>
    /// OnDrawGizmosSelected
    /// </summary>
    public void OnDrawGizmosSelected()
    {        
        OnRunDrawGizmosSelected();
    }
    /// <summary>
    /// OnOnDrawGizmosSelected
    /// </summary>
    protected virtual void OnRunDrawGizmosSelected() { }
    #endregion

    #region OnEnable
    /// <summary>
    /// OnEnable
    /// </summary>
    public void OnEnable()
    {        
        OnRunEnable();
    }
    /// <summary>
    /// OnOnEnable
    /// </summary>
    protected virtual void OnRunEnable() { }
    #endregion

    #region OnGUI
    /// <summary>
    /// OnGUI
    /// </summary>
    public void OnGUI()
    {        
        OnRunGUI();
    }
    /// <summary>
    /// OnOnGUI
    /// </summary>
    protected virtual void OnRunGUI() { }
    #endregion

    #region OnJointBreak
    /// <summary>
    /// OnJointBreak
    /// </summary>
    public void OnJointBreak(System.Single _breakForce)
    {        
        OnRunJointBreak(_breakForce);
    }
    /// <summary>
    /// OnOnJointBreak
    /// </summary>
    protected virtual void OnRunJointBreak(System.Single _breakForce) { }
    #endregion

    #region OnJointBreak2D
    /// <summary>
    /// OnJointBreak2D
    /// </summary>
    public void OnJointBreak2D(UnityEngine.Joint2D _joint)
    {        
        OnRunJointBreak2D(_joint);
    }
    /// <summary>
    /// OnOnJointBreak2D
    /// </summary>
    protected virtual void OnRunJointBreak2D(UnityEngine.Joint2D _joint) { }
    #endregion

    #region OnLevelWasLoaded
    /// <summary>
    /// OnLevelWasLoaded
    /// </summary>
    public void OnLevelWasLoaded(System.Int32 _level)
    {        
        OnRunLevelWasLoaded(_level);
    }
    /// <summary>
    /// OnOnLevelWasLoaded
    /// </summary>
    protected virtual void OnRunLevelWasLoaded(System.Int32 _level) { }
    #endregion

    #region OnMouseDown
    /// <summary>
    /// OnMouseDown
    /// </summary>
    public void OnMouseDown()
    {        
        OnRunMouseDown();
    }
    /// <summary>
    /// OnOnMouseDown
    /// </summary>
    protected virtual void OnRunMouseDown() { }
    #endregion

    #region OnMouseDrag
    /// <summary>
    /// OnMouseDrag
    /// </summary>
    public void OnMouseDrag()
    {        
        OnRunMouseDrag();
    }
    /// <summary>
    /// OnOnMouseDrag
    /// </summary>
    protected virtual void OnRunMouseDrag() { }
    #endregion

    #region OnMouseEnter
    /// <summary>
    /// OnMouseEnter
    /// </summary>
    public void OnMouseEnter()
    {        
        OnRunMouseEnter();
    }
    /// <summary>
    /// OnOnMouseEnter
    /// </summary>
    protected virtual void OnRunMouseEnter() { }
    #endregion

    #region OnMouseExit
    /// <summary>
    /// OnMouseExit
    /// </summary>
    public void OnMouseExit()
    {        
        OnRunMouseExit();
    }
    /// <summary>
    /// OnOnMouseExit
    /// </summary>
    protected virtual void OnRunMouseExit() { }
    #endregion

    #region OnMouseOver
    /// <summary>
    /// OnMouseOver
    /// </summary>
    public void OnMouseOver()
    {        
        OnRunMouseOver();
    }
    /// <summary>
    /// OnOnMouseOver
    /// </summary>
    protected virtual void OnRunMouseOver() { }
    #endregion

    #region OnMouseUp
    /// <summary>
    /// OnMouseUp
    /// </summary>
    public void OnMouseUp()
    {        
        OnRunMouseUp();
    }
    /// <summary>
    /// OnOnMouseUp
    /// </summary>
    protected virtual void OnRunMouseUp() { }
    #endregion

    #region OnMouseUpAsButton
    /// <summary>
    /// OnMouseUpAsButton
    /// </summary>
    public void OnMouseUpAsButton()
    {        
        OnRunMouseUpAsButton();
    }
    /// <summary>
    /// OnOnMouseUpAsButton
    /// </summary>
    protected virtual void OnRunMouseUpAsButton() { }
    #endregion

    #region OnParticleCollision
    /// <summary>
    /// OnParticleCollision
    /// </summary>
    public void OnParticleCollision(UnityEngine.GameObject _other)
    {        
        OnRunParticleCollision(_other);
    }
    /// <summary>
    /// OnOnParticleCollision
    /// </summary>
    protected virtual void OnRunParticleCollision(UnityEngine.GameObject _other) { }
    #endregion

    #region OnParticleTrigger
    /// <summary>
    /// OnParticleTrigger
    /// </summary>
    public void OnParticleTrigger()
    {        
        OnRunParticleTrigger();
    }
    /// <summary>
    /// OnOnParticleTrigger
    /// </summary>
    protected virtual void OnRunParticleTrigger() { }
    #endregion

    #region OnPostRender
    /// <summary>
    /// OnPostRender
    /// </summary>
    public void OnPostRender()
    {        
        OnRunPostRender();
    }
    /// <summary>
    /// OnOnPostRender
    /// </summary>
    protected virtual void OnRunPostRender() { }
    #endregion

    #region OnPreCull
    /// <summary>
    /// OnPreCull
    /// </summary>
    public void OnPreCull()
    {        
        OnRunPreCull();
    }
    /// <summary>
    /// OnOnPreCull
    /// </summary>
    protected virtual void OnRunPreCull() { }
    #endregion

    #region OnPreRender
    /// <summary>
    /// OnPreRender
    /// </summary>
    public void OnPreRender()
    {        
        OnRunPreRender();
    }
    /// <summary>
    /// OnOnPreRender
    /// </summary>
    protected virtual void OnRunPreRender() { }
    #endregion

    #region OnRectTransformDimensionsChange
    /// <summary>
    /// OnRectTransformDimensionsChange
    /// </summary>
    public void OnRectTransformDimensionsChange()
    {        
        OnRunRectTransformDimensionsChange();
    }
    /// <summary>
    /// OnOnRectTransformDimensionsChange
    /// </summary>
    protected virtual void OnRunRectTransformDimensionsChange() { }
    #endregion

    #region OnRectTransformRemoved
    /// <summary>
    /// OnRectTransformRemoved
    /// </summary>
    public void OnRectTransformRemoved()
    {        
        OnRunRectTransformRemoved();
    }
    /// <summary>
    /// OnOnRectTransformRemoved
    /// </summary>
    protected virtual void OnRunRectTransformRemoved() { }
    #endregion

    #region OnRenderImage
    /// <summary>
    /// OnRenderImage
    /// </summary>
    public void OnRenderImage(UnityEngine.RenderTexture _source,UnityEngine.RenderTexture _destination)
    {        
        OnRunRenderImage(_source,_destination);
    }
    /// <summary>
    /// OnOnRenderImage
    /// </summary>
    protected virtual void OnRunRenderImage(UnityEngine.RenderTexture _source,UnityEngine.RenderTexture _destination) { }
    #endregion

    #region OnRenderObject
    /// <summary>
    /// OnRenderObject
    /// </summary>
    public void OnRenderObject()
    {        
        OnRunRenderObject();
    }
    /// <summary>
    /// OnOnRenderObject
    /// </summary>
    protected virtual void OnRunRenderObject() { }
    #endregion

    #region OnServerInitialized
    /// <summary>
    /// OnServerInitialized
    /// </summary>
    public void OnServerInitialized()
    {        
        OnRunServerInitialized();
    }
    /// <summary>
    /// OnOnServerInitialized
    /// </summary>
    protected virtual void OnRunServerInitialized() { }
    #endregion

    #region OnTransformChildrenChanged
    /// <summary>
    /// OnTransformChildrenChanged
    /// </summary>
    public void OnTransformChildrenChanged()
    {        
        OnRunTransformChildrenChanged();
    }
    /// <summary>
    /// OnOnTransformChildrenChanged
    /// </summary>
    protected virtual void OnRunTransformChildrenChanged() { }
    #endregion

    #region OnTransformParentChanged
    /// <summary>
    /// OnTransformParentChanged
    /// </summary>
    public void OnTransformParentChanged()
    {        
        OnRunTransformParentChanged();
    }
    /// <summary>
    /// OnOnTransformParentChanged
    /// </summary>
    protected virtual void OnRunTransformParentChanged() { }
    #endregion

    #region OnTriggerEnter
    /// <summary>
    /// OnTriggerEnter
    /// </summary>
    public void OnTriggerEnter(UnityEngine.Collider _other)
    {        
        OnRunTriggerEnter(_other);
    }
    /// <summary>
    /// OnOnTriggerEnter
    /// </summary>
    protected virtual void OnRunTriggerEnter(UnityEngine.Collider _other) { }
    #endregion

    #region OnTriggerEnter2D
    /// <summary>
    /// OnTriggerEnter2D
    /// </summary>
    public void OnTriggerEnter2D(UnityEngine.Collider2D _collision)
    {        
        OnRunTriggerEnter2D(_collision);
    }
    /// <summary>
    /// OnOnTriggerEnter2D
    /// </summary>
    protected virtual void OnRunTriggerEnter2D(UnityEngine.Collider2D _collision) { }
    #endregion

    #region OnTriggerExit
    /// <summary>
    /// OnTriggerExit
    /// </summary>
    public void OnTriggerExit(UnityEngine.Collider _other)
    {        
        OnRunTriggerExit(_other);
    }
    /// <summary>
    /// OnOnTriggerExit
    /// </summary>
    protected virtual void OnRunTriggerExit(UnityEngine.Collider _other) { }
    #endregion

    #region OnTriggerExit2D
    /// <summary>
    /// OnTriggerExit2D
    /// </summary>
    public void OnTriggerExit2D(UnityEngine.Collider2D _collision)
    {        
        OnRunTriggerExit2D(_collision);
    }
    /// <summary>
    /// OnOnTriggerExit2D
    /// </summary>
    protected virtual void OnRunTriggerExit2D(UnityEngine.Collider2D _collision) { }
    #endregion

    #region OnTriggerStay
    /// <summary>
    /// OnTriggerStay
    /// </summary>
    public void OnTriggerStay(UnityEngine.Collider _other)
    {        
        OnRunTriggerStay(_other);
    }
    /// <summary>
    /// OnOnTriggerStay
    /// </summary>
    protected virtual void OnRunTriggerStay(UnityEngine.Collider _other) { }
    #endregion

    #region OnTriggerStay2D
    /// <summary>
    /// OnTriggerStay2D
    /// </summary>
    public void OnTriggerStay2D(UnityEngine.Collider2D _collision)
    {        
        OnRunTriggerStay2D(_collision);
    }
    /// <summary>
    /// OnOnTriggerStay2D
    /// </summary>
    protected virtual void OnRunTriggerStay2D(UnityEngine.Collider2D _collision) { }
    #endregion

    #region OnValidate
    /// <summary>
    /// OnValidate
    /// </summary>
    public void OnValidate()
    {        
        OnRunValidate();
    }
    /// <summary>
    /// OnOnValidate
    /// </summary>
    protected virtual void OnRunValidate() { }
    #endregion

    #region OnWillRenderObject
    /// <summary>
    /// OnWillRenderObject
    /// </summary>
    public void OnWillRenderObject()
    {        
        OnRunWillRenderObject();
    }
    /// <summary>
    /// OnOnWillRenderObject
    /// </summary>
    protected virtual void OnRunWillRenderObject() { }
    #endregion

}
