using System;
using UnityEngine;
/// <summary>
/// 代码特性
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class CodeAttribute : AliasTooltipAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_csTypeName">代码</param>
    public CodeAttribute(string _csTypeName)
        : this(_csTypeName, _csTypeName, _csTypeName)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_csTypeName">代码</param>
    public CodeAttribute(string _csTypeName, string _sqliteTypeName)
        : this(_csTypeName, _csTypeName, _sqliteTypeName)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    /// <param name="_csTypeName">CS类型名称</param>
    /// <param name="_sqliteTypeName">Sqlite数据库类型名称</param>
    public CodeAttribute(string _alias, string _csTypeName, string _sqliteTypeName)
        : base(_alias)
    {
        csTypeName = _csTypeName;
        sqliteTypeName = _sqliteTypeName;
}

    /// <summary>
    /// CS类型名称
    /// </summary>
    public string csTypeName { get; private set; }
    /// <summary>
    /// Sqlite数据库类型名称
    /// </summary>
    public string sqliteTypeName { get; private set; }
}
