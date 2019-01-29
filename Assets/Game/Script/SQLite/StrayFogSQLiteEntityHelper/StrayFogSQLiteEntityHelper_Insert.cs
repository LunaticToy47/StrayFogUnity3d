using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
/// <summary>
/// StrayFogSQLite表实体帮助类【Insert】
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
    #region Insert 插入数据
    /// <summary>
    /// 插入数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entity">实体</param>
    /// <returns>true:成功,false:失败</returns>
    public bool Insert<T>(T _entity)
         where T : AbsStrayFogSQLiteEntity
    {
        bool result = false;
        SQLiteTableMapAttribute tableAttribute =  OnGetTableAttribute<T>();
        return result;
    }
    #endregion
}