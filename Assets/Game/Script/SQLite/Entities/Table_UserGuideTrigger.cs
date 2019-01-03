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
	/// 
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string desc { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int nextId { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int guideType { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int displayType { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int levelId { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int[] conditions { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int[] intValues { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int validateId { get; private set; }
}