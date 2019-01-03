using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideTrigger实体
/// </summary>
public partial class Table_UserGuideTrigger: AbsSQLiteEntity
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
	/// desc
	/// </summary>
	public string desc { get; private set; }
	/// <summary>
	/// nextId
	/// </summary>
	public int nextId { get; private set; }
	/// <summary>
	/// guideType
	/// </summary>
	public int guideType { get; private set; }
	/// <summary>
	/// displayType
	/// </summary>
	public int displayType { get; private set; }
	/// <summary>
	/// levelId
	/// </summary>
	public int levelId { get; private set; }
	/// <summary>
	/// conditions
	/// </summary>
	public int[] conditions { get; private set; }
	/// <summary>
	/// intValues
	/// </summary>
	public int[] intValues { get; private set; }
	/// <summary>
	/// validateId
	/// </summary>
	public int validateId { get; private set; }
}