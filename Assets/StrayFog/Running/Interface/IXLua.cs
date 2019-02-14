using System;
using UnityEngine;

/// <summary>
/// 加载xLua结果
/// </summary>
public class LoadXLuaResult
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_xLuaId">xLua文件ID</param>
    /// <param name="_xLua">xLua资源</param>
    public LoadXLuaResult(int _xLuaId, TextAsset _xLua)
    {
        xLuaId = _xLuaId;
        xLua = _xLua;
        isExists = _xLua != null;
    }
    /// <summary>
    /// xLua文件ID
    /// </summary>
    public int xLuaId { get; private set; }
    /// <summary>
    /// xLua资源
    /// </summary>
    public TextAsset xLua { get; private set; }
    /// <summary>
    /// 是否存在xLua资源
    /// </summary>
    public bool isExists { get; private set; }
}

/// <summary>
/// 注册引导事件句柄
/// </summary>
/// <param name="xLua文件ID">_xLuaId</param>
/// <param name="_onComplete">完成事件</param>
public delegate void LoadXLuaEventHandle(int _xLuaId, Action<LoadXLuaResult> _onComplete);

/// <summary>
/// xLua接口
/// </summary>
public interface IXLua
{
    /// <summary>
    /// 加载xLua文件
    /// </summary>   
    /// <param name="_onComplete">完成回调</param>
    void LoadXLua(Action<LoadXLuaResult> _onComplete);
}
