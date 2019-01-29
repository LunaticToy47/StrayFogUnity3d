using System.Collections.Generic;
using System.IO;
using System.Text;
using Mono.Data.Sqlite;
using OfficeOpenXml;
using UnityEngine;
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
    public static bool Insert<T>(T _entity)
         where T : AbsStrayFogSQLiteEntity
    {
        SQLiteTableMapAttribute tableAttribute = OnGetTableAttribute<T>();
        bool result = tableAttribute.canModifyData;
        if (result)
        {
            if (StrayFogGamePools.setting.isInternal)
            {
                //插入内部资源
                result = OnInsertToXLS<T>(_entity, tableAttribute);
            }
            else
            {
                //插入外部资源
                result = OnInsertToSQLite<T>(_entity, tableAttribute);
            }
        }
        else
        {
            Debug.LogErrorFormat("The table 【{0}】can't be canModifyData.", tableAttribute.sqliteTableName);
        }
        return result;
    }
    #endregion

    #region  OnInsertToXLS 插入数据到XLS
    /// <summary>
    /// 插入数据到XLS
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">数据</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnInsertToXLS<T>(T _entity, SQLiteTableMapAttribute _tableAttribute) where T : AbsStrayFogSQLiteEntity
    {
        bool result = false;
        if (File.Exists(_tableAttribute.xlsFilePath))
        {
            bool tempPksValueIsNull = false;
            object tempXlsValue = null;
            object tempPropertyValue = null;
            bool isExistsData = false;
            int insertRowIndex = 0;
            string newXlsFilePath = _tableAttribute.xlsFilePath + "_New";
            StringBuilder sbLog =new StringBuilder() ;
            using (FileStream fs = new FileStream(_tableAttribute.xlsFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ExcelPackage pck = new ExcelPackage(fs);
                if (pck.Workbook.Worksheets.Count > 0)
                {
                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];
                    if (_tableAttribute.isDeterminant)
                    {
                        Debug.LogErrorFormat("The determinant table 【{0}】can't be insert data.", _tableAttribute.sqliteTableName);
                    }
                    else
                    {
                        #region 普通数据写入
                        if (sheet.Dimension.Rows >= _tableAttribute.xlsColumnValueIndex)
                        {
                            for (int row = _tableAttribute.xlsDataStartRowIndex; row <= sheet.Dimension.Rows; row++)
                            {                               
                                tempPksValueIsNull = true;
                                isExistsData = true;
                                foreach (KeyValuePair<int,SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
                                {                                                                        
                                    if (key.Value.isPK)
                                    {
                                        tempXlsValue = sheet.GetValue(row, key.Value.xlsColumnIndex);
                                        sbLog.AppendFormat("【{0}->{1}】", msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].Name, tempXlsValue);
                                        tempPksValueIsNull &= (tempXlsValue == null);
                                        if (tempXlsValue != null)
                                        {
                                            tempXlsValue = StrayFogSQLiteDataTypeHelper.GetXlsCSTypeColumnValue(tempXlsValue, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value.dataType, key.Value.arrayDimension);
                                            tempPropertyValue = msEntityPropertyInfoMaping[_tableAttribute.id][key.Key].GetValue(_entity, null);
                                            isExistsData &= tempXlsValue.Equals(tempPropertyValue);
                                        }                                        
                                    }                                    
                                }

                                if (isExistsData)
                                {//如果有相同的数据
                                    break;
                                }
                                else if (tempPksValueIsNull)
                                {//如果所有PK列为空                                    
                                    break;
                                }
                                else
                                {
                                    insertRowIndex = row;
                                }
                            }
                        }
                        if (!isExistsData)
                        {//插入数据
                            foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[_tableAttribute.id])
                            {
                                sheet.Cells[insertRowIndex + 1, key.Value.xlsColumnIndex].Value = StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[_tableAttribute.id][key.Key], key.Value);
                            }
                        }
                        #endregion
                    }
                }

                if (!isExistsData)
                {
                    pck.SaveAs(new FileInfo(newXlsFilePath));
                }
                else
                {
                    Debug.LogErrorFormat("【{0}】has the same value 【row->{1}】{2}", _tableAttribute.xlsFilePath, insertRowIndex, sbLog.ToString());
                }
            }

            if (File.Exists(newXlsFilePath))
            {
                File.Delete(_tableAttribute.xlsFilePath);
                File.Move(newXlsFilePath, _tableAttribute.xlsFilePath);
                OnInsertToCacheEntityData(_entity,_tableAttribute);
                result = true;
            }
        }
        return result;
    }
    #endregion

    #region OnInsertToSQLite 插入数据到SQLite
    /// <summary>
    /// 插入数据到SQLite
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="_entity">数据</param>
    /// <param name="_tableAttribute">表属性</param>
    /// <returns>true:成功,false:失败</returns>
    static bool OnInsertToSQLite<T>(T _entity, SQLiteTableMapAttribute _tableAttribute) where T : AbsStrayFogSQLiteEntity
    {
        bool result = false;

        return result;
    }
    #endregion

    
}