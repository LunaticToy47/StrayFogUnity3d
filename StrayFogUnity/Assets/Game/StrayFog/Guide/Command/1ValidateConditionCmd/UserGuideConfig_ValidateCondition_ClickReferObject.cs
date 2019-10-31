using System.Collections.Generic;
/// <summary>
/// 引导验证条件_点击触发参考对象
/// </summary>
public class UserGuideConfig_ValidateCondition_ClickReferObject : AbsGuideSubCommand_Condition
{
    /// <summary>
    /// 是否满足条件
    /// </summary>    
    /// <param name="_conditions">匹配组</param>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected override bool OnIsMatchCondition(IGuideCommand _sender, List<AbsGuideResolveMatchCommand> _conditions,
        IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters)
    {
        //AbsUIGuideGraphic mask = _sender.guideWindow.GetUIGuideGraphic((int)enGuideStatus.WaitTrigger, conditionIndex);
        bool result = _sender.guideWindow != null && base.OnIsMatchCondition(_sender, _conditions, _sponsor, _resolveStatus, _status, _parameters);
        if (result)
        {
            result = false;
            if (_parameters != null)
            {
                UIGuideValidate validate = null;
                foreach (object v in _parameters)
                {
                    if (v is UIGuideValidate)
                    {
                        validate = (UIGuideValidate)v;
                        result = validate.guideId == guideConfig.id && validate.type == (int)enGuideStatus.WaitTrigger && validate.index == conditionIndex;
                    }
                }
            }
        }
        return result;
    }
}
