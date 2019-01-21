using System.Collections.Generic;
/// <summary>
/// 数据库分类枚举
/// </summary>
public enum enSQLiteClassify
{
	XLS = -944190407
}

/// <summary>
/// StrayFogSQLite表实体帮助类
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
	/// <summary>
    /// 实体设定映射
    /// </summary>
    static readonly Dictionary<int, StrayFogSQLiteEntitySetting> msrEntityMaping = new Dictionary<int, StrayFogSQLiteEntitySetting>() {
		{ typeof(Table_AssetDiskMapingFile).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_AssetDiskMapingFile).GetHashCode(),"AssetDiskMapingFile","Assets/Game/Editor/XLS/AssetDiskMapingFile.xlsx",false,enSQLiteEntityClassify.Table,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_AssetDiskMapingFolder).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_AssetDiskMapingFolder).GetHashCode(),"AssetDiskMapingFolder","Assets/Game/Editor/XLS/AssetDiskMapingFolder.xlsx",false,enSQLiteEntityClassify.Table,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_GameLanguage).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_GameLanguage).GetHashCode(),"GameLanguage","Assets/Game/Editor/XLS/GameLanguage.xlsx",true,enSQLiteEntityClassify.Table,1,2,3,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_GameSetting).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_GameSetting).GetHashCode(),"GameSetting","Assets/Game/Editor/XLS/GameSetting.xlsx",true,enSQLiteEntityClassify.Table,1,2,3,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_TableColumnMaping).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_TableColumnMaping).GetHashCode(),"TableColumnMaping","Assets/Game/Editor/XLS/TableColumnMaping.xlsx",false,enSQLiteEntityClassify.Table,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_UIWindowSetting).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_UIWindowSetting).GetHashCode(),"UIWindowSetting","Assets/Game/Editor/XLS/UIWindowSetting.xlsx",false,enSQLiteEntityClassify.Table,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_UserGuideTrigger).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_UserGuideTrigger).GetHashCode(),"UserGuideTrigger","Assets/Game/Editor/XLS/UserGuideTrigger.xlsx",false,enSQLiteEntityClassify.Table,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(Table_UserGuideValidate).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(Table_UserGuideValidate).GetHashCode(),"UserGuideValidate","Assets/Game/Editor/XLS/UserGuideValidate.xlsx",false,enSQLiteEntityClassify.Table,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(View_DeterminantVT).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(View_DeterminantVT).GetHashCode(),"View_DeterminantVT","",false,enSQLiteEntityClassify.View,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
		{ typeof(View_AssetDiskMaping).GetHashCode(),new StrayFogSQLiteEntitySetting(typeof(View_AssetDiskMaping).GetHashCode(),"View_AssetDiskMaping","",false,enSQLiteEntityClassify.View,1,4,2,4,-944190407,"XLS.db","Assets/Game/Editor/XLS/XLS.db")},
    };

    /// <summary>
    /// 获得实体设定
    /// </summary>
    /// <returns>实体设定</returns>
    static StrayFogSQLiteEntitySetting OnGetEntitySetting<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        int key = typeof(T).GetHashCode();
        return msrEntityMaping[key];
    }
}