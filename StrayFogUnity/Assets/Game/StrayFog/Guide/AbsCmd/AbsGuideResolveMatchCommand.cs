using System;
using System.Collections.Generic;
/// <summary>
/// 引导解析匹配命令抽象
/// </summary>
public abstract class AbsGuideResolveMatchCommand : IGuideMatchConditionCommand, IGuideResolveConfigCommand, IGuideExcuteCommand, IRecycle
{
    #region conditionIndex 条件索引
    /// <summary>
    /// 条件索引
    /// </summary>
    public int conditionIndex { get; private set; }
    #endregion

    #region referObjectIndex 参考对象索引
    /// <summary>
    /// 参考对象索引
    /// </summary>
    public int referObjectIndex { get; private set; }
    #endregion

    #region styleIndex 样式索引
    /// <summary>
    /// 样式索引
    /// </summary>
    public int styleIndex { get; private set; }
    #endregion

    #region isMatch 是否匹配条件
    /// <summary>
    /// 是否匹配条件
    /// </summary>
    public bool isMatch { get; private set; }
    #endregion

    #region conditionOperator 条件运算符
    /// <summary>
    /// 条件运算符
    /// </summary>
    public enUserGuideConfig_ConditionOperator conditionOperator { get; private set; }
    #endregion

    #region resolveStatus 命令解析状态
    /// <summary>
    /// 命令解析状态
    /// </summary>
    public enGuideStatus resolveStatus { get; private set; }
    #endregion

    #region referType 参考对象类型
    /// <summary>
    /// 参考对象类型
    /// </summary>
    public enUserGuideReferObject_ReferType referType { get; private set; }
    #endregion

    #region guideConfig 引导配置
    /// <summary>
    /// 引导配置
    /// </summary>
    public XLS_Config_Table_UserGuideConfig guideConfig { get; private set; }
    #endregion

    #region referObjectConfig 参考对象配置
    /// <summary>
    /// 参考对象配置
    /// </summary>
    public XLS_Config_Table_UserGuideReferObject referObjectConfig { get; private set; }
    #endregion

    #region styleConfig 样式配置
    /// <summary>
    /// 样式配置
    /// </summary>
    public XLS_Config_Table_UserGuideStyle styleConfig { get; private set; }
    #endregion

    #region OnResolveOperator 解析操作符    
    /// <summary>
    /// 解析操作符
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_configIndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    void OnResolveOperator(XLS_Config_Table_UserGuideConfig _config, int _conditionTndex, enGuideStatus _resolveStatus)
    {
        conditionOperator = enUserGuideConfig_ConditionOperator.And;
        if (_conditionTndex > 0)
        {
            switch (_resolveStatus)
            {
                case enGuideStatus.WaitTrigger:
                    conditionOperator = (enUserGuideConfig_ConditionOperator)_config.triggerConditionOperators[_conditionTndex];
                    break;
                case enGuideStatus.WaitValidate:
                    conditionOperator = (enUserGuideConfig_ConditionOperator)_config.validateConditionOperators[_conditionTndex];
                    break;
            }
        }
    }
    #endregion

    #region ResolveConfig 解析配置XLS_Config_Table_UserGuideConfig
    /// <summary>
    /// 解析匹配命令集
    /// Key:enGuideStatus
    /// Value: List<AbsGuideResolveMatch>
    /// </summary>
    Dictionary<int, List<AbsGuideSubCommand_Condition>> mGuideResolveMatchCommandMaping = new Dictionary<int, List<AbsGuideSubCommand_Condition>>();
        
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_guideConfig">引导配置</param>
    /// <param name="_referObjectConfig">参考对象配置</param>
    /// <param name="_styleConfig">样式配置</param>
    /// <param name="_conditionIndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _guideConfig,
        XLS_Config_Table_UserGuideReferObject _referObjectConfig,
        XLS_Config_Table_UserGuideStyle _styleConfig,
        int _conditionIndex, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        guideConfig = _guideConfig;
        referObjectConfig = _referObjectConfig;
        styleConfig = _styleConfig;
        conditionIndex = referObjectIndex = styleIndex = _conditionIndex;
        if (_conditionIndex >= 0)
        {
            resolveStatus = _resolveStatus;
        }
        else
        {
            resolveStatus = _status;
        }
        OnResolveOperator(_guideConfig, _conditionIndex, _resolveStatus);
        int statusKey = (int)_resolveStatus;
        if (!mGuideResolveMatchCommandMaping.ContainsKey(statusKey))
        {
            mGuideResolveMatchCommandMaping.Add(statusKey, new List<AbsGuideSubCommand_Condition>());
        }
        List<AbsGuideSubCommand_Condition> conditions = OnResolveConfig(_guideConfig, _referObjectConfig, _styleConfig, _conditionIndex, _resolveStatus, _status);
        if (conditions != null)
        {
            foreach (AbsGuideSubCommand_Condition c in conditions)
            {
                if (_conditionIndex >= 0)
                {
                    c.ResolveConfig(_guideConfig, _referObjectConfig, _styleConfig, _conditionIndex, _resolveStatus, _status);
                }
                mGuideResolveMatchCommandMaping[statusKey].Add(c);
            }
        }
    }

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
    protected virtual List<AbsGuideSubCommand_Condition> OnResolveConfig(XLS_Config_Table_UserGuideConfig _guideConfig,
        XLS_Config_Table_UserGuideReferObject _referObjectConfig,
        XLS_Config_Table_UserGuideStyle _styleConfig,
        int _conditionIndex, enGuideStatus _resolveStatus, enGuideStatus _status)
    { return null; }

    /// <summary>
    /// 解析命令
    /// </summary>
    protected virtual void OnResolveCommand() { }
    #endregion
    
    #region ResolveReferObject 解析参考对象
    /// <summary>
    /// 解析参考对象
    /// </summary>
    public enUserGuideReferObject_ReferType ResolveReferObjectType()
    {
        referType |= OnResolveReferObject();
        if (mGuideResolveMatchCommandMaping != null && mGuideResolveMatchCommandMaping.Count > 0)
        {
            foreach (List<AbsGuideSubCommand_Condition> values in mGuideResolveMatchCommandMaping.Values)
            {
                foreach (AbsGuideSubCommand_Condition key in values)
                {
                    referType |= key.ResolveReferObjectType();
                }
            }
        }
        return referType;
    }

    /// <summary>
    /// 解析参考对象
    /// </summary>
    protected virtual enUserGuideReferObject_ReferType OnResolveReferObject() { return enUserGuideReferObject_ReferType.None; }
    #endregion

    #region isMatchCondition 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    public bool isMatchCondition(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters)
    {
        int key = (int)_resolveStatus;
        isMatch = true;
        List<AbsGuideResolveMatchCommand> matchs = new List<AbsGuideResolveMatchCommand>();
        if (mGuideResolveMatchCommandMaping != null && mGuideResolveMatchCommandMaping.ContainsKey(key))
        {
            foreach (AbsGuideResolveMatchCommand m in mGuideResolveMatchCommandMaping[key])
            {
                isMatch &= _sender.LogicalOperator(isMatch, m.isMatchCondition(_sender, this, _resolveStatus, _status, _parameters), m.conditionOperator);
                matchs.Add(m);
            }
        }
        isMatch &= OnIsMatchCondition(_sender, matchs, _sponsor, _resolveStatus, _status, _parameters);
        isMatch &= resolveStatus == _resolveStatus;
        isMatch &= _sender.status == _status;
        return isMatch;
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_conditions">条件组</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected virtual bool OnIsMatchCondition(IGuideCommand _sender, List<AbsGuideResolveMatchCommand> _conditions, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters) { return true; }
    #endregion

    #region Excute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    public void Excute(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters)
    {
        int key = (int)(_sender == _sponsor ? _sender.status : resolveStatus);
        bool result = mGuideResolveMatchCommandMaping.ContainsKey(key) ? mGuideResolveMatchCommandMaping[key].Count > 0 : false;
        if (result)
        {
            foreach (AbsGuideResolveMatchCommand m in mGuideResolveMatchCommandMaping[key])
            {
                m.Excute(_sender, this, _resolveStatus, _status, _parameters);
            }
        }
        OnExcute(_sender, _sponsor, _resolveStatus, _status, _parameters);
        resolveStatus = OnAfterExcuteResolveStatus(_sender, _sponsor, _resolveStatus, _status, _parameters);
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">当前状态</param>
    /// <param name="_parameters">参数</param>
    protected virtual void OnExcute(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters) { }

    /// <summary>
    /// 执行后解析状态
    /// </summary>
    /// <returns>解析状态</returns>
    protected virtual enGuideStatus OnAfterExcuteResolveStatus(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, enGuideStatus _resolveStatus, enGuideStatus _status, params object[] _parameters) { return _resolveStatus; }
    #endregion

    #region Recycle 回收
    /// <summary>
    /// 回收之前事件
    /// </summary>
    public event Action<IRecycle> OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件
    /// </summary>
    public event Action<IRecycle> OnAfterRecycle;

    /// <summary>
    /// 回收
    /// </summary>
    public void Recycle()
    {
        OnBeforeRecycle?.Invoke(this);
        OnRecycle();
        foreach (List<AbsGuideSubCommand_Condition> matchs in mGuideResolveMatchCommandMaping.Values)
        {
            foreach (AbsGuideSubCommand_Condition m in matchs)
            {
                m.Recycle();
            }
        }
        mGuideResolveMatchCommandMaping.Clear();
        OnAfterRecycle?.Invoke(this);
    }

    /// <summary>
    /// 回收
    /// </summary>
    protected virtual void OnRecycle() { }

    /// <summary>
    /// 延时回收
    /// </summary>
    /// <param name="_delay">延时时间</param>
    [Obsolete("Use Recycle() instead. Delay is not use.")]
    public void Recycle(float _delay)
    {
        Recycle();
    }
    #endregion
}
