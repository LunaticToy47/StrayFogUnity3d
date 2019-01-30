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
        bool result = false;
        if (tableAttribute.canModifyData)
        {
            if (tableAttribute.isDeterminant)
            {
                Debug.LogErrorFormat("The determinant table 【{0}】【{1}】can't be insert data.", tableAttribute.sqliteTableName, tableAttribute.xlsFilePath);
            }
            else
            {
                int xlsRowIndex = -1;
                result = OnInsertToCacheEntityData(_entity, tableAttribute, out xlsRowIndex);
                if (result)
                {                    
                    if (StrayFogGamePools.setting.isInternal)
                    {                                                
                        #region 插入内部资源 XLS表                      
                        if (File.Exists(tableAttribute.xlsFilePath))
                        {
                           using (ExcelPackage pck = new ExcelPackage(new FileInfo(tableAttribute.xlsFilePath)))
                            {
                                if (pck.Workbook.Worksheets.Count > 0)//消耗2秒
                                {
                                    ExcelWorksheet sheet = pck.Workbook.Worksheets[1];                                    
                                    if (sheet.Dimension.Rows >= tableAttribute.xlsColumnValueIndex)
                                    {                                        
                                        foreach (KeyValuePair<int, SQLiteFieldTypeAttribute> key in msEntitySQLitePropertySQLiteFieldTypeAttributeMaping[tableAttribute.id])
                                        {
                                            sheet.Cells[xlsRowIndex, key.Value.xlsColumnIndex].Value = StrayFogSQLiteDataTypeHelper.GetValueFromEntityPropertyToXlsColumn(_entity, msEntityPropertyInfoMaping[tableAttribute.id][key.Key], key.Value);
                                        }
                                    }
                                }
                                pck.Save();//消耗2秒
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 插入外部资源 SQLite
                        #endregion
                    }
                }                
            }
        }
        else
        {
            Debug.LogErrorFormat("The table 【{0}】can't be canModifyData.", tableAttribute.sqliteTableName);
        }
        return result;
    }
    #endregion    
}