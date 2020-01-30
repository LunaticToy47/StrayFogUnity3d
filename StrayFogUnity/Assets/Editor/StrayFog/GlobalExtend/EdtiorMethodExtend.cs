#if UNITY_EDITOR
using System;
using System.Reflection;
/// <summary>
/// MethodExtend
/// </summary>
public static class EdtiorMethodExtend
{
    /// <summary>
    /// 是否有ObsoleteAttribute属性
    /// </summary>
    /// <param name="_memberInfo">成员</param>
    /// <returns>true:有,false:无</returns>
    public static bool HasObsoleteAttribute(this MemberInfo _memberInfo)
    {
        return _memberInfo.GetFirstAttribute<ObsoleteAttribute>() != null;
    }

    /// <summary>
    /// 是否有ObsoleteAttribute属性
    /// </summary>
    /// <param name="_parameterInfo">参数信息</param>
    /// <returns>true:有,false:无</returns>
    public static bool HasObsoleteAttribute(this ParameterInfo _parameterInfo)
    {
        return _parameterInfo.ParameterType.GetFirstAttribute<ObsoleteAttribute>() != null;
    }    
}
#endif