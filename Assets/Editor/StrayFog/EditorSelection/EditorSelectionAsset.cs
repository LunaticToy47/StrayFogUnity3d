using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 选择的资源
/// </summary>
public class EditorSelectionAsset
{
    #region public 构造函数
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">资源路径或guid</param>
    public EditorSelectionAsset(string _pathOrGuid)
    {
        if (File.Exists(_pathOrGuid))
        {
            path = _pathOrGuid;
            guid = AssetDatabase.AssetPathToGUID(_pathOrGuid);
        }
        else
        {
            guid = _pathOrGuid;
            path = AssetDatabase.GUIDToAssetPath(_pathOrGuid);
        }
        guidHashCode = guid.UniqueHashCode();
        if (File.Exists(path))
        {
            name = Path.GetFileName(path);
            nameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            ext = Path.GetExtension(path);
            directory = Path.GetDirectoryName(path);
            isDirectory = Directory.Exists(directory);
            isFile = File.Exists(path);
        }
        else
        {
            path = guid = string.Empty;
            throw new UnityException(string.Format("The argument is not file path or guid. 【{0}】", _pathOrGuid));
        }
    }
    #endregion

    #region public 属性
    /// <summary>
    /// 资源guid
    /// </summary>
    public string guid { get; private set; }
    /// <summary>
    /// 资源guidHashCode
    /// </summary>
    public int guidHashCode { get; private set; }
    /// <summary>
    /// 资源路径
    /// </summary>
    public string path { get; private set; }
    /// <summary>
    /// 后缀
    /// </summary>
    public string ext { get; private set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 资源名称【无后缀】
    /// </summary>
    public string nameWithoutExtension { get; private set; }
    /// <summary>
    /// 目录
    /// </summary>
    public string directory { get; private set; }
    /// <summary>
    /// 是否是目录
    /// </summary>
    public bool isDirectory { get; private set; }
    /// <summary>
    /// 是否是文件
    /// </summary>
    public bool isFile { get; private set; }
    #endregion
}