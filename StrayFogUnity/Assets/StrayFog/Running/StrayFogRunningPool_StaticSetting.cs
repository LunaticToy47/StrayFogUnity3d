/// <summary>
/// 静态设置
/// </summary>
public partial class StrayFogRunningPool
{
	
    /// <summary>
    /// HotfixAsmdef静态设定路径
    /// </summary>    
    public static string HotfixAsmdefStaticSettingPath {
        get {
            if (runningSetting.isUseAssetBundle)
            {
                return "assets/game/assetbundles/assets/a_231799851";
            }
            else
            {
                return "Assets/Game/AssetBundles/Assets/StrayFogHotfixAsmdefStaticSetting.asset";
            }
        }
    }
	
}