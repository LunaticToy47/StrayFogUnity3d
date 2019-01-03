using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// View_AssetDiskMaping实体
/// </summary>
public partial class View_AssetDiskMaping: AbsSQLiteEntity
{
	
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }
	

	
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
	public string fileName { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string inAssetPath { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string outAssetPath { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int extEnumValue { get; private set; }
}