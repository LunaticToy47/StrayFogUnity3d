using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 引导命令抽象
/// </summary>
public abstract class AbsGuideCommand : AbsGuideResolveMatchCommand, IGuideCommand
{
    /// <summary>
    /// 当前引导状态
    /// </summary>
    public enGuideStatus status { get; private set; }

    /// <summary>
    /// 命令关联的引导窗口
    /// </summary>
    public AbsUIGuideWindowView guideWindow { get; set; }

    /// <summary>
    /// 参考对象回调
    /// </summary>
    Func<int, XLS_Config_Table_UserGuideReferObject> mFuncReferObject;

    /// <summary>
    /// 样式回调
    /// </summary>
    Func<int, XLS_Config_Table_UserGuideStyle> mFuncStyle;

    /// <summary>
    /// 完成引导
    /// </summary>
    public event Action<IGuideCommand> OnFinishGuide;

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    /// <param name="_funcStyle">获得样式回调</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject,Func<int,XLS_Config_Table_UserGuideStyle> _funcStyle)
    {
        mFuncReferObject = _funcReferObject;
        mFuncStyle = _funcStyle;
        ResolveConfig(_config, null, null, -1, enGuideStatus.WaitTrigger, enGuideStatus.WaitTrigger);
        ResolveConfig(_config, null, null, -1, enGuideStatus.WaitValidate, enGuideStatus.WaitTrigger);
        ResolveReferObjectType();
    }
    #endregion

    #region OnResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_guideConfig">引导配置</param>
    /// <param name="_referObjectConfig">参考对象配置</param>
    /// <param name="_styleConfig">样式配置</param>
    /// <param name="_conditionIndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>条件命令组</returns>
    protected override List<AbsGuideSubCommand_Condition> OnResolveConfig(XLS_Config_Table_UserGuideConfig _guideConfig,
        XLS_Config_Table_UserGuideReferObject _referObjectConfig,
        XLS_Config_Table_UserGuideStyle _styleConfig,
        int _conditionIndex, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        status = _status;
        List<AbsGuideSubCommand_Condition> conditions = new List<AbsGuideSubCommand_Condition>();
        AbsGuideSubCommand_Condition tempCondition = null;
        XLS_Config_Table_UserGuideReferObject tempRefer = null;
        XLS_Config_Table_UserGuideStyle tempStyle = null;
        switch (_resolveStatus)
        {
            case enGuideStatus.WaitTrigger:
                #region 收集触发命令
                //触发条件命令
                for (int i = 0; i < _guideConfig.triggerConditionTypes.Length; i++)
                {
                    tempRefer = null;
                    tempStyle = null;
                    if (_guideConfig.triggerConditionTypes[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
                    {
                        tempRefer = mFuncReferObject(_guideConfig.triggerReferObjectIds[i]);
                    }
                    tempStyle = mFuncStyle(_guideConfig.styleIds[i]);

                    tempCondition = StrayFogGuideManager.Cmd_UserGuideConfig_TriggerConditionTypeMaping[_guideConfig.triggerConditionTypes[i]]();
                    tempCondition.ResolveConfig(_guideConfig, tempRefer, tempStyle, i, _resolveStatus, _status);
                    conditions.Add(tempCondition);
                }
                #endregion
                break;
            case enGuideStatus.WaitValidate:
                #region 收集验证命令
                //验证条件命令
                for (int i = 0; i < _guideConfig.validateConditionTypes.Length; i++)
                {
                    tempRefer = null;
                    tempStyle = null;
                    if (_guideConfig.validateConditionTypes[i] == (int)enUserGuideConfig_TriggerConditionType.ReferObject)
                    {
                        tempRefer = mFuncReferObject(_guideConfig.validateReferObjectIds[i]);
                    }
                    tempStyle = mFuncStyle(_guideConfig.styleIds[i]);
                    tempCondition = StrayFogGuideManager.Cmd_UserGuideConfig_ValidateConditionTypeMaping[_guideConfig.validateConditionTypes[i]]();
                    tempCondition.ResolveConfig(_guideConfig, tempRefer, tempStyle, i, _resolveStatus, _status);
                    conditions.Add(tempCondition);
                }
                #endregion
                break;
        }
        return conditions;
    }
    #endregion

    #region LogicalOperator 逻辑运算
    /// <summary>
    /// 逻辑运算
    /// </summary>
    /// <param name="_leftValue">左值</param>
    /// <param name="_rightValue">右值</param>
    /// <param name="_operator">运算符</param>
    /// <returns>结果</returns>
    public bool LogicalOperator(bool _leftValue, bool _rightValue, enUserGuideConfig_ConditionOperator _operator)
    {
        bool result = true;
        switch (_operator)
        {
            case enUserGuideConfig_ConditionOperator.And:
                result &= (_leftValue & _rightValue);
                break;
            case enUserGuideConfig_ConditionOperator.Or:
                result &= (_leftValue | _rightValue);
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
    protected override void OnExcute(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, params object[] _parameters)
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
    /// <param name="_type">类型</param>
    /// <param name="_index">索引</param>
    /// <returns>验证控件</returns>
    public R CreateValidateMono<R>(MonoBehaviour _monoBehaviour, int _type, int _index) where R : UIGuideValidate
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
                result.SetData(guideConfig.id, _type, _index, UnityEngine.EventSystems.EventTriggerType.PointerClick);
                break;
            case enUserGuideConfig_ValidateConditionType.MoveTo:
                result.SetData(guideConfig.id, _type, _index, UnityEngine.EventSystems.EventTriggerType.EndDrag);
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
        if (status == enGuideStatus.Finish)
        {
            OnFinishGuide?.Invoke(this);
        }        
    }
    #endregion
}