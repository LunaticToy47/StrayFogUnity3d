using System;
using System.Collections.Generic;
using System.Reflection;
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

    #region OnGetTableAttribute 获得表属性
    /// <summary>
    /// 获得表属性
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <returns>表属性</returns>
    static SQLiteTableMapAttribute OnGetTableAttribute<T>()
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
}
