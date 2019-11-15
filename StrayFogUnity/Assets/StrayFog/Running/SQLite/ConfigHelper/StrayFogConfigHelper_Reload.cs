using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// SQLite数据重新加载分类
/// </summary>
public enum enSQLiteReloadClassify
{
    /// <summary>
    /// 磁盘覆盖所有缓存数据
    /// </summary>
    [AliasTooltip("磁盘覆盖所有缓存数据")]
    DiskCoverAllCahche,
    /// <summary>
    /// 磁盘覆盖与缓存相同的数据
    /// </summary>
    [AliasTooltip("磁盘覆盖与缓存相同的数据")]
    DiskCoverSameCache,
}
/// <summary>
/// 配置表实体帮助类【Reload】
/// </summary>
public sealed partial class StrayFogConfigHelper
{
    #region Reload 重新加载数据集
    /// <summary>
    /// 重新加载数据集【速度很慢，慎用】
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <returns>数据集</returns>
    public static List<T> Reload<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        return Reload<T>(enSQLiteReloadClassify.DiskCoverSameCache);
    }

    /// <summary>
    /// 重新加载数据集【速度很慢，慎用】
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_reloadClassify">重新加载分类</param>
    /// <returns>数据集</returns>
    public static List<T> Reload<T>(enSQLiteReloadClassify _reloadClassify)
        where T : AbsStrayFogSQLiteEntity
    {
        return Reload<T>(_reloadClassify, null);
    }

    /// <summary>
    /// 重新加载指定条件的数据集【速度很慢，慎用】
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_reloadClassify">重新加载分类</param>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    public static List<T> Reload<T>(enSQLiteReloadClassify _reloadClassify,Func<T, bool> _condition)
    where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, T>  cache = OnReload<T>(_reloadClassify, _condition);
        T[] result = new T[cache.Count];
        cache.Values.CopyTo(result, 0);
        return new List<T>(result);
    }

    /// <summary>
    /// 重新加载指定条件的数据集【速度很慢，慎用】
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_reloadClassify">重新加载分类</param>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    static Dictionary<int, T> OnReload<T>(enSQLiteReloadClassify _reloadClassify, Func<T, bool> _condition)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, T> fromCache = new Dictionary<int, T>();
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        OnRemoveExcelPackage(tableAttribute);
        Dictionary<int, T> fromDisk = OnReadAll<T>(tableAttribute);
        switch (_reloadClassify)
        {
            case enSQLiteReloadClassify.DiskCoverSameCache:
                #region 覆盖相同数据
                if (tableAttribute.hasPkColumn && fromDisk.Count > 0)
                {   //如果有磁盘数据，则进行对比处理
                    //如果有主键，则相同主键的磁盘数据覆盖缓存数据
                    fromCache = OnGetCacheData<T>(tableAttribute);
                    Dictionary<int, T> fromDiskMaping = new Dictionary<int, T>();
                    Dictionary<int, T> fromCacheMaping = new Dictionary<int, T>();
                    StringBuilder cacheKey = new StringBuilder();
                    #region 统计磁盘数据
                    foreach (T disk in fromDisk.Values)
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
                    foreach (T cache in fromCache.Values)
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
                            isRest = _condition == null || _condition((T)disk.Value);
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
                        fromCache = fromCacheMaping;
                    }
                    OnRefreshCacheData(fromCache, tableAttribute, false);
                }
                else
                {//如果没有主键，则磁盘数据直接覆盖缓存数据
                    fromCache = fromDisk;
                    OnRefreshCacheData(fromCache, tableAttribute, true);
                }
                #endregion
                break;
            case enSQLiteReloadClassify.DiskCoverAllCahche:
                #region 覆盖所有数据
                fromCache = fromDisk;
                OnRefreshCacheData(fromCache, tableAttribute, true);
                #endregion
                break;
        }
        return fromCache;
    }
    #endregion
}