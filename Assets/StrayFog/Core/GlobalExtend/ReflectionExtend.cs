using System;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// 反射扩展
/// </summary>
public static class ReflectionExtend
{
    #region Enum枚举反射

    #region EnumToName
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:名称
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static Dictionary<E, string> EnumToName<E>(this Type _enumType)
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<E, string, string>(_enumType,
            (k) =>
            {
                return (E)Enum.Parse(_enumType, k.Name);
            },
            (v) =>
            {
                return v.Name;
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region EnumToValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:值
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static Dictionary<E, int> EnumToValue<E>(this Type _enumType)
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<E, int, int>(_enumType,
            (k) =>
            {
                return (E)Enum.Parse(_enumType, k.Name);
            },
            (v) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, v.Name));
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region EnumToSpecialValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:值
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <typeparam name="R">值类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcSpecifyValue">函数特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<E, R> EnumToSpecialValue<E, R>(this Type _enumType, Func<E, R> _funcSpecifyValue)
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<E, E, R>(_enumType,
            (k) =>
            {
                return (E)Enum.Parse(_enumType, k.Name);
            },
            (v) =>
            {
                return (E)Enum.Parse(_enumType, v.Name);
            },
            (r) =>
            {
                return _funcSpecifyValue(r);
            }
        );
    }
    #endregion

    #region EnumToAttribute
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <typeparam name="A">特性类型</typeparam>
    /// <param name="_enumType">枚举类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<E, A> EnumToAttribute<E, A>(this Type _enumType)
        where A : Attribute
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<E, A, A>(_enumType,
            (k) =>
            {
                return (E)Enum.Parse(_enumType, k.Name);
            },
            (v) =>
            {
                return GetFirstAttribute<A>(v);
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region EnumToAttributeSpecifyValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <typeparam name="A">特性类型</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcAttributeSpecifyValue">属性特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<E, R> EnumToAttributeSpecifyValue<E, A, R>(this Type _enumType, Func<A, R> _funcAttributeSpecifyValue)
        where A : Attribute
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<E, A, R>(_enumType,
            (k) =>
            {
                return (E)Enum.Parse(_enumType, k.Name);
            },
            (v) =>
            {
                return GetFirstAttribute<A>(v);
            },
            (r) =>
            {
                return _funcAttributeSpecifyValue(r);
            }
        );
    }
    #endregion

    #region NameToEnum
    /// <summary>
    /// 将枚举转换为字典
    /// Key:名称
    /// Value:枚举
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static Dictionary<string, E> NameToEnum<E>(this Type _enumType)
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<string, E, E>(_enumType,
            (k) =>
            {
                return k.Name;
            },
            (v) =>
            {
                return (E)Enum.Parse(_enumType, v.Name);
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region NameToValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:名称
    /// Value:值
    /// </summary>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static Dictionary<string, int> NameToValue(this Type _enumType)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<string, int, int>(_enumType,
            (k) =>
            {
                return k.Name;
            },
            (v) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, v.Name));
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region NameToSpecialValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:值
    /// </summary>
    /// <typeparam name="R">值类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcSpecifyValue">函数特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<string, R> NameToSpecialValue<R>(this Type _enumType, Func<string, R> _funcSpecifyValue)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<string, string, R>(_enumType,
            (k) =>
            {
                return k.Name;
            },
            (v) =>
            {
                return v.Name;
            },
            (r) =>
            {
                return _funcSpecifyValue(r);
            }
        );
    }
    #endregion

    #region NameToAttribute
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举名称
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_enumType">枚举类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<string, A> NameToAttribute<A>(this Type _enumType)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<string, A, A>(_enumType,
            (k) =>
            {
                return k.Name;
            },
            (v) =>
            {
                return GetFirstAttribute<A>(v);
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region NameToAttributeSpecifyValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举名称
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcAttributeSpecifyValue">属性特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<string, R> NameToAttributeSpecifyValue<A, R>(this Type _enumType, Func<A, R> _funcAttributeSpecifyValue)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<string, A, R>(_enumType,
            (k) =>
            {
                return k.Name;
            },
            (v) =>
            {
                return GetFirstAttribute<A>(v);
            },
            (r) =>
            {
                return _funcAttributeSpecifyValue(r);
            }
        );
    }
    #endregion

    #region ValueToEnum
    /// <summary>
    /// 将枚举转换为字典
    /// Key:值
    /// Value:枚举
    /// </summary>
    /// <typeparam name="E">枚举类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static Dictionary<int, E> ValueToEnum<E>(this Type _enumType)
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<int, E, E>(_enumType,
            (k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, k.Name));
            },
            (v) =>
            {
                return (E)Enum.Parse(_enumType, v.Name);
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region ValueToName
    /// <summary>
    /// 将枚举转换为字典
    /// Key:值
    /// Value:名称
    /// </summary>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static Dictionary<int, string> ValueToName(this Type _enumType)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<int, string, string>(_enumType,
            (k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, k.Name));
            },
            (v) =>
            {
                return v.Name;
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region ValueToSpecialValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举
    /// Value:值
    /// </summary>
    /// <typeparam name="R">值类别</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcSpecifyValue">函数特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<int, R> ValueToSpecialValue<R>(this Type _enumType, Func<int, R> _funcSpecifyValue)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<int, int, R>(_enumType,
            (k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, k.Name));
            },
            (v) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, v.Name));
            },
            (r) =>
            {
                return _funcSpecifyValue(r);
            }
        );
    }
    #endregion

    #region ValueToAttribute
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举名称
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_enumType">枚举类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<int, A> ValueToAttribute<A>(this Type _enumType)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<int, A, A>(_enumType,
            (k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, k.Name));
            },
            (v) =>
            {
                return GetFirstAttribute<A>(v);
            },
            (r) =>
            {
                return r;
            }
        );
    }
    #endregion

    #region ValueToAttributeSpecifyValue
    /// <summary>
    /// 将枚举转换为字典
    /// Key:枚举名称
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcAttributeSpecifyValue">属性特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<int, R> ValueToAttributeSpecifyValue<A, R>(this Type _enumType, Func<A, R> _funcAttributeSpecifyValue)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToDictionary<int, A, R>(_enumType,
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f) =>
            {
                return GetFirstAttribute<A>(f);
            },
            (v) =>
            {
                return _funcAttributeSpecifyValue(v);
            }
        );
    }
    #endregion

    #region ToEnums
    /// <summary>
    /// 获得指定枚举的枚举组
    /// </summary>
    /// <typeparam name="E">枚举</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>枚举组</returns>
    public static List<E> ToEnums<E>(this Type _enumType)
    {
        if (!typeof(E).IsEnum)
        {
            throw new ArgumentException("T必须是枚举类型！");
        }
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        Dictionary<E, string> dic = _enumToDictionary<E, string, string>(_enumType,
            (f) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f) =>
            {
                return f.Name;
            },
            (v) =>
            {
                return v;
            }
        );
        List<E> rtn = new List<E>(dic.Keys);
        return rtn;
    }
    #endregion

    #region ToNames
    /// <summary>
    /// 获得指定枚举的名称组
    /// </summary>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>名称组</returns>
    public static List<string> ToNames(this Type _enumType)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        Dictionary<int, string> dic = _enumToDictionary<int, string, string>(_enumType,
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f) =>
            {
                return f.Name;
            },
            (v) =>
            {
                return v;
            }
        );
        List<string> rtn = new List<string>(dic.Values);
        return rtn;
    }
    #endregion

    #region ToValues
    /// <summary>
    /// 获得指定枚举的值组
    /// </summary>
    /// <param name="_enumType">枚举类型</param>
    /// <returns>字典</returns>
    public static List<int> ToValues(this Type _enumType)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        Dictionary<int, string> dic = _enumToDictionary<int, string, string>(_enumType,
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f) =>
            {
                return f.Name;
            },
            (v) =>
            {
                return v;
            }
        );
        List<int> rtn = new List<int>(dic.Keys);
        return rtn;
    }
    #endregion

    #region ToAttributes
    /// <summary>
    /// 获得指定枚举的特性组
    /// Key:枚举名称
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_enumType">枚举类型</param>    
    /// <returns>字典</returns>
    public static List<A> ToAttributes<A>(this Type _enumType)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        Dictionary<A, string> dic = _enumToDictionary<A, string, string>(_enumType,
            (f) =>
            {
                return GetFirstAttribute<A>(f);
            },
            (f) =>
            {
                return f.Name;
            },
            (v) =>
            {
                return v;
            }
        );
        List<A> rtn = new List<A>(dic.Keys);
        return rtn;
    }
    #endregion

    #region ToAttributeSpecifyValue
    /// <summary>
    /// 获得指定枚举的特性组
    /// Key:枚举名称
    /// Value:枚举特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_enumType">枚举类型</param>    
    /// <param name="_funcAlias">属性特定值函数</param>
    /// <returns>字典</returns>
    public static List<R> ToAttributeSpecifyValue<A, R>(this Type _enumType, Func<A, R> _funcAlias)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        Dictionary<string, R> dic = _enumToDictionary<string, A, R>(_enumType,
            (f) =>
            {
                return f.Name;
            },
            (f) =>
            {
                return GetFirstAttribute<A>(f);
            },
            (v) =>
            {
                return _funcAlias(v);
            }
        );
        List<R> rtn = new List<R>(dic.Values);
        return rtn;
    }
    #endregion

    #region GetAttribute 获得指定枚举的属性特性
    /// <summary>
    /// 获得指定枚举的属性特性
    /// </summary>
    /// <typeparam name="T">特性类型</typeparam>
    /// <param name="_enum">枚举</param>
    /// <returns>属性特性</returns>
    public static T GetAttribute<T>(this Enum _enum)
        where T : Attribute
    {
        Type type = _enum.GetType();
        Dictionary<string, T> dic = type.NameToAttribute<T>();
        T attr = default(T);
        foreach (KeyValuePair<string, T> key in dic)
        {
            if (key.Key.Equals(_enum.ToString()))
            {
                attr = key.Value;
                break;
            }
        }
        return attr;
    }
    #endregion

    #region static _enumToDictionary 枚举转换成指定字典
    /// <summary>
    /// 枚举字典映射
    /// </summary>
    static Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>> msEnumDictionaryMaping =
        new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>>();
    /// <summary>
    /// 枚举转换成指定字典
    /// </summary>
    /// <typeparam name="K">Key类型</typeparam>
    /// <typeparam name="V">Value类型</typeparam>
    /// <typeparam name="R">Value返回结果类型</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcKey">Key值</param>
    /// <param name="_funcValue">Value值</param>
    /// <param name="_funcResult">Value返回结果</param>
    /// <returns>字典</returns>
    static Dictionary<K, R> _enumToDictionary<K, V, R>(Type _enumType,
        Func<MemberInfo, K> _funcKey, Func<MemberInfo, V> _funcValue, Func<V, R> _funcResult)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！", "_enumType");
        }
        int kKey = typeof(K).GetHashCode();
        int vKey = typeof(V).GetHashCode();
        int rKey = typeof(R).GetHashCode();
        int eKey = _enumType.GetHashCode();
        if (!msEnumDictionaryMaping.ContainsKey(kKey))
        {
            msEnumDictionaryMaping.Add(kKey, new Dictionary<int, Dictionary<int, Dictionary<int, object>>>());
        }
        if (!msEnumDictionaryMaping[kKey].ContainsKey(vKey))
        {
            msEnumDictionaryMaping[kKey].Add(vKey, new Dictionary<int, Dictionary<int, object>>());
        }
        if (!msEnumDictionaryMaping[kKey][vKey].ContainsKey(rKey))
        {
            msEnumDictionaryMaping[kKey][vKey].Add(rKey, new Dictionary<int, object>());
        }

        if (!msEnumDictionaryMaping[kKey][vKey][rKey].ContainsKey(eKey))
        {
            Dictionary<K, R> enumDic = new Dictionary<K, R>();
            foreach (FieldInfo f in _enumType.GetFields())
            {
                if (!f.IsSpecialName)
                {
                    enumDic.Add(_funcKey(f), _funcResult(_funcValue(f)));
                }
            }
            msEnumDictionaryMaping[kKey][vKey][rKey].Add(eKey, enumDic);
        }
        return (Dictionary<K, R>)msEnumDictionaryMaping[kKey][vKey][rKey][eKey];
    }
    #endregion

    #endregion

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
    /// 枚举属性组映射
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
    /// 枚举属性组映射(指定类型)
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
