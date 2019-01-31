﻿using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
/// <summary>
/// StrayFogSQLite表实体帮助类【Delete】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region OnDeleteToCacheEntityData 从缓存删除数据
    /// <summary>
    /// 从缓存删除数据
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_xlsRowIndex">XLS表行索引</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnDeleteToCacheEntityData<T>(T _entity, SQLiteTableMapAttribute _tableAttribute, out int _xlsRowIndex)
        where T : AbsStrayFogSQLiteEntity
    {
        bool result = false;
        if (_tableAttribute.canModifyData)
        {
            switch (_tableAttribute.sqliteTableType)
            {
                case enSQLiteEntityClassify.Table:
                    if (_tableAttribute.isDeterminant)
                    {
                        throw new UnityException(string.Format("Can't be delete data from determinant table 【{0}->{1}】.", _tableAttribute.sqliteTableName, _tableAttribute.xlsFilePath));
                    }
                    else
                    {
                        #region 删除数据                      
                        if (_tableAttribute.hasPkColumn)
                        {
                            List<T> data = Select<T>();
                            StringBuilder sbLog = new StringBuilder();
                            _xlsRowIndex = -1;
                            object cacheValue = null;
                            object entityValue = null;
                            bool hasSamePKValue = true;

                            #region 查询缓存数据中是否有相同主键数据
                            for (int i = 0; i < data.Count; i++)
                            {
                                hasSamePKValue = true;
                                _xlsRowIndex = i;
                                foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
                                {
                                    if (key.Value.isPK)
                                    {
                                        cacheValue = msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].GetValue(data[i], null);
                                        entityValue = msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].GetValue(_entity, null);
                                        hasSamePKValue &= cacheValue.Equals(entityValue);
                                        sbLog.AppendFormat("【{0}->{1}】", msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].Name, entityValue);
                                    }
                                }
                                if (hasSamePKValue)
                                {
                                    break;
                                }
                            }
                            #endregion

                            if (hasSamePKValue)
                            {
                                data.RemoveAt(_xlsRowIndex);
                                _xlsRowIndex = _tableAttribute.xlsDataStartRowIndex + _xlsRowIndex;                                
                                OnRefreshCacheData(data, _tableAttribute, false);
                                result = true;
                            }
                            else
                            {
                                throw new UnityException(string.Format("Can't find the same pk row【{0}】=>{1}.", _tableAttribute.xlsFilePath, sbLog.ToString()));
                            }
                        }
                        else
                        {
                            throw new UnityException(string.Format("Can't be delete data to table 【{0}->{1}】has no PK column .", _tableAttribute.sqliteTableType, _tableAttribute.sqliteTableName));
                        }
                        #endregion
                    }
                    break;
                default:
                    throw new UnityException(string.Format("Can't be delete data to 【{0}->{1}】 .", _tableAttribute.sqliteTableType, _tableAttribute.sqliteTableName));
            }
        }
        else
        {
            throw new UnityException(string.Format("Can't be delete data to table 【{0}】's canModifyData【{1}】  .", _tableAttribute.sqliteTableName, _tableAttribute.canModifyData));
        }
        return result;
    }
    #endregion    

    #region Delete 删除数据集
    /// <summary>
    /// Delete 删除数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <returns>true:成功,false:失败</returns>
    public static bool Delete<T>(T _entity)
         where T : AbsStrayFogSQLiteEntity
    {
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        int xlsRowIndex = -1;
        bool result = OnDeleteToCacheEntityData(_entity, tableAttribute, out xlsRowIndex);
        if (result)
        {
            if (StrayFogGamePools.setting.isInternal)
            {
                #region 删除内部资源 XLS表                      
                if (File.Exists(tableAttribute.xlsFilePath))
                {
                    ExcelPackage pck = OnGetExcelPackage(tableAttribute);
                    {
                        if (pck.Workbook.Worksheets.Count > 0)//消耗2秒
                        {
                            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                            sheet.DeleteRow(xlsRowIndex);
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 删除外部资源 SQLite
                #endregion
            }
        }
        return result;
    }
    #endregion
}
