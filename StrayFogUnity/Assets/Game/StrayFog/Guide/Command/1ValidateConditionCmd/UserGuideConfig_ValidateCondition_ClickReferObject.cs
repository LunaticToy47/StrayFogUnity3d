using UnityEngine.EventSystems;
/// <summary>
/// 引导验证条件_点击触发参考对象
/// </summary>
public class UserGuideConfig_ValidateCondition_ClickReferObject : AbsGuideSubCommand_Condition
{
    //UIGuideValidate validate = behaviour.gameObject.AddDynamicMonoBehaviour<UIGuideValidate>();
    //validate.OnEventValidate += Validate_OnEventValidate;

    /// <summary>
    /// 引导验证事件
    /// </summary>
    /// <param name="_guideValidate">引导验证器</param>
    /// <param name="_eventTriggerType">事件类别</param>
    /// <param name="_eventData">事件数据</param>
    /// <returns>true:验证通过,false:验证不通过</returns>
    bool Validate_OnEventValidate(UIGuideValidate _guideValidate, EventTriggerType _eventTriggerType, BaseEventData _eventData)
    {
        return false;
    }
}
