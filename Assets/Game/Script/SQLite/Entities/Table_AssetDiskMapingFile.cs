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
	/// fileId
	/// </summary>
	public int fileId { get; private set; }
	/// <summary>
	/// folderId
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// inSide
	/// </summary>
	public string inSide { get; private set; }
	/// <summary>
	/// outSide
	/// </summary>
	public string outSide { get; private set; }
	/// <summary>
	/// extId
	/// </summary>
	public int extId { get; private set; }
	/// <summary>
	/// extEnumValue
	/// </summary>
	public int extEnumValue { get; private set; }
}