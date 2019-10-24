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
    enGuideStatus mGuideStatus = enGuideStatus.WaitTrigger;

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    {
        ResolveConfig(_config, -1, enGuideStatus.WaitTrigger, mGuideStatus);
        OnPushCommand(_config, _funcReferObject);
        OnResolveConfig(_config, _funcReferObject);
    }

    /// <summary>
    /// 触发条件集合
    /// </summary>
    List<AbsGuideSubCommand_Condition> mTriggerConditionCollection = new List<AbsGuideSubCommand_Condition>();
    /// <summary>
    /// 验证条件集合
    /// </summary>
    List<AbsGuideSubCommand_Condition> mValidateConditionCollection = new List<AbsGuideSubCommand_Condition>();
    /// <summary>
    /// 组装命令
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    void OnPushCommand(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    {
        #region 收集触发命令
        //触发参考命令
        List<XLS_Config_Table_UserGuideReferObject> referCfgs = new List<XLS_Config_Table_UserGuideReferObject>();
        foreach (int rid in _config.triggerReferObjectId)
        {
            XLS_Config_Table_UserGuideReferObject r = _funcReferObject(rid);
            if (r != null)
            {
                referCfgs.Add(r);
            }
        }

        //触发条件命令
        for (int i = 0; i < _config.triggerConditionType.Length; i++)
        {
            AbsGuideSubCommand_Condition tc = StrayFogGuideManager.Cmd_UserGuideConfig_TriggerConditionTypeMaping[_config.triggerConditionType[i]]();
            tc.ResolveConfig(_config, i, enGuideStatus.WaitTrigger, mGuideStatus);
            if (_config.triggerConditionType[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
            {
                foreach (XLS_Config_Table_UserGuideReferObject r in referCfgs)
                {
                    tc.ResolveConfig(r, i, enGuideStatus.WaitTrigger, mGuideStatus);
                }
            }
            mTriggerConditionCollection.Add(tc);
        }
        #endregion

        #region 收集验证命令
        //验证参考命令
        referCfgs = new List<XLS_Config_Table_UserGuideReferObject>();
        foreach (int rid in _config.validateReferObjectId)
        {
            XLS_Config_Table_UserGuideReferObject r = _funcReferObject(rid);
            if (r != null)
            {
                referCfgs.Add(r);
            }
        }

        //验证条件命令
        for (int i = 0; i < _config.validateConditionType.Length; i++)
        {
            AbsGuideSubCommand_Condition vc = StrayFogGuideManager.Cmd_UserGuideConfig_ValidateConditionTypeMaping[_config.validateConditionType[i]]();
            vc.ResolveConfig(_config, i, enGuideStatus.WaitValidate, mGuideStatus);
            if (_config.validateConditionType[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
            {
                foreach (XLS_Config_Table_UserGuideReferObject r in referCfgs)
                {
                    vc.ResolveConfig(r, i, enGuideStatus.WaitValidate, mGuideStatus);
                }
            }
            mValidateConditionCollection.Add(vc);
        }
        #endregion
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    protected virtual void OnResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    { }
    #endregion

    #region OnRecycle 回收
    /// <summary>
    /// 回收
    /// </summary>
    protected override void OnRecycle()
    {
        mGuideStatus = enGuideStatus.WaitTrigger;
        foreach (AbsGuideSubCommand_Condition cmd in mTriggerConditionCollection)
        {
            cmd.Recycle();
        }
        foreach (AbsGuideSubCommand_Condition cmd in mValidateConditionCollection)
        {
            cmd.Recycle();
        }
        mTriggerConditionCollection.Clear();
        mValidateConditionCollection.Clear();
        base.OnRecycle();
    }
    #endregion

    #region isMatchCmd 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足,false:不满足</returns>
    public bool isMatchCmd(params object[] _parameters)
    {
        return isMatchCondition(mGuideStatus, _parameters);
    }
    #endregion

    #region OnIsMatchCondition 是否匹配条件
    /// <summary>
    /// 是否匹配条件
    /// </summary>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:通过验证,false:不通过验证</returns>
    protected override bool OnIsMatchCondition(enGuideStatus _status, params object[] _parameters)
    {
        bool result = false;
        switch (_status)
        {
            case enGuideStatus.WaitTrigger:
                result = OnValidateCondition(mTriggerConditionCollection, guideConfig.enTriggerConditionMatchType, _status, _parameters);
                break;
            case enGuideStatus.WaitValidate:
                result = OnValidateCondition(mValidateConditionCollection, guideConfig.enValidateConditionMatchType, _status, _parameters);
                break;
            case enGuideStatus.Finish:
                result = true;
                break;
        }
        return result;
    }

    /// <summary>
    /// 验证条件
    /// </summary>
    /// <param name="_conditions">条件集合</param>
    /// <param name="_matchType">匹配类型</param>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:验证通过,false:验证不通过</returns>
    bool OnValidateCondition(List<AbsGuideSubCommand_Condition> _conditions,
        enUserGuideConfig_ConditionMatchType _matchType, enGuideStatus _status,
        params object[] _parameters)
    {
        bool result = false;
        switch (_matchType)
        {
            case enUserGuideConfig_ConditionMatchType.And:
                result = true;
                foreach (AbsGuideSubCommand_Condition tc in _conditions)
                {
                    result &= tc.isMatchCondition(_status, _parameters);
                }
                break;
            case enUserGuideConfig_ConditionMatchType.Or:
                result = false;
                foreach (AbsGuideSubCommand_Condition tc in _conditions)
                {
                    result |= tc.isMatchCondition(_status, _parameters);
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

    #region ExcuteCmd 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    public void ExcuteCmd(params object[] _parameters)
    {
        Excute(mGuideStatus, _parameters);
    }
    #endregion

    #region OnExcute 执行
    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_parameters">参数</param>
    protected override void OnExcute(enGuideStatus _status, params object[] _parameters)
    {
        switch (_status)
        {
            case enGuideStatus.WaitTrigger:
                OnExcuteCmd(mTriggerConditionCollection, _status, _parameters);
                break;
            case enGuideStatus.WaitValidate:
                OnExcuteCmd(mValidateConditionCollection, _status, _parameters);
                break;
            case enGuideStatus.Finish:

                break;
        }
    }

    /// <summary>
    /// 执行满足条件的命令操作
    /// </summary>
    /// <param name="_cmds">命令</param>
    /// <param name="_status">当前引导状态</param>
    /// <param name="_parameters">参数</param>
    void OnExcuteCmd(List<AbsGuideSubCommand_Condition> _cmds, enGuideStatus _status, object[] _parameters)
    {
        foreach (AbsGuideSubCommand_Condition c in _cmds)
        {
            c.Excute(_status, _parameters);
        }
    }
    #endregion
}