using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// StrayFogSQLite表实体帮助类【Select】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region OnReadFromXLS
    /// <summary>
    /// 从XLS读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据集</returns>
    static List<T> OnReadFromXLS<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        if (File.Exists(_tableAttribute.xlsFilePath))
        {
            T tempEntity = default(T);
            int tempPropertyKey = 0;
            object tempValue = null;
            string tempName = string.Empty;
            bool tempIsAllValueNull = false;
            ExcelPackage pck = OnGetExcelPackage(_tableAttribute);
            {
                if (pck.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (_tableAttribute.isDeterminant)
                    {
                        #region 行列式数据写入
                        if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex)
                        {
                            tempEntity = OnCreateInstance<T>(_tableAttribute);
                            for (int row = _tableAttribute.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {
                                tempName = sheet.GetValue<string>(row, _tableAttribute.xlsColumnNameIndex).Trim();
                                tempValue = sheet.GetValue(row, _tableAttribute.xlsColumnValueIndex);
                                //如果名称为空，则认为是数据结束
                                if (string.IsNullOrEmpty(tempName))
                                {
                                    break;
                                }
                                else
                                {
                                    tempPropertyKey = tempName.UniqueHashCode();
                                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                                    msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                                }
                            }
                            tempEntity.Resolve();
                            result.Add(tempEntity);
                        }
                        #endregion
                    }
                    else
                    {
                        #region 普通数据写入
                        if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex)
                        {
                            for (int row = _tableAttribute.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {
                                tempEntity = OnCreateInstance<T>(_tableAttribute);
                                tempIsAllValueNull = true;
                                for (int col = 1; col <= sheet.Dimension.Columns; col++)
                                {
                                    tempName = sheet.GetValue<string>(_tableAttribute.xlsColumnNameIndex, col).Trim();
                                    tempValue = sheet.GetValue(row, col);
                                    tempIsAllValueNull &= (tempValue == null);
                                    tempPropertyKey = tempName.UniqueHashCode();
                                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                                    msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                                }
                                if (tempIsAllValueNull)
                                {//如果所有列为空，则认为是数据结束
                                    break;
                                }
                                else
                                {
                                    tempEntity.Resolve();
                                    result.Add(tempEntity);
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
        }
        else
        {
            result = OnLoadViewFromXLS<T>(_tableAttribute);
        }
        return result;
    }
    #endregion

    #region OnReadFromSQLite
    /// <summary>
    /// 从SQLite读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据集</returns>
    static List<T> OnReadFromSQLite<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();        
        SqliteDataReader reader = msStrayFogSQLiteHelperMaping[_tableAttribute.dbSQLiteKey].ExecuteQuery(string.Format("SELECT * FROM {0}", _tableAttribute.sqliteTableName));
        T tempEntity = default(T);
        string tempPropertyName = string.Empty;
        int tempPropertyKey = 0;
        object tempValue = null;

        if (_tableAttribute.isDeterminant)
        {
            tempEntity = OnCreateInstance<T>(_tableAttribute);
            #region 行列式表
            while (reader.Read())
            {
                tempPropertyName = reader.GetString(_tableAttribute.xlsColumnNameIndex - 1);
                tempPropertyKey = tempPropertyName.UniqueHashCode();
                tempValue = reader.GetString(_tableAttribute.xlsColumnValueIndex - 1);
                tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
            }
            #endregion
            tempEntity.Resolve();
            result.Add(tempEntity);
        }
        else
        {
            #region 普通表
            while (reader.Read())
            {
                tempEntity = OnCreateInstance<T>(_tableAttribute);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    tempPropertyName = reader.GetName(i);
                    tempPropertyKey = tempPropertyName.UniqueHashCode();
                    tempValue = reader.GetValue(i);
                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                    msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                }
                tempEntity.Resolve();
                result.Add(tempEntity);
            }
            reader.Close();
            reader = null;
            #endregion
        }
        return result;
    }
    #endregion

    #region OnSelectAll 读取所有数据
    /// <summary>
    /// 读取所有数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据集合</returns>
    static List<T> OnReadAll<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        if (StrayFogGamePools.setting.isUseSQLite)
        {
            result = OnReadFromSQLite<T>(_tableAttribute);
        }
        else
        {
            result = OnReadFromXLS<T>(_tableAttribute);
        }
        return result;
    }
    #endregion

    #region OnLoadViewFromXLS 从XLS读取View数据
    /// <summary>
    /// 从XLS读取View数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据</returns>
    static List<T> OnLoadViewFromXLS<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        T tempEntity = default(T);
        if (_tableAttribute.sqliteTableType == enSQLiteEntityClassify.View)
        {
            if (_tableAttribute.tableClassType.Equals(typeof(XLS_Config_View_AssetDiskMaping)))
            {
                #region View_AssetDiskMaping 数据组装                                
                List<XLS_Config_Table_AssetDiskMapingFile> files = Select<XLS_Config_Table_AssetDiskMapingFile>();
                List<XLS_Config_Table_AssetDiskMapingFolder> folders = Select<XLS_Config_Table_AssetDiskMapingFolder>();
                Dictionary<int, XLS_Config_Table_AssetDiskMapingFile> dicFile = new Dictionary<int, XLS_Config_Table_AssetDiskMapingFile>();
                Dictionary<int, XLS_Config_Table_AssetDiskMapingFolder> dicFolder = new Dictionary<int, XLS_Config_Table_AssetDiskMapingFolder>();
                foreach (XLS_Config_Table_AssetDiskMapingFolder t in folders)
                {
                    dicFolder.Add(t.folderId, t);
                }
                int fileId = "fileId".UniqueHashCode();
                int folderId = "folderId".UniqueHashCode();
                int fileName = "fileName".UniqueHashCode();
                int inAssetPath = "inAssetPath".UniqueHashCode();
                int outAssetPath = "outAssetPath".UniqueHashCode();
                int extEnumValue = "extEnumValue".UniqueHashCode();
                foreach (XLS_Config_Table_AssetDiskMapingFile t in files)
                {
                    tempEntity = OnCreateInstance<T>(_tableAttribute);
                    msEntityPropertyInfoMaping[_tableAttribute.id][fileId].SetValue(tempEntity, t.fileId, null);
                    msEntityPropertyInfoMaping[_tableAttribute.id][folderId].SetValue(tempEntity, t.folderId, null);
                    msEntityPropertyInfoMaping[_tableAttribute.id][fileName].SetValue(tempEntity, t.inSide + t.ext, null);
                    msEntityPropertyInfoMaping[_tableAttribute.id][inAssetPath].SetValue(tempEntity, Path.Combine(dicFolder[t.folderId].inSide, t.inSide + t.ext).TransPathSeparatorCharToUnityChar(), null);
                    msEntityPropertyInfoMaping[_tableAttribute.id][outAssetPath].SetValue(tempEntity, t.outSide, null);
                    msEntityPropertyInfoMaping[_tableAttribute.id][extEnumValue].SetValue(tempEntity, t.extEnumValue, null);
                    result.Add(tempEntity);
                }
                #endregion
            }
            else if (_tableAttribute.tableClassType.Equals(typeof(XLS_Config_View_DeterminantVT)))
            {
                #region View_DeterminantVT 数据组装
                int vtNameKey = "vtName".UniqueHashCode();
                foreach (SQLiteTableMapAttribute key in msSQLiteTableMapAttributeMaping.Values)
                {
                    if (key.isDeterminant)
                    {
                        tempEntity = OnCreateInstance<T>(_tableAttribute);
                        msEntityPropertyInfoMaping[_tableAttribute.id][vtNameKey].SetValue(tempEntity, key.sqliteTableName, null);
                        result.Add(tempEntity);
                    }
                }
                #endregion
            }
        }
        return result;
    }
    #endregion    

    #region Select 查询数据集
    /// <summary>
    /// 是否已从磁盘读取数据
    /// </summary>
    static List<int> mCacheIsReadFromDisk = new List<int>();
    /// <summary>
    /// 查询数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <returns>数据集</returns>
    public static List<T> Select<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        return Select<T>(null);
    }

    /// <summary>
    /// 查询指定条件的数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    public static List<T> Select<T>(Func<T, bool> _condition)
    where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        if (mCacheIsReadFromDisk.Contains(tableAttribute.id))
        {
            result = OnGetCacheData<T>(tableAttribute);
        }
        else
        {
            result = OnReadAll<T>(tableAttribute);
            OnRefreshCacheData(result, tableAttribute, true);
            mCacheIsReadFromDisk.Add(tableAttribute.id);
        }

        if (_condition != null)
        {
            List<T> temp = new List<T>();
            foreach (T t in result)
            {
                if (_condition(t))
                {
                    temp.Add(t);
                }
            }
            result = temp;
        }
        return result;
    }
    #endregion
}