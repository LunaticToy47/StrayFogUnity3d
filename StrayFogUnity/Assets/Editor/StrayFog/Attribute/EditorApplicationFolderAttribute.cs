#if UNITY_EDITOR 
using System;
using UnityEngine;
/// <summary>
/// 编辑器工程目录属性
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class EditorApplicationFolderAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    /// <param name="_path">目录路径</param>
    /// <param name="_tooltip">提示信息</param>
    public EditorApplicationFolderAttribute(string _name,string _path,string _tooltip)
    {
        name = _name;
        path = _path;
    }
    /// <summary>
    /// 名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 目录路径
    /// </summary>
    public string path { get; private set; }
    /// <summary>
    /// 提示信息
    /// </summary>
    public string tooltip { get; private set; }
}
#endif


