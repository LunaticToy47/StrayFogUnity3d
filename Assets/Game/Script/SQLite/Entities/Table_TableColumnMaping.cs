using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// TableColumnMaping实体
/// </summary>
public partial class Table_TableColumnMaping: AbsSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }
	
	/// <summary>
	/// id
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// strCol
	/// </summary>
	public string strCol { get; private set; }
	/// <summary>
	/// boolCol
	/// </summary>
	public bool boolCol { get; private set; }
	/// <summary>
	/// intCol
	/// </summary>
	public int intCol { get; private set; }
	/// <summary>
	/// floatCol
	/// </summary>
	public float floatCol { get; private set; }
	/// <summary>
	/// byteCol
	/// </summary>
	public byte byteCol { get; private set; }
	/// <summary>
	/// shortCol
	/// </summary>
	public short shortCol { get; private set; }
	/// <summary>
	/// vec2Col
	/// </summary>
	public Vector2 vec2Col { get; private set; }
	/// <summary>
	/// vec3Col
	/// </summary>
	public Vector3 vec3Col { get; private set; }
	/// <summary>
	/// vec4Col
	/// </summary>
	public Vector4 vec4Col { get; private set; }
	/// <summary>
	/// strColArray
	/// </summary>
	public string[] strColArray { get; private set; }
	/// <summary>
	/// boolColArray
	/// </summary>
	public bool[] boolColArray { get; private set; }
	/// <summary>
	/// intColArray
	/// </summary>
	public int[] intColArray { get; private set; }
	/// <summary>
	/// floatColArray
	/// </summary>
	public float[] floatColArray { get; private set; }
	/// <summary>
	/// byteColArray
	/// </summary>
	public byte[] byteColArray { get; private set; }
	/// <summary>
	/// shortColArray
	/// </summary>
	public short[] shortColArray { get; private set; }
	/// <summary>
	/// vec2ColArray
	/// </summary>
	public Vector2[] vec2ColArray { get; private set; }
	/// <summary>
	/// vec3ColArray
	/// </summary>
	public Vector3[] vec3ColArray { get; private set; }
	/// <summary>
	/// vec4ColArray
	/// </summary>
	public Vector4[] vec4ColArray { get; private set; }
	/// <summary>
	/// strCol2Array
	/// </summary>
	public System.String strCol2Array { get; private set; }
	/// <summary>
	/// boolCol2Array
	/// </summary>
	public System.Boolean boolCol2Array { get; private set; }
	/// <summary>
	/// intCol2Array
	/// </summary>
	public System.Int32 intCol2Array { get; private set; }
	/// <summary>
	/// floatCol2Array
	/// </summary>
	public System.Object floatCol2Array { get; private set; }
	/// <summary>
	/// byteCol2Array
	/// </summary>
	public System.Byte byteCol2Array { get; private set; }
	/// <summary>
	/// shortCol2Array
	/// </summary>
	public System.Int16 shortCol2Array { get; private set; }
	/// <summary>
	/// vec2Col2Array
	/// </summary>
	public System.Object vec2Col2Array { get; private set; }
	/// <summary>
	/// vec3Col2Array
	/// </summary>
	public System.Object vec3Col2Array { get; private set; }
	/// <summary>
	/// vec4Col2Array
	/// </summary>
	public System.Object vec4Col2Array { get; private set; }
}