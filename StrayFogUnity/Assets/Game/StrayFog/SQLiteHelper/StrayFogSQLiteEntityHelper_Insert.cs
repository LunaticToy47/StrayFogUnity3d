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
    #region OnInsertToCacheEntityData 插入数据到缓存
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
                            bool hasSamePKValue = data.Count > 0;
                            int sameRowIndex = 0;
                            #region 查询缓存数据中是否有相同主键数据
                            for (int i = 0; i < data.Count; i++)
                            {
                                hasSamePKValue = data.Count > 0;
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

    #region OnInsertIntoXLS 插入数据到XLS表
    /// <summary>
    /// 插入数据到XLS表
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_xlsRowIndex">行索引</param>
    static void OnInsertIntoXLS<T>(T _entity, SQLiteTableMapAttribute _tableAttribute,int _xlsRowIndex)
        where T : AbsStrayFogSQLiteEntity
    {
        if (File.Exists(_tableAttribute.xlsFilePath))
        {
            ExcelPackage pck = OnGetExcelPackage(_tableAttribute);
            {
                if (pck.Workbook.Worksheets.Count > 0)//消耗2秒
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex - 1)
                    {
                        foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
                        {
                            sheet.Cells[_xlsRowIndex, key.Value.xlsColumnValueIndex].Value = StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value);
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region OnInsertIntoSQLite 插入数据到SQLite
    /// <summary>
    /// 插入数据到SQLite
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    static void OnInsertIntoSQLite<T>(T _entity, SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        List<string> values = new List<string>();
        List<SqliteParameter> valueSps = new List<SqliteParameter>();
        foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
        {
            values.Add(key.Value.sqliteParameterName);
            valueSps.Add(new SqliteParameter(key.Value.sqliteParameterName, StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value)));
        }
        string sql = string.Format("INSERT INTO {0} VALUES({1})", _tableAttribute.sqliteTableName, string.Join(",", values.ToArray()));
        msStrayFogSQLiteHelperMaping[_tableAttribute.dbSQLiteKey].ExecuteNonQuery(sql, valueSps.ToArray());
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
            if (StrayFogGamePools.setting.isUseSQLite)
            {
                OnInsertIntoSQLite(_entity, tableAttribute);
            }
            else
            {
                OnInsertIntoXLS(_entity, tableAttribute, xlsRowIndex);
            }
        }
        return result;
    }
    #endregion    
}