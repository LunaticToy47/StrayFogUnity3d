using System;
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
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    protected override void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config,int _index, enGuideStatus _status)
    {
        base.OnResolveConfig(_config, _index, _status);
        UserGuideConfig_ReferObject_Command refer = new UserGuideConfig_ReferObject_Command();
        refer.ResolveConfig(guideConfig, _index, _status);
        refer.ResolveConfig(_config, _index, _status);
        mReferObjectCollection.Add(refer);
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected override bool OnIsMatchCondition(params object[] _parameters)
    {
        bool result = base.OnIsMatchCondition(_parameters);
        foreach (AbsGuideSubCommand_ReferObject refer in mReferObjectCollection)
        {
            result &= refer.isMatchCondition(_parameters);
        }        
        return result;
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
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
