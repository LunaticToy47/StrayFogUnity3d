using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
/// <summary>
/// 配置表实体帮助类
/// </summary>
public sealed partial class StrayFogConfigHelper
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
        return (T)Activator.CreateInstance(typeof(T), _tableAttribute.hasPkColumn && _tableAttribute.canModifyData);
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
    /// <summary>
    /// 删除ExcelPackage
    /// </summary>
    /// <param name="_tableAttribute">表属性</param>    
    static void OnRemoveExcelPackage(SQLiteTableMapAttribute _tableAttribute)
    {
        mExcelPackageMaping.Remove(_tableAttribute.id);
    }
    #endregion

    #region mCacheEntityData 实体缓存数据
    /// <summary>
    /// 实体缓存数据
    /// Key:表
    /// Value:Dictionary<int, T> where T:AbsStrayFogSQLiteEntity
    /// </summary>
    static Dictionary<int, object> mCacheEntityData = new Dictionary<int, object>();
    #endregion

    #region OnRefreshCacheData 刷新内存数据
    /// <summary>
    /// 需要刷新的内存数据
    /// </summary>
    static List<int> mRefreshCacheData = new List<int>();
    /// <summary>
    /// 刷新内存数据
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_data">数据</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_isReadFromDisk">是否是从磁盘读取数据</param>
    static void OnRefreshCacheData<T>(Dictionary<int, T> _data, SQLiteTableMapAttribute _tableAttribute, 
        bool _isReadFromDisk)
        where T : AbsStrayFogSQLiteEntity
    {
        if (!mCacheEntityData.ContainsKey(_tableAttribute.id))
        {
            mCacheEntityData.Add(_tableAttribute.id, _data);
        }
        else
        {
            mCacheEntityData[_tableAttribute.id] = _data;
        }
        if (!_isReadFromDisk && !mRefreshCacheData.Contains(_tableAttribute.id))
        {
            mRefreshCacheData.Add(_tableAttribute.id);
        }
    }
    #endregion

    #region OnGetCacheData 获得内存数据
    /// <summary>
    /// 获得内存数据
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    static Dictionary<int, T> OnGetCacheData<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        return mCacheEntityData.ContainsKey(_tableAttribute.id) ?
            (Dictionary<int, T>)mCacheEntityData[_tableAttribute.id] : new Dictionary<int, T>();
    }
    #endregion

    #region OnSelectAll 读取所有数据
    /// <summary>
    /// 读取所有数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据集合</returns>
    static Dictionary<int, T> OnReadAll<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, T> result = new Dictionary<int, T>();
        if (StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseSQLite)
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

        //SQLiteTableMapAttribute
        if (!msSQLiteTableMapAttributeMaping.ContainsKey(key))
        {
            tableAttribute = typeof(T).GetFirstAttribute<SQLiteTableMapAttribute>();
            msSQLiteTableMapAttributeMaping.Add(key, tableAttribute);
        }
        else
        {
            tableAttribute = msSQLiteTableMapAttributeMaping[key];
        }

        //SQLiteFieldTypeAttribute
        if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping.ContainsKey(tableAttribute.id))
        {
            msEntitySQLitePropertySQLiteFieldTypeAttributeMaping.Add(tableAttribute.id, new Dictionary<int, SQLiteFieldTypeAttribute>());
        }

        //PropertyInfo
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

        //SQLiteHelper
        if (StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseSQLite)
        {
            if (!msStrayFogSQLiteHelperMaping.ContainsKey(tableAttribute.dbSQLiteKey))
            {
                if (StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseAssetBundle)
                {
                    msStrayFogSQLiteHelperMaping.Add(tableAttribute.dbSQLiteKey,
                        new StrayFogSQLiteHelper(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().GetSQLiteConnectionString(tableAttribute.dbSQLiteAssetBundleName)));
                }
                else
                {
                    msStrayFogSQLiteHelperMaping.Add(tableAttribute.dbSQLiteKey,
                        new StrayFogSQLiteHelper(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().GetSQLiteConnectionString(tableAttribute.dbSQLitePath)));
                }
            }
        }        
        return tableAttribute;
    }
    #endregion

    #region GetPropertyId
    /// <summary>
    /// 获得属性Id
    /// </summary>
    /// <param name="_propertyName">属性名称</param>
    /// <returns>属性Id</returns>
    public static int GetPropertyId(string _propertyName)
    {
        return _propertyName.UniqueHashCode();
    }
    #endregion

    #region 获得PropertyInfo
    /// <summary>
    /// 获得PropertyInfo
    /// </summary>
    /// <param name="_tableAttribute">表属性</param>
    /// <param name="_propertyId">属性Id</param>
    /// <returns>PropertyInfo</returns>
    public static PropertyInfo GetPropertyInfo(SQLiteTableMapAttribute _tableAttribute, int _propertyId)
    {
        return msEntityPropertyInfoMaping[_tableAttribute.id][_propertyId];
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
            if (mRefreshCacheData.Contains(key.Key))
            {
                key.Value.Save();

                Debug.LogFormat("Save ExcelPackage =>{0}", key.Value.File.FullName);
            }
        }
        mRefreshCacheData.Clear();
        mExcelPackageMaping.Clear();
#endif
    }
    #endregion
}
