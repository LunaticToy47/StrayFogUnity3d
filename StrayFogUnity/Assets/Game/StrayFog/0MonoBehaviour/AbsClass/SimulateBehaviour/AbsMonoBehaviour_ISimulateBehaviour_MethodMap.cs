using System;
using System.Collections.Generic;
/// <summary>
/// 【AbsMonoBehaviour】模拟Behaviour枚举与方法映射
/// </summary>
public abstract partial class AbsMonoBehaviour
{
    /// <summary>
    /// Key:enSimulateBehaviourMethod
    /// Value:Behaviour组件Type
    /// </summary>
    readonly Dictionary<int, Type> mSimulateBehaviourEnumForMethodMap = new Dictionary<int, Type>()
    {
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_Awake,typeof(SimulateMonoBehaviour_Awake)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_Start,typeof(SimulateMonoBehaviour_Start)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_Update,typeof(SimulateMonoBehaviour_Update)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_FixedUpdate,typeof(SimulateMonoBehaviour_FixedUpdate)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_LateUpdate,typeof(SimulateMonoBehaviour_LateUpdate)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnAnimatorIK,typeof(SimulateMonoBehaviour_OnAnimatorIK)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnAnimatorMove,typeof(SimulateMonoBehaviour_OnAnimatorMove)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnApplicationFocus,typeof(SimulateMonoBehaviour_OnApplicationFocus)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnApplicationQuit,typeof(SimulateMonoBehaviour_OnApplicationQuit)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnApplicationPause,typeof(SimulateMonoBehaviour_OnApplicationPause)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnAudioFilterRead,typeof(SimulateMonoBehaviour_OnAudioFilterRead)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnBecameInvisible,typeof(SimulateMonoBehaviour_OnBecameInvisible)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnBecameVisible,typeof(SimulateMonoBehaviour_OnBecameVisible)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnBeforeTransformParentChanged,typeof(SimulateMonoBehaviour_OnBeforeTransformParentChanged)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCanvasGroupChanged,typeof(SimulateMonoBehaviour_OnCanvasGroupChanged)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCollisionEnter,typeof(SimulateMonoBehaviour_OnCollisionEnter)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCollisionEnter2D,typeof(SimulateMonoBehaviour_OnCollisionEnter2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCollisionExit,typeof(SimulateMonoBehaviour_OnCollisionExit)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCollisionExit2D,typeof(SimulateMonoBehaviour_OnCollisionExit2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCollisionStay,typeof(SimulateMonoBehaviour_OnCollisionStay)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnCollisionStay2D,typeof(SimulateMonoBehaviour_OnCollisionStay2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnConnectedToServer,typeof(SimulateMonoBehaviour_OnConnectedToServer)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnControllerColliderHit,typeof(SimulateMonoBehaviour_OnControllerColliderHit)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnDestroy,typeof(SimulateMonoBehaviour_OnDestroy)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnDisable,typeof(SimulateMonoBehaviour_OnDisable)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnDrawGizmos,typeof(SimulateMonoBehaviour_OnDrawGizmos)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnDrawGizmosSelected,typeof(SimulateMonoBehaviour_OnDrawGizmosSelected)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnEnable,typeof(SimulateMonoBehaviour_OnEnable)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnGUI,typeof(SimulateMonoBehaviour_OnGUI)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnJointBreak,typeof(SimulateMonoBehaviour_OnJointBreak)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnJointBreak2D,typeof(SimulateMonoBehaviour_OnJointBreak2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnLevelWasLoaded,typeof(SimulateMonoBehaviour_OnLevelWasLoaded)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseDown,typeof(SimulateMonoBehaviour_OnMouseDown)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseDrag,typeof(SimulateMonoBehaviour_OnMouseDrag)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseEnter,typeof(SimulateMonoBehaviour_OnMouseEnter)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseExit,typeof(SimulateMonoBehaviour_OnMouseExit)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseOver,typeof(SimulateMonoBehaviour_OnMouseOver)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseUp,typeof(SimulateMonoBehaviour_OnMouseUp)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnMouseUpAsButton,typeof(SimulateMonoBehaviour_OnMouseUpAsButton)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnParticleCollision,typeof(SimulateMonoBehaviour_OnParticleCollision)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnParticleTrigger,typeof(SimulateMonoBehaviour_OnParticleTrigger)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnPostRender,typeof(SimulateMonoBehaviour_OnPostRender)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnPreCull,typeof(SimulateMonoBehaviour_OnPreCull)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnPreRender,typeof(SimulateMonoBehaviour_OnPreRender)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnRectTransformDimensionsChange,typeof(SimulateMonoBehaviour_OnRectTransformDimensionsChange)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnRectTransformRemoved,typeof(SimulateMonoBehaviour_OnRectTransformRemoved)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnRenderImage,typeof(SimulateMonoBehaviour_OnRenderImage)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnRenderObject,typeof(SimulateMonoBehaviour_OnRenderObject)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnServerInitialized,typeof(SimulateMonoBehaviour_OnServerInitialized)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTransformChildrenChanged,typeof(SimulateMonoBehaviour_OnTransformChildrenChanged)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTransformParentChanged,typeof(SimulateMonoBehaviour_OnTransformParentChanged)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTriggerEnter,typeof(SimulateMonoBehaviour_OnTriggerEnter)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTriggerEnter2D,typeof(SimulateMonoBehaviour_OnTriggerEnter2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTriggerExit,typeof(SimulateMonoBehaviour_OnTriggerExit)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTriggerExit2D,typeof(SimulateMonoBehaviour_OnTriggerExit2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTriggerStay,typeof(SimulateMonoBehaviour_OnTriggerStay)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnTriggerStay2D,typeof(SimulateMonoBehaviour_OnTriggerStay2D)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnValidate,typeof(SimulateMonoBehaviour_OnValidate)},
	
        { (int)enSimulateBehaviourMethod.MonoBehaviour_OnWillRenderObject,typeof(SimulateMonoBehaviour_OnWillRenderObject)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_Awake,typeof(SimulateUIBehaviour_Awake)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnBeforeTransformParentChanged,typeof(SimulateUIBehaviour_OnBeforeTransformParentChanged)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnCanvasGroupChanged,typeof(SimulateUIBehaviour_OnCanvasGroupChanged)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnCanvasHierarchyChanged,typeof(SimulateUIBehaviour_OnCanvasHierarchyChanged)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnDestroy,typeof(SimulateUIBehaviour_OnDestroy)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnDidApplyAnimationProperties,typeof(SimulateUIBehaviour_OnDidApplyAnimationProperties)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnDisable,typeof(SimulateUIBehaviour_OnDisable)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnEnable,typeof(SimulateUIBehaviour_OnEnable)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnRectTransformDimensionsChange,typeof(SimulateUIBehaviour_OnRectTransformDimensionsChange)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnTransformParentChanged,typeof(SimulateUIBehaviour_OnTransformParentChanged)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_OnValidate,typeof(SimulateUIBehaviour_OnValidate)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_Reset,typeof(SimulateUIBehaviour_Reset)},
	
        { (int)enSimulateBehaviourMethod.UIBehaviour_Start,typeof(SimulateUIBehaviour_Start)},
	
    };
}
