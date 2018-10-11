using System.Collections.Generic;
/// <summary>
/// View_UserGuideValidate实体
/// </summary>
public partial class View_UserGuideValidate: AbsSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }
	
	/// <summary>
	/// id
	/// </summary>
	public System.Int32 id { get; private set; }
	/// <summary>
	/// desc
	/// </summary>
	public System.String desc { get; private set; }
	/// <summary>
	/// conditions
	/// </summary>
	public System.Byte[] conditions { get; private set; }
	/// <summary>
	/// intValues
	/// </summary>
	public System.Byte[] intValues { get; private set; }
	/// <summary>
	/// vector2Values
	/// </summary>
	public System.Byte[] vector2Values { get; private set; }
}