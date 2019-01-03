using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideValidate实体
/// </summary>
public partial class Table_UserGuideValidate: AbsSQLiteEntity
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
	public int[] conditions { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int[] intValues { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector2[] vector2Values { get; private set; }
}