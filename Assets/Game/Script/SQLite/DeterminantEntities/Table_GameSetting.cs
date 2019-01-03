using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameSetting实体
/// </summary>
public partial class Table_GameSetting: AbsSQLiteDeterminantEntity
{
	

	
	/// <summary>
	/// 分辨率
	/// </summary>
	public Vector2 resolution { get; private set; }
	/// <summary>
	/// 帧率
	/// </summary>
	public int targetFrameRate { get; private set; }
	/// <summary>
	/// 是否运行引导
	/// </summary>
	public bool isRunGuide { get; private set; }
}