using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UIWindowSetting实体
/// </summary>
[SQLiteTableMap(2031098619,"Assets/Game/Editor/XLS_Config/UIWindowSetting.xlsx","UIWindowSetting", enSQLiteEntityClassify.Table,false, 1,4,2,4,"c__1581584321",typeof(XLS_Config_Table_UIWindowSetting),true)]
public partial class XLS_Config_Table_UIWindowSetting: AbsStrayFogSQLiteEntity
{
		
	#region constructor
	/// <summary>
    /// constructor
    /// </summary>
    XLS_Config_Table_UIWindowSetting()
    {
    }

    /// <summary>
    /// constructor
    /// </summary>
   /// <param name="_id">id</param>	
    public XLS_Config_Table_UIWindowSetting(int _id)
    {
		id = _id;
    }
    #endregion
	

	#region Properties	
		
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
	
	#endregion

	#region Set Properties
	
	/// <summary>
	/// Set name
	/// </summary>
	/// <param name="_name">name value</param>
	public void Set_name(string _name)
	{
		name = _name;
	}
	
	/// <summary>
	/// Set fileId
	/// </summary>
	/// <param name="_fileId">fileId value</param>
	public void Set_fileId(int _fileId)
	{
		fileId = _fileId;
	}
	
	/// <summary>
	/// Set folderId
	/// </summary>
	/// <param name="_folderId">folderId value</param>
	public void Set_folderId(int _folderId)
	{
		folderId = _folderId;
	}
	
	/// <summary>
	/// Set renderMode
	/// </summary>
	/// <param name="_renderMode">renderMode value</param>
	public void Set_renderMode(int _renderMode)
	{
		renderMode = _renderMode;
	}
	
	/// <summary>
	/// Set layer
	/// </summary>
	/// <param name="_layer">layer value</param>
	public void Set_layer(int _layer)
	{
		layer = _layer;
	}
	
	/// <summary>
	/// Set openMode
	/// </summary>
	/// <param name="_openMode">openMode value</param>
	public void Set_openMode(int _openMode)
	{
		openMode = _openMode;
	}
	
	/// <summary>
	/// Set closeMode
	/// </summary>
	/// <param name="_closeMode">closeMode value</param>
	public void Set_closeMode(int _closeMode)
	{
		closeMode = _closeMode;
	}
	
	/// <summary>
	/// Set isIgnoreOpenCloseMode
	/// </summary>
	/// <param name="_isIgnoreOpenCloseMode">isIgnoreOpenCloseMode value</param>
	public void Set_isIgnoreOpenCloseMode(bool _isIgnoreOpenCloseMode)
	{
		isIgnoreOpenCloseMode = _isIgnoreOpenCloseMode;
	}
	
	/// <summary>
	/// Set isNotAutoRestoreSequenceWindow
	/// </summary>
	/// <param name="_isNotAutoRestoreSequenceWindow">isNotAutoRestoreSequenceWindow value</param>
	public void Set_isNotAutoRestoreSequenceWindow(bool _isNotAutoRestoreSequenceWindow)
	{
		isNotAutoRestoreSequenceWindow = _isNotAutoRestoreSequenceWindow;
	}
	
	/// <summary>
	/// Set isDonotDestroyInstance
	/// </summary>
	/// <param name="_isDonotDestroyInstance">isDonotDestroyInstance value</param>
	public void Set_isDonotDestroyInstance(bool _isDonotDestroyInstance)
	{
		isDonotDestroyInstance = _isDonotDestroyInstance;
	}
	
	/// <summary>
	/// Set isImmediateDisplay
	/// </summary>
	/// <param name="_isImmediateDisplay">isImmediateDisplay value</param>
	public void Set_isImmediateDisplay(bool _isImmediateDisplay)
	{
		isImmediateDisplay = _isImmediateDisplay;
	}
	
	/// <summary>
	/// Set isManualCloseWhenGotoScene
	/// </summary>
	/// <param name="_isManualCloseWhenGotoScene">isManualCloseWhenGotoScene value</param>
	public void Set_isManualCloseWhenGotoScene(bool _isManualCloseWhenGotoScene)
	{
		isManualCloseWhenGotoScene = _isManualCloseWhenGotoScene;
	}
	
	/// <summary>
	/// Set isGuideWindow
	/// </summary>
	/// <param name="_isGuideWindow">isGuideWindow value</param>
	public void Set_isGuideWindow(bool _isGuideWindow)
	{
		isGuideWindow = _isGuideWindow;
	}
	
	#endregion
}