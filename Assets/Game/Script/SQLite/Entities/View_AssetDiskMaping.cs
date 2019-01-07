using System.Collections.Generic;
using UnityEngine;
using System;
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
	/// fileId
	/// </summary>
	public int fileId { get; private set; }
	/// <summary>
	/// folderId
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// fileName
	/// </summary>
	public string fileName { get; private set; }
	/// <summary>
	/// inAssetPath
	/// </summary>
	public string inAssetPath { get; private set; }
	/// <summary>
	/// outAssetPath
	/// </summary>
	public string outAssetPath { get; private set; }
	/// <summary>
	/// extEnumValue
	/// </summary>
	public int extEnumValue { get; private set; }
}