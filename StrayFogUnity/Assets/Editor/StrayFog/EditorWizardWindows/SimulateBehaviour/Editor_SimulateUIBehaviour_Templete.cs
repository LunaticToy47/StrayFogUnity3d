#if UNITY_EDITOR
using UnityEngine.EventSystems;
/// <summary>
/// 模拟UIBehaviour
/// </summary>
public class Editor_SimulateUIBehaviour_Templete : UIBehaviour
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override bool IsActive()
    {
        return base.IsActive();
    }

    protected override void OnBeforeTransformParentChanged()
    {
        base.OnBeforeTransformParentChanged();
    }

    protected override void OnCanvasGroupChanged()
    {
        base.OnCanvasGroupChanged();
    }

    protected override void OnCanvasHierarchyChanged()
    {
        base.OnCanvasHierarchyChanged();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnDidApplyAnimationProperties()
    {
        base.OnDidApplyAnimationProperties();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
    }

    protected override void OnTransformParentChanged()
    {
        base.OnTransformParentChanged();
    }

    //protected override void OnValidate()
    //{
    //    base.OnValidate();
    //}

    //protected override void Reset()
    //{
    //    base.Reset();
    //}

    protected override void Start()
    {
        base.Start();
    }
}
#endif