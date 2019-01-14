using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// UserGuideValidate实体
/// </summary>
public partial class Table_UserGuideValidate: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id,}.ToArray(); } }

	
	/// <summary>
	/// 标识id
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// 描述
	/// </summary>
	public string desc { get; private set; }
	/// <summary>
	/// 条件
	/// </summary>
	public int[] conditions { get; private set; }
	/// <summary>
	/// 条件Int值
	/// </summary>
	public int[] intValues { get; private set; }
	/// <summary>
	/// 条件Vector2值
	/// </summary>
	public Vector2[] vector2Values { get; private set; }
}