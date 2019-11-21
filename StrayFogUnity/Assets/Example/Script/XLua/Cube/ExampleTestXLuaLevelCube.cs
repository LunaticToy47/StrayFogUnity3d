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
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
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
        luaAwake?.Invoke();
        Start();
    }

    /// <summary>
    /// OnRunStart
    /// </summary>
    protected override void OnRunStart()
    {
        if (!mTriggerStart && mLuaStart != null)
        {
            mTriggerStart = true;
            mLuaStart();
        }
    }

    /// <summary>
    /// OnLuaStart
    /// </summary>
    /// <returns>异步</returns>
    private IEnumerator OnLuaStart()
    {
        yield return new WaitForEndOfFrame();
        if (mLuaStart != null)
        {
            mLuaStart();
        }
        else
        {
            coroutine.StartCoroutine(OnLuaStart());
        }
    }

    /// <summary>
    /// OnRunUpdate
    /// </summary>
    protected override  void OnRunUpdate()
    {
        mLuaUpdate?.Invoke();
    }

    /// <summary>
    /// OnRunDestroy
    /// </summary>
    protected override void OnRunDestroy()
    {
        mLuaOnDestroy?.Invoke();
        mLuaOnDestroy = null;
        mLuaUpdate = null;
        mLuaStart = null;
    }
}
