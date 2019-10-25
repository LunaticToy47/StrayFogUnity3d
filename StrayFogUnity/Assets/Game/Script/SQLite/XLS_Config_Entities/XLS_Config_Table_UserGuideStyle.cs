using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideStyle实体
/// </summary>
[SQLiteTableMap(980815040,"Assets/Game/Editor/XLS_Config/UserGuideStyle.xlsx","UserGuideStyle", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","c_853878160",typeof(XLS_Config_Table_UserGuideStyle),true,false)]
public partial class XLS_Config_Table_UserGuideStyle: AbsStrayFogSQLiteEntity
{
	

	
	protected override int OnResolvePkSequenceId()
    {
        return (id.ToString()).UniqueHashCode();
    }
	

	#region Properties	
		
	/// <summary>
	/// 标识id
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,1,"id","","@id1",true,false)]	
	public int id { get; private set; }	
		
	/// <summary>
	/// 描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,2,"desc","","@desc2",false,true)]	
	public string desc { get; private set; }	
		
	/// <summary>
	/// 箭头位置[索引与触发参考对象组索引相同]
	///0：箭头在框左侧
	///1：箭头在框右侧
	///2：箭头在框上侧
	///3：箭头在框下侧
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.OneDimensionArray,3,"arrowEdge","","@arrowEdge3",false,false)]	
	public int[] arrowEdge { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}