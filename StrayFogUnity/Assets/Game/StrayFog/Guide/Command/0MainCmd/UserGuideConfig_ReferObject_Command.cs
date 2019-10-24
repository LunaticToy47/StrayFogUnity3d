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
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    protected override void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config,int _index, enGuideStatus _status)
    {
        base.OnResolveConfig(_config, _index, _status);
        m2dReferObject = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer2DType]();
        m2dReferObject.ResolveConfig(guideConfig,_index, _status);
        m2dReferObject.ResolveConfig(_config, _index, _status);

        m3dReferObject = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer3DType]();
        m3dReferObject.ResolveConfig(guideConfig, _index, _status);
        m3dReferObject.ResolveConfig(_config, _index, _status);
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_parameters">参数</param>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected override bool OnIsMatchCondition(params object[] _parameters)
    {
        return base.OnIsMatchCondition(_parameters) && m2dReferObject.isMatchCondition(_parameters) && m3dReferObject.isMatchCondition(_parameters);
    }

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    protected override void OnExcute(params object[] _parameters)
    {
        base.OnExcute(_parameters);
        if (m2dReferObject != null)
        {
            m2dReferObject.Excute(_parameters);
        }
        if (m3dReferObject != null)
        {
            m3dReferObject.Excute(_parameters);
        }        
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
