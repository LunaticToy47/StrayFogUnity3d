using Mono.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <param name="_xlsColumnTypeIndex">XLS表列类型索引</param>
        /// <param name="_xlsDataStartRowIndex">XLS表数据起始行索引</param>
        public SQLiteEntitySetting(int _id, string _name, string _xlsFileName, bool _isDeterminant, enSQLiteEntityClassify _classify,
            int _xlsColumnNameIndex, int _xlsColumnDataIndex,int _xlsColumnTypeIndex,int _xlsDataStartRowIndex)
        {
            id = _id;
            name = _name;
            xlsFileName = _xlsFileName;
            isDeterminant = _isDeterminant;
            classify = _classify;
            xlsColumnNameIndex = _xlsColumnNameIndex;
            xlsColumnDataIndex = _xlsColumnDataIndex;
            xlsColumnTypeIndex = _xlsColumnTypeIndex;
            xlsDataStartRowIndex = _xlsDataStartRowIndex;
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
        /// <summary>
        /// XLS表列类型索引
        /// </summary>
        public int xlsColumnTypeIndex { get; private set; }
        /// <summary>
        /// XLS表数据起始行索引
        /// </summary>
        public int xlsDataStartRowIndex { get; private set; }
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
        enSQLiteDataType tempSQLiteDataType = enSQLiteDataType.String;
        enSQLiteDataTypeArrayDimension tempSQLiteDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
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
                        tempEntity = Activator.CreateInstance<T>();
                        for (int row = _entitySetting.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                        {                            
                            tempSQLiteDataType = enSQLiteDataType.String;
                            tempSQLiteDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
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
                                StrayFogSQLiteDataTypeHelper.ResolveCSDataType(sheet.GetValue<string>(row, _entitySetting.xlsColumnTypeIndex), ref tempSQLiteDataType, ref tempSQLiteDataTypeArrayDimension);
                                tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyMaping[_entitySetting.id][tempPropertyKey], tempSQLiteDataType, tempSQLiteDataTypeArrayDimension);
                                msEntityPropertyMaping[_entitySetting.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);                                
                            }                            
                        }
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
                            tempEntity = Activator.CreateInstance<T>();
                            tempIsAllValueNull = true;
                            for (int col = 1; col <= sheet.Dimension.Columns; col++)
                            {
                                tempSQLiteDataType = enSQLiteDataType.String;
                                tempSQLiteDataTypeArrayDimension = enSQLiteDataTypeArrayDimension.NoArray;
                                tempName = sheet.GetValue<string>(_entitySetting.xlsColumnNameIndex, col).Trim();
                                tempValue = sheet.GetValue(row, col);
                                tempIsAllValueNull &= (tempValue == null);
                                tempPropertyKey = tempName.UniqueHashCode();
                                StrayFogSQLiteDataTypeHelper.ResolveCSDataType(sheet.GetValue<string>(_entitySetting.xlsColumnTypeIndex, col), ref tempSQLiteDataType, ref tempSQLiteDataTypeArrayDimension);                                
                                tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyMaping[_entitySetting.id][tempPropertyKey], tempSQLiteDataType, tempSQLiteDataTypeArrayDimension);
                                msEntityPropertyMaping[_entitySetting.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);                                
                            }
                            if (tempIsAllValueNull)
                            {//如果所有列为空，则认为是数据结束
                                break;
                            }
                            else
                            {
                                result.Add(tempEntity);
                            }
                        }
                    }
                    #endregion
                }                
            }
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
