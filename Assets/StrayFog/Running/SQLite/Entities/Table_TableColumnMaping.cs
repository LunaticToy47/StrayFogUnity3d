using System.Collections.Generic;
/// <summary>
/// TableColumnMaping实体
/// </summary>
public partial class Table_TableColumnMaping : AbsSQLiteEntity
{
    /// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { pId, }.ToArray(); } }

    /// <summary>
    /// pId
    /// </summary>
    public System.Int32 pId { get; private set; }
    /// <summary>
    /// pByte
    /// </summary>
    public System.Byte pByte { get; private set; }
    /// <summary>
    /// pInt16
    /// </summary>
    public System.Int16 pInt16 { get; private set; }
    /// <summary>
    /// pInt32
    /// </summary>
    public System.Int32 pInt32 { get; private set; }
    /// <summary>
    /// pInt64
    /// </summary>
    public System.Int64 pInt64 { get; private set; }
    /// <summary>
    /// pstring
    /// </summary>
    public System.String pstring { get; private set; }
    /// <summary>
    /// pFloat
    /// </summary>
    public System.Single pFloat { get; private set; }
    /// <summary>
    /// pBytes
    /// </summary>
    public System.Byte[] pBytes { get; private set; }
    /// <summary>
    /// pBool
    /// </summary>
    public System.Boolean pBool { get; private set; }
    /// <summary>
    /// pVector2
    /// </summary>
    public UnityEngine.Vector2 pVector2 { get; private set; }
    /// <summary>
    /// pVector3
    /// </summary>
    public UnityEngine.Vector3 pVector3 { get; private set; }
    /// <summary>
    /// pVector4
    /// </summary>
    public UnityEngine.Vector4 pVector4 { get; private set; }
}