using System.Collections.Generic;
/// <summary>
/// StrayFogSQLite表实体帮助类
/// </summary>
public sealed partial class StrayFogSQLiteEntityHelper
{
	/// <summary>
    /// 实体设定映射
    /// </summary>
    static readonly Dictionary<int, StrayFogSQLiteEntitySetting> msrEntityMaping = new Dictionary<int, StrayFogSQLiteEntitySetting>() {
		{ -206577796,new StrayFogSQLiteEntitySetting(-206577796,"AssetDiskMapingFile","Assets/Game/Editor/XLS_Config/AssetDiskMapingFile.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -432580056,new StrayFogSQLiteEntitySetting(-432580056,"AssetDiskMapingFolder","Assets/Game/Editor/XLS_Config/AssetDiskMapingFolder.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 294742871,new StrayFogSQLiteEntitySetting(294742871,"GameLanguage","Assets/Game/Editor/XLS_Config/GameLanguage.xlsx","c__1581584321",true,enSQLiteEntityClassify.Table,1,2,3,4)},
		{ -1936055589,new StrayFogSQLiteEntitySetting(-1936055589,"GameSetting","Assets/Game/Editor/XLS_Config/GameSetting.xlsx","c__1581584321",true,enSQLiteEntityClassify.Table,1,2,3,4)},
		{ -2027841950,new StrayFogSQLiteEntitySetting(-2027841950,"TableColumnMaping","Assets/Game/Editor/XLS_Config/TableColumnMaping.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 2031098619,new StrayFogSQLiteEntitySetting(2031098619,"UIWindowSetting","Assets/Game/Editor/XLS_Config/UIWindowSetting.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 248584192,new StrayFogSQLiteEntitySetting(248584192,"UserGuideTrigger","Assets/Game/Editor/XLS_Config/UserGuideTrigger.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 1839133489,new StrayFogSQLiteEntitySetting(1839133489,"UserGuideValidate","Assets/Game/Editor/XLS_Config/UserGuideValidate.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 579308612,new StrayFogSQLiteEntitySetting(579308612,"XLSTableToSQLiteEntityMaping","Assets/Game/Editor/XLS_Config/XLSTableToSQLiteEntityMaping.xlsx","c__1581584321",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -1122245761,new StrayFogSQLiteEntitySetting(-1122245761,"TableColumnMaping","Assets/Game/Editor/XLS_Report/TableColumnMaping.xlsx","c__1833182787",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -66345705,new StrayFogSQLiteEntitySetting(-66345705,"View_DeterminantVT","","c__1581584321",false,enSQLiteEntityClassify.View,1,4,2,4)},
		{ 1200707353,new StrayFogSQLiteEntitySetting(1200707353,"View_AssetDiskMaping","","c__1581584321",false,enSQLiteEntityClassify.View,1,4,2,4)},
		{ 1342827752,new StrayFogSQLiteEntitySetting(1342827752,"View_DeterminantVT","","c__1833182787",false,enSQLiteEntityClassify.View,1,4,2,4)},
    };

    /// <summary>
    /// 获得实体设定
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
	/// <returns>实体设定</returns>
    static StrayFogSQLiteEntitySetting OnGetEntitySetting<T>()
        where T : AbsStrayFogSQLiteEntity
    {
        return msrEntityMaping[OnGetTypeKey<T>()];
    }

    /// <summary>
    /// 获得类型Key
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <returns>Key</returns>
    static int OnGetTypeKey<T>()
        where T: AbsStrayFogSQLiteEntity
    {
        return typeof(T).Name.UniqueHashCode();
    }
}