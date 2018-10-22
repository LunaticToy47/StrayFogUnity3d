using UnityEngine;
[AddComponentMenu("Game/StrayFogXLuaLevel")]
public class StrayFogXLuaLevel : AbsLevel
{
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.xLuaManager.luaEnv.DoString("CS.UnityEngine.Debug.Log('hello world')");
        StrayFogGamePools.xLuaManager.luaEnv.DoString("CS.UnityEngine.Debug.Log(CS.StrayFogGamePools.setting.assetBundleRoot)");
        StrayFogGamePools.xLuaManager.luaEnv.Dispose();
    }
}
