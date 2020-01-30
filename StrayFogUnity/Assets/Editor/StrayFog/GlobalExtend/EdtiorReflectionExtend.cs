#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// 反射扩展
/// </summary>
public static class EdtiorReflectionExtend
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
            (f) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k) =>
            {
                return f.Name;
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k) =>
            {
                return k;
            },
            (f, k, v) =>
            {
                return _funcSpecifyValue(v);
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
            (f) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return _funcAttributeSpecifyValue(v);
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
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return f.Name;
            },
            (f, k, v) =>
            {
                return _funcSpecifyValue(v);
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
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return _funcAttributeSpecifyValue(v);
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
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k) =>
            {
                return (E)Enum.Parse(_enumType, f.Name);
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k) =>
            {
                return f.Name;
            },
            (f, k, v) =>
            {
                return v;
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
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k) =>
            {
                return k;
            },
            (f, k, v) =>
            {
                return _funcSpecifyValue(v);
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
            (f) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return v;
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
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
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
        return _enumToList<string, E, E>(_enumType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return (E)Enum.Parse(_enumType, f.Name); 
            },
            (f, k, v) =>
            {
                return v;
            }
        );
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
        return _enumToList<string, string, string>(_enumType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return f.Name;
            },
            (f, k, v) =>
            {
                return v;
            }
        );
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
        return _enumToList<string, int, int>(_enumType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return Convert.ToInt32(Enum.Parse(_enumType, f.Name));
            },
            (f, k, v) =>
            {
                return v;
            }
        );
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
        return _enumToList<string, A, A>(_enumType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return v;
            }
        );
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
    public static List<R> ToAttributeSpecifyValues<A, R>(this Type _enumType, Func<A, R> _funcAlias)
        where A : Attribute
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！");
        }
        return _enumToList<string, A, R>(_enumType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return f.GetFirstAttribute<A>();
            },
            (f, k, v) =>
            {
                return _funcAlias(v);
            }
        );
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
        string key = _enum.ToString();
        dic.TryGetValue(key, out attr);
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
        Func<MemberInfo, K> _funcKey, Func<MemberInfo, K, V> _funcValue, Func<MemberInfo, K, V, R> _funcResult)
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
            V tempValue = default;
            K tempKey = default;
            foreach (FieldInfo f in _enumType.GetFields())
            {
                if (!f.IsSpecialName)
                {
                    tempKey = _funcKey(f);
                    tempValue = _funcValue(f, tempKey);
                    enumDic.Add(tempKey, _funcResult(f, tempKey, tempValue));
                }
            }
            msEnumDictionaryMaping[kKey][vKey][rKey].Add(eKey, enumDic);
        }
        return (Dictionary<K, R>)msEnumDictionaryMaping[kKey][vKey][rKey][eKey];
    }
    #endregion

    #region static _enumToList 枚举转换成指定数组
    /// <summary>
    /// 枚举数组映射
    /// </summary>
    static Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>> msEnumListMaping =
        new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>>();
    /// <summary>
    /// 将静态类const、readonly属性映射为字典
    /// </summary>
    /// <typeparam name="K">Key类型</typeparam>
    /// <typeparam name="V">Value类型</typeparam>
    /// <typeparam name="R">Value返回结果类型</typeparam>
    /// <param name="_enumType">枚举类型</param>
    /// <param name="_funcKey">Key值</param>
    /// <param name="_funcValue">Value值</param>
    /// <param name="_funcResult">Value返回结果</param>
    /// <returns>字典</returns>
    static List<R> _enumToList<K, V, R>(Type _enumType,
        Func<MemberInfo, K> _funcKey, Func<MemberInfo, K, V> _funcValue, Func<MemberInfo, K, V, R> _funcResult)
    {
        if (!_enumType.IsEnum)
        {
            throw new ArgumentException("Type必须是枚举类型！", "_enumType");
        }
        int kKey = typeof(K).GetHashCode();
        int vKey = typeof(V).GetHashCode();
        int rKey = typeof(R).GetHashCode();
        int eKey = _enumType.GetHashCode();
        if (!msEnumListMaping.ContainsKey(kKey))
        {
            msEnumListMaping.Add(kKey, new Dictionary<int, Dictionary<int, Dictionary<int, object>>>());
        }
        if (!msEnumListMaping[kKey].ContainsKey(vKey))
        {
            msEnumListMaping[kKey].Add(vKey, new Dictionary<int, Dictionary<int, object>>());
        }
        if (!msEnumListMaping[kKey][vKey].ContainsKey(rKey))
        {
            msEnumListMaping[kKey][vKey].Add(rKey, new Dictionary<int, object>());
        }

        if (!msEnumListMaping[kKey][vKey][rKey].ContainsKey(eKey))
        {
            Dictionary<K, R> dic = _enumToDictionary<K, V, R>(_enumType, _funcKey, _funcValue, _funcResult);
            msEnumListMaping[kKey][vKey][rKey].Add(eKey, new List<R>(dic.Values));
        }
        return (List<R>)msEnumListMaping[kKey][vKey][rKey][eKey];
    }
    #endregion

    #endregion
}
#endif