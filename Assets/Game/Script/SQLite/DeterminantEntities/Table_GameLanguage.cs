using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// GameLanguage实体
/// </summary>
public partial class Table_GameLanguage: AbsSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// 引导提示
	/// </summary>
	public string GuideTip { get; private set; }
	/// <summary>
	/// 大厅提示
	/// </summary>
	public string LobbyTip { get; private set; }
}