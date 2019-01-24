using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// XLSTableToSQLiteEntityMaping实体
/// </summary>
public partial class XLS_Config_Table_XLSTableToSQLiteEntityMaping: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { pid}.ToArray(); } }

	
	/// <summary>
	/// 主键id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int pid { get; private set; }
	/// <summary>
	/// XLS表名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string xlsFilePath { get; private set; }
	/// <summary>
	/// 数据库表名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string sqliteTableName { get; private set; }
	/// <summary>
	/// 数据库表类别
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Byte,enSQLiteDataTypeArrayDimension.NoArray)]
	public byte sqliteTableType { get; private set; }
	/// <summary>
	/// 是否是行列式表
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isDeterminant { get; private set; }
	/// <summary>
	/// XLS表列名称索引
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int xlsColumnNameIndex { get; private set; }
	/// <summary>
	/// XLS表列值索引
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int xlsColumnDataIndex { get; private set; }
	/// <summary>
	/// XLS表列类型索引
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int xlsColumnTypeIndex { get; private set; }
	/// <summary>
	/// XLS表数据起始行索引
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int xlsDataStartRowIndex { get; private set; }
	/// <summary>
	/// 数据库外部资源包Key
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int dbSQLiteAssetBundleKey { get; private set; }
	/// <summary>
	/// 数据库外部资源包路径
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int dbSQLiteAssetBundleName { get; private set; }
}