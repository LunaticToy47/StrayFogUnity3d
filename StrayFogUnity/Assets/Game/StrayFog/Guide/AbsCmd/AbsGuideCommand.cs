using System;
using System.Collections.Generic;
using UnityEngine;
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
    /// <param name="_conditionTndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>命令集</returns>
    protected override List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _conditionTndex, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        status = _status;
        List<AbsGuideResolveMatch> conditions = new List<AbsGuideResolveMatch>();
        switch (_resolveStatus)
        {
            case enGuideStatus.WaitTrigger:
                #region 收集触发命令
                //触发参考命令
                List<XLS_Config_Table_UserGuideReferObject> referCfgs = new List<XLS_Config_Table_UserGuideReferObject>();
                foreach (int rid in _config.triggerReferObjectIds)
                {
                    XLS_Config_Table_UserGuideReferObject r = mFuncReferObject(rid);
                    if (r != null)
                    {
                        referCfgs.Add(r);
                    }
                }

                //触发条件命令
                for (int i = 0; i < _config.triggerConditionTypes.Length; i++)
                {
                    AbsGuideSubCommand_Condition tc = StrayFogGuideManager.Cmd_UserGuideConfig_TriggerConditionTypeMaping[_config.triggerConditionTypes[i]]();
                    tc.ResolveConfig(_config, i, enGuideStatus.WaitTrigger, _status);
                    if (_config.triggerConditionTypes[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
                    {
                        for (int r = 0; r < referCfgs.Count; r++)
                        {
                            tc.ResolveConfig(referCfgs[r], r, enGuideStatus.WaitTrigger, _status);
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
                foreach (int rid in _config.validateReferObjectIds)
                {
                    XLS_Config_Table_UserGuideReferObject r = mFuncReferObject(rid);
                    if (r != null)
                    {
                        referCfgs.Add(r);
                    }
                }

                //验证条件命令
                for (int i = 0; i < _config.validateConditionTypes.Length; i++)
                {
                    AbsGuideSubCommand_Condition vc = StrayFogGuideManager.Cmd_UserGuideConfig_ValidateConditionTypeMaping[_config.validateConditionTypes[i]]();
                    vc.ResolveConfig(_config, i, enGuideStatus.WaitValidate, _status);
                    if (_config.validateConditionTypes[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
                    {
                        for (int r = 0; r < referCfgs.Count; r++)
                        {
                            vc.ResolveConfig(referCfgs[r], r, enGuideStatus.WaitValidate, _status);
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
    /// <param name="_sender">引导命令</param>
    /// <param name="_conditionResults">条件结果</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:通过验证,false:不通过验证</returns>
    protected override bool OnIsMatchCondition(IGuideCommand _sender, List<bool> _conditionResults, IGuideMatchCondition _sponsor, params object[] _parameters)
    {
        bool result = false;
        enUserGuideConfig_ConditionMatchType matchType = enUserGuideConfig_ConditionMatchType.And;
        switch (_sender.status)
        {
            case enGuideStatus.WaitTrigger:
                matchType = guideConfig.enTriggerConditionMatchType;
                break;
            case enGuideStatus.WaitValidate:
                matchType = guideConfig.enValidateConditionMatchType;
                break;
        }
        switch (matchType)
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
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_parameters">参数</param>
    protected override void OnExcute(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters)
    {
        base.OnExcute(_sender, _sponsor, _parameters);
        switch (_sender.status)
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

    #region CreateValidateMono 创建验证控件
    /// <summary>
    /// 创建验证控件
    /// </summary>
    /// <typeparam name="R">控件类别</typeparam>
    /// <param name="_monoBehaviour">要添加验证的控件</param>
    /// <param name="_index">索引</param>
    /// <returns>验证控件</returns>
    public R CreateValidateMono<R>(MonoBehaviour _monoBehaviour, int _index) where R : UIGuideValidate
    {
        R result = _monoBehaviour.gameObject.GetComponent<R>();
        if (result == null)
        {
            result = _monoBehaviour.gameObject.AddUIDynamicEventTrigger<R>();
        }
        enUserGuideConfig_ValidateConditionType condition = (enUserGuideConfig_ValidateConditionType)guideConfig.validateConditionTypes[_index];
        switch (condition)
        {
            case enUserGuideConfig_ValidateConditionType.Click:
                result.SetData(guideConfig.id, UnityEngine.EventSystems.EventTriggerType.PointerClick, _index);
                break;
            case enUserGuideConfig_ValidateConditionType.MoveTo:
                result.SetData(guideConfig.id, UnityEngine.EventSystems.EventTriggerType.EndDrag, _index);
                break;
        }
        return result;
    }
    #endregion

    #region isMatchCondition 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足,false:不满足</returns>
    public bool isMatchCondition(params object[] _parameters)
    {
        return base.isMatchCondition(this, this, _parameters);
    }
    #endregion

    #region Excute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    public void Excute(params object[] _parameters)
    {
        base.Excute(this, this, _parameters);
    }
    #endregion
}