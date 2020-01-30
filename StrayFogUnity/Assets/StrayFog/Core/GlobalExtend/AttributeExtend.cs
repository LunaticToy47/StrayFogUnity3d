using System;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// Attribute扩展
/// </summary>
public static class AttributeExtend
{
    #region Attribute反射

    #region GetFirstAttribute
    /// <summary>
    /// MemberInfo第一个属性映射(T或T的子类别)
    /// </summary>
    static Dictionary<int, Dictionary<int, object>> mMemberInfoFirstAttributeMaping = new Dictionary<int, Dictionary<int, object>>();
    /// <summary>
    /// 获得指定的属性特性(T或T的子类别)
    /// </summary>
    /// <typeparam name="A">特性类别</typeparam>
    /// <param name="_f">字段</param>
    /// <returns>特性</returns>
    public static A GetFirstAttribute<A>(this MemberInfo _f)
        where A : Attribute
    {
        int fkey = _f.GetHashCode();
        Type type = typeof(A);
        int tkey = type.GetHashCode();
        if (!mMemberInfoFirstAttributeMaping.ContainsKey(fkey))
        {
            mMemberInfoFirstAttributeMaping.Add(fkey, new Dictionary<int, object>());
        }
        if (!mMemberInfoFirstAttributeMaping[fkey].ContainsKey(tkey))
        {
            List<A> result = _f.GetAttributes<A>();
            if (result != null && result.Count > 0)
            {
                mMemberInfoFirstAttributeMaping[fkey].Add(tkey, result[0]);
            }
            else
            {
                mMemberInfoFirstAttributeMaping[fkey].Add(tkey, default(A));
            }
        }
        return (A)mMemberInfoFirstAttributeMaping[fkey][tkey];
    }
    #endregion

    #region GetFirstAttributeAbsolute
    /// <summary>
    /// MemberInfo检举第一个属性映射(仅T类别)
    /// </summary>
    static Dictionary<int, Dictionary<int, object>> mMemberInfoFirstAbsoluteAttributeMaping = new Dictionary<int, Dictionary<int, object>>();
    /// <summary>
    /// 获得指定的属性特性(仅T类别)
    /// </summary>
    /// <typeparam name="A">特性类别</typeparam>
    /// <param name="_f">字段</param>
    /// <returns>特性</returns>
    public static A GetFirstAttributeAbsolute<A>(this MemberInfo _f)
        where A : Attribute
    {
        int fkey = _f.GetHashCode();
        Type type = typeof(A);
        int tkey = type.GetHashCode();
        if (!mMemberInfoFirstAbsoluteAttributeMaping.ContainsKey(fkey))
        {
            mMemberInfoFirstAbsoluteAttributeMaping.Add(fkey, new Dictionary<int, object>());
        }
        if (!mMemberInfoFirstAbsoluteAttributeMaping[fkey].ContainsKey(tkey))
        {
            List<A> result = _f.GetAttributes<A>();
            if (result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].GetType().IsTypeOf(type))
                    {
                        mMemberInfoFirstAbsoluteAttributeMaping[fkey].Add(tkey, result[i]);
                        break;
                    }
                }
                if (!mMemberInfoFirstAbsoluteAttributeMaping[fkey].ContainsKey(tkey))
                {
                    mMemberInfoFirstAbsoluteAttributeMaping[fkey].Add(tkey, default(A));
                }
            }
            else
            {
                mMemberInfoFirstAbsoluteAttributeMaping[fkey].Add(tkey, default(A));
            }
        }
        return (A)mMemberInfoFirstAbsoluteAttributeMaping[fkey][tkey];
    }
    #endregion

    #region GetAttributes
    /// <summary>
    /// 静态类Const、readonly字段属性组映射
    /// </summary>
    static Dictionary<int, Dictionary<int, object>> mEnumAttributeMaping = new Dictionary<int, Dictionary<int, object>>();
    /// <summary>
    /// 获得指定的属性特性
    /// </summary>
    /// <typeparam name="A">特性类别</typeparam>
    /// <param name="_f">字段</param>
    /// <returns>特性</returns>
    public static List<A> GetAttributes<A>(this MemberInfo _f)
        where A : Attribute
    {
        int fkey = _f.GetHashCode();
        int tkey = typeof(A).GetHashCode();
        if (!mEnumAttributeMaping.ContainsKey(fkey))
        {
            mEnumAttributeMaping.Add(fkey, new Dictionary<int, object>());
        }
        if (!mEnumAttributeMaping[fkey].ContainsKey(tkey))
        {
            object[] obj = _f.GetCustomAttributes(typeof(A), true);
            List<A> attr = new List<A>();
            if (obj != null)
            {
                foreach (object j in obj)
                {
                    if (j is A)
                    {
                        attr.Add((A)j);
                    }
                }
            }
            mEnumAttributeMaping[fkey].Add(tkey, attr);
        }
        return (List<A>)mEnumAttributeMaping[fkey][tkey];
    }
    #endregion

    #region GetAbsoluteAttributes
    /// <summary>
    /// 静态类Const、readonly字段属性组映射(指定类型)
    /// </summary>
    static Dictionary<int, Dictionary<int, object>> mEnumAbsoluteAttributeMaping = new Dictionary<int, Dictionary<int, object>>();
    /// <summary>
    /// 获得指定的属性特性(指定类型)
    /// </summary>
    /// <typeparam name="A">特性类别</typeparam>
    /// <param name="_f">字段</param>
    /// <returns>特性</returns>
    public static List<A> GetAbsoluteAttributes<A>(this MemberInfo _f)
        where A : Attribute
    {
        int fkey = _f.GetHashCode();
        int tkey = typeof(A).GetHashCode();
        if (!mEnumAbsoluteAttributeMaping.ContainsKey(fkey))
        {
            mEnumAbsoluteAttributeMaping.Add(fkey, new Dictionary<int, object>());
        }
        if (!mEnumAbsoluteAttributeMaping[fkey].ContainsKey(tkey))
        {
            object[] obj = _f.GetCustomAttributes(typeof(A), true);
            List<A> attr = new List<A>();
            Type type = typeof(A);
            if (obj != null)
            {
                foreach (object j in obj)
                {
                    if (j.GetType().IsTypeOf(type))
                    {
                        attr.Add((A)j);
                    }
                }
            }
            mEnumAbsoluteAttributeMaping[fkey].Add(tkey, attr);
        }
        return (List<A>)mEnumAbsoluteAttributeMaping[fkey][tkey];
    }
    #endregion

    #region GetPropertyInfoAttribute 获得PropertyInfo与指定Attribute映射
    /// <summary>
    /// PropertyInfo与Attribute字典映射
    /// </summary>
    static Dictionary<int, Dictionary<int, Dictionary<int, object>>> msPropertyInfoAttributeDictionaryMaping =
        new Dictionary<int, Dictionary<int, Dictionary<int, object>>>();

    /// <summary>
    /// 获得PropertyInfo与指定Attribute映射
    /// </summary>
    /// <typeparam name="A">属性</typeparam>
    /// <param name="_type">类型</param>
    /// <returns>PropertyInfo属性映射字典</returns>
    public static Dictionary<PropertyInfo, A> GetPropertyInfoAttribute<A>(this Type _type)
        where A : Attribute
    {
        return _type.GetPropertyInfoAttribute<A>((p) => { return true; });
    }

    /// <summary>
    /// 获得PropertyInfo与指定Attribute映射
    /// </summary>
    /// <typeparam name="A">属性</typeparam>
    /// <param name="_type">类型</param>
    /// <param name="_condition">过渡条件</param>
    /// <returns>PropertyInfo属性映射字典</returns>
    public static Dictionary<PropertyInfo, A> GetPropertyInfoAttribute<A>(this Type _type, Func<PropertyInfo, bool> _condition)
    where A : Attribute
    {
        int tKey = _type.GetHashCode();
        int aKey = typeof(A).GetHashCode();
        int cKey = _condition == null ? 0 : _condition.GetHashCode();
        if (!msPropertyInfoAttributeDictionaryMaping.ContainsKey(tKey))
        {
            msPropertyInfoAttributeDictionaryMaping.Add(tKey, new Dictionary<int, Dictionary<int, object>>());
        }
        if (!msPropertyInfoAttributeDictionaryMaping[tKey].ContainsKey(aKey))
        {
            msPropertyInfoAttributeDictionaryMaping[tKey].Add(aKey, new Dictionary<int, object>());
        }
        if (!msPropertyInfoAttributeDictionaryMaping[tKey][aKey].ContainsKey(cKey))
        {
            Dictionary<PropertyInfo, A> dic = new Dictionary<PropertyInfo, A>();
            foreach (PropertyInfo p in _type.GetProperties())
            {
                if (_condition == null || _condition(p))
                {
                    dic.Add(p, p.GetFirstAttribute<A>());
                }
            }
            msPropertyInfoAttributeDictionaryMaping[tKey][aKey].Add(cKey, dic);
        }
        return (Dictionary<PropertyInfo, A>)msPropertyInfoAttributeDictionaryMaping[tKey][aKey][cKey];
    }
    #endregion

    #region GetFieldInfoAttribute 获得FieldInfo与指定Attribute映射
    /// <summary>
    /// FieldInfo与Attribute字典映射
    /// </summary>
    static Dictionary<int, Dictionary<int, Dictionary<int, object>>> msFieldInfoAttributeDictionaryMaping =
        new Dictionary<int, Dictionary<int, Dictionary<int, object>>>();

    /// <summary>
    /// 获得FieldInfo与指定Attribute映射
    /// </summary>
    /// <typeparam name="A">属性</typeparam>
    /// <param name="_type">类型</param>
    /// <returns>FieldInfo属性映射字典</returns>
    public static Dictionary<FieldInfo, A> GetFieldInfoAttribute<A>(this Type _type)
        where A : Attribute
    {
        return _type.GetFieldInfoAttribute<A>((p) => { return true; });
    }

    /// <summary>
    /// 获得FieldInfo与指定Attribute映射
    /// </summary>
    /// <typeparam name="A">属性</typeparam>
    /// <param name="_type">类型</param>
    /// <param name="_condition">过渡条件</param>
    /// <returns>FieldInfo属性映射字典</returns>
    public static Dictionary<FieldInfo, A> GetFieldInfoAttribute<A>(this Type _type, Func<FieldInfo, bool> _condition)
    where A : Attribute
    {
        int tKey = _type.GetHashCode();
        int aKey = typeof(A).GetHashCode();
        int cKey = _condition == null ? 0 : _condition.GetHashCode();
        if (!msFieldInfoAttributeDictionaryMaping.ContainsKey(tKey))
        {
            msFieldInfoAttributeDictionaryMaping.Add(tKey, new Dictionary<int, Dictionary<int, object>>());
        }
        if (!msFieldInfoAttributeDictionaryMaping[tKey].ContainsKey(aKey))
        {
            msFieldInfoAttributeDictionaryMaping[tKey].Add(aKey, new Dictionary<int, object>());
        }
        if (!msFieldInfoAttributeDictionaryMaping[tKey][aKey].ContainsKey(cKey))
        {
            Dictionary<FieldInfo, A> dic = new Dictionary<FieldInfo, A>();
            foreach (FieldInfo f in _type.GetFields())
            {
                if (_condition == null || _condition(f))
                {
                    dic.Add(f, f.GetFirstAttribute<A>());
                }
            }
            msFieldInfoAttributeDictionaryMaping[tKey][aKey].Add(cKey, dic);
        }
        return (Dictionary<FieldInfo, A>)msFieldInfoAttributeDictionaryMaping[tKey][aKey][cKey];
    }
    #endregion

    #endregion
}