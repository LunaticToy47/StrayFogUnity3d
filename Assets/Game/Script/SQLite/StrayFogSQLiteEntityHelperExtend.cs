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
		{ 1220685668,new StrayFogSQLiteEntitySetting(1220685668,"AssetDiskMapingFile","Assets/Game/Editor/XLS/AssetDiskMapingFile.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -1572136496,new StrayFogSQLiteEntitySetting(-1572136496,"AssetDiskMapingFolder","Assets/Game/Editor/XLS/AssetDiskMapingFolder.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 129506310,new StrayFogSQLiteEntitySetting(129506310,"GameLanguage","Assets/Game/Editor/XLS/GameLanguage.xlsx","c_298028678",true,enSQLiteEntityClassify.Table,1,2,3,4)},
		{ 475961400,new StrayFogSQLiteEntitySetting(475961400,"GameSetting","Assets/Game/Editor/XLS/GameSetting.xlsx","c_298028678",true,enSQLiteEntityClassify.Table,1,2,3,4)},
		{ -1153414000,new StrayFogSQLiteEntitySetting(-1153414000,"TableColumnMaping","Assets/Game/Editor/XLS/TableColumnMaping.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ 1214988366,new StrayFogSQLiteEntitySetting(1214988366,"UIWindowSetting","Assets/Game/Editor/XLS/UIWindowSetting.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -488128482,new StrayFogSQLiteEntitySetting(-488128482,"UserGuideTrigger","Assets/Game/Editor/XLS/UserGuideTrigger.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
		{ -1929576880,new StrayFogSQLiteEntitySetting(-1929576880,"UserGuideValidate","Assets/Game/Editor/XLS/UserGuideValidate.xlsx","c_298028678",false,enSQLiteEntityClassify.Table,1,4,2,4)},
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
        int key = typeof(T).GetHashCode();
        return msrEntityMaping[key];
    }
}