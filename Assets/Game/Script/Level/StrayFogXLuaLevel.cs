using System;
using System.Collections;
using UnityEngine;
using XLua;

[AddComponentMenu("Game/ExampleLevel/StrayFogXLuaLevel")]
public class StrayFogXLuaLevel : AbsLevel
{
    LuaTable mScriptEnv;

    Action luaStart;
    Action luaUpdate;
    Action luaOnDestroy;
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.xLuaManager.xLuaEnv.AddLoader((ref string filepath) =>
            {
                Debug.Log(filepath);
                return null;
            });
            StrayFogGamePools.xLuaManager.xLuaEnv.DoString(@"require '"+ xLuaFileId + "'");
            LoadXLua((rst) =>
                   {
                       if (rst.isExists)
                       {
                           mScriptEnv = StrayFogGamePools.xLuaManager.xLuaEnv.NewTable();
                           LuaTable meta = StrayFogGamePools.xLuaManager.xLuaEnv.NewTable();
                           meta.Set("__index", StrayFogGamePools.xLuaManager.xLuaEnv.Global);
                           mScriptEnv.SetMetaTable(meta);
                           meta.Dispose();

                           mScriptEnv.Set("self", this);
                           StrayFogGamePools.xLuaManager.xLuaEnv.DoString(rst.xLua.text, "StrayFogXLuaLevel", mScriptEnv);

                           Action luaAwake = mScriptEnv.Get<Action>("awake");
                           luaStart = mScriptEnv.Get<Action>("start");
                           luaUpdate = mScriptEnv.Get<Action>("update");
                           luaOnDestroy = mScriptEnv.Get<Action>("ondestroy");
                           if (luaAwake != null)
                           {
                               luaAwake();
                           }
                       }
                       Debug.Log(rst.isExists + "=>" + (rst.isExists ? rst.xLua.text : string.Empty));
                   });
        });
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(OnLuaStart());
    }

    private IEnumerator OnLuaStart()
    {
        yield return new WaitForEndOfFrame();
        if (luaStart != null)
        {
            luaStart();
        }
        else
        {
            StartCoroutine(OnLuaStart());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
        StrayFogGamePools.xLuaManager.xLuaEnv.Tick();
    }

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        mScriptEnv.Dispose();
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }

}