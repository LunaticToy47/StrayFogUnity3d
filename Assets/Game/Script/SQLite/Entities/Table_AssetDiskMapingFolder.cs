using System.Collections.Generic;
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
	/// folderId
	/// </summary>
	public System.Int32 folderId { get; private set; }
	/// <summary>
	/// inSide
	/// </summary>
	public System.String inSide { get; private set; }
	/// <summary>
	/// outSide
	/// </summary>
	public System.String outSide { get; private set; }
}