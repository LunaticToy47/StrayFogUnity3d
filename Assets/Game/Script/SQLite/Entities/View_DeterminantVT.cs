using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
public partial class View_DeterminantVT: AbsSQLiteEntity
{
	
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }
	

	
	/// <summary>
	/// 
	/// </summary>
	public string vtName { get; private set; }
}