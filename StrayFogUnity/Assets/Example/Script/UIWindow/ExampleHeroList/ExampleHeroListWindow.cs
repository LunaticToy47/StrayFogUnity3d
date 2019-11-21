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
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        mScriptEnv = StrayFogGamePools.xLuaManager.GetLuaTable(xLuaFileId, (table) =>
        {
            table.Set("self", this);
        });
        mScriptEnv.Get<Action>("Awake")?.Invoke();
    }
}