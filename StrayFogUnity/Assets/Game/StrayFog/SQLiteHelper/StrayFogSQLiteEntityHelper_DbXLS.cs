using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// StrayFogSQLite表实体帮助类【DbXLS】
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
    static Dictionary<int, AbsStrayFogSQLiteEntity> OnReadFromXLS<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, AbsStrayFogSQLiteEntity> result = new Dictionary<int, AbsStrayFogSQLiteEntity>();
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
                            result.Add(tempEntity.pkSequenceId, tempEntity);
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
                                    tempPropertyKey = tempName.UniqueHashCode();
#if UNITY_EDITOR
                                    if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id].ContainsKey(tempPropertyKey))
                                    {
                                        Debug.LogErrorFormat("Can't find column 【{0}】for table 【{1}】", tempName, _tableAttribute.sqliteTableName);
                                    }
#endif
                                    if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].isIngore)
                                    {
                                        tempValue = sheet.GetValue(row, col);
                                        tempIsAllValueNull &= (tempValue == null);
                                        tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                                        msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                                    }
                                }
                                if (tempIsAllValueNull)
                                {//如果所有列为空，则认为是数据结束
                                    break;
                                }
                                else
                                {
                                    tempEntity.Resolve();
                                    result.Add(tempEntity.pkSequenceId, tempEntity);
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

    #region OnLoadViewFromXLS 从XLS读取View数据
    /// <summary>
    /// 从XLS读取View数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据</returns>
    static Dictionary<int, AbsStrayFogSQLiteEntity> OnLoadViewFromXLS<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, AbsStrayFogSQLiteEntity> result = new Dictionary<int, AbsStrayFogSQLiteEntity>();
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
                    tempEntity.Resolve();
                    result.Add(tempEntity.pkSequenceId, tempEntity);
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
                        tempEntity.Resolve();
                        result.Add(tempEntity.pkSequenceId, tempEntity);
                    }
                }
                #endregion
            }
        }
        return result;
    }
    #endregion    
}
