#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
/// <summary>
/// 资源加载模式菜单
/// </summary>
static class EditorResourceLoadingModeMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Resource Loading Mode/";
    /// <summary>
    /// Asset菜单
    /// </summary>
    const string mcAssetMenu = "Assets/" + mcMenu;
    /// <summary>
    /// Hierarchy菜单
    /// </summary>
    const string mcHierarchy = "GameObject/" + mcMenu;
    /// <summary>
    /// 菜单优先级
    /// </summary>
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.ResourceLoadingMode;
    #endregion

    #region Internal
    const string mcRLMInternal = "Internal";
    /// <summary>
    /// 内部资源加载
    /// </summary>
    [MenuItem(mcMenu + mcRLMInternal, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcRLMInternal, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcRLMInternal, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_RLMInternalWindow()
    {
        OnEditorToggleLoadingResourceMode(true);
    }
    /// <summary>
    /// 内部资源加载
    /// </summary>
    [MenuItem(mcMenu + mcRLMInternal, true, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcRLMInternal, true, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcRLMInternal, true, mcPriority + 1)]
    static bool EditorDevelopMenuItem_RLMInternalValidateWindow()
    {
        return !StrayFogSetting.current.isInternal;
    }
    #endregion

    #region External
    const string mcRLMExternal = "External";
    /// <summary>
    /// 外部资源加载
    /// </summary>
    [MenuItem(mcMenu + mcRLMExternal, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcRLMExternal, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcRLMExternal, false, mcPriority + 2)]
    static void EditorDevelopMenuItem_RLMExternalWindow()
    {
        OnEditorToggleLoadingResourceMode(false);
    }
    /// <summary>
    /// 外部资源加载
    /// </summary>
    [MenuItem(mcMenu + mcRLMExternal, true, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcRLMExternal, true, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcRLMExternal, true, mcPriority + 2)]
    static bool EditorDevelopMenuItem_RLMExternalValidateWindow()
    {
        return StrayFogSetting.current.isInternal;
    }
    #endregion

    #region OnEditorToggleLoadingResourceMode 切换资源加载模式
    /// <summary>
    /// 切换资源加载模式
    /// </summary>
    /// <param name="_isInternal">是否是内部资源加载</param>
    static void OnEditorToggleLoadingResourceMode(bool _isInternal)
    {
        string forceexternalloadasset = enSystemDefine.FORCEEXTERNALLOADASSET.ToString();
        List<string> saveDefines = new List<string>();
        string[] symbol = EditorStrayFogApplication.GetScriptingDefineSymbolsForGroup();
        if (symbol != null)
        {
            foreach (string s in symbol)
            {
                saveDefines.Add(s);
            }
        }
        if (_isInternal)
        {
            saveDefines.Remove(forceexternalloadasset);
        }
        else
        {
            if (!saveDefines.Contains(forceexternalloadasset))
            {
                saveDefines.Add(forceexternalloadasset);
            }
        }
        EditorStrayFogApplication.SetScriptingDefineSymbolsForGroup(saveDefines.ToArray());
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
    }
    #endregion
}
#endif