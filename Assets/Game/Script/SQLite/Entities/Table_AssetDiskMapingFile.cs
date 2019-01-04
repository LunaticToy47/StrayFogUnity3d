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
    public override object[] pks { get { return new List<object>() { fileId,}.ToArray(); } }
	

	
	/// <summary>
	/// 文件id
	/// </summary>
	public int fileId { get; private set; }
	/// <summary>
	/// 文件夹id
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
	/// <summary>
	/// 扩展名id
	/// </summary>
	public int extId { get; private set; }
	/// <summary>
	/// 扩展名枚举值
	/// </summary>
	public int extEnumValue { get; private set; }
}