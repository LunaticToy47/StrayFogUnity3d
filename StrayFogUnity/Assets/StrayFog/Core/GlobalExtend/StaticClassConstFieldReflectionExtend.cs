using System;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// 静态类Const字段反射扩展
/// </summary>
public static class StaticClassConstFieldReflectionExtend
{
    #region StaticClassConstFieldReflection Type反射
    #region NameToValue
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:名称
    /// Value:值
    /// </summary>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>字典</returns>
    public static Dictionary<string, int> NameToValueForConstField(this Type _staticType)
    {
        return _staticType.NameToValueForConstField<int>();
    }
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:名称
    /// Value:值
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>字典</returns>
    public static Dictionary<string, V> NameToValueForConstField<V>(this Type _staticType)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<string, V, V>(_staticType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return (V)Convert.ChangeType(f.GetValue(null), typeof(V));
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
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段
    /// Value:值
    /// </summary>
    /// <typeparam name="R">值类别</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcSpecifyValue">函数特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<string, R> NameToSpecialValueForConstField<R>(this Type _staticType, Func<FieldInfo, R> _funcSpecifyValue)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<string, string, R>(_staticType,
            (f) =>
            {
                return f.Name;
            },
            (f, k) =>
            {
                return k;
            },
            (f, k, v) =>
            {
                return _funcSpecifyValue(f);
            }
        );
    }
    #endregion

    #region NameToAttribute
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_staticType">静态类类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<string, A> NameToAttributeForConstField<A>(this Type _staticType)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<string, A, A>(_staticType,
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
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <typeparam name="R">特殊值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcAttributeSpecifyValue">属性特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<string, R> NameToAttributeSpecifyValueForConstField<A, R>(this Type _staticType, Func<A, R> _funcAttributeSpecifyValue)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<string, A, R>(_staticType,
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

    #region ValueToName
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:值
    /// Value:名称
    /// </summary>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>字典</returns>
    public static Dictionary<int, string> ValueToNameForConstField(this Type _staticType)
    {
        return _staticType.ValueToNameForConstField<int>();
    }
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:值
    /// Value:名称
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>字典</returns>
    public static Dictionary<V, string> ValueToNameForConstField<V>(this Type _staticType)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<V, string, string>(_staticType,
            (f) =>
            {
                return (V)Convert.ChangeType(f.GetValue(null), typeof(V));
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
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段
    /// Value:值
    /// </summary>
    /// <typeparam name="R">特殊值类别</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcSpecifyValue">函数特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<int, R> ValueToSpecialValueForConstField<R>(this Type _staticType, Func<FieldInfo, R> _funcSpecifyValue)
    {
        return _staticType.ValueToSpecialValueForConstField<int, R>(_funcSpecifyValue);
    }
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段
    /// Value:值
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <typeparam name="R">特殊值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcSpecifyValue">函数特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<V, R> ValueToSpecialValueForConstField<V, R>(this Type _staticType, Func<FieldInfo, R> _funcSpecifyValue)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<V, string, R>(_staticType,
            (f) =>
            {
                return (V)Convert.ChangeType(f.GetValue(null), typeof(V));
            },
            (f, k) =>
            {
                return f.Name;
            },
            (f, k, v) =>
            {
                return _funcSpecifyValue(f);
            }
        );
    }
    #endregion

    #region ValueToAttribute
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_staticType">静态类类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<int, A> ValueToAttributeForConstField<A>(this Type _staticType)
        where A : Attribute
    {
        return _staticType.ValueToAttributeForConstField<int, A>();
    }

    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_staticType">静态类类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<V, A> ValueToAttributeForConstField<V, A>(this Type _staticType)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<V, A, A>(_staticType,
            (f) =>
            {
                return (V)Convert.ChangeType(f.GetValue(null), typeof(V));
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

    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="V">特值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>    
    /// <returns>字典</returns>
    public static Dictionary<V, FieldInfo> ValueToFieldForConstField<V>(this Type _staticType)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<V, FieldInfo, FieldInfo>(_staticType,
            (f) =>
            {
                return (V)Convert.ChangeType(f.GetValue(null), typeof(V));
            },
            (f, k) =>
            {
                return f;
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
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <typeparam name="R">特殊值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcAttributeSpecifyValue">属性特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<int, R> ValueToAttributeSpecifyValueForConstField<A, R>(this Type _staticType, Func<A, R> _funcAttributeSpecifyValue)
        where A : Attribute
    {
        return _staticType.ValueToAttributeSpecifyValueForConstField<int, A, R>(_funcAttributeSpecifyValue);
    }
    /// <summary>
    /// 将静态类Const、readonly字段转换为字典
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <typeparam name="R">特殊值类型</typeparam>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcAttributeSpecifyValue">属性特定值函数</param>
    /// <returns>字典</returns>
    public static Dictionary<V, R> ValueToAttributeSpecifyValueForConstField<V, A, R>(this Type _staticType, Func<A, R> _funcAttributeSpecifyValue)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToDictionary<V, A, R>(_staticType,
            (f) =>
            {
                return (V)Convert.ChangeType(f.GetValue(null), typeof(V));
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

    #region ToNames
    /// <summary>
    /// 获得指定静态类Const、readonly字段的名称组
    /// </summary>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>名称组</returns>
    public static List<string> ToNamesForConstField(this Type _staticType)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToList<int, string, string>(_staticType,
            (f) =>
            {
                return f.Name.GetHashCode();
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
    /// 获得指定静态类Const、readonly字段的值组
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>字典</returns>
    public static List<int> ToValuesForConstField(this Type _staticType)
    {
        return _staticType.ToValuesForConstField<int>();
    }
    /// <summary>
    /// 获得指定静态类Const、readonly字段的值组
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <returns>字典</returns>
    public static List<V> ToValuesForConstField<V>(this Type _staticType)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToList<int, string, V>(_staticType,
            (f) =>
            {
                return f.Name.GetHashCode();
            },
            (f, k) =>
            {
                return f.Name;
            },
            (f, k, v) =>
            {
                object d = f.GetValue(null);
                object c = Convert.ChangeType(f.GetValue(null), typeof(V));
                return (V)c;
            }
        );
    }
    #endregion

    #region ToAttributes
    /// <summary>
    /// 获得指定静态类Const、readonly字段的特性组
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <param name="_staticType">静态类类型</param>    
    /// <returns>字典</returns>
    public static List<A> ToAttributesForConstField<A>(this Type _staticType)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToList<string, A, A>(_staticType,
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
    /// 获得指定静态类Const、readonly字段的特性组
    /// Key:静态类Const、readonly字段名称
    /// Value:静态类Const、readonly字段特性
    /// </summary>
    /// <typeparam name="A">特性泛型</typeparam>
    /// <typeparam name="R">特殊值类型</typeparam>
    /// <param name="_staticType">静态类类型</param>    
    /// <param name="_funcAlias">属性特定值函数</param>
    /// <returns>字典</returns>
    public static List<R> ToAttributeSpecifyValueForConstField<A, R>(this Type _staticType, Func<A, R> _funcAlias)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        return _StaticClassConstFieldToList<string, A, R>(_staticType,
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

    #region static _StaticClassConstFieldToDictionary 静态类Const、readonly字段转换成指定字典
    /// <summary>
    /// 静态类const、readonly属性字典映射
    /// </summary>
    static Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>> msStaticClassConstFieldDictionaryMaping =
        new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>>();
    

    /// <summary>
    /// 将静态类const、readonly属性映射为字典
    /// </summary>
    /// <typeparam name="K">Key类型</typeparam>
    /// <typeparam name="V">Value类型</typeparam>
    /// <typeparam name="R">Value返回结果类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcKey">Key值</param>
    /// <param name="_funcValue">Value值</param>
    /// <param name="_funcResult">Value返回结果</param>
    /// <returns>字典</returns>
    static Dictionary<K, R> _StaticClassConstFieldToDictionary<K, V, R>(Type _staticType,
    Func<FieldInfo, K> _funcKey, Func<FieldInfo, K, V> _funcValue, Func<FieldInfo, K, V, R> _funcResult)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！", "_staticType");
        }
        int kKey = typeof(K).GetHashCode();
        int vKey = typeof(V).GetHashCode();
        int rKey = typeof(R).GetHashCode();
        int eKey = _staticType.GetHashCode();
        if (!msStaticClassConstFieldDictionaryMaping.ContainsKey(kKey))
        {
            msStaticClassConstFieldDictionaryMaping.Add(kKey, new Dictionary<int, Dictionary<int, Dictionary<int, object>>>());
        }
        if (!msStaticClassConstFieldDictionaryMaping[kKey].ContainsKey(vKey))
        {
            msStaticClassConstFieldDictionaryMaping[kKey].Add(vKey, new Dictionary<int, Dictionary<int, object>>());
        }
        if (!msStaticClassConstFieldDictionaryMaping[kKey][vKey].ContainsKey(rKey))
        {
            msStaticClassConstFieldDictionaryMaping[kKey][vKey].Add(rKey, new Dictionary<int, object>());
        }

        if (!msStaticClassConstFieldDictionaryMaping[kKey][vKey][rKey].ContainsKey(eKey))
        {
            Dictionary<K, R> maping = new Dictionary<K, R>();
            V tempValue = default;
            K tempKey = default;
            foreach (FieldInfo f in _staticType.GetFields())
            {
                tempKey = _funcKey(f);
                tempValue = _funcValue(f, tempKey);
                if (f.IsLiteral && !f.IsInitOnly)
                {
                    maping.Add(_funcKey(f), _funcResult(f, tempKey, tempValue));
                }
            }
            msStaticClassConstFieldDictionaryMaping[kKey][vKey][rKey].Add(eKey, maping);
        }
        return (Dictionary<K, R>)msStaticClassConstFieldDictionaryMaping[kKey][vKey][rKey][eKey];
    }
    #endregion

    #region static _StaticClassConstFieldToList 静态类Const、readonly字段转换成指定数组
    /// <summary>
    /// 静态类const、readonly属性数组映射
    /// </summary>
    static Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>> msStaticClassConstFieldListMaping =
        new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, object>>>>();

    /// <summary>
    /// 将静态类const、readonly属性映射为字典
    /// </summary>
    /// <typeparam name="K">Key类型</typeparam>
    /// <typeparam name="V">Value类型</typeparam>
    /// <typeparam name="R">Value返回结果类型</typeparam>
    /// <param name="_staticType">静态类类型</param>
    /// <param name="_funcKey">Key值</param>
    /// <param name="_funcValue">Value值</param>
    /// <param name="_funcResult">Value返回结果</param>
    /// <returns>字典</returns>
    static List<R> _StaticClassConstFieldToList<K, V, R>(Type _staticType,
        Func<FieldInfo, K> _funcKey, Func<FieldInfo, K, V> _funcValue, Func<FieldInfo, K, V, R> _funcResult)
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！", "_staticType");
        }
        int kKey = typeof(K).GetHashCode();
        int vKey = typeof(V).GetHashCode();
        int rKey = typeof(R).GetHashCode();
        int eKey = _staticType.GetHashCode();
        if (!msStaticClassConstFieldListMaping.ContainsKey(kKey))
        {
            msStaticClassConstFieldListMaping.Add(kKey, new Dictionary<int, Dictionary<int, Dictionary<int, object>>>());
        }
        if (!msStaticClassConstFieldListMaping[kKey].ContainsKey(vKey))
        {
            msStaticClassConstFieldListMaping[kKey].Add(vKey, new Dictionary<int, Dictionary<int, object>>());
        }
        if (!msStaticClassConstFieldListMaping[kKey][vKey].ContainsKey(rKey))
        {
            msStaticClassConstFieldListMaping[kKey][vKey].Add(rKey, new Dictionary<int, object>());
        }
        if (!msStaticClassConstFieldListMaping[kKey][vKey][rKey].ContainsKey(eKey))
        {
            Dictionary<K, R> dic = _StaticClassConstFieldToDictionary<K, V, R>(_staticType, _funcKey, _funcValue, _funcResult);
            msStaticClassConstFieldListMaping[kKey][vKey][rKey].Add(eKey, new List<R>(dic.Values));
        }        
        return (List<R>)msStaticClassConstFieldListMaping[kKey][vKey][rKey][eKey]; ;
    }
    #endregion

    #endregion

    #region StaticClassConstFieldReflection Attribute反射
    /// <summary>
    /// 指定值的静态类常量指定属性
    /// </summary>
    /// <typeparam name="A">属性泛型</typeparam>
    /// <param name="_staticType">静态类</param>
    /// <param name="_constValue">常量值</param>
    /// <returns>指定属性</returns>
    public static A GetAttributeForConstField<A>(this Type _staticType, int _constValue)
        where A : Attribute
    {
        return _staticType.GetAttributeForConstField<int, A>(_constValue);
    }

    /// <summary>
    /// 指定值的静态类常量指定属性
    /// </summary>
    /// <typeparam name="V">值类型</typeparam>
    /// <typeparam name="A">属性泛型</typeparam>
    /// <param name="_staticType">静态类</param>
    /// <param name="_constValue">常量值</param>
    /// <returns>指定属性</returns>
    public static A GetAttributeForConstField<V,A>(this Type _staticType, V _constValue)
        where A : Attribute
    {
        if (!_staticType.IsStatic())
        {
            throw new ArgumentException("Type必须是静态类类型！");
        }
        Dictionary<V,A> dic = _staticType.ValueToAttributeForConstField<V, A>();
        A result = default;
        dic.TryGetValue(_constValue, out result);
        return result;
    }
    #endregion
}
