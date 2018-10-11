using System.Collections.Generic;
/// <summary>
/// GameSetting实体
/// </summary>
public partial class Table_GameSetting: AbsSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id,}.ToArray(); } }
	
	/// <summary>
	/// id
	/// </summary>
	public System.Int32 id { get; private set; }
	/// <summary>
	/// resolution
	/// </summary>
	public UnityEngine.Vector2 resolution { get; private set; }
	/// <summary>
	/// targetFrameRate
	/// </summary>
	public System.Int32 targetFrameRate { get; private set; }
	/// <summary>
	/// isRunGuide
	/// </summary>
	public System.Boolean isRunGuide { get; private set; }
}