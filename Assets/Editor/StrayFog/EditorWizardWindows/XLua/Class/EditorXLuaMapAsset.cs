#if UNITY_EDITOR
using UnityEngine;
/// <summary>
/// 编辑器XLua映射资源
/// </summary>
public class EditorXLuaMapAsset : AbsScriptableObject
{
    /// <summary>
    /// 类全名称
    /// </summary>
    [AliasTooltip("类全名称")]
    [ReadOnly]
    public string classFullName;
    /// <summary>
    /// xLua文件资源
    /// </summary>
    [AliasTooltip("xLua文件资源")]
    public TextAsset xLuaTextAsset;
    /// <summary>
    /// xLua标识ID
    /// </summary>
    public int xLuaId { get { return classFullName.UniqueHashCode(); } }
}
#endif