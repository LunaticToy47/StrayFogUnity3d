using System;
using System.Reflection;
/// <summary>
/// Type扩展
/// </summary>
public static class TypeExtend
{
    /// <summary>
    /// 是否是静态类
    /// </summary>
    /// <param name="_type">源类别</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsStatic(this Type _type)
    {
        return _type.IsSealed && _type.IsAbstract;
    }

    /// <summary>
    /// 是否是指定类别或指定类别的子类别
    /// </summary>
    /// <param name="_srctype">源类别</param>
    /// <param name="_ofType">指定类别</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsTypeOrSubTypeOf(this Type _srctype, Type _ofType)
    {
        return _srctype.IsTypeOf(_ofType) || _srctype.IsSubTypeOf(_ofType);
    }

    /// <summary>
    /// 是否是指定类别
    /// </summary>
    /// <param name="_srctype">源类别</param>
    /// <param name="_ofType">指定类别</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsTypeOf(this Type _srctype, Type _ofType)
    {
        return _srctype.Equals(_ofType);
    }

    /// <summary>
    /// 是否是指定类别的子类别
    /// </summary>
    /// <param name="_srctype">源类别</param>
    /// <param name="_ofType">指定类别</param>
    /// <returns>True:是,False:否</returns>
    public static bool IsSubTypeOf(this Type _srctype, Type _ofType)
    {
        return _srctype.IsSubclassOf(_ofType) || _srctype.GetInterface(_ofType.Name) != null;
    }

    /// <summary>
    /// 是否是纯方法
    /// </summary>
    /// <param name="_methodInfo">方法</param>
    /// <returns>true:是,false:否</returns>
    public static bool IsMethod(this MethodInfo _methodInfo)
    {
        return !_methodInfo.IsSpecialName;
    }
}
