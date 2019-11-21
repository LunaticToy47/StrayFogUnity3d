using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 从XLS加载视图数据集
/// </summary>
/// <typeparam name="T">类型</typeparam>
/// <param name="_tableAttribute">表属性</param>
/// <returns>数据集</returns>
public delegate Dictionary<int, T> LoadViewFromXLSEventHandler<T>(SQLiteTableMapAttribute _tableAttribute) where T : AbsStrayFogSQLiteEntity;

/// <summary>
/// 配置表实体帮助类【DbXLS】
/// </summary>
public sealed partial class StrayFogConfigHelper
{
    /// <summary>
    /// 从XLS读取视图映射
    /// </summary>
    static Dictionary<int, object> mFunLoadViewFromXLSMaping = new Dictionary<int, object>();

    #region AddLoadViewFromXLS
    /// <summary>
    /// 添加从XLS加载视图
    /// </summary>
    public static void AddLoadViewFromXLS<T>(LoadViewFromXLSEventHandler<T> _funLoadViewFromXLS)
        where T : AbsStrayFogSQLiteEntity
    {
        Type t = typeof(T);
        int key = t.GetHashCode();
        if (!mFunLoadViewFromXLSMaping.ContainsKey(key))
        {
            mFunLoadViewFromXLSMaping.Add(key, _funLoadViewFromXLS);
        }
    }
    #endregion

    #region RemoveLoadViewFromXLS
    /// <summary>
    /// 移除从XLS加载视图
    /// </summary>
    public static void RemoveLoadViewFromXLS<T>(LoadViewFromXLSEventHandler<T> _funLoadViewFromXLS)
        where T : AbsStrayFogSQLiteEntity
    {
        Type t = typeof(T);
        int key = t.GetHashCode();
        mFunLoadViewFromXLSMaping.Remove(key);
    }
    #endregion

    #region OnReadFromXLS
    /// <summary>
    /// 从XLS读取数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据集</returns>
    static Dictionary<int, T> OnReadFromXLS<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, T> result = new Dictionary<int, T>();
        if (File.Exists(_tableAttribute.xlsFilePath))
        {
            T tempEntity = default;
            int tempPropertyKey = 0;
            object tempValue = null;
            string tempName = string.Empty;
            bool tempIsAllValueNull = false;
            ExcelPackage pck = OnGetExcelPackage(_tableAttribute);
            {
                if (pck.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (_tableAttribute.isDeterminant)
                    {
                        #region 行列式数据写入
                        if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex)
                        {
                            tempEntity = OnCreateInstance<T>(_tableAttribute);
                            for (int row = _tableAttribute.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {
                                tempName = sheet.GetValue<string>(row, _tableAttribute.xlsColumnNameIndex).Trim();
                                tempValue = sheet.GetValue(row, _tableAttribute.xlsColumnValueIndex);
                                //如果名称为空，则认为是数据结束
                                if (string.IsNullOrEmpty(tempName))
                                {
                                    break;
                                }
                                else
                                {
                                    tempPropertyKey = tempName.UniqueHashCode();
                                    tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                                    msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                                }
                            }
                            tempEntity.Resolve();
                            result.Add(tempEntity.pkSequenceId, tempEntity);
                        }
                        #endregion
                    }
                    else
                    {
                        #region 普通数据写入
                        if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex)
                        {
                            for (int row = _tableAttribute.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {
                                tempEntity = OnCreateInstance<T>(_tableAttribute);
                                tempIsAllValueNull = true;
                                for (int col = 1; col <= sheet.Dimension.Columns; col++)
                                {
                                    tempName = sheet.GetValue<string>(_tableAttribute.xlsColumnNameIndex, col).Trim();
                                    tempPropertyKey = tempName.UniqueHashCode();
#if UNITY_EDITOR
                                    if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id].ContainsKey(tempPropertyKey))
                                    {
                                        Debug.LogErrorFormat("Can't find column 【{0}】for table 【{1}】", tempName, _tableAttribute.sqliteTableName);
                                    }
#endif
                                    if (!msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].isIngore)
                                    {
                                        tempValue = sheet.GetValue(row, col);
                                        tempIsAllValueNull &= (tempValue == null);
                                        tempValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempValue, msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey], msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].dataType, msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id][tempPropertyKey].arrayDimension);
                                        msEntityPropertyInfoMaping[_tableAttribute.id][tempPropertyKey].SetValue(tempEntity, tempValue, null);
                                    }
                                }
                                if (tempIsAllValueNull)
                                {//如果所有列为空，则认为是数据结束
                                    break;
                                }
                                else
                                {
                                    tempEntity.Resolve();
                                    result.Add(tempEntity.pkSequenceId, tempEntity);
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
            result = OnLoadViewFromXLS<T>(_tableAttribute);
        }
        return result;
    }
    #endregion

    #region OnLoadViewFromXLS 从XLS读取View数据
    /// <summary>
    /// 从XLS读取View数据
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>数据</returns>
    static Dictionary<int, T> OnLoadViewFromXLS<T>(SQLiteTableMapAttribute _tableAttribute)
        where T : AbsStrayFogSQLiteEntity
    {
        Dictionary<int, T> result = new Dictionary<int, T>();
        if (_tableAttribute.sqliteTableType == enSQLiteEntityClassify.View)
        {
            Type t = typeof(T);
            int key = t.GetHashCode();
            if (mFunLoadViewFromXLSMaping.ContainsKey(key))
            {
                if (mFunLoadViewFromXLSMaping[key] is LoadViewFromXLSEventHandler<T>)
                {
                    LoadViewFromXLSEventHandler<T> call = (LoadViewFromXLSEventHandler<T>)mFunLoadViewFromXLSMaping[key];
                    result = call?.Invoke(_tableAttribute);
                }
            }
        }
        return result;
    }
    #endregion    
}
