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
	/// id
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// name
	/// </summary>
	public string name { get; private set; }
	/// <summary>
	/// folderId
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// fileId
	/// </summary>
	public int fileId { get; private set; }
	/// <summary>
	/// renderMode
	/// </summary>
	public int renderMode { get; private set; }
	/// <summary>
	/// layer
	/// </summary>
	public int layer { get; private set; }
	/// <summary>
	/// openMode
	/// </summary>
	public int openMode { get; private set; }
	/// <summary>
	/// closeMode
	/// </summary>
	public int closeMode { get; private set; }
	/// <summary>
	/// isIgnoreOpenCloseMode
	/// </summary>
	public bool isIgnoreOpenCloseMode { get; private set; }
	/// <summary>
	/// isNotAutoRestoreSequenceWindow
	/// </summary>
	public bool isNotAutoRestoreSequenceWindow { get; private set; }
	/// <summary>
	/// isDonotDestroyInstance
	/// </summary>
	public bool isDonotDestroyInstance { get; private set; }
	/// <summary>
	/// isImmediateDisplay
	/// </summary>
	public bool isImmediateDisplay { get; private set; }
	/// <summary>
	/// isManualCloseWhenGotoScene
	/// </summary>
	public bool isManualCloseWhenGotoScene { get; private set; }
	/// <summary>
	/// isGuideWindow
	/// </summary>
	public bool isGuideWindow { get; private set; }
}