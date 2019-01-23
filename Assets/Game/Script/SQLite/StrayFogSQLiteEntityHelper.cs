using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
/// <summary>
/// StrayFogSQLite表实体帮助类
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region OnSelectAll 读取所有数据
    /// <summary>
    /// 实体属性映射
    /// </summary>
    static Dictionary<int, Dictionary<int, PropertyInfo>> msEntityPropertyInfoMaping = new Dictionary<int, Dictionary<int, PropertyInfo>>();

    /// <summary>
    /// 实体SQLite属性类型映射
    /// </summary>
    static Dictionary<int, Dictionary<int, SQLiteFieldTypeAttribute>> msEntitySQLitePropertySQLiteFieldTypeAttributeMaping = new Dictionary<int, Dictionary<int, SQLiteFieldTypeAttribute>>();

    /// <summary>
    /// SQLite数据库映射
    /// </summary>
    static Dictionary<int,StrayFogSQLiteHelper> msStrayFogSQLiteHelperMaping = new Dictionary<int, StrayFogSQLiteHelper>();

    /// <summary>
    /// 是否是ScriptableObject类
    /// </summary>
    static Dictionary<int, bool> msIsScriptableObject = new Dictionary<int, bool>();
    /// <summary>
    /// 读取所有数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entitySetting">实体设定</param>
    /// <returns>数据集合</returns>
    static List<T> OnReadAll<T>(StrayFogSQLiteEntitySetting _entitySetting)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping.ContainsKey(_entitySetting.id))
        {
            msEntitySQLitePropertySQLiteFieldTypeAttributeMaping.Add(_entitySetting.id, new Dictionary<int, SQLiteFieldTypeAttribute>());
        }
        if (!msEntityPropertyInfoMaping.ContainsKey(_entitySetting.id))
        {
            msEntityPropertyInfoMaping.Add(_entitySetting.id, new Dictionary<int, PropertyInfo>());
            Type type = typeof(T);
            PropertyInfo[] pps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.DeclaredOnly);
            if (pps != null && pps.Length > 0)
            {
                int key = 0;
                foreach (PropertyInfo p in pps)
                {
                    key = p.Name.UniqueHashCode();
                    if (!msEntityPropertyInfoMaping[_entitySetting.id].ContainsKey(key))
                    {
                        msEntityPropertyInfoMaping[_entitySetting.id].Add(key, p);
                    }
                    if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id].ContainsKey(key))
                    {
                        msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id].Add(key, p.GetFirstAttribute<SQLiteFieldTypeAttribute>());
                    }
                }
            }
        }       
        if (StrayFogGamePools.setting.isInternal)
        {
            //内部资源加载
            result = OnReadFromXLS<T>(_entitySetting);
        }
        else
        {
            //外部资源加载
            result = OnReadFromSQLite<T>(_entitySetting);
        }
        return result;
    }
    #endregion

    #region OnReadFromXLS
    /// <summary>
    /// 从XLS读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entitySetting">实体设定</param>
    /// <returns>数据集</returns>
    static List<T> OnReadFromXLS<T>(StrayFogSQLiteEntitySetting _entitySetting)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();        
        if (File.Exists(_entitySetting.xlsFileName))
        {         
            T tempEntity = default(T);
            int tempPropertyKey = 0;
            object tempValue = null;
            string tempName = string.Empty;
            bool tempIsAllValueNull = false;
            using (FileStream fs = new FileStream(_entitySetting.xlsFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ExcelPackage pck = new ExcelPackage(fs);
                if (pck.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (_entitySetting.isDeterminant)
                    {
                        #region 行列式数据写入
                        if (sheet.Dimension.Rows >= _entitySetting.xlsColumnDataIndex)
                        {
                            tempEntity = OnCreateInstance<T>();
                            for (int row = _entitySetting.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {
                                tempName = sheet.GetValue<string>(row, _entitySetting.xlsColumnNameIndex).Trim();
                                tempValue = sheet.GetValue(row, _entitySetting.xlsColumnDataIndex);
                                //如果名称为空，则认为是数据结束
                                if (string.IsNullOrEmpty(tempName))
                                {
                                    break;
                                }
                                else
                                {
                                    tempPropertyKey = tempName.UniqueHashCode();
                                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].arrayDimension);
                                    msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
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
                        if (sheet.Dimension.Rows >= _entitySetting.xlsColumnDataIndex)
                        {
                            for (int row = _entitySetting.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {
                                tempEntity = OnCreateInstance<T>();
                                tempIsAllValueNull = true;
                                for (int col = 1; col <= sheet.Dimension.Columns; col++)
                                {                                   
                                    tempName = sheet.GetValue<string>(_entitySetting.xlsColumnNameIndex, col).Trim();
                                    tempValue = sheet.GetValue(row, col);
                                    tempIsAllValueNull &= (tempValue == null);
                                    tempPropertyKey = tempName.UniqueHashCode();                                    
                                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].arrayDimension);
                                    msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
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
            result = OnLoadFromXLSView<T>(_entitySetting);
        }
        return result;
    }
    #endregion

    #region OnReadFromSQLite
    /// <summary>
    /// 从SQLite读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entitySetting">实体设定</param>
    /// <returns>数据集</returns>
    static List<T> OnReadFromSQLite<T>(StrayFogSQLiteEntitySetting _entitySetting)
        where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        if (!msStrayFogSQLiteHelperMaping.ContainsKey(_entitySetting.dbSQLiteKey))
        {
            msStrayFogSQLiteHelperMaping.Add(_entitySetting.dbSQLiteKey,
                new StrayFogSQLiteHelper(StrayFogGamePools.setting.GetSQLiteConnectionString(_entitySetting.assetBundleDbName)));
        }
        SqliteDataReader reader = msStrayFogSQLiteHelperMaping[_entitySetting.dbSQLiteKey].ExecuteQuery(string.Format("SELECT * FROM {0}", _entitySetting.tableName));
        T tempEntity = default(T);
        string tempPropertyName = string.Empty;
        int tempPropertyKey = 0;
        object tempValue = null;

        if (_entitySetting.isDeterminant)
        {
            tempEntity = OnCreateInstance<T>();
            #region 行列式表
            while (reader.Read())
            {
                tempPropertyName = reader.GetString(_entitySetting.xlsColumnNameIndex - 1);
                tempPropertyKey = tempPropertyName.UniqueHashCode();
                tempValue = reader.GetString(_entitySetting.xlsColumnDataIndex - 1);               
                tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].arrayDimension);
                msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
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
                tempEntity = OnCreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    tempPropertyName = reader.GetName(i);
                    tempPropertyKey = tempPropertyName.UniqueHashCode();
                    tempValue = reader.GetValue(i);
                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_entitySetting.id][tempPropertyKey].arrayDimension);
                    msEntityPropertyInfoMaping[_entitySetting.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
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

    #region OnCreateInstance
    /// <summary>
    /// OnCreateInstance
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <returns>实例</returns>
    static T OnCreateInstance<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        int key = OnGetTypeKey<T>();
        if (!msIsScriptableObject.ContainsKey(key))
        {
            msIsScriptableObject.Add(key, typeof(T).IsTypeOrSubTypeOf(typeof(ScriptableObject)));
        }
        return msIsScriptableObject[key] ? ScriptableObject.CreateInstance<T>() : Activator.CreateInstance<T>();
    }
    #endregion

    #region Select 获得数据集
    /// <summary>
    /// 实体缓存数据
    /// </summary>
    static Dictionary<int, object> mCacheEntityData = new Dictionary<int, object>();
    /// <summary>
    /// 获得指定条件的数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <returns>数据集</returns>
    public static List<T> Select<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        return Select<T>(null);
    }

    /// <summary>
    /// 获得指定条件的数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    public static List<T> Select<T>(Func<T, bool> _condition)
    where T : AbsStrayFogSQLiteEntity
    {
        List<T> result = new List<T>();
        StrayFogSQLiteEntitySetting entitySetting = OnGetEntitySetting<T>();
        if (mCacheEntityData.ContainsKey(entitySetting.id))
        {
            result = (List<T>)mCacheEntityData[entitySetting.id];
        }
        else
        {
            result = OnReadAll<T>(entitySetting);
            mCacheEntityData.Add(entitySetting.id, result);
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
            }
        }
    }
    #endregion
}
