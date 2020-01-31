#if UNITY_EDITOR
using System.IO;
/// <summary>
/// XlsSchemaToSQLite选择节点
/// </summary>
public class EditorSelectionXlsSchemaToSQLiteAsset : EditorSelectionAsset
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionXlsSchemaToSQLiteAsset(string _pathOrGuid) : base(_pathOrGuid)
    {
        tableMapingDirectory = Path.Combine(directory, "TableMaping").TransPathSeparatorCharToUnityChar();
        tableAssetConfig = new EditorEngineAssetConfig(nameWithoutExtension, tableMapingDirectory, enFileExt.Asset, typeof(EditorXlsTableSchema).FullName);        
        dbName = (Path.GetFileName(directory) + typeof(enFileExt).GetAttributeForConstField<FileExtAttribute>(enFileExt.SQLiteDb).ext).TransPathSeparatorCharToUnityChar();
        dbPath = Path.Combine(directory, dbName).TransPathSeparatorCharToUnityChar();
    }

    /// <summary>
    /// 解析数据
    /// </summary>
    public void Resolve()
    {
        if (!tableAssetConfig.Exists())
        {
            tableAssetConfig.CreateAsset();
        }
        tableAssetConfig.LoadAsset();
    }

    /// <summary>
    /// 表格映射目录
    /// </summary>
    public string tableMapingDirectory { get; private set; }
    /// <summary>
    /// 数据库名称
    /// </summary>
    public string dbName { get; private set; }
    /// <summary>
    /// 数据库路径
    /// </summary>
    public string dbPath { get; private set; }
    /// <summary>
    /// 表配置资源
    /// </summary>
    public EditorEngineAssetConfig tableAssetConfig { get; private set; }
}
#endif