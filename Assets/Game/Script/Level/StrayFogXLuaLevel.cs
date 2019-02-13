using UnityEngine;
[AddComponentMenu("Game/ExampleLevel/StrayFogXLuaLevel")]
public class StrayFogXLuaLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            LoadXLua((int)enAssetDiskMapingFile.f_StrayFogXLuaLevel_xlua_txt,
               (int)enAssetDiskMapingFolder.Assets_Game_XLuaScript_Level, (rst) =>
               {
                   Debug.Log(rst.isExists + "=>" + (rst.isExists ? rst.xLua.text : string.Empty));
               });
        });
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnDestroy()
    {
       
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }

}