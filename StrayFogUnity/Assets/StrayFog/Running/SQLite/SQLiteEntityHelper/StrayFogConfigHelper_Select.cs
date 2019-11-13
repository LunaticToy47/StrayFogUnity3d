using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 配置表实体帮助类【Select】
/// </summary>
public sealed partial class StrayFogConfigHelper
{
    #region Select 查询数据集
    /// <summary>
    /// 是否已从磁盘读取数据
    /// </summary>
    static List<int> mCacheIsReadFromDisk = new List<int>();
    /// <summary>
    /// 查询数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <returns>数据集</returns>
    public static List<T> Select<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        return Select<T>(null);
    }

    /// <summary>
    /// 查询指定条件的数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    public static List<T> Select<T>(Func<T, bool> _condition)
    where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, AbsStrayFogSQLiteEntity>  result = OnSelect<T>(_condition);
        T[] data = new T[result.Count];
        result.Values.CopyTo(data, 0);
        return new List<T>(data);
    }
    #endregion

    #region OnSelect 查询指定条件的数据集
    /// <summary>
    /// 查询指定条件的数据集
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_condition">条件</param>
    /// <returns>数据集</returns>
    static Dictionary<int, AbsStrayFogSQLiteEntity> OnSelect<T>(Func<T, bool> _condition)
    where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, AbsStrayFogSQLiteEntity> result = new Dictionary<int, AbsStrayFogSQLiteEntity>();
        SQLiteTableMapAttribute tableAttribute = GetTableAttribute<T>();
        Dictionary<int, AbsStrayFogSQLiteEntity> srcResult = new Dictionary<int, AbsStrayFogSQLiteEntity>();
        if (mCacheIsReadFromDisk.Contains(tableAttribute.id))
        {
            srcResult = OnGetCacheData(tableAttribute);
        }
        else
        {
            srcResult = OnReadAll<T>(tableAttribute);
            OnRefreshCacheData(srcResult, tableAttribute, true);
            mCacheIsReadFromDisk.Add(tableAttribute.id);
        }

        if (_condition != null)
        {
            foreach (T t in srcResult.Values)
            {
                if (_condition(t))
                {
                    result.Add(t.pkSequenceId, t);
                }
            }
        }
        else
        {
            result = srcResult;
        }
        return result;
    }
    #endregion
}