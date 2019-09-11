using System;
using System.Collections;
using UnityEngine;
using XLua;
/// <summary>
/// ExampleTestXLuaLevelCube
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/xLua/ExampleTestXLuaLevelCube")]
public class ExampleTestXLuaLevelCube : AbsMonoBehaviour
{
    /// <summary>
    /// LuaTable
    /// </summary>
    LuaTable mScriptEnv;
    /// <summary>
    /// Start函数
    /// </summary>
    Action mLuaStart;
    /// <summary>
    /// Update函数
    /// </summary>
    Action mLuaUpdate;
    /// <summary>
    /// Destroy函数
    /// </summary>
    Action mLuaOnDestroy;
    /// <summary>
    /// 是否触发Start
    /// </summary>
    bool mTriggerStart = false;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        mScriptEnv = StrayFogGamePools.xLuaManager.GetLuaTable(xLuaFileId, (table) =>
        {
            table.Set("self", this);
            table.Set("axis",Vector3.right * Mathf.Sign(UnityEngine.Random.Range(-1, 1)));
            table.Set("speed", UnityEngine.Random.Range(-20, 20));
        });

        Action luaAwake = mScriptEnv.Get<Action>("awake");
        mLuaStart = mScriptEnv.Get<Action>("start");
        mLuaUpdate = mScriptEnv.Get<Action>("update");
        mLuaOnDestroy = mScriptEnv.Get<Action>("ondestroy");
        if (luaAwake != null)
        {
            luaAwake();
        }
        Start();
    }

    // Use this for initialization
    void Start()
    {
        if (!mTriggerStart && mLuaStart != null)
        {
            mTriggerStart = true;
            mLuaStart();
        }
    }

    private IEnumerator OnLuaStart()
    {
        yield return new WaitForEndOfFrame();
        if (mLuaStart != null)
        {
            mLuaStart();
        }
        else
        {
            StartCoroutine(OnLuaStart());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mLuaUpdate != null)
        {
            mLuaUpdate();
        }
    }

    void OnDestroy()
    {
        if (mLuaOnDestroy != null)
        {
            mLuaOnDestroy();
        }
        mLuaOnDestroy = null;
        mLuaUpdate = null;
        mLuaStart = null;
    }
}
