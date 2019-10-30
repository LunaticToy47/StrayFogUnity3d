using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 引导参考对象UI窗口控件
/// </summary>
public class UserGuideReferObject_Refer2DType_UIWindowControl_Command : AbsGuideSubCommand_Condition
{
    /// <summary>
    /// 窗口名称
    /// </summary>
    public string windowName { get; private set; }
    /// <summary>
    /// 控件名称
    /// </summary>
    public string controlName { get; private set; }
    /// <summary>
    /// Graphic遮罩名称
    /// </summary>
    public string graphicMask { get; private set; }
    /// <summary>
    /// 遮罩控件
    /// </summary>
    AbsUIGuideGraphic mGraphicMask = null;
    /// <summary>
    /// 遮罩控件ActiveSelf
    /// </summary>
    bool mGraphicMaskActiveSelf = false;
    /// <summary>
    /// 引导命令发送者
    /// </summary>
    IGuideCommand mGuideCommandSender = null;
    /// <summary>
    /// 控件
    /// </summary>
    UIBehaviour mControl = null;
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
        base.OnResolveConfig(_guideConfig, _referObjectConfig, _styleConfig, _conditionIndex, _resolveStatus, _status);
        string[] values = _referObjectConfig.refer2DValue.Split(enSplitSymbol.VerticalBar);
        windowName = values[0];
        controlName = graphicMask = values[1];
        if (values.Length >= 3)
        {
            graphicMask = values[2];
        }
        switch (_status)
        {
            case enGuideStatus.WaitTrigger:
                mGraphicMaskActiveSelf = Convert.ToBoolean(byte.Parse(guideConfig.triggerConditionValues[conditionIndex]));
                break;
        }
        return null;
    }

    /// <summary>
    /// 解析参考对象
    /// </summary>
    /// <returns>参考对象</returns>
    protected override enUserGuideReferObject_ReferType OnResolveReferObject()
    {
        return enUserGuideReferObject_ReferType.Refer2D;
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <param name="_conditions">匹配组</param>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">条件匹配发起者</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected override bool OnIsMatchCondition(IGuideCommand _sender, List<AbsGuideResolveMatchCommand> _conditions, IGuideMatchConditionCommand _sponsor, params object[] _parameters)
    {
        bool result = base.OnIsMatchCondition(_sender, _conditions, _sponsor, _parameters);
        if (_parameters != null && mGraphicMask == null)
        {
            foreach (object p in _parameters)
            {
                if (p is AbsUIWindowView)
                {
                    AbsUIWindowView w = (AbsUIWindowView)p;
                    if (w.config.name.Equals(windowName))
                    {
                        mGuideCommandSender = _sender;
                        mControl = w.FindCtrlByNameIsSelfOrParent<UIBehaviour>(controlName);
                        mGraphicMask = new UIGuideGraphic((int)_sender.status, w.FindCtrlByNameIsSelfOrParent<Graphic>(graphicMask), referObjectIndex);
                        if (mControl != null)
                        {
                            break;
                        }
                    }
                }
            }
        }

        result &= mControl != null && mGraphicMask != null && mGraphicMask.graphic != null
            && mGraphicMask.graphic.gameObject.activeInHierarchy == mGraphicMaskActiveSelf;
        if (result)
        {            
            UIGuideValidate validate = _sender.CreateValidateMono<UIGuideValidate>(mControl, (int)_sender.status, referObjectIndex);
            validate.OnEventValidate += Validate_OnEventValidate;
        }
        return result;
    }

    /// <summary>
    /// 引导验证事件
    /// </summary>
    /// <param name="_guideValidate">引导验证器</param>
    /// <returns>true:验证通过,false:验证不通过</returns>
    bool Validate_OnEventValidate(UIGuideValidate _guideValidate)
    {
        bool result = false;
        if (mGuideCommandSender != null)
        {
            result = mGuideCommandSender.isMatchCondition(_guideValidate);
            if (result)
            {
                mGuideCommandSender.Excute();
            }
        }
        return result;
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_sender">引导命令</param>
    /// <param name="_sponsor">执行发起者</param>
    /// <param name="_parameters">参数</param>
    protected override void OnExcute(IGuideCommand _sender, IGuideMatchConditionCommand _sponsor, params object[] _parameters)
    {        
        if (isMatch)
        {
            mGraphicMask.SetStyleData(styleConfig);
            StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIGuideWindowView>(StrayFogGamePools.guideManager.guideWindowId, (wins, pars) =>
            {
                _sender.guideWindow = wins[0];
                _sender.guideWindow.AddGraphicMask(mGraphicMask);
            });
        }
        base.OnExcute(_sender, _sponsor, _parameters);
    }

    /// <summary>
    /// 回收
    /// </summary>
    protected override void OnRecycle()
    {
        mGuideCommandSender.guideWindow.RemoveGraphicMask(mGraphicMask);
        mGraphicMask = null;
        mGuideCommandSender = null;
        base.OnRecycle();
    }
}
