using System.Collections.Generic;
/// <summary>
/// 引导触发条件_参考对象
/// </summary>
public class UserGuideConfig_TriggerCondition_ReferObject : AbsGuideSubCommand_Condition
{
    /// <summary>
    /// 参考对象组
    /// </summary>
    List<AbsGuideSubCommand_ReferObject> mReferObjectCollection = new List<AbsGuideSubCommand_ReferObject>();

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    protected override void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config)
    {
        base.OnResolveConfig(_config);
        UserGuideConfig_ReferObject_Command refer = new UserGuideConfig_ReferObject_Command();
        refer.ResolveConfig(_config);
        mReferObjectCollection.Add(refer);
    }

    protected override bool OnIsMatchCondition(params object[] _parameters)
    {
        bool result = true;
        foreach (AbsGuideSubCommand_ReferObject refer in mReferObjectCollection)
        {
            result &= refer.isMatchCondition(_parameters);
        }
        return result && base.OnIsMatchCondition(_parameters);
    }

    protected override void OnExcute(params object[] _parameters)
    {
        base.OnExcute(_parameters);
        foreach (AbsGuideSubCommand_ReferObject refer in mReferObjectCollection)
        {
            refer.Excute(_parameters);
        }        
    }

    protected override void OnRecycle()
    {
        base.OnRecycle();
        foreach (AbsGuideSubCommand_ReferObject refer in mReferObjectCollection)
        {
            refer.Recycle();
        }
        mReferObjectCollection.Clear();
    }
}
