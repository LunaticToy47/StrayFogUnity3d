using System;
using System.Collections.Generic;
/// <summary>
/// 引导解析匹配抽象
/// </summary>
public abstract class AbsGuideResolveMatch : IGuideMatchCondition, IGuideResolveConfig, IRecycle
{
    /// <summary>
    /// 参考对象类型
    /// </summary>
    public enUserGuideReferObject_ReferType referType { get; private set; }

    /// <summary>
    /// 引导配置
    /// </summary>
    public XLS_Config_Table_UserGuideConfig guideConfig { get; private set; }

    /// <summary>
    /// 参考对象配置
    /// </summary>
    public XLS_Config_Table_UserGuideReferObject referObjectConfig { get; private set; }

    /// <summary>
    /// 解析匹配集
    /// Key:enGuideStatus
    /// Value: List<AbsGuideResolveMatch>
    /// </summary>
    Dictionary<int, List<AbsGuideResolveMatch>> mGuideResolveMatchMaping = new Dictionary<int, List<AbsGuideResolveMatch>>();

    #region OnAddGuideResolveMatch 添加引导解析匹配
    /// <summary>
    /// 添加引导解析匹配
    /// </summary>
    /// <param name="_matchs">匹配组</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <returns>匹配组</returns>
    List<AbsGuideResolveMatch> OnAddGuideResolveMatch(List<AbsGuideResolveMatch> _matchs, enGuideStatus _resolveStatus)
    {
        if (_matchs != null && _matchs.Count > 0)
        {
            int key = (int)_resolveStatus;
            if (!mGuideResolveMatchMaping.ContainsKey(key))
            {
                mGuideResolveMatchMaping.Add(key, new List<AbsGuideResolveMatch>());
            }
            mGuideResolveMatchMaping[key].AddRange(_matchs);
        }
        return _matchs;
    }
    #endregion    

    #region isMatchCondition 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    public bool isMatchCondition(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters)
    {
        int key = (int)_sender.status;
        List<bool> conditions = new List<bool>();
        if (mGuideResolveMatchMaping != null && mGuideResolveMatchMaping.ContainsKey(key))
        {
            foreach (AbsGuideResolveMatch m in mGuideResolveMatchMaping[key])
            {
                conditions.Add(m.isMatchCondition(_sender, this, _parameters));
            }
        }
        return OnIsMatchCondition(_sender, conditions, _sponsor, _parameters);
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_conditionResults">条件结果</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected virtual bool OnIsMatchCondition(IGuideCommand _sender, List<bool> _conditionResults, IGuideMatchCondition _sponsor, params object[] _parameters) { return true; }
    #endregion

    #region Excute 执行处理
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_parameters">参数</param>
    public void Excute(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters)
    {        
        int key = (int)_sender.status;
        bool result = mGuideResolveMatchMaping.ContainsKey(key) ? mGuideResolveMatchMaping[key].Count > 0 : false;
        if (result)
        {
            foreach (AbsGuideResolveMatch m in mGuideResolveMatchMaping[key])
            {
                m.Excute(_sender, this, _parameters);
            }
        }
        OnExcute(_sender, _sponsor, _parameters);
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_parameters">参数</param>
    protected virtual void OnExcute(IGuideCommand _sender, IGuideMatchCondition _sponsor, params object[] _parameters) { }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _index, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        guideConfig = _config;
        List<AbsGuideResolveMatch> result = OnAddGuideResolveMatch(OnResolveConfig(_config, _index, _resolveStatus, _status),_resolveStatus);
        if (result != null)
        {
            foreach (AbsGuideResolveMatch m in result)
            {
                m.ResolveConfig(_config, _index, _resolveStatus, _status);
            }
        }
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>命令集</returns>
    protected virtual List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _index, enGuideStatus _resolveStatus, enGuideStatus _status) { return null; }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>命令集</returns>
    public void ResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        referObjectConfig = _config;
        List<AbsGuideResolveMatch> result = OnAddGuideResolveMatch(OnResolveConfig(_config, _index, _resolveStatus, _status), _resolveStatus);
        if (result != null)
        {
            foreach (AbsGuideResolveMatch m in result)
            {
                m.ResolveConfig(guideConfig, _index, _resolveStatus, _status);
                m.ResolveConfig(_config, _index, _resolveStatus, _status);
            }
        }
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    protected virtual List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _resolveStatus, enGuideStatus _status) { return null; }
    #endregion

    #region ResolveReferObject 解析参考对象
    /// <summary>
    /// 解析参考对象
    /// </summary>
    public enUserGuideReferObject_ReferType ResolveReferObject()
    {
        referType |= OnResolveReferObject();
        if (mGuideResolveMatchMaping != null && mGuideResolveMatchMaping.Count > 0)
        {
            foreach (List<AbsGuideResolveMatch> values in mGuideResolveMatchMaping.Values)
            {
                foreach (AbsGuideResolveMatch key in values)
                {
                    referType |= key.ResolveReferObject();
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

    #region Recycle 回收
    /// <summary>
    /// 回收之前事件
    /// </summary>
    public event EventHandlerRecycle OnBeforeRecycle;
    /// <summary>
    /// 回收之后事件
    /// </summary>
    public event EventHandlerRecycle OnAfterRecycle;

    /// <summary>
    /// 回收
    /// </summary>
    public void Recycle()
    {
        OnBeforeRecycle?.Invoke(this);
        OnRecycle();
        foreach (List<AbsGuideResolveMatch> matchs in mGuideResolveMatchMaping.Values)
        {
            foreach (AbsGuideResolveMatch m in matchs)
            {
                m.Recycle();
            }
        }
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

    #region OnSegmentationGroup 将源字符串按组分隔
    /// <summary>
    /// 将源字符串按组分隔
    /// </summary>
    /// <param name="_source">源字符</param>
    /// <returns>组字符</returns>
    protected string[] OnSegmentationGroup(string _source)
    {
        return string.IsNullOrEmpty(_source) ? new string[0] : _source.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries);
    }
    #endregion

    #region OnSegmentationValue 将源字符串按值分隔
    /// <summary>
    /// 将源字符串按值分隔
    /// </summary>
    /// <param name="_source">源字符</param>
    /// <returns>值字符</returns>
    protected string[] OnSegmentationValue(string _source)
    {
        return string.IsNullOrEmpty(_source) ? new string[0] : _source.Split(new string[1] { "_" }, StringSplitOptions.RemoveEmptyEntries);
    }
    #endregion
}
