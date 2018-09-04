using System.Collections.Generic;
/// <summary>
/// SkillBehaviour实体
/// </summary>
public partial class Table_SkillBehaviour : AbsSQLiteEntity
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
    /// desc
    /// </summary>
    public System.String desc { get; private set; }
    /// <summary>
    /// enFmsStateValue
    /// </summary>
    public System.Int32 enFmsStateValue { get; private set; }
    /// <summary>
    /// duration
    /// </summary>
    public System.Single duration { get; private set; }
    /// <summary>
    /// enSkillDestoryCondition
    /// </summary>
    public System.Int32 enSkillDestoryCondition { get; private set; }
    /// <summary>
    /// enSkillDestoryPriority
    /// </summary>
    public System.Int32 enSkillDestoryPriority { get; private set; }
}