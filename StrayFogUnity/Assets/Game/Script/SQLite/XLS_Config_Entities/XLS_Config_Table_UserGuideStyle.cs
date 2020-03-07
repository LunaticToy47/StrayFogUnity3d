using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UserGuideStyle实体
/// </summary>
[SQLiteTableMap(666904118,"Assets/Game/Editor/XLS_Config/UserGuideStyle.xlsx","UserGuideStyle", enSQLiteEntityClassify.Table,false, 1,4,2,4,"Assets/Game/Editor/XLS_Config/XLS_Config.db","Assets/c_334573285",typeof(XLS_Config_Table_UserGuideStyle),true,false)]
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
	/// 箭头锚点[索引与触发参考对象组索引相同]
	///3：箭头在框左侧
	///5：箭头在框右侧
	///1：箭头在框上侧
	///7：箭头在框下侧
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,3,"arrowAnchor","","@arrowAnchor3",false,false)]	
	public int arrowAnchor { get; private set; }	
		
	/// <summary>
	/// 文本描述
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.String,enSQLiteDataTypeArrayDimension.NoArray,4,"content","","@content4",false,false)]	
	public string content { get; private set; }	
		
	/// <summary>
	/// 文本宽度
	/// </summary>
	[SQLiteFieldType(enSQLiteDataType.Int32,enSQLiteDataTypeArrayDimension.NoArray,5,"contentWidth","","@contentWidth5",false,false)]	
	public int contentWidth { get; private set; }	
	
	#endregion

	#region Set Properties
	
	#endregion
}