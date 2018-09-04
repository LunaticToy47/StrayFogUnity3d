using System.Collections.Generic;
/// <summary>
/// View_AssetDiskMaping实体
/// </summary>
public partial class View_AssetDiskMaping : AbsSQLiteEntity
{
    /// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

    /// <summary>
    /// fileId
    /// </summary>
    public System.Int32 fileId { get; private set; }
    /// <summary>
    /// folderId
    /// </summary>
    public System.Int32 folderId { get; private set; }
    /// <summary>
    /// fileName
    /// </summary>
    public System.String fileName { get; private set; }
    /// <summary>
    /// inAssetPath
    /// </summary>
    public System.String inAssetPath { get; private set; }
    /// <summary>
    /// outAssetPath
    /// </summary>
    public System.String outAssetPath { get; private set; }
    /// <summary>
    /// extEnumValue
    /// </summary>
    public System.Int32 extEnumValue { get; private set; }
}