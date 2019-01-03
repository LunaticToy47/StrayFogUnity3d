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
	/// id
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// desc
	/// </summary>
	public string desc { get; private set; }
	/// <summary>
	/// conditions
	/// </summary>
	public int[] conditions { get; private set; }
	/// <summary>
	/// intValues
	/// </summary>
	public int[] intValues { get; private set; }
	/// <summary>
	/// vector2Values
	/// </summary>
	public Vector2[] vector2Values { get; private set; }
}