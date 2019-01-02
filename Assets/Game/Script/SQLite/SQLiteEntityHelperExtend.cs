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
		{ typeof(Table_AssetDiskMapingFolder).GetHashCode(),"AssetDiskMapingFolder" },
		{ typeof(Table_AssetDiskMapingFileExt).GetHashCode(),"AssetDiskMapingFileExt" },
		{ typeof(View_AssetDiskMaping).GetHashCode(),"View_AssetDiskMaping" },
		{ typeof(View_DynamicDll).GetHashCode(),"View_DynamicDll" },
		{ typeof(View_UIWindowSetting).GetHashCode(),"View_UIWindowSetting" },
		{ typeof(Table_TableColumnMaping).GetHashCode(),"TableColumnMaping" },
		{ typeof(Table_AssetDiskMapingFile).GetHashCode(),"AssetDiskMapingFile" },
		{ typeof(Table_UIWindowSetting).GetHashCode(),"UIWindowSetting" },
		{ typeof(View_UserGuideTrigger).GetHashCode(),"View_UserGuideTrigger" },
		{ typeof(Table_UserGuideTrigger).GetHashCode(),"UserGuideTrigger" },
		{ typeof(View_UserGuideValidate).GetHashCode(),"View_UserGuideValidate" },
		{ typeof(Table_UserGuideValidate).GetHashCode(),"UserGuideValidate" },
		{ typeof(Table_GameLanguage).GetHashCode(),"GameLanguageText" },
		{ typeof(View_DeterminantVT).GetHashCode(),"View_DeterminantVT" },
		{ typeof(Table_SkillBehaviour).GetHashCode(),"SkillBehaviour" },
		{ typeof(Table_Skill).GetHashCode(),"Skill" },
		{ typeof(Table_GameSetting).GetHashCode(),"GameSetting" },
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