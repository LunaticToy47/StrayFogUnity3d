using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// AssetDiskMapingFile实体
/// </summary>
public partial class Table_AssetDiskMapingFile: AbsSQLiteEntity
{
	
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { fileId,folderId,}.ToArray(); } }
	

	
	/// <summary>
	/// 
	/// </summary>
	public int fileId { get; private set; }
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
	/// <summary>
	/// 
	/// </summary>
	public int extId { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int extEnumValue { get; private set; }
}