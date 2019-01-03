using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UIWindowSetting实体
/// </summary>
public partial class Table_UIWindowSetting: AbsSQLiteEntity
{
	
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id,}.ToArray(); } }
	

	
	/// <summary>
	/// 
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string name { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int fileId { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int renderMode { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int layer { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int openMode { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int closeMode { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool isIgnoreOpenCloseMode { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool isNotAutoRestoreSequenceWindow { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool isDonotDestroyInstance { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool isImmediateDisplay { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool isManualCloseWhenGotoScene { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool isGuideWindow { get; private set; }
}