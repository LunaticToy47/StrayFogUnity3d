using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
/// <summary>
/// StrayFogSQLite表实体帮助类【Refresh】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region Refresh 刷新数据集
    /// <summary>
    /// 刷新数据集【速度很慢，慎用】
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <returns>数据集</returns>
    public static List<T> Refresh<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        return Select<T>(null);
    }

    /// <summary>
    /// 刷新指定条件的数据集【速度很慢，慎用】
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    public static List<T> Refresh<T>(Func<T, bool> _condition)
    where T : AbsStrayFogSQLiteEntity
    {
        List<T> fromCache = new List<T>();
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        List<T> fromDisk = OnReadAll<T>(tableAttribute);
        if (tableAttribute.hasPkColumn && fromDisk.Count > 0)
        {   //如果有磁盘数据，则进行对比处理
            //如果有主键，则相同主键的磁盘数据覆盖缓存数据
            fromCache = OnGetCacheData<T>(tableAttribute);            
            Dictionary<int, T> fromDiskMaping = new Dictionary<int, T>();
            Dictionary<int, T> fromCacheMaping = new Dictionary<int, T>();
            StringBuilder cacheKey = new StringBuilder();
            #region 统计磁盘数据
            foreach (T disk in fromDisk)
            {
                cacheKey.Length = 0;
                foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[tableAttribute.id])
                {
                    if (key.Value.isPK)
                    {
                        cacheKey.Append(msEntityPropertyInfoMaping[tableAttribute.id][key.Key].GetValue(disk, null).ToString());                        
                    }
                }
                fromDiskMaping.Add(cacheKey.ToString().UniqueHashCode(), disk);
            }
            #endregion

            #region 统计缓存数据
            foreach (T cache in fromCache)
            {
                cacheKey.Length = 0;
                foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[tableAttribute.id])
                {
                    if (key.Value.isPK)
                    {
                        cacheKey.Append(msEntityPropertyInfoMaping[tableAttribute.id][key.Key].GetValue(cache, null).ToString());
                    }
                }
                fromCacheMaping.Add(cacheKey.ToString().UniqueHashCode(), cache);
            }
            #endregion

            #region 对比磁盘与缓存数据
            bool isRest = false;
            foreach (KeyValuePair<int, T> disk in fromDiskMaping)
            {
                if (fromCacheMaping.ContainsKey(disk.Key))
                {
                    isRest = _condition == null || _condition(disk.Value);
                    if (isRest)
                    {
                        fromCacheMaping[disk.Key] = disk.Value;
                    }
                }
            }
            #endregion

            fromDiskMaping = null;
            if (fromCacheMaping.Count > 0)
            {
                fromCache = new List<T>(fromCacheMaping.Values);
            }
            OnRefreshCacheData(fromCache, tableAttribute, false);
        }
        else
        {//如果没有主键，则磁盘数据直接覆盖缓存数据
            fromCache = fromDisk;
            OnRefreshCacheData(fromCache, tableAttribute, true);
        }
        return fromCache;
    }
    #endregion
}