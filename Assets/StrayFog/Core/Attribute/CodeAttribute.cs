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
    /// <param name="_code">代码</param>
    public CodeAttribute(string _code)
        : this(_code, _code, _code)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    /// <param name="_code">代码</param>
    public CodeAttribute(string _alias, string _code)
        : this(_alias,_code,_code)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    /// <param name="_code">代码</param>
    /// <param name="_prefixCode">代码前缀</param>
    public CodeAttribute(string _alias, string _code,string _codePrefix)
        : base(_alias)
    {
        code = _code;
        codePrefix = _codePrefix;
}

    /// <summary>
    /// 代码
    /// </summary>
    public string code { get; private set; }
    /// <summary>
    /// 代码前缀
    /// </summary>
    public string codePrefix { get; private set; }
}
