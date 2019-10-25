using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 引导验证事件
/// </summary>
/// <param name="_guideValidate">引导验证器</param>
/// <param name="_eventTriggerType">事件类别</param>
/// <param name="_eventData">事件数据</param>
/// <returns>true:验证通过,false:验证不通过</returns>
public delegate bool GuideValidateEventHandler(UIGuideValidate _guideValidate, EventTriggerType _eventTriggerType, BaseEventData _eventData);

/// <summary>
/// 引导验证
/// </summary>
[AddComponentMenu("StrayFog/Game/Guide/UIGuideValidate")]
public class UIGuideValidate : EventTrigger
{
    #region OnEventValidate 事件验证
    /// <summary>
    /// 事件验证
    /// </summary>
    public event GuideValidateEventHandler OnEventValidate;
    #endregion

    #region guideId 引导Id
    /// <summary>
    /// 引导Id
    /// </summary>
    public int guideId { get; private set; }
    #endregion

    #region eventTriggerType 触发验证的事件
    /// <summary>
    /// 触发验证的事件
    /// </summary>
    public EventTriggerType eventTriggerType { get; private set; }
    #endregion

    #region SetData  设置数据
    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="_guideId">引导Id</param>
    /// <param name="_eventTriggerType">触发验证的事件</param>
    public void SetData(int _guideId, EventTriggerType _eventTriggerType)
    {
        guideId = _guideId;
        eventTriggerType = _eventTriggerType;
    }
    #endregion

    #region OnIsTriggerValidate  是否触发验证
    /// <summary>
    /// 是否触发验证
    /// </summary>
    /// <param name="_eventTriggerType">事件类型</param>
    /// <param name="_eventData">事件参数</param>
    /// <returns>true:触发,false:不触发</returns>
    bool OnIsTriggerValidate(EventTriggerType _eventTriggerType, BaseEventData _eventData)
    {
        bool result = false;
        if (OnEventValidate != null)
        {
            result = OnEventValidate.Invoke(this, _eventTriggerType, _eventData);
        }
        return result;
    }
    #endregion

    #region OnBeginDrag
    /// <summary>
    /// OnBeginDrag
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnBeginDrag(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.BeginDrag, _eventData))
        {
            base.OnBeginDrag(_eventData);
        }
    }
    #endregion

    #region OnCancel
    /// <summary>
    /// OnCancel
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnCancel(BaseEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Cancel, _eventData))
        {
            base.OnCancel(_eventData);
        }
    }
    #endregion

    #region OnDeselect
    /// <summary>
    /// OnDeselect
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnDeselect(BaseEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Deselect, _eventData))
        {
            base.OnDeselect(_eventData);
        }
    }
    #endregion

    #region OnDrag
    /// <summary>
    /// OnDrag
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnDrag(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Drag, _eventData))
        {
            base.OnDrag(_eventData);
        }
    }
    #endregion

    #region OnDrop
    /// <summary>
    /// OnDrop
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnDrop(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Drop, _eventData))
        {
            base.OnDrop(_eventData);
        }
    }
    #endregion

    #region OnEndDrag
    /// <summary>
    /// OnEndDrag
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnEndDrag(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.EndDrag, _eventData))
        {
            base.OnEndDrag(_eventData);
        }
    }
    #endregion

    #region OnInitializePotentialDrag
    /// <summary>
    /// OnInitializePotentialDrag
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnInitializePotentialDrag(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.InitializePotentialDrag, _eventData))
        {
            base.OnInitializePotentialDrag(_eventData);
        }
    }
    #endregion

    #region OnMove
    /// <summary>
    /// OnMove
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnMove(AxisEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Move, _eventData))
        {
            base.OnMove(_eventData);
        }
    }
    #endregion

    #region OnPointerDown
    /// <summary>
    /// OnPointerDown
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnPointerDown(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.PointerDown, _eventData))
        {
            base.OnPointerDown(_eventData);
        }
    }
    #endregion

    #region OnPointerClick
    /// <summary>
    /// OnPointerClick
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnPointerClick(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.PointerClick, _eventData))
        {
            base.OnPointerClick(_eventData);
        }
    }
    #endregion

    #region OnPointerEnter
    /// <summary>
    /// OnPointerEnter
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnPointerEnter(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.PointerEnter, _eventData))
        {
            base.OnPointerEnter(_eventData);
        }
    }
    #endregion

    #region OnPointerExit
    /// <summary>
    /// OnPointerExit
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnPointerExit(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.PointerExit, _eventData))
        {
            base.OnPointerExit(_eventData);
        }
    }
    #endregion

    #region OnPointerUp
    /// <summary>
    /// OnPointerUp
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnPointerUp(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.PointerUp, _eventData))
        {
            base.OnPointerUp(_eventData);
        }
    }
    #endregion

    #region OnScroll
    /// <summary>
    /// OnScroll
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnScroll(PointerEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Scroll, _eventData))
        {
            base.OnScroll(_eventData);
        }
    }
    #endregion

    #region OnSelect
    /// <summary>
    /// OnSelect
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnSelect(BaseEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Select, _eventData))
        {
            base.OnSelect(_eventData);
        }
    }
    #endregion

    #region OnSubmit
    /// <summary>
    /// OnSubmit
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnSubmit(BaseEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.Submit, _eventData))
        {
            base.OnSubmit(_eventData);
        }
    }
    #endregion

    #region OnUpdateSelected
    /// <summary>
    /// OnUpdateSelected
    /// </summary>
    /// <param name="_eventData">_eventData</param>
    public override void OnUpdateSelected(BaseEventData _eventData)
    {
        if (OnIsTriggerValidate(EventTriggerType.UpdateSelected, _eventData))
        {
            base.OnUpdateSelected(_eventData);
        }
    }
    #endregion
}
