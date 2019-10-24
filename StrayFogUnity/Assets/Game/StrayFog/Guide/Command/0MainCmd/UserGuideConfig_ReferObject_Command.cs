/// <summary>
/// 引导参考对象结构
/// </summary>
public class UserGuideConfig_ReferObject_Command : AbsGuideSubCommand_ReferObject
{
    /// <summary>
    /// 2D参考对象
    /// </summary>
    AbsGuideSubCommand_ReferObject m2dReferObject = null;

    /// <summary>
    /// 3D参考对象
    /// </summary>
    AbsGuideSubCommand_ReferObject m3dReferObject = null;

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    protected override void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config)
    {
        base.OnResolveConfig(_config);
        m2dReferObject = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer2DType]();
        m2dReferObject.ResolveConfig(_config);

        m3dReferObject = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer3DType]();
        m3dReferObject.ResolveConfig(_config);
    }

    protected override bool OnIsMatchCondition(params object[] _parameters)
    {
        return m2dReferObject.isMatchCondition(_parameters) && m3dReferObject.isMatchCondition(_parameters) && base.OnIsMatchCondition(_parameters);
    }

    protected override void OnExcute(params object[] _parameters)
    {
        if (m2dReferObject != null)
        {
            m2dReferObject.Excute(_parameters);
        }
        if (m3dReferObject != null)
        {
            m3dReferObject.Excute(_parameters);
        }
        base.OnExcute(_parameters);
    }

    protected override void OnRecycle()
    {
        base.OnRecycle();
        if (m2dReferObject != null)
        {
            m2dReferObject.Recycle();
        }
        m2dReferObject = null;

        if(m3dReferObject != null)
        {
            m3dReferObject.Recycle();
        }
        m3dReferObject = null;
    }
}
