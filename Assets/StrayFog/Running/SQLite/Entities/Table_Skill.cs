using System.Collections.Generic;
/// <summary>
/// Skill实体
/// </summary>
public partial class Table_Skill : AbsSQLiteEntity
{
    /// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id, }.ToArray(); } }

    /// <summary>
    /// id
    /// </summary>
    public System.Int32 id { get; private set; }
    /// <summary>
    /// name
    /// </summary>
    public System.String name { get; private set; }
    /// <summary>
    /// iconFileId
    /// </summary>
    public System.Int32 iconFileId { get; private set; }
    /// <summary>
    /// iconFolderId
    /// </summary>
    public System.Int32 iconFolderId { get; private set; }
    /// <summary>
    /// enSkillFireMode
    /// </summary>
    public System.Int32 enSkillFireMode { get; private set; }
    /// <summary>
    /// cooldown
    /// </summary>
    public System.Single cooldown { get; private set; }
    /// <summary>
    /// limitLevel
    /// </summary>
    public System.Int32 limitLevel { get; private set; }
    /// <summary>
    /// limitStar
    /// </summary>
    public System.Int32 limitStar { get; private set; }
    /// <summary>
    /// autoFireWeight
    /// </summary>
    public System.Single autoFireWeight { get; private set; }
    /// <summary>
    /// manulCancelTime
    /// </summary>
    public System.Single manulCancelTime { get; private set; }
    /// <summary>
    /// isAutoForwardCastingTarget
    /// </summary>
    public System.Boolean isAutoForwardCastingTarget { get; private set; }
    /// <summary>
    /// enSkillPromptShape
    /// </summary>
    public System.Int32 enSkillPromptShape { get; private set; }
    /// <summary>
    /// PromptShapeWide
    /// </summary>
    public System.Single PromptShapeWide { get; private set; }
    /// <summary>
    /// PromptShapeLength
    /// </summary>
    public System.Single PromptShapeLength { get; private set; }
    /// <summary>
    /// PromptShapeRadius
    /// </summary>
    public System.Single PromptShapeRadius { get; private set; }
    /// <summary>
    /// PromptShapeAngle
    /// </summary>
    public System.Single PromptShapeAngle { get; private set; }
}