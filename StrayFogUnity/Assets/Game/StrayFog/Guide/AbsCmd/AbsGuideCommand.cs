using System;
using System.Collections.Generic;
/// <summary>
/// 引导命令抽象
/// </summary>
public abstract class AbsGuideCommand : AbsGuideResolveMatch, IGuideCommand
{
    /// <summary>
    /// 当前引导状态
    /// </summary>
    public enGuideStatus status { get; private set; }

    /// <summary>
    /// 参考对象回调
    /// </summary>
    Func<int, XLS_Config_Table_UserGuideReferObject> mFuncReferObject;

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    {
        mFuncReferObject = _funcReferObject;
        ResolveConfig(_config, -1, enGuideStatus.WaitTrigger, enGuideStatus.WaitTrigger);
        ResolveConfig(_config, -1, enGuideStatus.WaitValidate, enGuideStatus.WaitTrigger);
        ResolveReferObject();
    }
    #endregion

    #region OnResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>命令集</returns>
    protected override List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _index, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        status = _status;
        List<AbsGuideResolveMatch> conditions = new List<AbsGuideResolveMatch>();
        switch (_resolveStatus)
        {
            case enGuideStatus.WaitTrigger:
                #region 收集触发命令
                //触发参考命令
                List<XLS_Config_Table_UserGuideReferObject> referCfgs = new List<XLS_Config_Table_UserGuideReferObject>();
                foreach (int rid in _config.triggerReferObjectId)
                {
                    XLS_Config_Table_UserGuideReferObject r = mFuncReferObject(rid);
                    if (r != null)
                    {
                        referCfgs.Add(r);
                    }
                }

                //触发条件命令
                for (int i = 0; i < _config.triggerConditionType.Length; i++)
                {
                    AbsGuideSubCommand_Condition tc = StrayFogGuideManager.Cmd_UserGuideConfig_TriggerConditionTypeMaping[_config.triggerConditionType[i]]();
                    tc.ResolveConfig(_config, i, enGuideStatus.WaitTrigger, _status);
                    if (_config.triggerConditionType[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
                    {
                        foreach (XLS_Config_Table_UserGuideReferObject r in referCfgs)
                        {
                            tc.ResolveConfig(r, i, enGuideStatus.WaitTrigger, _status);
                        }
                    }
                    conditions.Add(tc);
                }
                #endregion
                break;
            case enGuideStatus.WaitValidate:
                #region 收集验证命令
                //验证参考命令
                referCfgs = new List<XLS_Config_Table_UserGuideReferObject>();
                foreach (int rid in _config.validateReferObjectId)
                {
                    XLS_Config_Table_UserGuideReferObject r = mFuncReferObject(rid);
                    if (r != null)
                    {
                        referCfgs.Add(r);
                    }
                }

                //验证条件命令
                for (int i = 0; i < _config.validateConditionType.Length; i++)
                {
                    AbsGuideSubCommand_Condition vc = StrayFogGuideManager.Cmd_UserGuideConfig_ValidateConditionTypeMaping[_config.validateConditionType[i]]();
                    vc.ResolveConfig(_config, i, enGuideStatus.WaitValidate, _status);
                    if (_config.validateConditionType[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
                    {
                        foreach (XLS_Config_Table_UserGuideReferObject r in referCfgs)
                        {
                            vc.ResolveConfig(r, i, enGuideStatus.WaitValidate, _status);
                        }
                    }
                    conditions.Add(vc);
                }
                #endregion
                break;
        }
        return conditions;
    }
    #endregion

    #region OnIsMatchCondition 是否匹配条件
    /// <summary>
    /// 是否匹配条件
    /// </summary>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_conditionResults">条件结果</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:通过验证,false:不通过验证</returns>
    protected override bool OnIsMatchCondition(enGuideStatus _status, List<bool> _conditionResults, params object[] _parameters)
    {
        bool result = false;
        switch (guideConfig.enTriggerConditionMatchType)
        {
            case enUserGuideConfig_ConditionMatchType.And:
                result = true;
                foreach (bool rst in _conditionResults)
                {
                    result &= rst;
                }
                break;
            case enUserGuideConfig_ConditionMatchType.Or:
                result = false;
                foreach (bool rst in _conditionResults)
                {
                    result |= rst;
                    if (result)
                    {
                        break;
                    }
                }
                break;
        }
        return result;
    }
    #endregion

    #region OnExcute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_parameters">参数</param>
    protected override void OnExcute(enGuideStatus _status, params object[] _parameters)
    {
        base.OnExcute(_status, _parameters);
        switch (_status)
        {
            case enGuideStatus.WaitTrigger:
                status = enGuideStatus.WaitValidate;
                break;
            case enGuideStatus.WaitValidate:
                status = enGuideStatus.Finish;
                break;
        }
    }
    #endregion

    #region OnRecycle 回收
    /// <summary>
    /// 回收
    /// </summary>
    protected override void OnRecycle()
    {
        status = enGuideStatus.WaitTrigger;
        base.OnRecycle();
    }
    #endregion
}