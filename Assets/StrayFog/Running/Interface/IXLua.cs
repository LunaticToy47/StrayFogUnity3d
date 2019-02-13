using System;
using UnityEngine;
/// <summary>
/// xLua接口
/// </summary>
public interface IXLua
{
    /// <summary>
    /// 加载xLua文件
    /// </summary>
    /// <param name="_xLuaFileId">xLua文件ID</param>
    /// <param name="_xLuaFolderId">xLua文件夹ID</param>
    /// <param name="_onComplete">完成回调</param>
    void LoadXLua(int _xLuaFileId,int _xLuaFolderId,Action<bool,TextAsset> _onComplete);
}
