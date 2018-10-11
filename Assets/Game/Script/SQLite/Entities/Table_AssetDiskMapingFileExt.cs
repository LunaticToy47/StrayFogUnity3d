using System.Collections.Generic;
/// <summary>
/// AssetDiskMapingFileExt实体
/// </summary>
public partial class Table_AssetDiskMapingFileExt: AbsSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { extId,}.ToArray(); } }
	
	/// <summary>
	/// extId
	/// </summary>
	public System.Int32 extId { get; private set; }
	/// <summary>
	/// ext
	/// </summary>
	public System.String ext { get; private set; }
}