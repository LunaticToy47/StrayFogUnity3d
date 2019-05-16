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
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
            });            
        });
    }

    /// <summary>
    /// 初始化XLua
    /// </summary>
    /// <param name="_xLuaFileId">xLuaFileId</param>
    void InitXLua(int _xLuaFileId)
    {
        mScriptEnv = StrayFogGamePools.xLuaManager.GetLuaTable(_xLuaFileId, (table) => {
            table.Set("self", this);
            table.Set("cube", cube);
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

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
        if (GUILayout.Button(string.Format("{0}=>{1}", GetType().Name, xLuaFileId)))
        {
            InitXLua(xLuaFileId);
            InitBatchCube();
        }
    }

   /// <summary>
    /// Cube组
    /// </summary>
    List<GameObject> mlstCubes = new List<GameObject>();
       
    /// <summary>
    /// 初始化一批Cube
    /// </summary>
    void InitBatchCube()
    {
        if (mlstCubes.Count > 0)
        {
            foreach (GameObject g in mlstCubes)
            {
                Destroy(g);
            }
        }

        GameObject go = null;

        go = Instantiate(cube.gameObject);
        go.name = "Cube Left";
        go.AddComponent<ExampleTestXLuaLevelCube>();
        go.transform.position = Vector3.right * -1.8f + cube.position;
        mlstCubes.Add(go);

        go = Instantiate(cube.gameObject);
        go.name = "Cube Right";
        go.AddComponent<ExampleTestXLuaLevelCube>();
        go.transform.position = Vector3.right * 1.8f + cube.position;
        mlstCubes.Add(go);
    }
}