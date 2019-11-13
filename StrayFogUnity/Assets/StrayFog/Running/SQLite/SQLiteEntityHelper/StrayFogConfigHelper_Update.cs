using Mono.Data.Sqlite;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
/// <summary>
/// 配置表实体帮助类【Update】
/// </summary>
public sealed partial class StrayFogConfigHelper
{
    #region OnUpdateToCacheEntityData 更新数据到缓存
    /// <summary>
    /// 更新数据到缓存
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_xlsRowIndex">XLS表行索引</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnUpdateToCacheEntityData<T>(T _entity, SQLiteTableMapAttribute _tableAttribute, out int _xlsRowIndex)
        where T : AbsStrayFogSQLiteEntity
    {
        bool result = false;
        _xlsRowIndex = -1;
        if (_tableAttribute.canModifyData)
        {
            switch (_tableAttribute.sqliteTableType)
            {
                case enSQLiteEntityClassify.Table:
                    #region 更新数据
                    Dictionary<int, AbsStrayFogSQLiteEntity> data = OnSelect<T>(null);
                    StringBuilder sbLog = new StringBuilder();
                    if (_tableAttribute.isDeterminant)
                    {
                        #region 更新行列式表
                        if (data.ContainsKey(_entity.pkSequenceId))
                        {
                            data[_entity.pkSequenceId] = _entity;
                        }
                        else
                        {
                            data.Add(_entity.pkSequenceId, _entity);
                        }
                        OnRefreshCacheData(data, _tableAttribute, false);
                        result = true;
                        #endregion
                    }
                    else
                    {
                        #region 更新普通表                        
                        if (_tableAttribute.hasPkColumn)
                        {
                            object cacheValue = null;
                            object entityValue = null;
                            bool hasSamePKValue = data.Count > 0;
                            int sameRowIndex = -1;
                            #region 查询缓存数据中是否有相同主键数据
                            foreach (KeyValuePair<int, AbsStrayFogSQLiteEntity> entity in data)
                            {
                                hasSamePKValue = data.Count > 0;
                                sameRowIndex++;
                                foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
                                {
                                    if (key.Value.isPK)
                                    {
                                        cacheValue = msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].GetValue(entity.Value, null);
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
                                _xlsRowIndex = _tableAttribute.xlsDataStartRowIndex + sameRowIndex;                             
                                data[_entity.pkSequenceId] = _entity;
                                OnRefreshCacheData(data, _tableAttribute, false);
                                result = true;
                            }
                            else
                            {
                                throw new UnityException(string.Format("【{0}】can't find value 【{1}】", _tableAttribute.xlsFilePath, sbLog.ToString()));
                            }
                        }
                        else
                        {
                            throw new UnityException(string.Format("Can't be update data table 【{0}->{1}】has't 【PK】column.", _tableAttribute.sqliteTableName, _tableAttribute.xlsFilePath));
                        }
                        #endregion
                    }
                    #endregion
                    break;
                default:
                    throw new UnityException(string.Format("Can't be update data to 【{0}->{1}】 .", _tableAttribute.sqliteTableType, _tableAttribute.sqliteTableName));
            }
        }
        else
        {
            throw new UnityException(string.Format("Can't be update data to table 【{0}】's canModifyData【{1}】  .", _tableAttribute.sqliteTableName, _tableAttribute.canModifyData));
        }
        return result;
    }
    #endregion    

    #region OnUpdateToXLS 更新数据到XLS表
    /// <summary>
    /// 更新数据到XLS表
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_xlsRowIndex">行索引</param>
    static void OnUpdateToXLS<T>(T _entity, SQLiteTableMapAttribute _tableAttribute, int _xlsRowIndex)
        where T : AbsStrayFogSQLiteEntity
    {
        if (File.Exists(_tableAttribute.xlsFilePath))
        {
            ExcelPackage pck = OnGetExcelPackage(_tableAttribute);
            {
                if (pck.Workbook.Worksheets.Count > 0)//消耗2秒
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (_tableAttribute.isDeterminant)
                    {
                        foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
                        {
                            sheet.Cells[key.Value.xlsColumnValueIndex, _tableAttribute.xlsColumnValueIndex].Value = StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value);
                        }
                    }
                    else
                    {
                        if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex)
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
    }
    #endregion

    #region OnUpdateToSQLite 更新数据到SQLite
    /// <summary>
    /// 更新数据到SQLite
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <param name="_tableAttribute">表属性</param>
    static void OnUpdateToSQLite<T>(T _entity, SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {        
        Dictionary<string, List<SqliteParameter>> dicSql = new Dictionary<string, List<SqliteParameter>>();
        if (_tableAttribute.isDeterminant)
        {
            string pfxSet = "Set";
            foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
            {
                dicSql.Add(string.Format("UPDATE {0} SET {1} WHERE {2}",
                    _tableAttribute.sqliteTableName,
                    key.Value.sqliteColumnValue + "=" + key.Value.sqliteParameterName + pfxSet,
                    key.Value.sqliteColumnName + "=" + key.Value.sqliteParameterName),
                    new List<SqliteParameter>() {
                        new SqliteParameter(key.Value.sqliteParameterName + pfxSet, StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value)),
                        new SqliteParameter(key.Value.sqliteParameterName,msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].Name) }
                    );
            }
            msStrayFogSQLiteHelperMaping[_tableAttribute.dbSQLiteKey].ExecuteTransaction(dicSql);
        }
        else
        {
            List<string> pks = new List<string>();
            List<string> sets = new List<string>();
            List<SqliteParameter> sps = new List<SqliteParameter>();
            foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
            {
                if (key.Value.isPK)
                {
                    pks.Add(key.Value.sqliteColumnName + "=" + key.Value.sqliteParameterName);
                }
                else
                {
                    sets.Add(key.Value.sqliteColumnName+"="+key.Value.sqliteParameterName);
                }
                sps.Add(new SqliteParameter(key.Value.sqliteParameterName, StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value)));
            }
            string sql = string.Format("UPDATE {0} SET {1} WHERE {2}", _tableAttribute.sqliteTableName, string.Join(",", sets.ToArray()), string.Join(",", pks.ToArray()));
            msStrayFogSQLiteHelperMaping[_tableAttribute.dbSQLiteKey].ExecuteNonQuery(sql, sps.ToArray());
        }
    }
    #endregion

    #region 更新数据集
    /// <summary>
    /// 插入数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <returns>true:成功,false:失败</returns>
    public static bool Update<T>(T _entity)
         where T : AbsStrayFogSQLiteEntity
    {
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        bool result = false;
        if (tableAttribute.canModifyData)
        {
            switch (tableAttribute.sqliteTableType)
            {
                case enSQLiteEntityClassify.Table:
                    #region 更新数据
                    int xlsRowIndex = -1;
                    result = OnUpdateToCacheEntityData(_entity, tableAttribute, out xlsRowIndex);
                    if (result)
                    {
                        if (StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseSQLite)
                        {
                            OnUpdateToSQLite(_entity,tableAttribute);
                        }
                        else
                        {
                            OnUpdateToXLS(_entity, tableAttribute, xlsRowIndex);
                        }
                    }
                    #endregion
                    break;
                default:
                    throw new UnityException(string.Format("Can't be update data to 【{0}->{1}】 .", tableAttribute.sqliteTableType, tableAttribute.sqliteTableName));
            }
        }
        else
        {
            throw new UnityException(string.Format("Can't be update data to table 【{0}】's canModifyData【{1}】  .", tableAttribute.sqliteTableName, tableAttribute.canModifyData));
        }
        return result;
    }
    #endregion
}