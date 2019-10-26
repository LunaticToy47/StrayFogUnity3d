using System.Collections.Generic;
/// <summary>
/// 引导验证条件_触发参考对象移动到验证参考对象
/// </summary>
public class UserGuideConfig_ValidateCondition_MoveToReferObject : AbsGuideSubCommand_Condition
{
    protected override bool OnIsMatchCondition(IGuideCommand _sender, List<bool> _conditionResults, IGuideMatchCondition _sponsor, params object[] _parameters)
    {
        return base.OnIsMatchCondition(_sender, _conditionResults, _sponsor, _parameters);
    }
}
