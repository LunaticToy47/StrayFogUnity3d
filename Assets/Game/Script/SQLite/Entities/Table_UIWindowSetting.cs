using System.Collections.Generic;
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
	public System.Int32 id { get; private set; }
	/// <summary>
	/// name
	/// </summary>
	public System.String name { get; private set; }
	/// <summary>
	/// fileId
	/// </summary>
	public System.Int32 fileId { get; private set; }
	/// <summary>
	/// folderId
	/// </summary>
	public System.Int32 folderId { get; private set; }
	/// <summary>
	/// renderMode
	/// </summary>
	public System.Int32 renderMode { get; private set; }
	/// <summary>
	/// layer
	/// </summary>
	public System.Int32 layer { get; private set; }
	/// <summary>
	/// openMode
	/// </summary>
	public System.Int32 openMode { get; private set; }
	/// <summary>
	/// closeMode
	/// </summary>
	public System.Int32 closeMode { get; private set; }
	/// <summary>
	/// isIgnoreOpenCloseMode
	/// </summary>
	public System.Boolean isIgnoreOpenCloseMode { get; private set; }
	/// <summary>
	/// isNotAutoRestoreSequenceWindow
	/// </summary>
	public System.Boolean isNotAutoRestoreSequenceWindow { get; private set; }
	/// <summary>
	/// isDonotDestroyInstance
	/// </summary>
	public System.Boolean isDonotDestroyInstance { get; private set; }
	/// <summary>
	/// isImmediateDisplay
	/// </summary>
	public System.Boolean isImmediateDisplay { get; private set; }
	/// <summary>
	/// isManualCloseWhenGotoScene
	/// </summary>
	public System.Boolean isManualCloseWhenGotoScene { get; private set; }
	/// <summary>
	/// isGuideWindow
	/// </summary>
	public System.Boolean isGuideWindow { get; private set; }
}