using System.Collections.Generic;
/// <summary>
/// 引导验证条件_点击触发参考对象
/// </summary>
public class UserGuideConfig_ValidateCondition_ClickReferObject : AbsGuideSubCommand_Condition
{
    protected override bool OnIsMatchCondition(IGuideCommand _sender, List<AbsGuideResolveMatch> _conditions, IGuideMatchCondition _sponsor, params object[] _parameters)
    {
        bool result = base.OnIsMatchCondition(_sender, _conditions, _sponsor, _parameters);
        if (_parameters != null)
        {
            UIGuideValidate uiGv = null;
            foreach (object t in _parameters)
            {
                if (t is UIGuideValidate)
                {
                    uiGv = (UIGuideValidate)t;

                }
            }
        }
        return result;
    }
}
