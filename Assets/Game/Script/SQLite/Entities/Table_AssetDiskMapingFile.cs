using System.Collections.Generic;
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
	public System.Int32 fileId { get; private set; }
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
	/// <summary>
	/// extId
	/// </summary>
	public System.Int32 extId { get; private set; }
	/// <summary>
	/// extEnumValue
	/// </summary>
	public System.Int32 extEnumValue { get; private set; }
}