/// <summary>
/// 引导参考对象UI窗口控件
/// </summary>
public class UserGuideReferObject_Refer2DType_UIWindowControl_Command : AbsGuideSubCommand_ReferObject
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

    protected override void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config)
    {
        base.OnResolveConfig(_config);
        string[] values = OnSegmentationGroup(_config.refer2DValue);
        windowName = values[0];
        controlName = graphicMask = values[1];
        if (values.Length >= 3)
        {
            graphicMask = values[2];
        }        
    }

    protected override bool OnIsMatchCondition(params object[] _parameters)
    {
        return base.OnIsMatchCondition(_parameters);
    }

    protected override void OnExcute(params object[] _parameters)
    {
        base.OnExcute(_parameters);
    }
}
