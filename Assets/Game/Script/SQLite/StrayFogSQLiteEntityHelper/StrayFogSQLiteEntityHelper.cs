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
    #region 静态映射
    /// <summary>
    /// 实体属性映射
    /// </summary>
    static Dictionary<int, Dictionary<int, PropertyInfo>> msEntityPropertyInfoMaping = new Dictionary<int, Dictionary<int, PropertyInfo>>();

    /// <summary>
    /// SQLite数据库映射
    /// </summary>
    static Dictionary<int, StrayFogSQLiteHelper> msStrayFogSQLiteHelperMaping = new Dictionary<int, StrayFogSQLiteHelper>();

    /// <summary>
    /// 实体SQLite表属性映射
    /// </summary>
    static Dictionary<int, SQLiteTableMapAttribute> msSQLiteTableMapAttributeMaping = new Dictionary<int, SQLiteTableMapAttribute>();

    /// <summary>
    /// 实体SQLite属性类型映射
    /// </summary>
    static Dictionary<int, Dictionary<int, SQLiteFieldTypeAttribute>> msEntitySQLitePropertySQLiteFieldTypeAttributeMaping = new Dictionary<int, Dictionary<int, SQLiteFieldTypeAttribute>>();
    #endregion

    #region OnCreateInstance 创建实体
    /// <summary>
    /// 创建实体
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>实例</returns>
    static T OnCreateInstance<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        return (T)Activator.CreateInstance(typeof(T), _tableAttribute.hasPkColumn);
    }
    #endregion

    #region OnGetExcelPackage 获得ExcelPackage
    /// <summary>
    /// ExcelPackage映射
    /// </summary>
    static Dictionary<int, ExcelPackage> mExcelPackageMaping = new Dictionary<int, ExcelPackage>();
    /// <summary>
    /// 获得ExcelPackage
    /// </summary>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>ExcelPackage</returns>
    static ExcelPackage OnGetExcelPackage(SQLiteTableMapAttribute _tableAttribute)
    {
        if (!mExcelPackageMaping.ContainsKey(_tableAttribute.id))
        {
            mExcelPackageMaping.Add(_tableAttribute.id, new ExcelPackage(new FileInfo(_tableAttribute.xlsFilePath)));
        }
        return mExcelPackageMaping[_tableAttribute.id];
    }
    #endregion

    #region mCacheEntityData 实体缓存数据
    /// <summary>
    /// 实体缓存数据
    /// </summary>
    static Dictionary<int, object> mCacheEntityData = new Dictionary<int, object>();
    #endregion

    #region OnUpdateCacheData 变更内存数据
    /// <summary>
    /// 变更内存数据
    /// </summary>
    static List<int> mUpdateCacheData = new List<int>();
    /// <summary>
    /// 刷新内存
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_data">数据</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_isReadFromDisk">是否是从磁盘读取数据</param>
    static void OnUpdateCacheData<T>(List<T> _data, SQLiteTableMapAttribute _tableAttribute, 
        bool _isReadFromDisk) where T : AbsStrayFogSQLiteEntity
    {
        if (!mCacheEntityData.ContainsKey(_tableAttribute.id))
        {
            mCacheEntityData.Add(_tableAttribute.id, _data);
        }
        else
        {
            mCacheEntityData[_tableAttribute.id] = _data;
        }
        if (!_isReadFromDisk && !mUpdateCacheData.Contains(_tableAttribute.id))
        {
            mUpdateCacheData.Add(_tableAttribute.id);
        }
    }
    #endregion

    #region OnGetCacheData 获得内存数据
    /// <summary>
    /// 获得内存数据
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    static List<T> OnGetCacheData<T>(SQLiteTableMapAttribute _tableAttribute) where T : AbsStrayFogSQLiteEntity
    {
        return mCacheEntityData.ContainsKey(_tableAttribute.id) ? (List<T>)mCacheEntityData[_tableAttribute.id] : new List<T>();
    }
    #endregion

    #region GetTableAttribute 获得表属性
    /// <summary>
    /// 获得表属性
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <returns>表属性</returns>
    public static SQLiteTableMapAttribute GetTableAttribute<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        int key = typeof(T).GetHashCode();
        int propertyKey = 0;
        Type entityType = typeof(T);
        SQLiteTableMapAttribute tableAttribute = null;
        SQLiteFieldTypeAttribute fieldAttribute = null;
        if (!msSQLiteTableMapAttributeMaping.ContainsKey(key))
        {
            tableAttribute = typeof(T).GetFirstAttribute<SQLiteTableMapAttribute>();
            msSQLiteTableMapAttributeMaping.Add(key, tableAttribute);
        }
        else
        {
            tableAttribute = msSQLiteTableMapAttributeMaping[key];
        }

        if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping.ContainsKey(tableAttribute.id))
        {
            msEntitySQLitePropertySQLiteFieldTypeAttributeMaping.Add(tableAttribute.id, new Dictionary<int, SQLiteFieldTypeAttribute>());
        }

        if (!msEntityPropertyInfoMaping.ContainsKey(tableAttribute.id))
        {
            msEntityPropertyInfoMaping.Add(tableAttribute.id, new Dictionary<int, PropertyInfo>());

            PropertyInfo[] pps = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.DeclaredOnly);
            if (pps != null && pps.Length > 0)
            {
                foreach (PropertyInfo p in pps)
                {
                    propertyKey = p.Name.UniqueHashCode();
                    fieldAttribute = p.GetFirstAttribute<SQLiteFieldTypeAttribute>();
                    if (fieldAttribute != null)
                    {
                        if (!msEntityPropertyInfoMaping[tableAttribute.id].ContainsKey(propertyKey))
                        {
                            msEntityPropertyInfoMaping[tableAttribute.id].Add(propertyKey, p);
                        }
                        if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[tableAttribute.id].ContainsKey(propertyKey))
                        {
                            msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[tableAttribute.id].Add(propertyKey, fieldAttribute);
                        }
                    }
                }
            }
        }

        return tableAttribute;
    }
    #endregion

    #region SaveExcelPackage 保存ExcelPackage
    /// <summary>
    /// 保存ExcelPackage
    /// </summary>
    public static void SaveExcelPackage()
    {
#if UNITY_EDITOR
        foreach (KeyValuePair<int, ExcelPackage> key in mExcelPackageMaping)
        {
            if (mUpdateCacheData.Contains(key.Key))
            {
                key.Value.Save();

                Debug.LogFormat("Save ExcelPackage =>{0}", key.Value.File.FullName);
            }
        }
        mUpdateCacheData.Clear();
        mExcelPackageMaping.Clear();
#endif
    }
    #endregion
}
