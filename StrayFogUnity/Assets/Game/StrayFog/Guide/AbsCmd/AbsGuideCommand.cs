using System;
using System.Collections.Generic;
/// <summary>
/// 引导命令抽象
/// </summary>
public abstract class AbsGuideCommand : AbsGuideResolveMatch,IGuideCommand
{
    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject)
    {
        ResolveConfig(_config, -1, status);
        OnPushCommand(_config,_funcReferObject);
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
            tc.ResolveConfig(_config, i, status);
            if (_config.triggerConditionType[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
            {
                foreach (XLS_Config_Table_UserGuideReferObject r in referCfgs)
                {
                    tc.ResolveConfig(r, i, status);
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
            vc.ResolveConfig(_config, i, status);
            if (_config.validateConditionType[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
            {
                foreach (XLS_Config_Table_UserGuideReferObject r in referCfgs)
                {
                    vc.ResolveConfig(r, i, status);
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

    #region status 当前引导状态
    /// <summary>
    /// 当前引导状态
    /// </summary>
    public enGuideStatus status { get; private set; }
    #endregion

    #region OnRecycle 回收
    protected override void OnRecycle()
    {
        status = enGuideStatus.WaitTrigger;
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

    #region OnIsMatchCondition 是否匹配条件
    /// <summary>
    /// 是否匹配条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:通过验证,false:不通过验证</returns>
    protected override bool OnIsMatchCondition(params object[] _parameters)
    {
        bool result = false;
        switch (status)
        {
            case enGuideStatus.WaitTrigger:
                result = OnValidateCondition(mTriggerConditionCollection, guideConfig.enTriggerConditionMatchType,_parameters);
                break;
            case enGuideStatus.WaitValidate:
                result = OnValidateCondition(mValidateConditionCollection, guideConfig.enValidateConditionMatchType, _parameters);
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
    /// <param name="_parameters">参数</param>
    /// <returns>true:验证通过,false:验证不通过</returns>
    bool OnValidateCondition(List<AbsGuideSubCommand_Condition> _conditions, 
        enUserGuideConfig_ConditionMatchType _matchType, 
        params object[] _parameters)
    {
        bool result = false;
        switch (_matchType)
        {
            case enUserGuideConfig_ConditionMatchType.And:
                result = true;
                foreach (AbsGuideSubCommand_Condition tc in _conditions)
                {
                    result &= tc.isMatchCondition(_parameters);
                }
                break;
            case enUserGuideConfig_ConditionMatchType.Or:
                result = false;
                foreach (AbsGuideSubCommand_Condition tc in _conditions)
                {
                    result |= tc.isMatchCondition(_parameters);
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

    #region OnExcute 执行
    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="_parameters">参数</param>
    protected override void OnExcute(params object[] _parameters)
    {
        switch (status)
        {
            case enGuideStatus.WaitTrigger:
                OnExcuteCmd(mTriggerConditionCollection, _parameters);
                break;
            case enGuideStatus.WaitValidate:
                OnExcuteCmd(mValidateConditionCollection, _parameters);
                break;
            case enGuideStatus.Finish:
                
                break;
        }
    }

    /// <summary>
    /// 执行满足条件的命令操作
    /// </summary>
    /// <param name="_cmds">命令</param>
    /// <param name="_parameters">参数</param>
    void OnExcuteCmd(List<AbsGuideSubCommand_Condition> _cmds, object[] _parameters)
    {
        foreach (AbsGuideSubCommand_Condition c in _cmds)
        {
            c.Excute(_parameters);
        }
    }
    #endregion
}