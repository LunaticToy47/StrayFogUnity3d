using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
public class StrayFogXLuaManager : AbsSingleMonoBehaviour
{
    /// <summary>
    /// lua引擎
    /// </summary>
    public LuaEnv xLuaEnv  { get; private set; }

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
            string path = string.Empty;
            XLS_Config_View_AssetDiskMaping adm = StrayFogGamePools.assetBundleManager.GetAssetPath(mXLuaConfigMaping[_xLuaFileId].xLuaFileId, mXLuaConfigMaping[_xLuaFileId].xLuaFolderId, out path);
            if (adm != null)
            {
                if (!mXLuaScriptMaping.ContainsKey(_xLuaFileId))
                {
                    TextAsset ta = null;
                    if (StrayFogGamePools.setting.isInternal)
                    {
                        ta = (TextAsset)StrayFogGamePools.runningApplication.LoadAssetAtPath(adm.inAssetPath, typeof(TextAsset));
                        xLuaScript = ta.text;
                    }
                    else
                    {
                        AssetBundle ab = AssetBundle.LoadFromFile(path);
                        ta = ab.LoadAsset<TextAsset>(adm.fileName);
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
    /// LuaTable映射
    /// </summary>
    Dictionary<int, LuaTable> mLuaTableMaping = new Dictionary<int, LuaTable>();
    /// <summary>
    /// LuaFunction映射
    /// </summary>
    Dictionary<int, LuaFunction> mLuaFunctionMaping = new Dictionary<int, LuaFunction>();
    /// <summary>
    /// 解析xLua
    /// </summary>
    /// <param name="_xLuaFileId">xLua文件ID</param>
    /// <param name="_setTableCallback">设置table回调</param>
    /// <returns>LuaTable</returns>
    public LuaTable GetLuaTable(int _xLuaFileId, Action<LuaTable> _setTableCallback)
    {
        if (!mLuaTableMaping.ContainsKey(_xLuaFileId))
        {            
            LuaTable funLuaTable = xLuaEnv.NewTable();
            LuaTable meta = StrayFogGamePools.xLuaManager.xLuaEnv.NewTable();
            meta.Set("__index", StrayFogGamePools.xLuaManager.xLuaEnv.Global);
            funLuaTable.SetMetaTable(meta);
            meta.Dispose();
            mLuaTableMaping.Add(_xLuaFileId, funLuaTable);
        }

        if (!mLuaFunctionMaping.ContainsKey(_xLuaFileId))
        {
            string xLua = OnGetXLuaScript(_xLuaFileId);
            LuaFunction fun = xLuaEnv.LoadString(xLua);
            fun.SetEnv(mLuaTableMaping[_xLuaFileId]);
            mLuaFunctionMaping.Add(_xLuaFileId, fun);
        }

        if (_setTableCallback != null)
        {
            _setTableCallback(mLuaTableMaping[_xLuaFileId]);
        }
        mLuaFunctionMaping[_xLuaFileId].Call();

        return mLuaTableMaping[_xLuaFileId];
    }
    #endregion
}
