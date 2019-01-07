using System.Collections.Generic;
using UnityEngine;
using System;
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
	/// 标识id
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// 描述
	/// </summary>
	public string desc { get; private set; }
	/// <summary>
	/// 下一引导id
	/// </summary>
	public int nextId { get; private set; }
	/// <summary>
	/// 引导类型
	/// </summary>
	public int guideType { get; private set; }
	/// <summary>
	/// 显示类型
	/// </summary>
	public int displayType { get; private set; }
	/// <summary>
	/// 关卡id
	/// </summary>
	public int levelId { get; private set; }
	/// <summary>
	/// 条件
	/// </summary>
	public int[] conditions { get; private set; }
	/// <summary>
	/// 条件Int值
	/// </summary>
	public int[] intValues { get; private set; }
	/// <summary>
	/// 验证id
	/// </summary>
	public int validateId { get; private set; }
}