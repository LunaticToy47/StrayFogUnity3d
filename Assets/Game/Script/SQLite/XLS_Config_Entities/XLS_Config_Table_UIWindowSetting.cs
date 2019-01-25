using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UIWindowSetting实体
/// </summary>
[SQLiteTableMap(2031098619,"Assets/Game/Editor/XLS_Config/UIWindowSetting.xlsx","UIWindowSetting", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_UIWindowSetting))]
public partial class XLS_Config_Table_UIWindowSetting: AbsStrayFogSQLiteEntity
{
	
	/// <summary>
	/// 窗口id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"@id1",true)]
	public int id { get; private set; }
	/// <summary>
	/// 窗口名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"@name2",false)]
	public string name { get; private set; }
	/// <summary>
	/// 文件id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"@fileId3",false)]
	public int fileId { get; private set; }
	/// <summary>
	/// 文件夹id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"@folderId4",false)]
	public int folderId { get; private set; }
	/// <summary>
	/// 画布绘制模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"@renderMode5",false)]
	public int renderMode { get; private set; }
	/// <summary>
	/// 窗口Layer
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"@layer6",false)]
	public int layer { get; private set; }
	/// <summary>
	/// 窗口打开模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,7,"@openMode7",false)]
	public int openMode { get; private set; }
	/// <summary>
	/// 窗口关闭模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,8,"@closeMode8",false)]
	public int closeMode { get; private set; }
	/// <summary>
	/// 是否忽略打开关闭模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,9,"@isIgnoreOpenCloseMode9",false)]
	public bool isIgnoreOpenCloseMode { get; private set; }
	/// <summary>
	/// 是否是不可自动恢复序列窗口
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,10,"@isNotAutoRestoreSequenceWindow10",false)]
	public bool isNotAutoRestoreSequenceWindow { get; private set; }
	/// <summary>
	/// 是否是不可销毁实例
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,11,"@isDonotDestroyInstance11",false)]
	public bool isDonotDestroyInstance { get; private set; }
	/// <summary>
	/// 是否立即显示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,12,"@isImmediateDisplay12",false)]
	public bool isImmediateDisplay { get; private set; }
	/// <summary>
	/// 跳转场景时是否手动关闭
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,13,"@isManualCloseWhenGotoScene13",false)]
	public bool isManualCloseWhenGotoScene { get; private set; }
	/// <summary>
	/// 是否是引导窗口
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,14,"@isGuideWindow14",false)]
	public bool isGuideWindow { get; private set; }
}