using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleXLuaLevel")]
public class ExampleXLuaLevel : AbsLevel
{
    /// <summary>
    /// cube
    /// </summary>
    public Transform cube;
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
    bool mTriggerStart=false;
    /// <summary>
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
            });            
        });
    }

    /// <summary>
    /// 使用require方式调用
    /// </summary>
    /// <param name="_xLuaFileId">xLuaFileId</param>
    void OnXLuaUseRequire(int _xLuaFileId)
    {
        /*
         * 调用【Assets\Example\XLuaScript\Level\ExampleXLuaLevel.lua.txt】
         * 并使用require方式调用【Assets\Example\XLuaScript\Level\ExampleXLuaLevelFunction.lua.txt】
         */
        mScriptEnv = StrayFogGamePools.xLuaManager.GetLuaTable(_xLuaFileId, (table) => {
            table.Set("self", this);
            table.Set("cube", cube);
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
    protected override  void OnRunStart()
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
    protected override void OnRunUpdate()
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

    /// <summary>
    /// OnRunGUI
    /// </summary>
    protected override void OnRunGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
        if (GUILayout.Button(string.Format("{0}=>{1}", GetType().Name, xLuaFileId)))
        {
            OnXLuaUseRequire(xLuaFileId);
            OnAddComponentUseXLua();
        }
    }

   /// <summary>
    /// Cube组
    /// </summary>
    List<GameObject> mlstCubes = new List<GameObject>();
       
    /// <summary>
    /// 添加组件并使用XLua
    /// </summary>
    void OnAddComponentUseXLua()
    {
        if (mlstCubes.Count > 0)
        {
            foreach (GameObject g in mlstCubes)
            {
                GameObject.Destroy(g);
            }
        }

        GameObject go = null;

        go = GameObject.Instantiate(cube.gameObject);
        go.name = "Cube Left";
        go.AddDynamicComponent<ExampleTestXLuaLevelCube>();
        go.transform.position = Vector3.right * -1.8f + cube.position;
        mlstCubes.Add(go);

        go = GameObject.Instantiate(cube.gameObject);
        go.name = "Cube Right";
        go.AddDynamicComponent<ExampleTestXLuaLevelCube>();
        go.transform.position = Vector3.right * 1.8f + cube.position;
        mlstCubes.Add(go);
    }
}