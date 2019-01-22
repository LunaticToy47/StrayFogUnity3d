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
		{ 1527660842,new StrayFogSQLiteEntitySetting(1527660842,"AssetDiskMapingFile","Assets/Game/Editor/XLS/AssetDiskMapingFile.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 1251033563,new StrayFogSQLiteEntitySetting(1251033563,"AssetDiskMapingFolder","Assets/Game/Editor/XLS/AssetDiskMapingFolder.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 1577506090,new StrayFogSQLiteEntitySetting(1577506090,"GameLanguage","Assets/Game/Editor/XLS/GameLanguage.xlsx","c_298028678",true,enSQLiteEntityClassify.Table,1,2,3,4)},
		{ 442311892,new StrayFogSQLiteEntitySetting(442311892,"GameSetting","Assets/Game/Editor/XLS/GameSetting.xlsx","c_298028678",true,enSQLiteEntityClassify.Table,1,2,3,4)},
		{ -1211555605,new StrayFogSQLiteEntitySetting(-1211555605,"TableColumnMaping","Assets/Game/Editor/XLS/TableColumnMaping.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -492500815,new StrayFogSQLiteEntitySetting(-492500815,"UIWindowSetting","Assets/Game/Editor/XLS/UIWindowSetting.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 558964701,new StrayFogSQLiteEntitySetting(558964701,"UserGuideTrigger","Assets/Game/Editor/XLS/UserGuideTrigger.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -945369002,new StrayFogSQLiteEntitySetting(-945369002,"UserGuideValidate","Assets/Game/Editor/XLS/UserGuideValidate.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -1421965245,new StrayFogSQLiteEntitySetting(-1421965245,"View_DeterminantVT","","c_298028678",false,enSQLiteEntityClassify.View,1,4,2,4)},
		{ -1287889953,new StrayFogSQLiteEntitySetting(-1287889953,"View_AssetDiskMaping","","c_298028678",false,enSQLiteEntityClassify.View,1,4,2,4)},
    };

    /// <summary>
    /// 获得实体设定
    /// </summary>
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