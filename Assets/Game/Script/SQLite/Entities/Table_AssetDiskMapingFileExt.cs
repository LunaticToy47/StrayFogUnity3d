using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// AssetDiskMapingFileExt实体
/// </summary>
public partial class Table_AssetDiskMapingFileExt: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { extId,}.ToArray(); } }

	
	/// <summary>
	/// 扩展名id
	/// </summary>
	public int extId { get; private set; }
	/// <summary>
	/// 扩展名
	/// </summary>
	public string ext { get; private set; }
}