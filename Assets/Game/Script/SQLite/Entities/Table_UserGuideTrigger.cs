using System.Collections.Generic;
/// <summary>
/// UserGuideTrigger实体
/// </summary>
public partial class Table_UserGuideTrigger: AbsSQLiteEntity
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
	/// desc
	/// </summary>
	public System.String desc { get; private set; }
	/// <summary>
	/// nextId
	/// </summary>
	public System.Int32 nextId { get; private set; }
	/// <summary>
	/// guideType
	/// </summary>
	public System.Int32 guideType { get; private set; }
	/// <summary>
	/// displayType
	/// </summary>
	public System.Int32 displayType { get; private set; }
	/// <summary>
	/// levelId
	/// </summary>
	public System.Int32 levelId { get; private set; }
	/// <summary>
	/// conditions
	/// </summary>
	public System.Byte[] conditions { get; private set; }
	/// <summary>
	/// intValues
	/// </summary>
	public System.Byte[] intValues { get; private set; }
	/// <summary>
	/// validateId
	/// </summary>
	public System.Int32 validateId { get; private set; }
}