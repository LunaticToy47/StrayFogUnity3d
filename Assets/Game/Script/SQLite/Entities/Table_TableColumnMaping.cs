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
	/// int列
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// string列
	/// </summary>
	public string strCol { get; private set; }
	/// <summary>
	/// bool列
	/// </summary>
	public bool boolCol { get; private set; }
	/// <summary>
	/// int列
	/// </summary>
	public int intCol { get; private set; }
	/// <summary>
	/// float列
	/// </summary>
	public float floatCol { get; private set; }
	/// <summary>
	/// byte列
	/// </summary>
	public byte byteCol { get; private set; }
	/// <summary>
	/// short列
	/// </summary>
	public short shortCol { get; private set; }
	/// <summary>
	/// vector2列
	/// </summary>
	public Vector2 vec2Col { get; private set; }
	/// <summary>
	/// vector3列
	/// </summary>
	public Vector3 vec3Col { get; private set; }
	/// <summary>
	/// vector4列
	/// </summary>
	public Vector4 vec4Col { get; private set; }
	/// <summary>
	/// string一维数组列
	/// </summary>
	public string[] strColArray { get; private set; }
	/// <summary>
	/// bool一维数组列
	/// </summary>
	public bool[] boolColArray { get; private set; }
	/// <summary>
	/// int一维数组列
	/// </summary>
	public int[] intColArray { get; private set; }
	/// <summary>
	/// float一维数组列
	/// </summary>
	public float[] floatColArray { get; private set; }
	/// <summary>
	/// byte一维数组列
	/// </summary>
	public byte[] byteColArray { get; private set; }
	/// <summary>
	/// short一维数组列
	/// </summary>
	public short[] shortColArray { get; private set; }
	/// <summary>
	/// vector2一维数组列
	/// </summary>
	public Vector2[] vec2ColArray { get; private set; }
	/// <summary>
	/// vector3一维数组列
	/// </summary>
	public Vector3[] vec3ColArray { get; private set; }
	/// <summary>
	/// vector4一维数组列
	/// </summary>
	public Vector4[] vec4ColArray { get; private set; }
	/// <summary>
	/// string二维数组列
	/// </summary>
	public System.String strCol2Array { get; private set; }
	/// <summary>
	/// bool二维数组列
	/// </summary>
	public System.Boolean boolCol2Array { get; private set; }
	/// <summary>
	/// int二维数组列
	/// </summary>
	public System.Int32 intCol2Array { get; private set; }
	/// <summary>
	/// float二维数组列
	/// </summary>
	public System.Object floatCol2Array { get; private set; }
	/// <summary>
	/// byte二维数组列
	/// </summary>
	public System.Byte byteCol2Array { get; private set; }
	/// <summary>
	/// short二维数组列
	/// </summary>
	public System.Int16 shortCol2Array { get; private set; }
	/// <summary>
	/// vector2二维数组列
	/// </summary>
	public System.Object vec2Col2Array { get; private set; }
	/// <summary>
	/// vector3二维数组列
	/// </summary>
	public System.Object vec3Col2Array { get; private set; }
	/// <summary>
	/// vector4二维数组列
	/// </summary>
	public System.Object vec4Col2Array { get; private set; }
}