using System.Collections.Generic;
/// <summary>
/// SQLite表实体帮助类
/// </summary>
public sealed partial class SQLiteEntityHelper
{
	/// <summary>
    /// 实体设定映射
    /// </summary>
    static readonly Dictionary<int, SQLiteEntitySetting> msrEntityMaping = new Dictionary<int, SQLiteEntitySetting>() {
		{ typeof(Table_AssetDiskMapingFile).GetHashCode(),new SQLiteEntitySetting(typeof(Table_AssetDiskMapingFile).GetHashCode(),"AssetDiskMapingFile","Assets/Game/Editor/XLS/AssetDiskMapingFile.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(Table_AssetDiskMapingFileExt).GetHashCode(),new SQLiteEntitySetting(typeof(Table_AssetDiskMapingFileExt).GetHashCode(),"AssetDiskMapingFileExt","Assets/Game/Editor/XLS/AssetDiskMapingFileExt.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(Table_AssetDiskMapingFolder).GetHashCode(),new SQLiteEntitySetting(typeof(Table_AssetDiskMapingFolder).GetHashCode(),"AssetDiskMapingFolder","Assets/Game/Editor/XLS/AssetDiskMapingFolder.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(Table_GameLanguage).GetHashCode(),new SQLiteEntitySetting(typeof(Table_GameLanguage).GetHashCode(),"GameLanguage","Assets/Game/Editor/XLS/GameLanguage.xlsx",true,enSQLiteEntityClassify.Table)},
		{ typeof(Table_GameSetting).GetHashCode(),new SQLiteEntitySetting(typeof(Table_GameSetting).GetHashCode(),"GameSetting","Assets/Game/Editor/XLS/GameSetting.xlsx",true,enSQLiteEntityClassify.Table)},
		{ typeof(Table_TableColumnMaping).GetHashCode(),new SQLiteEntitySetting(typeof(Table_TableColumnMaping).GetHashCode(),"TableColumnMaping","Assets/Game/Editor/XLS/TableColumnMaping.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(Table_UIWindowSetting).GetHashCode(),new SQLiteEntitySetting(typeof(Table_UIWindowSetting).GetHashCode(),"UIWindowSetting","Assets/Game/Editor/XLS/UIWindowSetting.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(Table_UserGuideTrigger).GetHashCode(),new SQLiteEntitySetting(typeof(Table_UserGuideTrigger).GetHashCode(),"UserGuideTrigger","Assets/Game/Editor/XLS/UserGuideTrigger.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(Table_UserGuideValidate).GetHashCode(),new SQLiteEntitySetting(typeof(Table_UserGuideValidate).GetHashCode(),"UserGuideValidate","Assets/Game/Editor/XLS/UserGuideValidate.xlsx",false,enSQLiteEntityClassify.Table)},
		{ typeof(View_DeterminantVT).GetHashCode(),new SQLiteEntitySetting(typeof(View_DeterminantVT).GetHashCode(),"View_DeterminantVT","",false,enSQLiteEntityClassify.View)},
		{ typeof(View_AssetDiskMaping).GetHashCode(),new SQLiteEntitySetting(typeof(View_AssetDiskMaping).GetHashCode(),"View_AssetDiskMaping","",false,enSQLiteEntityClassify.View)},
    };

    /// <summary>
    /// 获得实体设定
    /// </summary>
    /// <returns>实体设定</returns>
    static SQLiteEntitySetting OnGetEntitySetting<T>()
        where T : AbsSQLiteEntity
    {
        int key = typeof(T).GetHashCode();
        return msrEntityMaping[key];
    }
}