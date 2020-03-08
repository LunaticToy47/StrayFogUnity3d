using System;
/// <summary>
/// HotfixAsmdef静态设置子项
/// </summary>
[Serializable]
public class StrayFogHotfixAsmdefStaticSettingItem
{
    /// <summary>
    /// Id值
    /// </summary>
    [ReadOnly]
    public int hotfixAsmdefId;
    /// <summary>
    /// HotfixAsmdef Dll AssetBundle路径
    /// </summary>
    [ReadOnly]
    public string hotfixAsmdefDllAssetBundlePath = string.Empty;
    /// <summary>
    /// HotfixAsmdef Pdb AssetBundle路径
    /// </summary>
    [ReadOnly]
    public string hotfixAsmdefPdbAssetBundlePath = string.Empty;
}

/// <summary>
/// HotfixAsmdef静态设置
/// </summary>
public class StrayFogHotfixAsmdefStaticSetting : AbsScriptableObject
{
    /// <summary>
    /// 设定
    /// </summary>
    [ReadOnly]
    public StrayFogHotfixAsmdefStaticSettingItem[] settings;
}
