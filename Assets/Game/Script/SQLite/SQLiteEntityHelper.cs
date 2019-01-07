using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
/// <summary>
/// SQLite表实体帮助类
/// </summary>
public sealed partial class SQLiteEntityHelper
{
    #region SQLite表实体设定
    /// <summary>
    /// SQLite表实体设定
    /// </summary>
    class SQLiteEntitySetting
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_id">id</param>
        /// <param name="_name">实体名称</param>
        /// <param name="_xlsFileName">xls文件名称</param>
        /// <param name="_isDeterminant">是否是行列式</param>
        /// <param name="_classify">实体分类</param>
        /// <param name="_xlsColumnNameIndex">XLS表列名称索引</param>
        /// <param name="_xlsColumnDataIndex">XLS表列值索引</param>
        public SQLiteEntitySetting(int _id, string _name, string _xlsFileName, bool _isDeterminant, enSQLiteEntityClassify _classify,
            int _xlsColumnNameIndex, int _xlsColumnDataIndex)
        {
            id = _id;
            name = _name;
            xlsFileName = _xlsFileName;
            isDeterminant = _isDeterminant;
            classify = _classify;
            xlsColumnNameIndex = _xlsColumnNameIndex;
            xlsColumnDataIndex = _xlsColumnDataIndex;
        }
        /// <summary>
        /// 实体id
        /// </summary>
        public int id { get; private set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public string name { get; private set; }
        /// <summary>
        /// 实体XLS表名称
        /// </summary>
        public string xlsFileName { get; private set; }
        /// <summary>
        /// 是否是行列式表
        /// </summary>
        public bool isDeterminant { get; private set; }
        /// <summary>
        /// 实体分类
        /// </summary>
        public enSQLiteEntityClassify classify { get; private set; }
        /// <summary>
        /// XLS表列名称索引
        /// </summary>
        public int xlsColumnNameIndex { get; private set; }
        /// <summary>
        /// XLS表列值索引
        /// </summary>
        public int xlsColumnDataIndex { get; private set; }
    }
    #endregion

    /// <summary>
    /// 从SQLite到实体的数据值转换
    /// </summary>
    readonly static Dictionary<string, Func<object, object>> msrPropertyTypeValueSQLiteToEntity = new Dictionary<string, Func<object, object>>() {
            { typeof(Vector2).FullName,(src)=>{ return ToVectorX(src,2); } },
            { typeof(Vector3).FullName,(src)=>{ return ToVectorX(src,3); } },
            { typeof(Vector4).FullName,(src)=>{ return ToVectorX(src,4);} },
        };

    #region ToVectorX 值转为VectorX
    /// <summary>
    /// 值转为VectorX
    /// </summary>
    /// <param name="_src">源值</param>
    /// <param name="_num">向量维度</param>
    /// <returns>转换后的值</returns>
    static object ToVectorX(object _src, int _num)
    {
        object result = null;
        Vector4 v4 = Vector4.zero;
        #region 读值
        string[] values = new string[0];
        if (_src != null)
        {
            values = _src.ToString().Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
        if (values.Length > 0)
        {
            v4.x = float.Parse(values[0]);
        }
        if (values.Length > 1)
        {
            v4.y = float.Parse(values[1]);
        }
        if (values.Length > 2)
        {
            v4.z = float.Parse(values[2]);
        }
        if (values.Length > 3)
        {
            v4.w = float.Parse(values[3]);
        }
        #endregion
        switch (_num)
        {
            case 2:
                result = (Vector2)v4;
                break;
            case 3:
                result = (Vector3)v4;
                break;
            case 4:
                result = v4;
                break;
        }
        return result;
    }
    #endregion

    #region OnSelectAll 读取所有数据
    /// <summary>
    /// 实体属性映射
    /// </summary>
    static Dictionary<int, Dictionary<int, PropertyInfo>> msEntityPropertyMaping = new Dictionary<int, Dictionary<int, PropertyInfo>>();

    /// <summary>
    /// 读取所有数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_entitySetting">实体设定</param>
    /// <returns>数据集合</returns>
    static List<T> OnReadAll<T>(SQLiteEntitySetting _entitySetting)
        where T : AbsSQLiteEntity
    {
        List<T> result = new List<T>();
        if (!msEntityPropertyMaping.ContainsKey(_entitySetting.id))
        {
            msEntityPropertyMaping.Add(_entitySetting.id, new Dictionary<int, PropertyInfo>());
            Type type = typeof(T);
            PropertyInfo[] pps = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.DeclaredOnly);
            if (pps != null && pps.Length > 0)
            {
                int key = 0;
                foreach (PropertyInfo p in pps)
                {
                    key = p.Name.UniqueHashCode();
                    if (!msEntityPropertyMaping[_entitySetting.id].ContainsKey(key))
                    {
                        msEntityPropertyMaping[_entitySetting.id].Add(key, p);
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
    static List<T> OnReadFromXLS<T>(SQLiteEntitySetting _entitySetting)
        where T : AbsSQLiteEntity
    {
        List<T> result = new List<T>();

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
    static List<T> OnReadFromSQLite<T>(SQLiteEntitySetting _entitySetting)
        where T : AbsSQLiteEntity
    {
        List<T> result = new List<T>();
        //SqliteDataReader reader = SQLiteHelper.sqlHelper.ExecuteQuery(string.Format("SELECT * FROM {0}", _entitySetting.name));
        //string propertyName = string.Empty;
        //T entity = default(T);
        //Type columnType = null;
        //Type propertyType = null;
        //object readerValue = null;
        //while (reader.Read())
        //{
        //    entity = Activator.CreateInstance<T>();
        //    for (int i = 0; i < reader.FieldCount; i++)
        //    {
        //        propertyName = reader.GetName(i);
        //        propertyKey = propertyName.UniqueHashCode();
        //        if (!msEntityPropertyMaping[entityKey].ContainsKey(propertyKey))
        //        {
        //            msEntityPropertyMaping[entityKey].Add(propertyKey, entityType.GetProperty(propertyName));
        //        }
        //        columnType = reader.GetFieldType(i);
        //        propertyType = msEntityPropertyMaping[entityKey][propertyKey].PropertyType;
        //        readerValue = reader.GetValue(i);
        //        if (columnType.Equals(propertyType))
        //        {//如果实体属性类型与数据库保存的类型一致
        //            msEntityPropertyMaping[entityKey][propertyKey].SetValue(entity, readerValue, null);
        //        }
        //        else if (msrPropertyTypeValueSQLiteToEntity.ContainsKey(propertyType.FullName))
        //        {//如果实体属性值与数据库值有相应的转换函数
        //            msEntityPropertyMaping[entityKey][propertyKey].SetValue(entity, msrPropertyTypeValueSQLiteToEntity[propertyType.FullName](readerValue), null);
        //        }
        //        else
        //        {
        //            Debug.LogErrorFormat("{0}'s property[{1}][{2}] can not convert value from db【{3】【{4}】",
        //                entityType.Name,
        //                msEntityPropertyMaping[entityKey][propertyKey].Name, propertyType.FullName,
        //                readerValue == null ? "null" : readerValue.JsonSerialize(), columnType.FullName);
        //        }
        //    }
        //    entity.Resolve();
        //    result.Add(entity);
        //}
        //reader.Close();
        //reader = null;
        return result;
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
        where T : AbsSQLiteEntity
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
    where T : AbsSQLiteEntity
    {
        List<T> result = new List<T>();
        SQLiteEntitySetting entitySetting = OnGetEntitySetting<T>();
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
}
