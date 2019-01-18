using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// UIWindowSetting实体
/// </summary>
public partial class Table_UIWindowSetting: AbsStrayFogSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id}.ToArray(); } }

	
	/// <summary>
	/// 窗口id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int id { get; private set; }
	/// <summary>
	/// 窗口名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray)]
	public string name { get; private set; }
	/// <summary>
	/// 文件id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int fileId { get; private set; }
	/// <summary>
	/// 文件夹id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int folderId { get; private set; }
	/// <summary>
	/// 画布绘制模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int renderMode { get; private set; }
	/// <summary>
	/// 窗口Layer
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int layer { get; private set; }
	/// <summary>
	/// 窗口打开模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int openMode { get; private set; }
	/// <summary>
	/// 窗口关闭模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray)]
	public int closeMode { get; private set; }
	/// <summary>
	/// 是否忽略打开关闭模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isIgnoreOpenCloseMode { get; private set; }
	/// <summary>
	/// 是否是不可自动恢复序列窗口
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isNotAutoRestoreSequenceWindow { get; private set; }
	/// <summary>
	/// 是否是不可销毁实例
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isDonotDestroyInstance { get; private set; }
	/// <summary>
	/// 是否立即显示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isImmediateDisplay { get; private set; }
	/// <summary>
	/// 跳转场景时是否手动关闭
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isManualCloseWhenGotoScene { get; private set; }
	/// <summary>
	/// 是否是引导窗口
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray)]
	public bool isGuideWindow { get; private set; }
}