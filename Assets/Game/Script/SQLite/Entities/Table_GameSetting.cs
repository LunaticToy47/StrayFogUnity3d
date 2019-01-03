using System.Collections.Generic;
using UnityEngine;
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
	public int id { get; private set; }
	/// <summary>
	/// resolution
	/// </summary>
	public Vector2 resolution { get; private set; }
	/// <summary>
	/// targetFrameRate
	/// </summary>
	public int targetFrameRate { get; private set; }
	/// <summary>
	/// isRunGuide
	/// </summary>
	public bool isRunGuide { get; private set; }
}