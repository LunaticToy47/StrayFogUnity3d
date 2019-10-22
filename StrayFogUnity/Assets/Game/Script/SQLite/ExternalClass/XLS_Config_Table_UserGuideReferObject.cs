/// <summary>
/// XLS_Config_Table_UserGuideReferObject扩展
/// </summary>
public partial class XLS_Config_Table_UserGuideReferObject
{
    /// <summary>
    /// 2D动态组件搜索条件类别
    /// </summary>
    public enUserGuideReferObject_Refer2DSearchDynamicConditionType enRefer2DSearchDynamicConditionType { get; private set; }
    
    /// <summary>
    /// 2D参考类型
    /// </summary>
    public enUserGuideReferObject_Refer2DType enRefer2DType { get; private set; }

    /// <summary>
    /// 3D参考类型
    /// </summary>
    public enUserGuideReferObject_Refer3DType enRefer3DType { get; private set; }

    /// <summary>
    /// OnResolve
    /// </summary>
    protected override void OnResolve()
    {
        enRefer2DSearchDynamicConditionType = (enUserGuideReferObject_Refer2DSearchDynamicConditionType)refer2DSearchDynamicConditionType;
        enRefer2DType = (enUserGuideReferObject_Refer2DType)refer2DType;
        enRefer3DType = (enUserGuideReferObject_Refer3DType)refer3DType;
        base.OnResolve();
    }
}