using System.Collections.Generic;
/// <summary>
/// View_DynamicDll实体
/// </summary>
public partial class View_DynamicDll : AbsSQLiteEntity
{
    /// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { }.ToArray(); } }

    /// <summary>
    /// inAssetPath
    /// </summary>
    public System.String inAssetPath { get; private set; }
    /// <summary>
    /// outAssetPath
    /// </summary>
    public System.String outAssetPath { get; private set; }
}