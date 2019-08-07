using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[AddComponentMenu("StrayFog/Game/Manager/StrayFogXLuaManager")]
public sealed partial class StrayFogXLuaManager : AbsSingleMonoBehaviour
{
    #region lua引擎
    /// <summary>
    /// lua引擎
    /// </summary>
    public LuaEnv xLuaEnv  { get; private set; }
    #endregion

    #region OnAfterConstructor
    /// <summary>
    /// XLua配置映射
    /// </summary>
    static Dictionary<int, XLS_Config_Table_XLuaMap> mXLuaConfigMaping = new Dictionary<int, XLS_Config_Table_XLuaMap>();
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        List<XLS_Config_Table_XLuaMap> src = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_XLuaMap>();
        foreach (XLS_Config_Table_XLuaMap r in src)
        {
            if (!mXLuaConfigMaping.ContainsKey(r.id))
            {
                mXLuaConfigMaping.Add(r.id, r);
            }
        }

        xLuaEnv = new LuaEnv();
        xLuaEnv.AddLoader((ref string filepath) =>
        {
            int xLuaId = 0;
            string xLuaString = string.Empty;
            byte[] result = null;
            if (!int.TryParse(filepath, out xLuaId))
            {
                xLuaId = filepath.UniqueHashCode();
            }
            xLuaString = OnGetXLuaScript(xLuaId);
            if (!string.IsNullOrEmpty(xLuaString))
            {
                result = System.Text.Encoding.UTF8.GetBytes(xLuaString);
            }            
            return result;
        });
        base.OnAfterConstructor();
    }
    #endregion

    #region OnGetXLuaScript 获得xLua文件脚本
    /// <summary>
    /// xLua脚本映射
    /// </summary>
    static Dictionary<int, string> mXLuaScriptMaping = new Dictionary<int, string>();
    /// <summary>
    /// 获得xLua文件脚本
    /// </summary>
    /// <param name="_xLuaFileId">xLua文件ID</param>
    /// <returns>xLua文件脚本</returns>
    public string OnGetXLuaScript(int _xLuaFileId)
    {
        string xLuaScript = string.Empty;
        if (mXLuaConfigMaping.ContainsKey(_xLuaFileId))
        {
            IAssetBundleFileParameter file = StrayFogGamePools.assetBundleManager.GetAssetBundleFile(mXLuaConfigMaping[_xLuaFileId].xLuaFileId, mXLuaConfigMaping[_xLuaFileId].xLuaFolderId);
            XLS_Config_View_AssetDiskMaping config = StrayFogGamePools.assetBundleManager.GetAssetDiskMaping(mXLuaConfigMaping[_xLuaFileId].xLuaFileId, mXLuaConfigMaping[_xLuaFileId].xLuaFolderId);
            if (file != null)
            {
                if (!mXLuaScriptMaping.ContainsKey(_xLuaFileId))
                {
                    TextAsset ta = null;
                    if (StrayFogGamePools.setting.isInternal)
                    {
                        ta = (TextAsset)StrayFogGamePools.runningApplication.LoadAssetAtPath(file.assetBundlePath, typeof(TextAsset));
                        xLuaScript = ta.text;
                    }
                    else
                    {
                        AssetBundle ab = AssetBundle.LoadFromFile(file.assetBundlePath);
                        ta = ab.LoadAsset<TextAsset>(config.fileName);
                        xLuaScript = ta.text;
                        ab.Unload(false);
                        ab = null;
                    }
                    mXLuaScriptMaping.Add(_xLuaFileId, xLuaScript);
                }
                else
                {
                    xLuaScript = mXLuaScriptMaping[_xLuaFileId];
                }
            }
        }
        return xLuaScript;
     }
    #endregion

    #region GetLuaTable 获得LuaTable
    /// <summary>
    /// 解析xLua
    /// </summary>
    /// <param name="_xLuaFileId">xLua文件ID</param>
    /// <param name="_setTableCallback">设置table回调</param>
    /// <returns>LuaTable</returns>
    public LuaTable GetLuaTable(int _xLuaFileId, Action<LuaTable> _setTableCallback)
    {
        LuaTable luaTable = xLuaEnv.NewTable();
        LuaTable meta = StrayFogGamePools.xLuaManager.xLuaEnv.NewTable();
        meta.Set("__index", StrayFogGamePools.xLuaManager.xLuaEnv.Global);
        luaTable.SetMetaTable(meta);
        meta.Dispose();

        string xLua = OnGetXLuaScript(_xLuaFileId);
        LuaFunction luaFun = xLuaEnv.LoadString(xLua); 
        luaFun.SetEnv(luaTable);
        _setTableCallback?.Invoke(luaTable);
        luaFun.Call();
        return luaTable;
    }
    #endregion

    #region Update
    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
        xLuaEnv.Tick();
    }
    #endregion
}
