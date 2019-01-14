using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// AssetDiskMapingFolder实体
/// </summary>
public partial class Table_AssetDiskMapingFolder: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { folderId,}.ToArray(); } }

	
	/// <summary>
	/// 文件夹Id
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// 内部资源路径
	/// </summary>
	public string inSide { get; private set; }
	/// <summary>
	/// 外部资源路径
	/// </summary>
	public string outSide { get; private set; }
}