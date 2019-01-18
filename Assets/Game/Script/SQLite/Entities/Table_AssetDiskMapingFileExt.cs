using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// AssetDiskMapingFileExt实体
/// </summary>
public partial class Table_AssetDiskMapingFileExt: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { extId}.ToArray(); } }

	
	/// <summary>
	/// 扩展名id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int extId { get; private set; }
	/// <summary>
	/// 扩展名
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string ext { get; private set; }
}