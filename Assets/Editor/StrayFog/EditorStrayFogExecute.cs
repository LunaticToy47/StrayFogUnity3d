#if UNITY_EDITOR
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 执行工具
/// </summary>
public sealed class EditorStrayFogExecute
{
    #region ExecuteSetAssetBundleName 设置AssetBundleName
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    public static void ExecuteSetAssetBundleName()
    {
        EditorSetAssetBundleNameConfig cfg = EditorStrayFogSavedConfigAssetFile.setAssetBundleName;
        if (cfg.file != null)
        {
            string error = string.Empty;
            List<EditorSelectionAssetBundleNameAsset> nodes = EditorStrayFogUtility.assetBundleName.Collect<EditorSelectionAssetBundleNameAsset>(cfg.file.folders, out error);
            if (string.IsNullOrEmpty(error))
            {
                StringBuilder sbLog = new StringBuilder();
                if (nodes != null && nodes.Count > 0)
                {
                    float progress = 0;
                    Dictionary<int, EditorSelectionAssetBundleNameAsset> nodeMaping = new Dictionary<int, EditorSelectionAssetBundleNameAsset>();
                    #region 构建拓扑起始节点                        
                    foreach (EditorSelectionAssetBundleNameAsset n in nodes)
                    {
                        if (!nodeMaping.ContainsKey(n.guidHashCode))
                        {
                            nodeMaping.Add(n.guidHashCode, n);
                        }
                        progress++;
                        EditorUtility.DisplayProgressBar("Build Topolopy Node", n.path, progress / nodes.Count);
                    }
                    #endregion

                    #region 构建依赖链      
                    progress = 0;
                    foreach (EditorSelectionAssetBundleNameAsset n in nodes)
                    {
                        n.BuildDependencyLink(nodeMaping);
                        progress++;
                        EditorUtility.DisplayProgressBar("Build DependencyLink", n.path, progress / nodes.Count);
                    }
                    #endregion

                    #region 收缩合并                        
                    OnRecursiveShrinkMerge(nodeMaping);
                    #endregion

                    #region 设置AssetBundleName
                    progress = 0;
                    foreach (EditorSelectionAssetBundleNameAsset n in nodeMaping.Values)
                    {
                        progress++;
                        n.SaveAssetBundleName(null);
                        EditorUtility.DisplayProgressBar("Set AssetBundleName", n.path, progress / nodeMaping.Count);
                    }
                    #endregion

                    EditorUtility.ClearProgressBar();
                    AssetDatabase.SaveAssets();
                    AssetDatabase.RemoveUnusedAssetBundleNames();
                    EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();

                    #region 节点日志
                    progress++;
                    foreach (EditorSelectionAssetBundleNameAsset n in nodeMaping.Values)
                    {
                        sbLog.AppendLine(n.ToLog());
                        EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodeMaping.Count);
                    }
                    if (EditorStrayFogApplication.IsExecuteMethodInCmd())
                    {
                        Debug.Log(sbLog.ToString());
                    }
                    else
                    {
                        string logFilename = Path.Combine(Path.GetTempPath(), "AssetBundleName.log");
                        File.WriteAllText(logFilename, sbLog.ToString());
                        Debug.LogFormat("Log=>{0}", logFilename);
                    }
                    #endregion
                }
            }
            else
            {
                Debug.LogError(error);
            }
        }

        Debug.Log("ExecuteSetAssetBundleName Succeed!");
    }

    /// <summary>
    /// 递归收缩合并
    /// </summary>
    /// <param name="_nodeMaping">需要合并的节点</param>
    static void OnRecursiveShrinkMerge(Dictionary<int, EditorSelectionAssetBundleNameAsset> _nodeMaping)
    {
        float progress = 0;
        List<int> clear = new List<int>();
        foreach (KeyValuePair<int, EditorSelectionAssetBundleNameAsset> key in _nodeMaping)
        {
            if (key.Value.ShrinkMerge() && !clear.Contains(key.Key))
            {
                clear.Add(key.Key);
            }
            progress++;
            EditorUtility.DisplayProgressBar("Recursive Shrink Merge", key.Value.path, progress / _nodeMaping.Count);
        }
        if (clear.Count > 0)
        {
            foreach (int c in clear)
            {
                _nodeMaping.Remove(c);
            }
            OnRecursiveShrinkMerge(_nodeMaping);
        }
    }
    #endregion

    #region ExecuteClearAssetBundleName 清除AssetBundleName
    /// <summary>
    /// 清除AssetBundleName
    /// </summary>
    public static void ExecuteClearAssetBundleName()
    {
        EditorSetAssetBundleNameConfig cfg = EditorStrayFogSavedConfigAssetFile.setAssetBundleName;
        StringBuilder sbErrorLog = new StringBuilder();
        if (cfg.file != null)
        {
            string error = string.Empty;
            List<EditorSelectionAssetBundleNameAsset> nodes = EditorStrayFogUtility.assetBundleName.Collect<EditorSelectionAssetBundleNameAsset>(cfg.file.folders, out error);
            if (string.IsNullOrEmpty(error))
            {
                if (nodes != null && nodes.Count > 0)
                {
                    float progress = 0;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        progress++;
                        nodes[i].ClearAssetBundleName();
                        EditorUtility.DisplayProgressBar("Clear AssetBundleName", nodes[i].name + "=>" + nodes[i].path, progress / nodes.Count);
                    }
                    EditorUtility.ClearProgressBar();
                    AssetDatabase.SaveAssets();
                    AssetDatabase.RemoveUnusedAssetBundleNames();
                    EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
                }
            }
            else
            {
                Debug.LogError(error);
            }
        }
        Debug.Log("ExecuteClearAssetBundleName Succeed!");
    }
    #endregion

    #region ExecuteClearAllAssetBundleName 清除所有的AssetBundleName
    /// <summary>
    /// 清除所有的AssetBundleName
    /// </summary>
    public static void ExecuteClearAllAssetBundleName()
    {
        string[] names = AssetDatabase.GetAllAssetBundleNames();
        if (names != null && names.Length > 0)
        {
            float progress = 0;
            for (int i = 0; i < names.Length; i++)
            {
                progress++;
                AssetDatabase.RemoveAssetBundleName(names[i], true);
                EditorUtility.DisplayProgressBar("Clear All AssetBundleName", names[i], progress / names.Length);
            }
            AssetDatabase.RemoveUnusedAssetBundleNames();
            AssetDatabase.SaveAssets();
            EditorUtility.ClearProgressBar();
        }
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log("ExecuteClearAllAssetBundleName Succeed!");
    }
    #endregion

    #region ExecuteSetSpritePackingTag 设置SpritePackingTage
    /// <summary>
    /// 设置SpritePackingTage
    /// </summary>
    public static void ExecuteSetSpritePackingTag()
    {
        EditorSetSpritePackingTagConfig cfg = EditorStrayFogSavedConfigAssetFile.setSpritePackingTag;
        StringBuilder sbErrorLog = new StringBuilder();
        if (cfg.file != null)
        {
            List<EditorSelectionSpritePackingTagAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionSpritePackingTagAsset>(cfg.file.folders, enEditorAssetFilterClassify.Texture2D);
            float progress = 0;
            foreach (EditorSelectionSpritePackingTagAsset n in nodes)
            {
                progress++;
                n.SaveSpritePackingTag();
                EditorUtility.DisplayProgressBar("Save Sprite Packing Tag", n.path, progress / nodes.Count);
            }
            EditorUtility.ClearProgressBar();
            AssetDatabase.SaveAssets();
            EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        }
        Debug.Log("ExecuteSetSpritePackingTag Succeed!");
    }
    #endregion

    #region ExecuteClearSpritePackingTag 清除SpritePackingTag
    /// <summary>
    /// 清除SpritePackingTag
    /// </summary>
    /// <returns>执行节点</returns>
    public static void ExecuteClearSpritePackingTag()
    {
        EditorSetSpritePackingTagConfig cfg = EditorStrayFogSavedConfigAssetFile.setSpritePackingTag;
        StringBuilder sbErrorLog = new StringBuilder();
        if (cfg.file != null)
        {
            List<EditorSelectionSpritePackingTagAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionSpritePackingTagAsset>(cfg.file.folders, enEditorAssetFilterClassify.Texture2D);
            float progress = 0;
            foreach (EditorSelectionSpritePackingTagAsset n in nodes)
            {
                progress++;
                n.ClearSpritePackingTag();
                EditorUtility.DisplayProgressBar("Clear Sprite Packing Tag", n.path, progress / nodes.Count);
            }
            EditorUtility.ClearProgressBar();
            AssetDatabase.SaveAssets();
            EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        }
        Debug.Log("ExecuteClearSpritePackingTag Succeed!");
    }
    #endregion

    #region ExecuteClearAllSpritePackingTag 清除所有SpritePackingTag
    /// <summary>
    /// 清除所有SpritePackingTag
    /// </summary>
    public static void ExecuteClearAllSpritePackingTag()
    {
        StringBuilder sbErrorLog = new StringBuilder();
        List<EditorSelectionSpritePackingTagAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionSpritePackingTagAsset>(
            new string[1] { Path.GetFileName(Application.dataPath) }, enEditorAssetFilterClassify.Texture2D);
        float progress = 0;
        foreach (EditorSelectionSpritePackingTagAsset n in nodes)
        {
            progress++;
            n.ClearSpritePackingTag();
            EditorUtility.DisplayProgressBar("Clear Sprite Packing Tag", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log("ExecuteClearAllSpritePackingTag Succeed!");
    }
    #endregion

    #region ExecuteLookPackageDll 查看要打包的dll
    /// <summary>
    /// 查看要打包的dll
    /// </summary>
    /// <returns>执行节点</returns>
    public static List<EditorSelectionAssetBundleNameAsset> ExecuteLookPackageDll()
    {
        List<EditorSelectionAssetBundleNameAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAssetBundleNameAsset>(
            new string[1] { enEditorApplicationFolder.Game.GetAttribute<EditorApplicationFolderAttribute>().path }, "", false,
            (n) => { return EditorStrayFogUtility.assetBundleName.IsDllPlugins(n); });
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Package Dll");
        float progress = 0;
        foreach (EditorSelectionAssetBundleNameAsset n in nodes)
        {
            progress++;
            sbLog.AppendLine(n.path);
            EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        Debug.Log(sbLog.ToString());
        Debug.Log("ExecuteLookPackageDll Succeed!");
        return nodes;
    }
    #endregion

    #region ExecuteBuildDllToPackage 生成dll到包
    /// <summary>
    /// 生成dll到包
    /// </summary>
    public static void ExecuteBuildDllToPackage()
    {
        float progress = 0;
        List<EditorSelectionAssetBundleNameAsset> nodes = ExecuteLookPackageDll();
        foreach (EditorSelectionAssetBundleNameAsset n in nodes)
        {
            progress++;
            if (!string.IsNullOrEmpty(n.GetAssetBundleName()))
            {
                File.Copy(n.path, Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, n.GetAssetBundleName()));
            }
            else
            {
                Debug.LogErrorFormat("Dll 【{0}】's AssetBundleName is empty.", n.path);
            }
            EditorUtility.DisplayProgressBar("Build Log", n.path, progress / nodes.Count);
        }
        EditorUtility.ClearProgressBar();
        Debug.Log("ExecuteBuildDllToPackage Succeed!");
    }
    #endregion

    #region ExecuteBuildSQLiteEntity 生成SQLite实体
    /// <summary>
    /// 特殊实体数据类型
    /// </summary>
    readonly static Dictionary<string, string> msrSpecialEntityDataType = new Dictionary<string, string>() {
            { typeof(Vector2).Name ,typeof(Vector2).FullName },
            { typeof(Vector3).Name ,typeof(Vector3).FullName },
            { typeof(Vector4).Name ,typeof(Vector4).FullName },
        };
    /// <summary>
    /// 生成SQLite实体
    /// </summary>
    public static void ExecuteBuildSQLiteEntity()
    {
        string sqliteFolder = Path.GetFullPath(enEditorApplicationFolder.Game_Script_SQLite.GetAttribute<EditorApplicationFolderAttribute>().path);
        string sqliteEntityFolder = Path.Combine(sqliteFolder, "Entities");
        string sqliteDeterminantEntitiesFolder = Path.Combine(sqliteFolder, "DeterminantEntities");

        EditorStrayFogUtility.cmd.DeleteFolder(sqliteEntityFolder);
        EditorStrayFogUtility.cmd.DeleteFolder(sqliteDeterminantEntitiesFolder);

        StringBuilder sbLog = new StringBuilder();
        List<SQLiteEntity> entities = new List<SQLiteEntity>();
        SqliteDataReader pragmaReader = null;
        SqliteDataReader schemaReader = null;
        SQLiteEntity tempEntity = null;
        SQLiteEntityProperty tempEntityProperty = null;
        string tempEntityName = string.Empty;
        string tempEntityType = string.Empty;
        bool tempIsDetermainant = false;
        Type tempPropertyType = null;
        Dictionary<string, enSQLiteEntityClassify> classifyMaping = typeof(enSQLiteEntityClassify).NameToEnum<enSQLiteEntityClassify>();
        enSQLiteEntityClassify tempEntityClassify = enSQLiteEntityClassify.Table;
        float progress = 0;
        #region 收集实体            
        Int64 count = EditorStrayFogApplication.sqlHelper.ReadEntityNamesCount();
        SqliteDataReader tableNameReader = EditorStrayFogApplication.sqlHelper.ReadEntityNames();
        while (tableNameReader.Read())
        {
            progress++;
            tempEntityName = tableNameReader.GetString(tableNameReader.GetOrdinal("tbl_name"));
            tempEntityType = tableNameReader.GetString(tableNameReader.GetOrdinal("type"));
            tempIsDetermainant = tableNameReader.GetInt32(tableNameReader.GetOrdinal("isDetermainant")) > 0;
            foreach (KeyValuePair<string, enSQLiteEntityClassify> key in classifyMaping)
            {
                if (key.Key.ToLower().Equals(tempEntityType.ToLower()))
                {
                    tempEntityClassify = key.Value;
                    break;
                }
            }
            tempEntity = new SQLiteEntity(tempEntityName, tempEntityClassify, tempIsDetermainant);
            pragmaReader = EditorStrayFogApplication.sqlHelper.ReadTablePragma(tempEntityName);
            schemaReader = EditorStrayFogApplication.sqlHelper.ReadTableSchema(tempEntityName);
            //收集列名
            while (pragmaReader.Read())
            {
                tempEntityProperty = new SQLiteEntityProperty(pragmaReader.GetString(pragmaReader.GetOrdinal("name")));
                tempEntityProperty.isPK = pragmaReader.GetInt64(pragmaReader.GetOrdinal("pk")) > 0;
                tempEntityProperty.sqliteDataTypeName = pragmaReader.GetString(pragmaReader.GetOrdinal("type"));
                tempEntity.properties.Add(tempEntityProperty);
            }
            //收集列类型
            foreach (SQLiteEntityProperty c in tempEntity.properties)
            {
                tempPropertyType = schemaReader.GetFieldType(schemaReader.GetOrdinal(c.name));
                if (msrSpecialEntityDataType.ContainsKey(c.sqliteDataTypeName))
                {
                    c.typeName = msrSpecialEntityDataType[c.sqliteDataTypeName];
                }
                else if (string.IsNullOrEmpty(c.sqliteDataTypeName))
                {
                    c.typeName = typeof(string).FullName;
                }
                else
                {
                    c.typeName = tempPropertyType.FullName;
                }
            }
            entities.Add(tempEntity);
            EditorUtility.DisplayProgressBar("Collection Entity", tempEntity.name, progress / count);
        }
        #endregion

        #region 生成实体对象
        EditorTextAssetConfig cfgEntityScript = new EditorTextAssetConfig("", sqliteEntityFolder, enFileExt.CS, "");
        progress = 0;
        foreach (SQLiteEntity t in entities)
        {
            progress++;
            if (t.isDetermainant)
            {
                #region 行列式实体对象
                string entityScriptTemplete = EditorResxTemplete.SQLiteDeterminantEntityScriptTemplete;

                string rowMark = "#Row#";
                string rowReplaceTemplete = string.Empty;
                string rowTemplete = string.Empty;
                StringBuilder sbRowReplace = new StringBuilder();
                rowTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, rowMark, out rowReplaceTemplete);
                Dictionary<string, SQLiteEntityProperty> rowMaping = new Dictionary<string, SQLiteEntityProperty>();

                foreach (SQLiteEntityProperty p in t.properties)
                {
                    rowMaping.Add(p.name, p);
                }

                SqliteDataReader dataReader = EditorStrayFogApplication.sqlHelper.ReadFullTable(t.name);
                while (dataReader.Read())
                {
                    sbRowReplace.Append(
                        rowTemplete.Replace("#Name#", dataReader.GetValue(0).ToString()).Replace("#Type#", rowMaping[dataReader.GetName(1)].typeName)
                        );
                }

                cfgEntityScript.SetName(t.className);
                cfgEntityScript.SetDirectory(sqliteDeterminantEntitiesFolder);
                entityScriptTemplete = entityScriptTemplete
                    .Replace("#EntityName#", t.name)
                    .Replace("#ClassName#", cfgEntityScript.name)
                    .Replace(rowReplaceTemplete, sbRowReplace.ToString())
                    ;
                cfgEntityScript.SetText(entityScriptTemplete);
                cfgEntityScript.CreateAsset();
                sbLog.AppendLine(cfgEntityScript.fileName);
                #endregion
            }
            else
            {
                #region 非行列式实体对象
                string entityScriptTemplete = EditorResxTemplete.SQLiteEntityScriptTemplete;

                string propertyMark = "#Properties#";
                string propertyReplaceTemplete = string.Empty;
                string propertyTemplete = string.Empty;
                StringBuilder sbPropertyReplace = new StringBuilder();
                propertyTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, propertyMark, out propertyReplaceTemplete);

                string pkMark = "#PK#";
                string pkReplaceTemplete = string.Empty;
                string pkTemplete = string.Empty;
                StringBuilder sbPkReplace = new StringBuilder();
                pkTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(entityScriptTemplete, pkMark, out pkReplaceTemplete);

                foreach (SQLiteEntityProperty p in t.properties)
                {
                    sbPropertyReplace.Append(
                        propertyTemplete.Replace("#Name#", p.name).Replace("#Type#", p.typeName)
                        );
                    if (p.isPK)
                    {
                        sbPkReplace.Append(pkTemplete.Replace("#Name#", p.name));
                    }
                }
                cfgEntityScript.SetName(t.className);
                cfgEntityScript.SetDirectory(sqliteEntityFolder);
                entityScriptTemplete = entityScriptTemplete
                    .Replace("#EntityName#", t.name)
                    .Replace("#ClassName#", cfgEntityScript.name)
                    .Replace(pkReplaceTemplete, sbPkReplace.ToString())
                    .Replace(propertyReplaceTemplete, sbPropertyReplace.ToString())
                    ;

                cfgEntityScript.SetText(entityScriptTemplete);
                cfgEntityScript.CreateAsset();
                sbLog.AppendLine(cfgEntityScript.fileName);
                #endregion
            }
            EditorUtility.DisplayProgressBar("Build Entity", t.name, progress / entities.Count);
        }
        #endregion

        #region 生成实体操作扩展
        EditorTextAssetConfig cfgHeplerExtendScript = new EditorTextAssetConfig("SQLiteEntityHelperExtend", sqliteFolder, enFileExt.CS, "");
        string helperScriptTemplete = EditorResxTemplete.SQLiteEntityHelperExtendTemplete;

        string entityMapingMark = "#EntityMaping#";
        string entityMapingReplaceTemplete = string.Empty;
        string entityMapingTemplete = string.Empty;
        StringBuilder sbEntityMapingReplace = new StringBuilder();
        entityMapingTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(helperScriptTemplete, entityMapingMark, out entityMapingReplaceTemplete);
        progress = 0;
        foreach (SQLiteEntity t in entities)
        {
            progress++;
            sbEntityMapingReplace.Append(entityMapingTemplete.Replace("#ClassName#", t.className).Replace("#TableName#", t.name));
            EditorUtility.DisplayProgressBar("Build Entity Extend", t.name, progress / entities.Count);
        }
        cfgHeplerExtendScript.SetText(helperScriptTemplete.Replace(entityMapingReplaceTemplete, sbEntityMapingReplace.ToString()));
        cfgHeplerExtendScript.CreateAsset();
        #endregion

        EditorStrayFogApplication.CloseDb();
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log(sbLog.ToString());
        Debug.Log("BuildSQLiteEntity Succeed!");
    }
    #endregion

    #region ExecuteBuildSQLiteDbToPackage 生成SQLite数据库到包
    /// <summary>
    /// 生成SQLite数据库到包
    /// </summary>
    public static void ExecuteBuildSQLiteDbToPackage()
    {
        string db = Path.Combine(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot, StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleDbName);
        File.Copy(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().dbSource, db);
        Debug.Log("ExecuteBuildSQLiteDbToPackage Succeed!");
    }
    #endregion

    #region ExecuteBuildAllAssetDiskMaping 生成资源磁盘映射
    /// <summary>
    /// 资源磁盘映射文件夹枚举
    /// </summary>
    readonly static string msrEnumAssetDiskMapingFolder = "EnumAssetDiskMapingFolder";
    /// <summary>
    /// 资源磁盘映射文件枚举
    /// </summary>
    readonly static string msrEnumAssetDiskMapingFile = "EnumAssetDiskMapingFile";
    /// <summary>
    /// 生成资源磁盘映射
    /// </summary>
    public static void ExecuteBuildAllAssetDiskMaping()
    {
        EditorSetAssetBundleNameConfig cfg = EditorStrayFogSavedConfigAssetFile.setAssetBundleName;
        if (cfg.file != null)
        {
            string error = string.Empty;
            List<EditorSelectionAssetDiskMaping> nodes = EditorStrayFogUtility.assetBundleName.Collect<EditorSelectionAssetDiskMaping>(cfg.file.folders, out error);
            if (string.IsNullOrEmpty(error))
            {
                OnBuildSingleAssetDiskMaping(nodes, false);
            }
            else
            {
                Debug.LogError(error);
            }
        }
    }
    #endregion

    #region ExecuteBuildSingleAssetDiskMaping 生成资源磁盘映射        
    /// <summary>
    /// 生成资源磁盘映射
    /// </summary>
    public static void ExecuteBuildSingleAssetDiskMaping()
    {
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Build Single Asset Disk Maping");
        string[] guids = Selection.assetGUIDs;
        string error = string.Empty;
        List<EditorSelectionAssetDiskMaping> nodes = new List<EditorSelectionAssetDiskMaping>();
        if (guids != null && guids.Length > 0)
        {
            string path = string.Empty;
            List<string> folders = new List<string>();
            #region 解析已选择的节点
            foreach (string g in guids)
            {
                path = AssetDatabase.GUIDToAssetPath(g);
                if (File.Exists(path))
                {
                    EditorSelectionAssetDiskMaping d = new EditorSelectionAssetDiskMaping(path);
                    if (EditorStrayFogUtility.assetBundleName.IsLegalAssetBundleNamePackageNode(d))
                    {
                        nodes.Add(d);
                    }
                }
                else if (!folders.Contains(path))
                {
                    folders.Add(path);
                }
            }
            #endregion

            #region 已选择的目录过滤节点
            List<EditorSelectionAssetDiskMaping> appends = EditorStrayFogUtility.assetBundleName.Collect<EditorSelectionAssetDiskMaping>(folders.ToArray(), out error);
            if (string.IsNullOrEmpty(error))
            {
                if (appends.Count > 0)
                {
                    nodes.AddRange(appends);
                }
            }
            else
            {
                nodes.Clear();
                Debug.LogError(error);
            }
            #endregion
        }

        OnBuildSingleAssetDiskMaping(nodes, true);
    }

    static void OnBuildSingleAssetDiskMaping(List<EditorSelectionAssetDiskMaping> _nodes, bool _isSingle)
    {
        StringBuilder sbLog = new StringBuilder();
        sbLog.AppendLine("Build Asset Disk Maping");
        if (_nodes != null && _nodes.Count > 0)
        {
            Dictionary<int, string> fileEnum = new Dictionary<int, string>();
            Dictionary<int, string> folderEnum = new Dictionary<int, string>();
            List<string> scriptLines = new List<string>();
            bool hasEnum = false;
            List<int> appendEnum = new List<int>();
            float progress = 0;

            #region 分析资源
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                n.Resolve();
                progress++;
                EditorUtility.DisplayProgressBar("Resolve Node",
                                n.path, progress / (float)_nodes.Count);
            }
            #endregion

            if (!_isSingle)
            {
                #region 删除所有映射
                sbLog.AppendLine(EditorSelectionAssetDiskMaping.ExecuteDeleteAllFile());
                sbLog.AppendLine(EditorSelectionAssetDiskMaping.ExecuteDeleteAllFileExt());
                sbLog.AppendLine(EditorSelectionAssetDiskMaping.ExecuteDeleteAllFolder());
                #endregion
            }

            #region 插入目录
            progress = 0;
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                if (!folderEnum.ContainsKey(n.folderId))
                {
                    folderEnum.Add(n.folderId, n.folderEnumName);
                }
                if (!n.ExistsFolder())
                {
                    sbLog.AppendLine(n.ExecuteInsertFolder());
                }
                progress++;
                EditorUtility.DisplayProgressBar("Insert Folder Maping",
                                n.path, progress / (float)_nodes.Count);
            }
            #endregion

            #region 插入文件后缀            
            List<int> extHashCode = new List<int>();
            progress = 0;
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                if (!extHashCode.Contains(n.fileExtHashCode))
                {
                    extHashCode.Add(n.fileExtHashCode);
                }
                if (!n.ExistsFileExt())
                {
                    sbLog.AppendLine(n.ExecuteInsertFileExt());
                }
                progress++;
                EditorUtility.DisplayProgressBar("Insert FileExt",
                                n.path, progress / (float)_nodes.Count);
            }
            #endregion

            #region 插入文件            
            progress = 0;
            foreach (EditorSelectionAssetDiskMaping n in _nodes)
            {
                if (!fileEnum.ContainsKey(n.fileId))
                {
                    fileEnum.Add(n.fileId, n.fileScriptEnumName);
                }
                if (!n.ExistsFile())
                {
                    sbLog.AppendLine(n.ExecuteInsertFile());
                }
                progress++;
                EditorUtility.DisplayProgressBar("Insert File Maping",
                                n.path, progress / (float)_nodes.Count);
            }
            #endregion

            #region 生成枚举
            EditorTextAssetConfig cfgEnumScript = new EditorTextAssetConfig("", enEditorApplicationFolder.Game_Script_AssetDiskMaping.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.CS, "");
            string assetDiskMapingScriptTemplete = EditorResxTemplete.AssetDiskMapingEnumTemplete;

            string enumMark = "#Enums#";
            string enumReplaceTemplete = string.Empty;
            string enumTemplete = string.Empty;
            StringBuilder sbEnumTableReplace = new StringBuilder();
            enumTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(assetDiskMapingScriptTemplete, enumMark, out enumReplaceTemplete);
            #endregion

            #region 目录枚举
            progress = 0;
            scriptLines.Clear();
            appendEnum.Clear();
            cfgEnumScript.SetName(msrEnumAssetDiskMapingFolder);
            if (!cfgEnumScript.Exists() || !_isSingle)
            {
                #region 没有目录枚举文件时
                foreach (KeyValuePair<int, string> key in folderEnum)
                {
                    progress++;
                    sbEnumTableReplace.Append(
                      enumTemplete.Replace("#Name#", key.Value)
                      .Replace("#HashCode#", key.Key.ToString())
                        );
                    EditorUtility.DisplayProgressBar("Build Folder Enum",
                                    key.Value, progress / folderEnum.Count);
                }
                cfgEnumScript.SetText(assetDiskMapingScriptTemplete
                    .Replace("#EnumName#", "AssetDiskMapingFolder")
                    .Replace(enumReplaceTemplete, sbEnumTableReplace.ToString()));
                cfgEnumScript.CreateAsset();
                #endregion
            }
            else
            {
                #region 有目录枚举文件时
                scriptLines.AddRange(File.ReadAllLines(cfgEnumScript.fileName));
                foreach (KeyValuePair<int, string> key in folderEnum)
                {
                    hasEnum = false;
                    foreach (string t in scriptLines)
                    {
                        hasEnum = t.Contains(key.Key.ToString()) && t.Contains(key.Value);
                        if (hasEnum)
                        {
                            break;
                        }
                    }
                    if (!hasEnum)
                    {
                        appendEnum.Add(key.Key);
                    }
                }

                foreach (int k in appendEnum)
                {
                    scriptLines.Insert(scriptLines.Count - 2, string.Format("{0} = {1},", folderEnum[k], k));
                }
                if (appendEnum.Count > 0)
                {
                    File.WriteAllLines(cfgEnumScript.fileName, scriptLines.ToArray());
                }
                #endregion
            }
            #endregion

            #region 文件枚举
            progress = 0;
            sbEnumTableReplace.Length = 0;
            scriptLines.Clear();
            appendEnum.Clear();
            cfgEnumScript.SetName(msrEnumAssetDiskMapingFile);
            if (!cfgEnumScript.Exists() || !_isSingle)
            {
                #region 没有文件枚举文件时
                foreach (KeyValuePair<int, string> key in fileEnum)
                {
                    progress++;
                    sbEnumTableReplace.Append(
                      enumTemplete.Replace("#Name#", key.Value)
                      .Replace("#HashCode#", key.Key.ToString())
                        );
                    EditorUtility.DisplayProgressBar("Build File Enum",
                                    key.Value, progress / fileEnum.Count);
                }
                cfgEnumScript.SetText(assetDiskMapingScriptTemplete
                    .Replace("#EnumName#", "AssetDiskMapingFile")
                    .Replace(enumReplaceTemplete, sbEnumTableReplace.ToString()));
                cfgEnumScript.CreateAsset();
                #endregion
            }
            else
            {
                #region 有目录枚举文件时
                scriptLines.AddRange(File.ReadAllLines(cfgEnumScript.fileName));
                foreach (KeyValuePair<int, string> key in fileEnum)
                {
                    hasEnum = false;
                    foreach (string t in scriptLines)
                    {
                        hasEnum = t.Contains(key.Key.ToString()) && t.Contains(key.Value);
                        if (hasEnum)
                        {
                            break;
                        }
                    }
                    if (!hasEnum)
                    {
                        appendEnum.Add(key.Key);
                    }
                }

                foreach (int k in appendEnum)
                {
                    scriptLines.Insert(scriptLines.Count - 2, string.Format("{0} = {1},", fileEnum[k], k));
                }
                if (appendEnum.Count > 0)
                {
                    File.WriteAllLines(cfgEnumScript.fileName, scriptLines.ToArray());
                }
                #endregion
            }
            #endregion

            EditorStrayFogApplication.CloseDb();
            EditorUtility.ClearProgressBar();
        }
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log(sbLog.ToString());
        Debug.Log("ExecuteBuildSingleAssetDiskMaping Succeed!");
    }
    #endregion

    #region ExecuteBuildDeleteNouseAssetBatToPackage 生成删除包中无用资源的bat文件
    /// <summary>
    /// 删除Manifest批处理
    /// </summary>
    static readonly EditorTextAssetConfig mDeleteManifestBat = new EditorTextAssetConfig("DeleteManifest", enEditorApplicationFolder.Game_Editor.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_DeleteManifestTemplete);

    /// <summary>
    /// DebugProfiler批处理
    /// </summary>
    static readonly EditorTextAssetConfig mDebugProfilerBat = new EditorTextAssetConfig("DebugProfiler", enEditorApplicationFolder.Game_Editor.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_DebugProfilerTemplete);

    /// <summary>
    /// ClearSvn批处理
    /// </summary>
    static readonly EditorTextAssetConfig mClearSvnReg = new EditorTextAssetConfig("ClearSvn", enEditorApplicationFolder.Game_Editor.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Bat, EditorResxTemplete.Cmd_ClearSvnTemplete);
    /// <summary>
    /// 生成删除包中无用资源的bat文件
    /// </summary>
    public static void ExecuteBuildDeleteNouseAssetBatToPackage()
    {
        string path = Path.GetFullPath(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot);
        string scriptTemplete = mDeleteManifestBat.text;
        string replaceTemplete = string.Empty;
        string formatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(scriptTemplete, @"#DelCmd#", out replaceTemplete);
        StringBuilder sbTemplete = new StringBuilder();
        string[] directories = Directory.GetDirectories(path);
        foreach (string key in directories)
        {
            sbTemplete.AppendLine(formatTemplete.Replace("#Folder#", key));
        }
        sbTemplete.AppendLine(formatTemplete.Replace("#Folder#", path));
        string result = scriptTemplete.Replace(replaceTemplete, sbTemplete.ToString());
        result = EditorStrayFogUtility.regex.ClearRepeatCRLF(result);
        mDeleteManifestBat.SetText(result);
        mDeleteManifestBat.CreateAsset();

        mDebugProfilerBat.SetText(mDebugProfilerBat.text.Replace("#DebugProfiler#", PlayerSettings.applicationIdentifier));
        mDebugProfilerBat.CreateAsset();

        mClearSvnReg.CreateAsset();
        Debug.Log("ExecuteBuildPackageDeleteNouseAssetBat Succeed!");
    }
    #endregion

    #region ExecuteBuildPackage 发布包
    /// <summary>
    /// 发布包
    /// </summary>
    public static void ExecuteBuildPackage()
    {
        string path = Path.GetFullPath(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot);
        List<EditorSelectionAssetBundleNameAsset> dlls = new List<EditorSelectionAssetBundleNameAsset>();
        EditorStrayFogUtility.cmd.DeleteFolder(path);

        if (Directory.Exists(path))
        {
            string error = string.Format("The folder can't delete, it will restart editor.");
            if (EditorUtility.DisplayDialog("Error", error, "Yes", "No"))
            {
                EditorStrayFogUtility.cmd.Restart();
            }
            throw new UnityException(error);
        }
        else
        {
            Directory.CreateDirectory(path);
        }
        ExecuteClearAllSpritePackingTag();
        ExecuteClearAllAssetBundleName();

        ExecuteBuildSQLiteEntity();
        ExecuteSetSpritePackingTag();
        ExecuteSetAssetBundleName();
        ExecuteBuildAllAssetDiskMaping();

        ExecuteBuildDllToPackage();
        ExecuteBuildSQLiteDbToPackage();
        ExecuteBuildDeleteNouseAssetBatToPackage();

        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        BuildPipeline.BuildAssetBundles(path,
            BuildAssetBundleOptions.ChunkBasedCompression,
            EditorUserBuildSettings.activeBuildTarget);
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        EditorStrayFogUtility.cmd.ExcuteFile(Path.GetFullPath(mDeleteManifestBat.fileName));
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        EditorUtility.RevealInFinder(path);
        Debug.Log(path);
        Debug.Log("ExecuteBuildPackage Succeed!");
    }
    #endregion

    #region ExecuteBuildAnimCurves 生成AnimCurve
    /// <summary>
    /// 生成AnimCurve
    /// </summary>
    public static void ExecuteBuildAnimCurves()
    {
        StringBuilder sbLog = new StringBuilder();
        Type act = typeof(IEditorAnimCurve);
        Type[] srcs = Assembly.GetExecutingAssembly().GetExportedTypes();
        List<Type> dest = new List<Type>();
        float progress = 0;
        List<EditorAnimCurve> animCurves = new List<EditorAnimCurve>();

        #region Find Setting
        if (srcs != null && srcs.Length > 0)
        {
            for (int i = 0; i < srcs.Length; i++)
            {
                if (srcs[i].IsSubTypeOf(act))
                {
                    dest.Add(srcs[i]);
                }
                progress++;
                EditorUtility.DisplayProgressBar("Find Setting", srcs[i].FullName, progress / srcs.Length);
            }
        }
        #endregion

        #region Collect Setting            
        sbLog.AppendLine("Collect Anim Curve Settings");
        if (dest.Count > 0)
        {
            progress = 0;
            for (int i = 0; i < dest.Count; i++)
            {
                animCurves.Add(new EditorAnimCurve((IEditorAnimCurve)Activator.CreateInstance(dest[i])));
                progress++;
                EditorUtility.DisplayProgressBar("Collect Setting", dest[i].FullName, progress / dest.Count);
                sbLog.AppendLine(string.Format("{0}=>{1}", (i + 1).PadLeft(dest.Count), dest[i].FullName));
            }
        }
        #endregion

        #region Build Anim Curve
        string folder = enEditorApplicationFolder.Game_Editor.GetAttribute<EditorApplicationFolderAttribute>().path;
        string path = Path.Combine(folder, "AnimCurveAsset" + enFileExt.Curves.GetAttribute<FileExtAttribute>().ext).TransPathSeparatorCharToUnityChar();
        ScriptableObject library = ScriptableObject.CreateInstance(EditorStrayFogApplication.curvePresetLibrary);
        MethodInfo addMehtod = EditorStrayFogApplication.curvePresetLibrary.GetMethod("Add");
        sbLog.AppendLine("Add Anim Curve");
        if (animCurves.Count > 0)
        {
            progress = 0;
            for (int i = 0; i < animCurves.Count; i++)
            {
                addMehtod.Invoke(library, new object[]
                {
                        animCurves[i].curve,
                        animCurves[i].name
                });
                EditorUtility.DisplayProgressBar("Add Curve", animCurves[i].name, progress / dest.Count);
                sbLog.AppendLine(string.Format("{0}=>{1}", (i + 1).PadLeft(dest.Count), animCurves[i].name));
            }
        }
        AssetDatabase.CreateAsset(library, path);
        AssetDatabase.SaveAssets();
        EditorStrayFogApplication.PingObject(path);
        #endregion

        EditorUtility.ClearProgressBar();
        AssetDatabase.SaveAssets();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log(sbLog.ToString());
        Debug.Log("ExecuteBuildAnimCurves Succeed!");
    }
    #endregion

    #region ExecuteBuildAnimatorControllerFMSMaping 生成AnimatorControllerFMS映射
    /// <summary>
    /// 生成AnimatorControllerFMS映射
    /// </summary>
    public static void ExecuteBuildAnimatorControllerFMSMaping()
    {
        EditorAnimatorControllerFMSMapingConfig cfg = EditorStrayFogSavedConfigAssetFile.setAnimatorControllerFMSMaping;
        if (cfg.file != null)
        {
            FileExtAttribute animatorControllerExt = enFileExt.AnimatorController.GetAttribute<FileExtAttribute>();
            List<EditorSelectionAnimatorControllerFMSMapingAsset> nodes = EditorStrayFogUtility.collectAsset.CollectAsset<EditorSelectionAnimatorControllerFMSMapingAsset>(cfg.file.folders, enEditorAssetFilterClassify.Object, true, (n) => { return n.ext.Equals(animatorControllerExt.ext); });
            if (nodes != null && nodes.Count > 0)
            {
                OnBuilderAnimatorControllerMaping(nodes);
            }
        }
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log("ExecuteBuildAnimatorControllerFMSMaping Succeed!");
    }

    #region BuilderAnimatorControllerManager 生成AnimatorController管理器
    /// <summary>
    /// 生成AnimatorController管理器
    /// </summary>
    /// <param name="_nodes">节点</param>
    static void OnBuilderAnimatorControllerMaping(List<EditorSelectionAnimatorControllerFMSMapingAsset> _nodes)
    {
        SortedDictionary<string, List<string>> stateForMachineMaping = new SortedDictionary<string, List<string>>();
        SortedDictionary<string, List<string>> machineForStateMaping = new SortedDictionary<string, List<string>>();
        SortedDictionary<string, List<int>> stateForLayerMaping = new SortedDictionary<string, List<int>>();
        SortedDictionary<int, List<string>> layerForStateMaping = new SortedDictionary<int, List<string>>();
        SortedDictionary<string, List<int>> machineForLayerMaping = new SortedDictionary<string, List<int>>();
        SortedDictionary<int, List<string>> layerForMachineMaping = new SortedDictionary<int, List<string>>();
        SortedDictionary<string, int> stateForNameHashMaping = new SortedDictionary<string, int>();
        SortedDictionary<string, int> parameterForNameHashMaping = new SortedDictionary<string, int>();
        float progress = 0;
        foreach (EditorSelectionAnimatorControllerFMSMapingAsset n in _nodes)
        {
            progress++;
            n.Resolver();
            #region StateForLayer                      
            foreach (KeyValuePair<string, List<int>> key in n.stateForLayerMaping)
            {
                if (!stateForLayerMaping.ContainsKey(key.Key))
                {
                    stateForLayerMaping.Add(key.Key, new List<int>());
                }
                foreach (int v in key.Value)
                {
                    if (!stateForLayerMaping[key.Key].Contains(v))
                    {
                        stateForLayerMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver StateForLayer",
                            n.path, progress / _nodes.Count);
            #endregion

            #region LayerForState            
            foreach (KeyValuePair<int, List<string>> key in n.layerForStateMaping)
            {
                if (!layerForStateMaping.ContainsKey(key.Key))
                {
                    layerForStateMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!layerForStateMaping[key.Key].Contains(v))
                    {
                        layerForStateMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver LayerForState",
                            n.path, progress / _nodes.Count);
            #endregion

            #region MachineForLayer           
            foreach (KeyValuePair<string, List<int>> key in n.machineForLayerMaping)
            {
                if (!machineForLayerMaping.ContainsKey(key.Key))
                {
                    machineForLayerMaping.Add(key.Key, new List<int>());
                }
                foreach (int v in key.Value)
                {
                    if (!machineForLayerMaping[key.Key].Contains(v))
                    {
                        machineForLayerMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver MachineForLayer",
                            n.path, progress / _nodes.Count);
            #endregion

            #region LayerForMachine            
            foreach (KeyValuePair<int, List<string>> key in n.layerForMachineMaping)
            {
                if (!layerForMachineMaping.ContainsKey(key.Key))
                {
                    layerForMachineMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!layerForMachineMaping[key.Key].Contains(v))
                    {
                        layerForMachineMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver LayerForMachine",
                            n.path, progress / _nodes.Count);
            #endregion

            #region StateForMachine            
            foreach (KeyValuePair<string, List<string>> key in n.stateForMachineMaping)
            {
                if (!stateForMachineMaping.ContainsKey(key.Key))
                {
                    stateForMachineMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!stateForMachineMaping[key.Key].Contains(v))
                    {
                        stateForMachineMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver StateForMachine",
                            n.path, progress / _nodes.Count);
            #endregion

            #region MachineForState            
            foreach (KeyValuePair<string, List<string>> key in n.machineForStateMaping)
            {
                if (!machineForStateMaping.ContainsKey(key.Key))
                {
                    machineForStateMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!machineForStateMaping[key.Key].Contains(v))
                    {
                        machineForStateMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver MachineForState",
                            n.path, progress / _nodes.Count);
            #endregion

            #region EnumMachine           
            foreach (KeyValuePair<string, List<string>> key in n.machineForStateMaping)
            {
                if (!machineForStateMaping.ContainsKey(key.Key))
                {
                    machineForStateMaping.Add(key.Key, new List<string>());
                }
                foreach (string v in key.Value)
                {
                    if (!machineForStateMaping[key.Key].Contains(v))
                    {
                        machineForStateMaping[key.Key].Add(v);
                    }
                }
            }
            EditorUtility.DisplayProgressBar("Resolver EnumMachine",
                            n.path, progress / _nodes.Count);
            #endregion

            #region EnumState
            foreach (KeyValuePair<string, int> key in n.stateForNameHashMaping)
            {
                if (!stateForNameHashMaping.ContainsKey(key.Key))
                {
                    stateForNameHashMaping.Add(key.Key, key.Value);
                }
            }
            EditorUtility.DisplayProgressBar("Resolver EnumState",
                            n.path, progress / _nodes.Count);
            #endregion

            #region EnumParameter            
            foreach (KeyValuePair<string, int> key in n.parameterForNameHashMaping)
            {
                if (!parameterForNameHashMaping.ContainsKey(key.Key))
                {
                    parameterForNameHashMaping.Add(key.Key, key.Value);
                }
            }
            EditorUtility.DisplayProgressBar("Resolver EnumParameter",
                            n.path, progress / _nodes.Count);
            #endregion
        }

        string editorFMSMachineMapingScriptTemplete = EditorResxTemplete.EditorFMSMachineMapingScriptTemplete;
        string editorFMSMachineMapingResult = editorFMSMachineMapingScriptTemplete;

        string editorFMSMachineMapingReplaceTemplete = string.Empty;
        string editorFMSMachineMapingFormatTemplete = string.Empty;
        string editorFMSMachineMapingReplaceTempleteA = string.Empty;
        string editorFMSMachineMapingFormatTempleteA = string.Empty;
        StringBuilder editorFMSMachineMapingSbTemplete = new StringBuilder();
        StringBuilder editorFMSMachineMapingSbTempleteA = new StringBuilder();

        #region StateForLayer
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#STATEFORLAYER#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTLAYER#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<int>> key in stateForLayerMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (int layer in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#LAYER#", layer.ToString()));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("StateForLayer",
                            "State=>" + key.Key, progress / stateForLayerMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region LayerForState
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#LAYERFORSTATE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTSTATE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<int, List<string>> key in layerForStateMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string state in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(state.ToString())));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#LAYER#", key.Key.ToString()).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("LayerForState",
                            "Layer=>" + key.Key, progress / layerForStateMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region MachineForLayer
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#MACHINEFORLAYER#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTLAYER#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<int>> key in machineForLayerMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (int layer in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#LAYER#", layer.ToString()));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("MachineForLayer",
                            "Machine=>" + key.Key, progress / machineForLayerMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region LayerForMachine
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#LAYERFORMACHINE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTMACHINE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<int, List<string>> key in layerForMachineMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string state in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(state.ToString())));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#LAYER#", key.Key.ToString()).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("LayerForMachine",
                            "Layer=>" + key.Key, progress / layerForMachineMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region StateForMachine
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#STATEFORMACHINE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTMACHINE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<string>> key in stateForMachineMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string m in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(m)));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("StateForMachine",
                            "State=>" + key.Key, progress / stateForMachineMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region MachineForState
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#MACHINEFORSTATE#", out editorFMSMachineMapingReplaceTemplete);
        editorFMSMachineMapingFormatTempleteA = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingFormatTemplete, @"#LISTSTATE#", out editorFMSMachineMapingReplaceTempleteA);
        progress = 0;
        foreach (KeyValuePair<string, List<string>> key in machineForStateMaping)
        {
            progress++;
            editorFMSMachineMapingSbTempleteA.Length = 0;
            foreach (string s in key.Value)
            {
                editorFMSMachineMapingSbTempleteA.Append(editorFMSMachineMapingFormatTempleteA.Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(s)));
            }
            editorFMSMachineMapingSbTemplete.AppendLine(editorFMSMachineMapingFormatTemplete.Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key)).Replace(editorFMSMachineMapingReplaceTempleteA, editorFMSMachineMapingSbTempleteA.ToString()));
            EditorUtility.DisplayProgressBar("MachineForState",
                            "Machine=>" + key.Key, progress / machineForStateMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumMachine
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMMACHINE#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        foreach (string key in machineForStateMaping.Keys)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#MACHINE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key))
                .Replace("#VALUE#", key.UniqueHashCode().ToString())
                .Replace("#MACHINEDESC#", key));
            EditorUtility.DisplayProgressBar("EnumMachine",
                            "Machine=>" + key, progress / machineForStateMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumState
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMSTATE#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        foreach (KeyValuePair<string, int> key in stateForNameHashMaping)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#STATE#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key))
                .Replace("#VALUE#", key.Value.ToString())
                .Replace("#STATEDESC#", key.Key));
            EditorUtility.DisplayProgressBar("EnumState",
                            "State=>" + key, progress / stateForNameHashMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        #region EnumParameter
        editorFMSMachineMapingSbTemplete.Length = 0;
        editorFMSMachineMapingFormatTemplete = EditorStrayFogUtility.regex.MatchPairMarkTemplete(editorFMSMachineMapingScriptTemplete, @"#ENUMPARAMETER#", out editorFMSMachineMapingReplaceTemplete);
        progress = 0;
        foreach (KeyValuePair<string, int> key in parameterForNameHashMaping)
        {
            progress++;
            editorFMSMachineMapingSbTemplete.AppendLine(
                editorFMSMachineMapingFormatTemplete
                .Replace("#NAME#", EditorStrayFogUtility.assetBundleName.ReplaceIllgealCharToUnderline(key.Key))
                .Replace("#VALUE#", key.Value.ToString()));
            EditorUtility.DisplayProgressBar("EnumParameter",
                            "Parameter=>" + key, progress / parameterForNameHashMaping.Count);
        }
        editorFMSMachineMapingResult = editorFMSMachineMapingResult.Replace(editorFMSMachineMapingReplaceTemplete, editorFMSMachineMapingSbTemplete.ToString());
        #endregion

        editorFMSMachineMapingResult = EditorStrayFogUtility.regex.ClearRepeatCRLF(editorFMSMachineMapingResult);

        EditorTextAssetConfig cfgScript = new EditorTextAssetConfig("FMSMachineMaping", enEditorApplicationFolder.Game_Script_FMS.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.CS, "");

        cfgScript.SetText(editorFMSMachineMapingResult);
        cfgScript.CreateAsset();
    }
    #endregion
    #endregion

    #region ExecuteBuildDefaultShader 生成默认Shader
    /// <summary>
    /// 生成默认Shader
    /// </summary>
    public static void ExecuteBuildDefaultShader()
    {
        EditorBinaryAssetConfig txtCfg = new EditorBinaryAssetConfig("", enEditorApplicationFolder.Project_Shader.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Shader, null);
        PropertyInfo[] pis = typeof(EditorResxTemplete).GetProperties();
        if (pis != null && pis.Length > 0)
        {
            float progress = 0;
            foreach (PropertyInfo p in pis)
            {
                progress++;
                if (p.PropertyType.IsArray &&
                    p.PropertyType.HasElementType &&
                    p.PropertyType.GetElementType().Equals(typeof(byte)) &&
                    p.Name.Contains("Shader"))
                {
                    txtCfg.SetName(p.Name);
                    txtCfg.SetBinary((byte[])p.GetValue(null, null));
                    txtCfg.CreateAsset();
                }
                EditorUtility.DisplayProgressBar("Build Shader", p.Name, progress / pis.Length);
            }
        }
        EditorUtility.ClearProgressBar();
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log("BuildDefaultShader Succeed!");
    }
    #endregion

    #region ExecuteBuildProjectAssets 生成工程资源
    /// <summary>
    /// 生成工程资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    public static void ExecuteBuildProjectAssets<T>() 
        where T : AbsSingleScriptableObject
    {
        Type absInheritType = typeof(T);
        Type destType = null;
        int destCount = 0;
        List<Assembly> asms = EditorStrayFogAssembly.GetDynamicAssemblies();
        if (asms != null && asms.Count > 0)
        {
            foreach (Assembly m in asms)
            {
                Type[] types = m.GetExportedTypes();
                if (types != null && types.Length > 0)
                {
                    foreach (Type t in types)
                    {
                        if (t.IsTypeOrSubTypeOf(absInheritType) && t.IsClass && !t.IsInterface && !t.IsAbstract)
                        {
                            destType = t;
                            destCount++;
                        }
                    }
                }
            }
            switch (destCount)
            {
                case 0:
                    throw new UnityException(string.Format("There is no class inherit '{0}'.", absInheritType.FullName));
                case 1:
                    EditorEngineAssetConfig absCfg = new EditorEngineAssetConfig(absInheritType.Name, enEditorApplicationFolder.Project_Resources.GetAttribute<EditorApplicationFolderAttribute>().path, enFileExt.Asset, destType.Name);
                    if (!absCfg.Exists())
                    {
                        absCfg.CreateAsset();
                        Debug.LogFormat("BuildProjectAssets=>【{0}】", absCfg.fileName);
                    }
                    break;
                default:
                    throw new UnityException(string.Format("It is must be one class inherit '{0}',please delete others.", absInheritType.FullName));
            }
        }

        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
        Debug.Log(string.Format("ExecuteBuildProjectAssets 【{0}】Succeed!", absInheritType.FullName));
    }
    #endregion

    #region ExecuteFindUIGuideRegisterMaskGraphic 查的引导注册器的MaskGraphic
    /// <summary>
    /// 查的引导注册器的MaskGraphic
    /// </summary>
    public static void ExecuteFindUIGuideRegisterMaskGraphic()
    {
        if (Selection.activeGameObject != null)
        {
            UIGuideRegister register = Selection.activeGameObject.GetComponent<UIGuideRegister>();
            Transform root = register.transform;
            if (register.graphicsNodeIndexs != null && register.graphicsNodeIndexs.Length > 0)
            {
                foreach (int i in register.graphicsNodeIndexs)
                {
                    root = root.GetChild(i);
                }
            }
            EditorStrayFogApplication.PingObject(root);
        }
    }
    #endregion
}
#endif