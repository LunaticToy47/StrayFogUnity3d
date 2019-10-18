using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// StrayFogSQLite表实体帮助类【DbSQLite】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region OnReadFromSQLite
    /// <summary>
    /// 从SQLite读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据集</returns>
    static Dictionary<int, AbsStrayFogSQLiteEntity> OnReadFromSQLite<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, AbsStrayFogSQLiteEntity> result = new Dictionary<int, AbsStrayFogSQLiteEntity>();
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
            result.Add(tempEntity.pkSequenceId, tempEntity);
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
                    if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].isIngore)
                    {
                        tempValue = reader.GetValue(i);
                        tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                        msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                    }
                }
                tempEntity.Resolve();
                result.Add(tempEntity.pkSequenceId, tempEntity);
            }
            reader.Close();
            reader = null;
            #endregion
        }
        return result;
    }
    #endregion

    #region CloseDb 关闭所有用到的SQLite数据库
    /// <summary>
    /// 关闭所有用到的SQLite数据库
    /// </summary>
    public static void CloseSQLite()
    {
        if (msStrayFogSQLiteHelperMaping.Count > 0)
        {
            foreach (StrayFogSQLiteHelper db in msStrayFogSQLiteHelperMaping.Values)
            {
                db.Close();
#if UNITY_EDITOR
                Debug.LogFormat("Close DbSQlite =>{0}",db.connectionString);
#endif
            }
        }
        msStrayFogSQLiteHelperMaping.Clear();
    }
    #endregion
}
