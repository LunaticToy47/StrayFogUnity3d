using System;
using UnityEngine;
using XLua;
/// <summary>
/// ExampleHeroListWindow
/// </summary>
[AddComponentMenu("StrayFog/Example/UIWindow/ExampleHeroListWindow")]
public class ExampleHeroListWindow : AbsUIWindowView
{
    /// <summary>
    /// LuaTable
    /// </summary>
    LuaTable mScriptEnv;
    /// <summary>
    /// Awake
    /// </summary>
    protected override void OnAfterAwake()
    {
        mScriptEnv = StrayFogGamePools.xLuaManager.GetLuaTable(xLuaFileId, (table) =>
        {
            table.Set("self", this);
        });
        mScriptEnv.Get<Action>("Awake")?.Invoke();
    }
}