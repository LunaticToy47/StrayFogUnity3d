using System.Collections.Generic;
/// <summary>
/// SQLite表实体帮助类
/// </summary>
public sealed partial class SQLiteEntityHelper
{
    /// <summary>
    /// 实体名称映射
    /// </summary>
    static readonly Dictionary<int, string> msrEntityNameMaping = new Dictionary<int, string>() {
		{ typeof(Table_AssetDiskMapingFile).GetHashCode(),"AssetDiskMapingFile" },
		{ typeof(Table_AssetDiskMapingFileExt).GetHashCode(),"AssetDiskMapingFileExt" },
		{ typeof(Table_AssetDiskMapingFolder).GetHashCode(),"AssetDiskMapingFolder" },
		{ typeof(Table_GameLanguage).GetHashCode(),"GameLanguage" },
		{ typeof(Table_GameSetting).GetHashCode(),"GameSetting" },
		{ typeof(Table_TableColumnMaping).GetHashCode(),"TableColumnMaping" },
		{ typeof(Table_UIWindowSetting).GetHashCode(),"UIWindowSetting" },
		{ typeof(Table_UserGuideTrigger).GetHashCode(),"UserGuideTrigger" },
		{ typeof(Table_UserGuideValidate).GetHashCode(),"UserGuideValidate" },
		{ typeof(View_DeterminantVT).GetHashCode(),"View_DeterminantVT" },
		{ typeof(View_AssetDiskMaping).GetHashCode(),"View_AssetDiskMaping" },
    };

	/// <summary>
    /// 实体XLS表路径映射
    /// </summary>
    static readonly Dictionary<int, string> msrEntityXlsFileNameMaping = new Dictionary<int, string>() {
		{ typeof(Table_AssetDiskMapingFile).GetHashCode(),"Assets/Game/Editor/XLS/AssetDiskMapingFile.xlsx" },
		{ typeof(Table_AssetDiskMapingFileExt).GetHashCode(),"Assets/Game/Editor/XLS/AssetDiskMapingFileExt.xlsx" },
		{ typeof(Table_AssetDiskMapingFolder).GetHashCode(),"Assets/Game/Editor/XLS/AssetDiskMapingFolder.xlsx" },
		{ typeof(Table_GameLanguage).GetHashCode(),"Assets/Game/Editor/XLS/GameLanguage.xlsx" },
		{ typeof(Table_GameSetting).GetHashCode(),"Assets/Game/Editor/XLS/GameSetting.xlsx" },
		{ typeof(Table_TableColumnMaping).GetHashCode(),"Assets/Game/Editor/XLS/TableColumnMaping.xlsx" },
		{ typeof(Table_UIWindowSetting).GetHashCode(),"Assets/Game/Editor/XLS/UIWindowSetting.xlsx" },
		{ typeof(Table_UserGuideTrigger).GetHashCode(),"Assets/Game/Editor/XLS/UserGuideTrigger.xlsx" },
		{ typeof(Table_UserGuideValidate).GetHashCode(),"Assets/Game/Editor/XLS/UserGuideValidate.xlsx" },
		{ typeof(View_DeterminantVT).GetHashCode(),"" },
		{ typeof(View_AssetDiskMaping).GetHashCode(),"" },
    };

    /// <summary>
    /// 获得实体表格名称
    /// </summary>
    /// <param name="_key">键值</param>
    /// <returns>表格名称</returns>
    static string OnGetEntityTableName<T>(out int _key)
        where T : AbsSQLiteEntity
    {
        _key = typeof(T).GetHashCode();
        return msrEntityNameMaping[_key];
    }

	/// <summary>
    /// 获得实体表格名称
    /// </summary>
    /// <param name="_key">键值</param>
    /// <returns>表格名称</returns>
    static string OnGetDeterminantEntityTableName<T>(out int _key)
        where T : AbsSQLiteDeterminantEntity
    {
        _key = typeof(T).GetHashCode();
        return msrEntityNameMaping[_key];
    }
}