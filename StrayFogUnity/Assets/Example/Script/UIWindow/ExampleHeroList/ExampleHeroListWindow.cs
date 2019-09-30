using System;
using UnityEngine;
using UnityEngine.UI;
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
    /// OnAwake
    /// </summary>
    protected override void OnAwake()
    {
        mScriptEnv = StrayFogGamePools.xLuaManager.GetLuaTable(xLuaFileId, (table) =>
        {
            table.Set("self", this);
        });
        Action luaAwake = mScriptEnv.Get<Action>("Awake");
        if (luaAwake != null)
        {
            luaAwake();
        }
    }
}