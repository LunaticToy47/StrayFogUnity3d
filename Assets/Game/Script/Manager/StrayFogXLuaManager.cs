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
            return System.Text.Encoding.UTF8.GetBytes(StrayFogGamePools.xLuaManager.GetXLua(int.Parse(filepath)));
        });
        base.OnAfterConstructor();
    }
    #endregion

    #region GetXLua 获得xLua文件路径
    /// <summary>
    /// xLua脚本映射
    /// </summary>
    static Dictionary<int, string> mXLuaScriptMaping = new Dictionary<int, string>();
    /// <summary>
    /// 获得xLua文件路径
    /// </summary>
    /// <param name="xLua文件ID">_xLuaId</param>
    /// <returns>xLua文件路径</returns>
    public string GetXLua(int _xLuaId)
    {
        string xlua = string.Empty;
        if (mXLuaConfigMaping.ContainsKey(_xLuaId))
        {
            string path = string.Empty;
            XLS_Config_View_AssetDiskMaping adm = StrayFogGamePools.assetBundleManager.GetAssetPath(mXLuaConfigMaping[_xLuaId].xLuaFileId, mXLuaConfigMaping[_xLuaId].xLuaFolderId, out path);
            if (adm != null)
            {
                if (!mXLuaScriptMaping.ContainsKey(_xLuaId))
                {
                    TextAsset ta = null;
                    if (StrayFogGamePools.setting.isInternal)
                    {
                        ta = (TextAsset)StrayFogGamePools.runningApplication.LoadAssetAtPath(adm.inAssetPath, typeof(TextAsset));
                        xlua = ta.text;
                    }
                    else
                    {
                        AssetBundle ab = AssetBundle.LoadFromFile(path);
                        ta = ab.LoadAsset<TextAsset>(adm.fileName);
                        xlua = ta.text;
                        ab.Unload(false);
                        ab = null;
                    }
                    mXLuaScriptMaping.Add(_xLuaId, xlua);
                }
                else
                {
                    xlua = mXLuaScriptMaping[_xLuaId];
                }
            }
        }
        return xlua;
     }
    #endregion
}
