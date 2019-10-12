using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 引导触发事件
/// </summary>
/// <param name="_guideTrigger">引导触发器</param>
/// <param name="_eventTriggerType">事件类别</param>
/// <param name="_eventData">事件数据</param>
public delegate void GuideTriggerEventHandler(UIGuideTrigger _guideTrigger, EventTriggerType _eventTriggerType, BaseEventData _eventData);
/// <summary>
/// 引导触发
/// </summary>
[AddComponentMenu("StrayFog/Game/Guide/UIGuideTrigger")]
public class UIGuideTrigger : EventTrigger
{
    #region config
    /// <summary>
    /// config
    /// </summary>
    public XLS_Config_Table_UserGuideTrigger config { get; private set; }
    #endregion

    #region maskGraphic
    /// <summary>
    /// maskGraphic
    /// </summary>
    public Graphic maskGraphic { get; private set; }
    #endregion

    #region OnEventTrigger 事件触发
    /// <summary>
    /// 事件触发
    /// </summary>
    public event GuideTriggerEventHandler OnEventTrigger;
    #endregion

    #region mIsFinishEventTriggerType 验证是否完成事件
    /// <summary>
    /// 验证是否完成事件
    /// </summary>
    EventTriggerType mIsFinishEventTriggerType;
    #endregion

    #region mCanTriggerValidate 是否可触发验证
    /// <summary>
    /// 是否可触发验证
    /// </summary>
    bool mCanTriggerValidate = false;
    #endregion

    #region SetConfig  设置配置
    /// <summary>
    /// 设置配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_triggerType">触发类别</param>
    public void SetConfig(XLS_Config_Table_UserGuideTrigger _config, EventTriggerType _triggerType)
    {
        config = _config;
        maskGraphic = gameObject.GetComponent<Graphic>();
        mIsFinishEventTriggerType = _triggerType;
        mCanTriggerValidate = false;
    }
    #endregion

    #region ToggleTriggerValidate 切换触发验证
    /// <summary>
    /// 切换触发验证
    /// </summary>
    /// <param name="_canTriggerValidate">是否可触发验证</param>
    public void ToggleTriggerValidate(bool _canTriggerValidate)
    {
        mCanTriggerValidate = _canTriggerValidate;
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
        bool isTrigger = mCanTriggerValidate && mIsFinishEventTriggerType == _eventTriggerType;
        if (isTrigger)
        {
            if (OnEventTrigger != null)
            {
                OnEventTrigger.Invoke(this, _eventTriggerType, _eventData);
            }
        }
        return isTrigger;
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
