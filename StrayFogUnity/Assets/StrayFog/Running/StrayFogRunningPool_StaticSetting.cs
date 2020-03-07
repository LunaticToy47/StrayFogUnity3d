/// <summary>
/// 静态设置
/// </summary>
public partial class StrayFogRunningPool
{
    /// <summary>
    /// HotfixAsmdef静态设定路径
    /// </summary>    
    public string HotfixAsmdefStaticSettingPath {
        get {
            if (runningSetting.isUseAssetBundle)
            {
                return "#HotfixAsmdefStaticSettingAssetBundlePath#";
            }
            else
            {
                return "#HotfixAsmdefStaticSettingEditorPath#";
            }
        }
    }
}
