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
            InitXLua(@"require '" + xLuaFileId + "'");
            //InitXLua(StrayFogGamePools.xLuaManager.GetXLua(xLuaFileId));
        });
    }

    /// <summary>
    /// 初始化XLua
    /// </summary>
    /// <param name="_xlua">xlua</param>
    void InitXLua(string _xlua)
    {
        mScriptEnv = StrayFogGamePools.xLuaManager.xLuaEnv.NewTable();
        LuaTable meta = StrayFogGamePools.xLuaManager.xLuaEnv.NewTable();
        meta.Set("__index", StrayFogGamePools.xLuaManager.xLuaEnv.Global);
        mScriptEnv.SetMetaTable(meta);
        meta.Dispose();

        mScriptEnv.Set("self", this);
        LuaFunction fun = StrayFogGamePools.xLuaManager.xLuaEnv.LoadString(_xlua);
        fun.SetEnv(mScriptEnv);
        fun.Call();

        Action luaAwake = mScriptEnv.Get<Action>("awake");
        luaStart = mScriptEnv.Get<Action>("start");
        luaUpdate = mScriptEnv.Get<Action>("update");
        luaOnDestroy = mScriptEnv.Get<Action>("ondestroy");
        if (luaAwake != null)
        {
            luaAwake();
        }
    }

    // Use this for initialization
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
        //StartCoroutine(OnLuaStart());
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