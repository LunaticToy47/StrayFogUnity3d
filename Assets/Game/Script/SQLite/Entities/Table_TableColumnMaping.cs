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
	/// 
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string strCol { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool boolCol { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int intCol { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public float floatCol { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public byte byteCol { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public short shortCol { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector2 vec2Col { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector3 vec3Col { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector4 vec4Col { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public string[] strColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public bool[] boolColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public int[] intColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public float[] floatColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public byte[] byteColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public short[] shortColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector2[] vec2ColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector3[] vec3ColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public Vector4[] vec4ColArray { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.String strCol2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Boolean boolCol2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Int32 intCol2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Object floatCol2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Byte byteCol2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Int16 shortCol2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Object vec2Col2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Object vec3Col2Array { get; private set; }
	/// <summary>
	/// 
	/// </summary>
	public System.Object vec4Col2Array { get; private set; }
}