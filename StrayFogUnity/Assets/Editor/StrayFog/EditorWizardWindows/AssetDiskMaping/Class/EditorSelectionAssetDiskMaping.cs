#if UNITY_EDITOR
using System.IO;
using System.Collections.Generic;
using System;
/// <summary>
/// 磁盘资源映射选择资源
/// </summary>
public class EditorSelectionAssetDiskMaping : EditorSelectionAssetBundleNameAsset
{
    /// <summary>
    /// 文件后缀映射
    /// </summary>
    static readonly Dictionary<int, string> mFileExtMaping = typeof(enFileExt).ValueToAttributeSpecifyValueForConstField<FileExtAttribute, string>((a) => { return a.ext; });
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionAssetDiskMaping(string _pathOrGuid) : base(_pathOrGuid)
    {
        fileExtHashCode = ext.GetHashCode();
        foreach (KeyValuePair<int, string> key in mFileExtMaping)
        {
            if (key.Value.Equals(ext))
            {
                fileExtEnumValue = key.Key;
                break;
            }
        }
    }
    /// <summary>
    /// 文件夹id
    /// </summary>
    public int folderId { get; private set; }
    /// <summary>
    /// 文件夹枚举名称
    /// </summary>
    public string folderEnumName { get; private set; }
    /// <summary>
    /// 文件夹内部名称
    /// </summary>
    public string folderInSide { get; private set; }
    /// <summary>
    /// 文件夹外部名称
    /// </summary>
    public string folderOutSide { get; private set; }
    /// <summary>
    /// 文件id
    /// </summary>
    public int fileId { get; private set; }
    /// <summary>
    /// 文件枚举名称
    /// </summary>
    public string fileEnumName { get; private set; }
    /// <summary>
    /// 文件脚本枚举名称
    /// </summary>
    public string fileScriptEnumName { get; private set; }
    /// <summary>
    /// 文件内部名称
    /// </summary>
    public string fileInSide { get; private set; }
    /// <summary>
    /// 文件外部名称
    /// </summary>
    public string fileOutSide { get; private set; }
    /// <summary>
    /// 文件后缀HashCode
    /// </summary>
    public int fileExtHashCode { get; private set; }
    /// <summary>
    /// 文件后缀枚举值
    /// </summary>
    public int fileExtEnumValue { get; private set; }

    /// <summary>
    /// 解析
    /// </summary>
    public void Resolve()
    {
        fileEnumName = EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(name);
        fileId = fileEnumName.UniqueHashCode();
        fileScriptEnumName = "f_" + EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(fileEnumName).Replace(".", "_");
        fileInSide = Path.GetFileNameWithoutExtension(name);
        fileOutSide = GetAssetBundleName();
        folderEnumName = EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(directory);
        folderId = folderEnumName.UniqueHashCode();
        folderInSide = directory;
        if (!string.IsNullOrEmpty(fileOutSide))
        {
            folderOutSide = Path.GetDirectoryName(fileOutSide);
        }
        OnResolve();
    }
    /// <summary>
    /// 解析
    /// </summary>
    protected virtual void OnResolve() { }
}
#endif