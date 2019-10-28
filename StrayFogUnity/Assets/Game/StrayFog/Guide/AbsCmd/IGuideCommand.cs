using System;
using UnityEngine;
/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand
{    
    /// <summary>
    /// 当前引导状态
    /// </summary>
    enGuideStatus status { get; }
    /// <summary>
    /// 命令关联的引导窗口
    /// </summary>
    AbsUIGuideWindowView guideWindow { get; set; }    
    /// <summary>
    /// 逻辑运算
    /// </summary>
    /// <param name="_leftValue">左值</param>
    /// <param name="_rightValue">右值</param>
    /// <param name="_operator">运算符</param>
    /// <returns>结果</returns>
    bool LogicalOperator(bool _leftValue,bool _rightValue, enUserGuideConfig_ConditionOperator _operator);
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCondition(params object[] _parameters);
    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    void Excute(params object[] _parameters);
    /// <summary>
    /// 创建验证控件
    /// </summary>
    /// <typeparam name="R">控件类别</typeparam>
    /// <param name="_monoBehaviour">要添加验证的控件</param>
    /// <param name="_type">类型</param>
    /// <param name="_index">索引</param>
    /// <returns>验证控件</returns>
    R CreateValidateMono<R>(MonoBehaviour _monoBehaviour, int _type, int _index) where R : UIGuideValidate;
    /// <summary>
    /// 完成引导
    /// </summary>
    event Action<IGuideCommand> OnFinishGuide;
}
