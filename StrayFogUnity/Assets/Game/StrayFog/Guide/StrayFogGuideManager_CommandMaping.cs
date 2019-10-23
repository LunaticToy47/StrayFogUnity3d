using System;
using System.Collections.Generic;
/// <summary>
/// 引导管理器[命令映射]
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// UserGuideConfig表引导类型命令映射
    /// </summary>
    public readonly static Dictionary<int, Func<AbsGuideCommand>> Cmd_UserGuideConfig_GuideTypeMaping = new Dictionary<int, Func<AbsGuideCommand>>()
    {
        { (int)enUserGuideConfig_GuideType.Strong,()=>{ return new UserGuideConfig_GuideType_Strong_Command(); } },
        { (int)enUserGuideConfig_GuideType.Weakness,()=>{ return new UserGuideConfig_GuideType_Weakness_Command(); } },
    };

    /// <summary>
    /// UserGuideConfig表触发条件类型命令映射
    /// Key:enUserGuideConfig_TriggerConditionType
    /// Value:AbsGuideSubCommand_Condition
    /// </summary>
    public readonly static Dictionary<int, Func<AbsGuideSubCommand_Condition>> Cmd_UserGuideConfig_TriggerConditionTypeMaping = new Dictionary<int, Func<AbsGuideSubCommand_Condition>>()
    {
        { (int)enUserGuideConfig_TriggerConditionType.Equip,()=>{ return new UserGuideConfig_TriggerCondition_Equip(); } },
        { (int)enUserGuideConfig_TriggerConditionType.Item,()=>{ return new UserGuideConfig_TriggerCondition_Item(); } },
        { (int)enUserGuideConfig_TriggerConditionType.PlayerLv,()=>{ return new UserGuideConfig_TriggerCondition_PlayerLv(); } },
        { (int)enUserGuideConfig_TriggerConditionType.PlayerStatus,()=>{ return new UserGuideConfig_TriggerCondition_PlayerStatus(); } },
        { (int)enUserGuideConfig_TriggerConditionType.ReferObject,()=>{ return new UserGuideConfig_TriggerCondition_ReferObject(); } },
        { (int)enUserGuideConfig_TriggerConditionType.Task,()=>{ return new UserGuideConfig_TriggerCondition_Task(); } },
    };

    /// <summary>
    /// UserGuideReferObject表2D参考对象命令映射
    /// Key:enUserGuideReferObject_Refer2DType
    /// Value:AbsGuideSubCommand_ReferObject
    /// </summary>
    public readonly static Dictionary<int, Func<AbsGuideSubCommand_ReferObject>> Cmd_UserGuideReferObject_Refer2DTypeMaping = new Dictionary<int, Func<AbsGuideSubCommand_ReferObject>>()
    {
        { (int)enUserGuideReferObject_Refer2DType.None,()=>{ return new UserGuideReferObject_None_Command(); } },
        { (int)enUserGuideReferObject_Refer2DType.UIWindowControl,()=>{ return new UserGuideReferObject_Refer2DType_UIWindowControl_Command(); } },
        { (int)enUserGuideReferObject_Refer2DType.UIWindowDynamicControl,()=>{ return new UserGuideReferObject_Refer2DType_UIWindowDynamicControl_Command(); } },
    };

    /// <summary>
    /// UserGuideReferObject表2D动态组件搜索条件命令映射
    /// Key:enUserGuideReferObject_Refer2DSearchDynamicConditionType
    /// Value:AbsGuideSubCommand_Condition
    /// </summary>
    public readonly static Dictionary<int, Func<AbsGuideSubCommand_Condition>> Cmd_UserGuideReferObject_Refer2DSearchDynamicConditionTypeMaping = new Dictionary<int, Func<AbsGuideSubCommand_Condition>>()
    {
        { (int)enUserGuideReferObject_Refer2DSearchDynamicConditionType.Equip,()=>{ return new UserGuideReferObject_Refer2DType_UIWindowDynamicControl_Condition_Command_Equip(); } },
        { (int)enUserGuideReferObject_Refer2DSearchDynamicConditionType.Index,()=>{ return new UserGuideReferObject_Refer2DType_UIWindowDynamicControl_Condition_Command_Index(); } },
        { (int)enUserGuideReferObject_Refer2DSearchDynamicConditionType.Item,()=>{ return new UserGuideReferObject_Refer2DType_UIWindowDynamicControl_Condition_Command_Item(); } },
    };

    /// <summary>
    /// UserGuideReferObject表3D参考对象命令映射
    /// Key:enUserGuideReferObject_Refer2DType
    /// Value:AbsGuideSubCommand_ReferObject
    /// </summary>
    public readonly static Dictionary<int, Func<AbsGuideSubCommand_ReferObject>> Cmd_UserGuideReferObject_Refer3DTypeMaping = new Dictionary<int, Func<AbsGuideSubCommand_ReferObject>>()
    {
        { (int)enUserGuideReferObject_Refer3DType.None,()=>{ return new UserGuideReferObject_None_Command(); } },
        { (int)enUserGuideReferObject_Refer3DType.Boss,()=>{ return new UserGuideReferObject_Refer3DType_Boss_Command(); } },
        { (int)enUserGuideReferObject_Refer3DType.Coordinate,()=>{ return new UserGuideReferObject_Refer3DType_Coordinate_Command(); } },
        { (int)enUserGuideReferObject_Refer3DType.Item,()=>{ return new UserGuideReferObject_Refer3DType_Item_Command(); } },
        { (int)enUserGuideReferObject_Refer3DType.Monster,()=>{ return new UserGuideReferObject_Refer3DType_Monster_Command(); } },
        { (int)enUserGuideReferObject_Refer3DType.NPC,()=>{ return new UserGuideReferObject_Refer3DType_NPC_Command(); } },
        { (int)enUserGuideReferObject_Refer3DType.Player,()=>{ return new UserGuideReferObject_Refer3DType_Player_Command(); } },
    };

    /// <summary>
    /// UserGuideConfig表验证条件类型命令映射
    /// Key:enUserGuideConfig_ValidateConditionType
    /// Value:AbsGuideSubCommand_Condition
    /// </summary>
    public readonly static Dictionary<int, Func<AbsGuideSubCommand_Condition>> Cmd_UserGuideConfig_ValidateConditionTypeMaping = new Dictionary<int, Func<AbsGuideSubCommand_Condition>>()
    {
        { (int)enUserGuideConfig_ValidateConditionType.Click,()=>{ return new UserGuideConfig_ValidateCondition_ClickReferObject(); } },
        { (int)enUserGuideConfig_ValidateConditionType.Drag,()=>{ return new UserGuideConfig_ValidateCondition_DragReferObject(); } },
        { (int)enUserGuideConfig_ValidateConditionType.MoveTo,()=>{ return new UserGuideConfig_ValidateCondition_MoveToReferObject(); } },
    };
}
