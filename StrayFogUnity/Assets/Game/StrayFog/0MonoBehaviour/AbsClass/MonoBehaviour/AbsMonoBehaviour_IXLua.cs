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
}
