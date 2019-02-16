using System;
using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour【IXLua接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IXLua
{
    #region xLuaFileId xLua文件ID
    /// <summary>
    /// xLua文件ID
    /// </summary>
    public int xLuaFileId { get { return GetType().FullName.UniqueHashCode(); } }
    #endregion

    #region LoadXLua 加载xLua文件
    /// <summary>
    /// 加载xLua文件
    /// </summary>
    /// <param name="_onComplete">完成回调</param>
    public void LoadXLua(Action<LoadXLuaResult> _onComplete)
    {
        StrayFogRunningUtility.SingleScriptableObject<StrayFogRunningApplication>().LoadXLua(xLuaFileId, _onComplete);
    }
    #endregion
}
