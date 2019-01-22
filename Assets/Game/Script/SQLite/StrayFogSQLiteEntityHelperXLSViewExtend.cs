﻿using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// SQLite表实体XLS视图数据帮助类
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    /// <summary>
    /// 从XLS读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entitySetting">实体设置</param>
    /// <returns>数据</returns>
    static List<T> OnLoadFromXLSView<T>(StrayFogSQLiteEntitySetting _entitySetting)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        T tempEntity = default(T);        
        if (_entitySetting.classify == enSQLiteEntityClassify.View)
        {
            if (_entitySetting.id == OnGetTypeKey<View_AssetDiskMaping>())
            {
                #region View_AssetDiskMaping 数据组装                                
                List<Table_AssetDiskMapingFile> files = Select<Table_AssetDiskMapingFile>();
                List<Table_AssetDiskMapingFolder> folders = Select<Table_AssetDiskMapingFolder>();
                Dictionary<int, Table_AssetDiskMapingFile> dicFile = new Dictionary<int, Table_AssetDiskMapingFile>();              
                Dictionary<int, Table_AssetDiskMapingFolder> dicFolder = new Dictionary<int, Table_AssetDiskMapingFolder>();               
                foreach (Table_AssetDiskMapingFolder t in folders)
                {
                    dicFolder.Add(t.folderId, t);
                }
                int fileId = "fileId".UniqueHashCode();
                int folderId = "folderId".UniqueHashCode();
                int fileName = "fileName".UniqueHashCode();
                int inAssetPath = "inAssetPath".UniqueHashCode();
                int outAssetPath = "outAssetPath".UniqueHashCode();
                int extEnumValue = "extEnumValue".UniqueHashCode();
                foreach (Table_AssetDiskMapingFile t in files)
                {
                    tempEntity = Activator.CreateInstance<T>();
                    msEntityPropertyInfoMaping[_entitySetting.id][fileId].SetValue(tempEntity, t.fileId, null);
                    msEntityPropertyInfoMaping[_entitySetting.id][folderId].SetValue(tempEntity, t.folderId, null);
                    msEntityPropertyInfoMaping[_entitySetting.id][fileName].SetValue(tempEntity, t.inSide + t.ext, null);
                    msEntityPropertyInfoMaping[_entitySetting.id][inAssetPath].SetValue(tempEntity,Path.Combine(dicFolder[t.folderId].inSide, t.inSide + t.ext).TransPathSeparatorCharToUnityChar(), null);
                    msEntityPropertyInfoMaping[_entitySetting.id][outAssetPath].SetValue(tempEntity, t.outSide, null);
                    msEntityPropertyInfoMaping[_entitySetting.id][extEnumValue].SetValue(tempEntity, t.extEnumValue, null);
                    result.Add(tempEntity);
                }
                #endregion
            }
            else if (_entitySetting.id == OnGetTypeKey<View_DeterminantVT>())
            {
                #region View_DeterminantVT 数据组装
                int vtNameKey = "vtName".UniqueHashCode();
                foreach (StrayFogSQLiteEntitySetting key in msrEntityMaping.Values)
                {
                    if (key.isDeterminant)
                    {
                        tempEntity = Activator.CreateInstance<T>();
                        msEntityPropertyInfoMaping[_entitySetting.id][vtNameKey].SetValue(tempEntity, key.tableName, null);
                        result.Add(tempEntity);
                    }
                }
                #endregion
            }
        }        
        return result;
    }
}
