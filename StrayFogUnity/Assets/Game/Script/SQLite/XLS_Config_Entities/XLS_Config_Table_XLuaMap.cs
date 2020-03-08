using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// XLuaMap实体
/// </summary>
[SQLiteTableMap(292118249,"Assets/Game/Editor/XLS_Config/XLuaMap.xlsx","XLuaMap", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","Assets/497757a9c5b2ec17ded656170b51c788/c_334573285",typeof(XLS_Config_Table_XLuaMap),true,false)]
public partial class XLS_Config_Table_XLuaMap: AbsStrayFogSQLiteEntity
{
	

	
	protected override int OnResolvePkSequenceId()
    {
        return (id.ToString()).UniqueHashCode();
    }
	

	#region Properties	
		
	/// <summary>
	/// 路径ID
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true,false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// xLua文件id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,2,"xLuaFileId","","@xLuaFileId2",false,false)]	
	public int xLuaFileId { get; private set; }	
		
	/// <summary>
	/// xLua文件夹id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"xLuaFolderId","","@xLuaFolderId3",false,false)]	
	public int xLuaFolderId { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}