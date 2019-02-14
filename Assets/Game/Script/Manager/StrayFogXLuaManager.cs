using System;
using System.Collections.Generic;
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
    /// XLua文件映射
    /// </summary>
    static Dictionary<int, XLS_Config_Table_XLuaMap> mXLuaMaping = new Dictionary<int, XLS_Config_Table_XLuaMap>();
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        xLuaEnv = new LuaEnv();
        List<XLS_Config_Table_XLuaMap> src = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_XLuaMap>();
        foreach (XLS_Config_Table_XLuaMap r in src)
        {
            if (!mXLuaMaping.ContainsKey(r.id))
            {
                mXLuaMaping.Add(r.id, r);
            }
        }
        base.OnAfterConstructor();
    }
    #endregion

    #region xLua相关
    /// <summary>
    /// 加载xLua文件
    /// </summary>
    /// <param name="xLua文件ID">_xLuaId</param>
    /// <param name="_onComplete">完成回调</param>
    public void LoadXLua(int _xLuaId, Action<LoadXLuaResult> _onComplete)
    {
        if (mXLuaMaping.ContainsKey(_xLuaId))
        {
            StrayFogGamePools.assetBundleManager.LoadAssetInMemory(mXLuaMaping[_xLuaId].xLuaFileId, 
                mXLuaMaping[_xLuaId].xLuaFolderId,
                (result) =>
                {
                    result.Instantiate<TextAsset>((rst, args) =>
                    {
                        Action<LoadXLuaResult> call = (Action<LoadXLuaResult>)args[1];
                        call(new LoadXLuaResult(((XLS_Config_Table_XLuaMap)args[0]).id, rst));
                    }, result.extraParameter);

                }, mXLuaMaping[_xLuaId], _onComplete);
        }
        else
        {
            _onComplete(new LoadXLuaResult(_xLuaId, null));
        }
    }
    #endregion
}
