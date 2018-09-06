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
    static readonly Dictionary<int, string> mFileExtMaping = typeof(enFileExt).ValueToAttributeSpecifyValue<FileExtAttribute, string>((a) => { return a.ext; });
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
    }

    /// <summary>
    /// 执行删除File表
    /// </summary>
    /// <returns>执行语句</returns>
    public static string ExecuteDeleteAllFile()
    {
        string sql = "DELETE FROM AssetDiskMapingFile";
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 插入File到SQL数据库
    /// </summary>
    /// <returns>SQL语句</returns>
    public string ExecuteInsertFile()
    {
        string sql = string.Format("INSERT INTO AssetDiskMapingFile (fileId,folderId,inSide,outSide,extId,extEnumValue) VALUES({0},{1},'{2}','{3}',{4},{5});", fileId, folderId, fileInSide, fileOutSide, fileExtHashCode, fileExtEnumValue);
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 文件数据是否在数据库
    /// </summary>
    /// <returns>true:文件存在,false:文件不存在</returns>
    public bool ExistsFile()
    {
        string sql = string.Format("SELECT COUNT(*) FROM AssetDiskMapingFile WHERE  fileId={0} AND folderId = {1};", fileId, folderId);
        Int64 count = (Int64)EditorStrayFogApplication.sqlHelper.ExecuteScalar(sql);
        return count > 0;
    }

    /// <summary>
    /// 执行删除FileExt表
    /// </summary>
    /// <returns>执行语句</returns>
    public static string ExecuteDeleteAllFileExt()
    {
        string sql = "DELETE FROM AssetDiskMapingFileExt";
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 插入FileExt到SQL数据库
    /// </summary>
    /// <returns>SQL语句</returns>
    public string ExecuteInsertFileExt()
    {
        string sql = string.Format("INSERT INTO AssetDiskMapingFileExt (extId,ext) VALUES({0},'{1}')", fileExtHashCode, ext);
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// FileExt数据是否在数据库
    /// </summary>
    /// <returns>true:文件Ext存在,false:文件Ext不存在</returns>
    public bool ExistsFileExt()
    {
        string sql = string.Format("SELECT COUNT(*) FROM AssetDiskMapingFileExt WHERE  extId={0};", fileExtHashCode);
        Int64 count = (Int64)EditorStrayFogApplication.sqlHelper.ExecuteScalar(sql);
        return count > 0;
    }

    /// <summary>
    /// 执行删除Folder表
    /// </summary>
    /// <returns>执行语句</returns>
    public static string ExecuteDeleteAllFolder()
    {
        string sql = "DELETE FROM AssetDiskMapingFolder";
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 插入Folder到SQL数据库
    /// </summary>
    /// <returns>SQL语句</returns>
    public string ExecuteInsertFolder()
    {
        string sql = string.Format("INSERT INTO AssetDiskMapingFolder (folderId,inSide,outSide) VALUES({0},'{1}', '{2}');", folderId, folderInSide, folderOutSide);
        EditorStrayFogApplication.sqlHelper.ExecuteNonQuery(sql);
        return sql;
    }

    /// <summary>
    /// 文件夹数据是否在数据库
    /// </summary>
    /// <returns>true:文件夹存在,false:文件夹不存在</returns>
    public bool ExistsFolder()
    {
        string sql = string.Format("SELECT COUNT(*) FROM AssetDiskMapingFolder WHERE  folderId={0};", folderId);
        Int64 count = (Int64)EditorStrayFogApplication.sqlHelper.ExecuteScalar(sql);
        return count > 0;
    }
}
#endif