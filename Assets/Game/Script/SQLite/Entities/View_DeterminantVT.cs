using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// View_DeterminantVT实体
/// </summary>
public partial class View_DeterminantVT: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

	
	/// <summary>
	/// vtName
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string vtName { get; private set; }
}