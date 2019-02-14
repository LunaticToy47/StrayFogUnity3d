using System;
using UnityEngine;
/// <summary>
/// 抽象MonoBehaviour【IXLua接口】
/// </summary>
public abstract partial class AbsMonoBehaviour : IXLua
{
    #region LoadXLua 加载xLua文件
    /// <summary>
    /// 加载xLua文件
    /// </summary>
    /// <param name="_onComplete">完成回调</param>
    public void LoadXLua(Action<LoadXLuaResult> _onComplete)
    {
        StrayFogRunningUtility.SingleScriptableObject<StrayFogRunningApplication>().LoadXLua(GetType().FullName.UniqueHashCode(), _onComplete);
    }
    #endregion
}
