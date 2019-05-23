using System;
using UnityEngine;
using UnityEngine.UI;
using XLua;
/// <summary>
/// HeroListWindow
/// </summary>
[AddComponentMenu("StrayFog/Game/UIWindow/HeroListWindow")]
public class HeroListWindow : AbsUIWindowView
{
    /// <summary>
    /// LuaTable
    /// </summary>
    LuaTable mScriptEnv;
    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
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