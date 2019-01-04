using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFileExt实体
/// </summary>
public partial class Table_AssetDiskMapingFileExt: AbsSQLiteEntity
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