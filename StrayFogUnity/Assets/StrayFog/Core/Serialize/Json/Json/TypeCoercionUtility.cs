namespace JsonFx.Json
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.InteropServices;

    internal class TypeCoercionUtility
    {
        private bool allowNullValueTypes = true;
        private const string ErrorCannotInstantiate = "Interfaces, Abstract classes, and unsupported ValueTypes cannot be deserialized. ({0})";
        private const string ErrorDefaultCtor = "Only objects with default constructors can be deserialized. ({0})";
        private const string ErrorNullValueType = "{0} does not accept null as a value";
        private Dictionary<Type, Dictionary<string, MemberInfo>> memberMapCache;

        private Array CoerceArray(Type elementType, IEnumerable value)
        {
            ArrayList list = new ArrayList();
            IEnumerator enumerator = value.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    list.Add(this.CoerceType(elementType, current));
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                }
                disposable.Dispose();
            }
            return list.ToArray(elementType);
        }

        private object CoerceList(Type targetType, Type arrayType, IEnumerable value)
        {
            object obj2;
            object obj4;
            if (targetType.IsArray)
            {
                return this.CoerceArray(targetType.GetElementType(), value);
            }
            ConstructorInfo[] constructors = targetType.GetConstructors();
            ConstructorInfo info = null;
            foreach (ConstructorInfo info2 in constructors)
            {
                ParameterInfo[] parameters = info2.GetParameters();
                if (parameters.Length == 0)
                {
                    info = info2;
                }
                else if ((parameters.Length == 1) && parameters[0].ParameterType.IsAssignableFrom(arrayType))
                {
                    try
                    {
                        object[] objArray1 = new object[] { value };
                        return info2.Invoke(objArray1);
                    }
                    catch
                    {
                    }
                }
            }
            if (info == null)
            {
                throw new JsonTypeCoercionException(string.Format("Only objects with default constructors can be deserialized. ({0})", targetType.FullName));
            }
            try
            {
                obj2 = info.Invoke(null);
            }
            catch (TargetInvocationException exception)
            {
                if (exception.InnerException != null)
                {
                    throw new JsonTypeCoercionException(exception.InnerException.Message, exception.InnerException);
                }
                throw new JsonTypeCoercionException("Error instantiating " + targetType.FullName, exception);
            }
            MethodInfo method = targetType.GetMethod("AddRange");
            ParameterInfo[] infoArray4 = (method != null) ? method.GetParameters() : null;
            Type type = ((infoArray4 != null) && (infoArray4.Length == 1)) ? infoArray4[0].ParameterType : null;
            if ((type != null) && type.IsAssignableFrom(arrayType))
            {
                try
                {
                    object[] objArray2 = new object[] { value };
                    method.Invoke(obj2, objArray2);
                }
                catch (TargetInvocationException exception2)
                {
                    if (exception2.InnerException != null)
                    {
                        throw new JsonTypeCoercionException(exception2.InnerException.Message, exception2.InnerException);
                    }
                    throw new JsonTypeCoercionException("Error calling AddRange on " + targetType.FullName, exception2);
                }
                return obj2;
            }
            method = targetType.GetMethod("Add");
            infoArray4 = (method != null) ? method.GetParameters() : null;
            type = ((infoArray4 != null) && (infoArray4.Length == 1)) ? infoArray4[0].ParameterType : null;
            if (type != null)
            {
                IEnumerator enumerator = value.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        object current = enumerator.Current;
                        try
                        {
                            object[] objArray3 = new object[] { this.CoerceType(type, current) };
                            method.Invoke(obj2, objArray3);
                            continue;
                        }
                        catch (TargetInvocationException exception3)
                        {
                            if (exception3.InnerException != null)
                            {
                                throw new JsonTypeCoercionException(exception3.InnerException.Message, exception3.InnerException);
                            }
                            throw new JsonTypeCoercionException("Error calling Add on " + targetType.FullName, exception3);
                        }
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }                    
                }
                return obj2;
            }
            try
            {
                obj4 = Convert.ChangeType(value, targetType);
            }
            catch (Exception exception4)
            {
                throw new JsonTypeCoercionException(string.Format("Error converting {0} to {1}", value.GetType().FullName, targetType.FullName), exception4);
            }
            return obj4;
        }

        internal object CoerceType(Type targetType, object value)
        {
            bool flag = IsNullable(targetType);
            if (value == null)
            {
                if ((!this.allowNullValueTypes && targetType.IsValueType) && !flag)
                {
                    throw new JsonTypeCoercionException(string.Format("{0} does not accept null as a value", targetType.FullName));
                }
                return value;
            }
            if (flag)
            {
                Type[] genericArguments = targetType.GetGenericArguments();
                if (genericArguments.Length == 1)
                {
                    targetType = genericArguments[0];
                }
            }
            Type c = value.GetType();
            if (targetType.IsAssignableFrom(c))
            {
                return value;
            }
            if (!targetType.IsEnum)
            {
                object obj2;
                if (value is IDictionary)
                {
                    Dictionary<string, MemberInfo> dictionary;
                    return this.CoerceType(targetType, (IDictionary) value, out dictionary);
                }
                if (typeof(IEnumerable).IsAssignableFrom(targetType) && typeof(IEnumerable).IsAssignableFrom(c))
                {
                    return this.CoerceList(targetType, c, (IEnumerable) value);
                }
                if (value is string)
                {
                    if (targetType != typeof(DateTime))
                    {
                        if (targetType == typeof(Guid))
                        {
                            return new Guid((string) value);
                        }
                        if (targetType != typeof(char))
                        {
                            if (targetType != typeof(Uri))
                            {
                                if (targetType == typeof(Version))
                                {
                                    return new Version((string) value);
                                }
                            }
                            else
                            {
                                Uri uri;
                                if (Uri.TryCreate((string) value, UriKind.RelativeOrAbsolute, out uri))
                                {
                                    return uri;
                                }
                            }
                        }
                        else if (((string) value).Length == 1)
                        {
                            return ((string) value)[0];
                        }
                    }
                    else
                    {
                        DateTime time;
                        if (DateTime.TryParse((string) value, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.RoundtripKind | DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AllowWhiteSpaces, out time))
                        {
                            return time;
                        }
                    }
                }
                else if (targetType == typeof(TimeSpan))
                {
                    return new TimeSpan((long) this.CoerceType(typeof(long), value));
                }
                TypeConverter converter = TypeDescriptor.GetConverter(targetType);
                if (converter.CanConvertFrom(c))
                {
                    return converter.ConvertFrom(value);
                }
                converter = TypeDescriptor.GetConverter(c);
                if (converter.CanConvertTo(targetType))
                {
                    return converter.ConvertTo(value, targetType);
                }
                try
                {
                    obj2 = Convert.ChangeType(value, targetType);
                }
                catch (Exception exception)
                {
                    throw new JsonTypeCoercionException(string.Format("Error converting {0} to {1}", value.GetType().FullName, targetType.FullName), exception);
                }
                return obj2;
            }
            if (!(value is string))
            {
                value = this.CoerceType(Enum.GetUnderlyingType(targetType), value);
                return Enum.ToObject(targetType, value);
            }
            if (!Enum.IsDefined(targetType, value))
            {
                foreach (FieldInfo info in targetType.GetFields())
                {
                    string jsonName = JsonNameAttribute.GetJsonName(info);
                    if (((string) value).Equals(jsonName))
                    {
                        value = info.Name;
                        break;
                    }
                }
            }
            return Enum.Parse(targetType, (string) value);
        }

        private object CoerceType(Type targetType, IDictionary value, out Dictionary<string, MemberInfo> memberMap)
        {
            object result = this.InstantiateObject(targetType, out memberMap);
            if (memberMap != null)
            {
                IEnumerator enumerator = value.Keys.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        MemberInfo info;
                        object current = enumerator.Current;
                        Type memberType = GetMemberInfo(memberMap, current as string, out info);
                        this.SetMemberValue(result, memberType, info, value[current]);
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable == null)
                    {
                    }
                    disposable.Dispose();
                }
            }
            return result;
        }

        internal Dictionary<string, MemberInfo> CreateFieldMemberMap(Type objectType)
        {
            if (this.MemberMapCache.ContainsKey(objectType))
            {
                return this.MemberMapCache[objectType];
            }
            Dictionary<string, MemberInfo> dictionary = new Dictionary<string, MemberInfo>();
            foreach (FieldInfo info2 in objectType.GetFields())
            {
                if (info2.IsPublic && !JsonIgnoreAttribute.IsJsonIgnore(info2))
                {
                    string str2 = JsonNameAttribute.GetJsonName(info2);
                    if (string.IsNullOrEmpty(str2))
                    {
                        dictionary[info2.Name] = info2;
                    }
                    else
                    {
                        dictionary[str2] = info2;
                    }
                }
            }
            this.MemberMapCache[objectType] = dictionary;
            return dictionary;
        }

        private Dictionary<string, MemberInfo> CreateMemberMap(Type objectType)
        {
            if (this.MemberMapCache.ContainsKey(objectType))
            {
                return this.MemberMapCache[objectType];
            }
            Dictionary<string, MemberInfo> dictionary = new Dictionary<string, MemberInfo>();
            foreach (PropertyInfo info in objectType.GetProperties())
            {
                if ((info.CanRead && info.CanWrite) && !JsonIgnoreAttribute.IsJsonIgnore(info))
                {
                    string jsonName = JsonNameAttribute.GetJsonName(info);
                    if (string.IsNullOrEmpty(jsonName))
                    {
                        dictionary[info.Name] = info;
                    }
                    else
                    {
                        dictionary[jsonName] = info;
                    }
                }
            }
            foreach (FieldInfo info2 in objectType.GetFields())
            {
                if (info2.IsPublic && !JsonIgnoreAttribute.IsJsonIgnore(info2))
                {
                    string str2 = JsonNameAttribute.GetJsonName(info2);
                    if (string.IsNullOrEmpty(str2))
                    {
                        dictionary[info2.Name] = info2;
                    }
                    else
                    {
                        dictionary[str2] = info2;
                    }
                }
            }
            this.MemberMapCache[objectType] = dictionary;
            return dictionary;
        }

        internal static Type GetMemberInfo(Dictionary<string, MemberInfo> memberMap, string memberName, out MemberInfo memberInfo)
        {
            if ((memberMap != null) && memberMap.ContainsKey(memberName))
            {
                memberInfo = memberMap[memberName];
                if (memberInfo is PropertyInfo)
                {
                    return ((PropertyInfo) memberInfo).PropertyType;
                }
                if (memberInfo is FieldInfo)
                {
                    return ((FieldInfo) memberInfo).FieldType;
                }
            }
            memberInfo = null;
            return null;
        }

        internal object InstantiateObject(Type objectType, out Dictionary<string, MemberInfo> memberMap)
        {
            object obj2;            
            if ((objectType.IsInterface || objectType.IsAbstract) || objectType.IsValueType)
            {
                throw new JsonTypeCoercionException(string.Format("Interfaces, Abstract classes, and unsupported ValueTypes cannot be deserialized. ({0})", objectType.FullName));
            }
            ConstructorInfo constructor = objectType.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
            {
                throw new JsonTypeCoercionException(string.Format("Only objects with default constructors can be deserialized. ({0})", objectType.FullName));
            }
            try
            {
                obj2 = constructor.Invoke(null);
            }
            catch (TargetInvocationException exception)
            {
                if (exception.InnerException != null)
                {
                    throw new JsonTypeCoercionException(exception.InnerException.Message, exception.InnerException);
                }
                throw new JsonTypeCoercionException("Error instantiating " + objectType.FullName, exception);
            }
            if (typeof(IDictionary).IsAssignableFrom(objectType))
            {
                memberMap = null;
                return obj2;
            }
            memberMap = this.CreateMemberMap(objectType);
            return obj2;
        }

        private static bool IsNullable(Type type)
        {
            return (type.IsGenericType && (typeof(Nullable<>) == type.GetGenericTypeDefinition()));
        }

        internal object ProcessTypeHint(IDictionary result, string typeInfo, out Type objectType, out Dictionary<string, MemberInfo> memberMap)
        {
            if (string.IsNullOrEmpty(typeInfo))
            {
                objectType = null;
                memberMap = null;
                return result;
            }
            Type targetType = Type.GetType(typeInfo, false);
            if (targetType == null)
            {
                objectType = null;
                memberMap = null;
                return result;
            }
            objectType = targetType;
            return this.CoerceType(targetType, result, out memberMap);
        }

        internal void SetMemberValue(object result, Type memberType, MemberInfo memberInfo, object value)
        {
            if (memberInfo is PropertyInfo)
            {
                ((PropertyInfo) memberInfo).SetValue(result, this.CoerceType(memberType, value), null);
            }
            else if (memberInfo is FieldInfo)
            {
                ((FieldInfo) memberInfo).SetValue(result, this.CoerceType(memberType, value));
            }
        }

        public bool AllowNullValueTypes
        {
            get
            {
                return this.allowNullValueTypes;
            }
            set
            {
                this.allowNullValueTypes = value;
            }
        }

        private Dictionary<Type, Dictionary<string, MemberInfo>> MemberMapCache
        {
            get
            {
                if (this.memberMapCache == null)
                {
                    this.memberMapCache = new Dictionary<Type, Dictionary<string, MemberInfo>>();
                }
                return this.memberMapCache;
            }
        }
    }
}

