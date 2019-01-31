using System.Collections.Generic;
using System.IO;
using System.Text;
using Mono.Data.Sqlite;
using OfficeOpenXml;
using UnityEngine;
/// <summary>
/// StrayFogSQLite表实体帮助类【Insert】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region OnInsertToCacheEntityData
    /// <summary>
    /// 插入数据到缓存
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_xlsRowIndex">XLS表行索引</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnInsertToCacheEntityData<T>(T _entity, SQLiteTableMapAttribute _tableAttribute, out int _xlsRowIndex)
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
                        throw new UnityException(string.Format("Can't be insert data into determinant table 【{0}->{1}】.", _tableAttribute.sqliteTableName, _tableAttribute.xlsFilePath));
                    }
                    else
                    {
                        #region 插入数据
                        List<T> data = Select<T>();
                        StringBuilder sbLog = new StringBuilder();
                        _xlsRowIndex = -1;
                        if (_tableAttribute.hasPkColumn)
                        {
                            object cacheValue = null;
                            object entityValue = null;
                            bool hasSamePKValue = true;
                            int sameRowIndex = 0;
                            #region 查询缓存数据中是否有相同主键数据
                            for (int i = 0; i < data.Count; i++)
                            {
                                hasSamePKValue = true;
                                sameRowIndex = _tableAttribute.xlsDataStartRowIndex + i;
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
                                throw new UnityException(string.Format("【{0}】has the same value 【row->{1}】【{2}】", _tableAttribute.xlsFilePath, sameRowIndex, sbLog.ToString()));
                            }
                            else
                            {
                                _xlsRowIndex = _tableAttribute.xlsDataStartRowIndex + data.Count;
                                data.Add(_entity);
                                OnRefreshCacheData(data, _tableAttribute, false);
                                result = true;
                            }
                        }
                        else
                        {
                            _xlsRowIndex = _tableAttribute.xlsDataStartRowIndex + data.Count;
                            data.Add(_entity);
                            OnRefreshCacheData(data, _tableAttribute, false);
                            result = true;
                        }
                        #endregion
                    }
                    break;
                default:
                    throw new UnityException(string.Format("Can't be insert data to 【{0}->{1}】 .", _tableAttribute.sqliteTableType, _tableAttribute.sqliteTableName));
            }
        }
        else
        {
            throw new UnityException(string.Format("Can't be insert data to table 【{0}】's canModifyData【{1}】  .", _tableAttribute.sqliteTableName, _tableAttribute.canModifyData));
        }        
        return result;
    }
    #endregion    

    #region Insert 插入数据
    /// <summary>
    /// 插入数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <returns>true:成功,false:失败</returns>
    public static bool Insert<T>(T _entity)
         where T : AbsStrayFogSQLiteEntity
    {
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        int xlsRowIndex = -1;
        bool result = OnInsertToCacheEntityData(_entity, tableAttribute, out xlsRowIndex);
        if (result)
        {
            if (StrayFogGamePools.setting.isInternal)
            {
                #region 插入内部资源 XLS表                      
                if (File.Exists(tableAttribute.xlsFilePath))
                {
                    ExcelPackage pck = OnGetExcelPackage(tableAttribute);
                    {
                        if (pck.Workbook.Worksheets.Count > 0)//消耗2秒
                        {
                            ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                            if (sheet.Dimension.Rows >= tableAttribute.xlsColumnValueIndex)
                            {
                                foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[tableAttribute.id])
                                {
                                    sheet.Cells[xlsRowIndex, key.Value.xlsColumnIndex].Value = StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[tableAttribute.id][key.Key], key.Value);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region 插入外部资源 SQLite
                #endregion
            }
        }
        return result;
    }
    #endregion    
}