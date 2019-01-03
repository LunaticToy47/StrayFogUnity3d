using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFolder实体
/// </summary>
public partial class Table_AssetDiskMapingFolder: AbsSQLiteEntity
{
	
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { folderId,}.ToArray(); } }
	

	
	/// <summary>
	/// 
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string inSide { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string outSide { get; private set; }
}