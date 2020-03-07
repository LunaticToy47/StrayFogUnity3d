using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UIWindowSetting实体
/// </summary>
[SQLiteTableMap(1749234405,"Assets/Game/Editor/XLS_Config/UIWindowSetting.xlsx","UIWindowSetting", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","Assets/c_334573285",typeof(XLS_Config_Table_UIWindowSetting),true,false)]
public partial class XLS_Config_Table_UIWindowSetting: AbsStrayFogSQLiteEntity
{
	

	
	protected override int OnResolvePkSequenceId()
    {
        return (id.ToString()).UniqueHashCode();
    }
	

	#region Properties	
		
	/// <summary>
	/// 窗口id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true,false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 窗口名称
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"name","","@name2",false,false)]	
	public string name { get; private set; }	
		
	/// <summary>
	/// 文件id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"fileId","","@fileId3",false,false)]	
	public int fileId { get; private set; }	
		
	/// <summary>
	/// 文件夹id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,4,"folderId","","@folderId4",false,false)]	
	public int folderId { get; private set; }	
		
	/// <summary>
	/// 画布绘制模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"renderMode","","@renderMode5",false,false)]	
	public int renderMode { get; private set; }	
		
	/// <summary>
	/// 窗口Layer
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,6,"layer","","@layer6",false,false)]	
	public int layer { get; private set; }	
		
	/// <summary>
	/// 窗口打开模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,7,"openMode","","@openMode7",false,false)]	
	public int openMode { get; private set; }	
		
	/// <summary>
	/// 窗口关闭模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,8,"closeMode","","@closeMode8",false,false)]	
	public int closeMode { get; private set; }	
		
	/// <summary>
	/// 是否忽略打开关闭模式
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,9,"isIgnoreOpenCloseMode","","@isIgnoreOpenCloseMode9",false,false)]	
	public bool isIgnoreOpenCloseMode { get; private set; }	
		
	/// <summary>
	/// 是否是自动恢复序列窗口
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,10,"isAutoRestoreSequenceWindow","","@isAutoRestoreSequenceWindow10",false,false)]	
	public bool isAutoRestoreSequenceWindow { get; private set; }	
		
	/// <summary>
	/// 是否是不可销毁实例
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,11,"isDonotDestroyInstance","","@isDonotDestroyInstance11",false,false)]	
	public bool isDonotDestroyInstance { get; private set; }	
		
	/// <summary>
	/// 是否立即显示
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,12,"isImmediateDisplay","","@isImmediateDisplay12",false,false)]	
	public bool isImmediateDisplay { get; private set; }	
		
	/// <summary>
	/// 跳转场景时是否手动关闭
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,13,"isManualCloseWhenGotoScene","","@isManualCloseWhenGotoScene13",false,false)]	
	public bool isManualCloseWhenGotoScene { get; private set; }	
		
	/// <summary>
	/// 是否是引导窗口
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Boolean,enSQLiteDataTypeArrayDimension.NoArray,14,"isGuideWindow","","@isGuideWindow14",false,false)]	
	public bool isGuideWindow { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}