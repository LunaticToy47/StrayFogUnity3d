namespace JsonFx.Json
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using UnityEngine;
    public class JsonReader
    {
        private const string CommentEnd = "*/";
        private const string CommentLine = "//";
        private const string CommentStart = "/*";
        private const string ErrorExpectedArray = "Expected JSON array.";
        private const string ErrorExpectedObject = "Expected JSON object.";
        private const string ErrorExpectedPropertyName = "Expected JSON object property name.";
        private const string ErrorExpectedPropertyNameDelim = "Expected JSON object property name delimiter.";
        private const string ErrorExpectedString = "Expected JSON string.";
        private const string ErrorGenericIDictionary = "Types which implement Generic IDictionary<TKey, TValue> also need to implement IDictionary to be deserialized. ({0})";
        private const string ErrorGenericIDictionaryKeys = "Types which implement Generic IDictionary<TKey, TValue> need to have string keys to be deserialized. ({0})";
        private const string ErrorIllegalNumber = "Illegal JSON number.";
        private const string ErrorUnrecognizedToken = "Illegal JSON sequence.";
        private const string ErrorUnterminatedArray = "Unterminated JSON array.";
        private const string ErrorUnterminatedComment = "Unterminated comment block.";
        private const string ErrorUnterminatedObject = "Unterminated JSON object.";
        private const string ErrorUnterminatedString = "Unterminated JSON string.";
        private int index;
        private const string LineEndings = "\r\n";
        internal const string LiteralFalse = "false";
        internal const string LiteralNegativeInfinity = "-Infinity";
        internal const string LiteralNotANumber = "NaN";
        internal const string LiteralNull = "null";
        internal const string LiteralPositiveInfinity = "Infinity";
        internal const string LiteralTrue = "true";
        internal const string LiteralUndefined = "undefined";
        internal const char OperatorArrayEnd = ']';
        internal const char OperatorArrayStart = '[';
        internal const char OperatorCharEscape = '\\';
        internal const char OperatorNameDelim = ':';
        internal const char OperatorNegate = '-';
        internal const char OperatorObjectEnd = '}';
        internal const char OperatorObjectStart = '{';
        internal const char OperatorStringDelim = '"';
        internal const char OperatorStringDelimAlt = '\'';
        internal const char OperatorUnaryPlus = '+';
        internal const char OperatorValueDelim = ',';
        private readonly JsonReaderSettings Settings;
        private readonly string Source;
        private readonly int SourceLength;
        internal const string TypeGenericIDictionary = "System.Collections.Generic.IDictionary`2";

        public JsonReader(Stream input) : this(input, new JsonReaderSettings())
        {
        }

        public JsonReader(TextReader input) : this(input, new JsonReaderSettings())
        {
        }

        public JsonReader(string input) : this(input, new JsonReaderSettings())
        {
        }

        public JsonReader(StringBuilder input) : this(input, new JsonReaderSettings())
        {
        }

        public JsonReader(Stream input, JsonReaderSettings settings)
        {
            this.Settings = new JsonReaderSettings();
            this.Settings = settings;
            using (StreamReader reader = new StreamReader(input, true))
            {
                this.Source = reader.ReadToEnd();
            }
            this.SourceLength = this.Source.Length;
        }

        public JsonReader(TextReader input, JsonReaderSettings settings)
        {
            this.Settings = new JsonReaderSettings();
            this.Settings = settings;
            this.Source = input.ReadToEnd();
            this.SourceLength = this.Source.Length;
        }

        public JsonReader(string input, JsonReaderSettings settings)
        {
            this.Settings = new JsonReaderSettings();
            this.Settings = settings;
            this.Source = input;
            this.SourceLength = this.Source.Length;
        }

        public JsonReader(StringBuilder input, JsonReaderSettings settings)
        {
            this.Settings = new JsonReaderSettings();
            this.Settings = settings;
            this.Source = input.ToString();
            this.SourceLength = this.Source.Length;
        }

        public static T CoerceType<T>(object value)
        {
            return (T) new TypeCoercionUtility().CoerceType(typeof(T), value);
        }

        public static T CoerceType<T>(object value, T typeToMatch)
        {
            return (T) new TypeCoercionUtility().CoerceType(typeof(T), value);
        }

        public static object CoerceType(Type targetType, object value)
        {
            return new TypeCoercionUtility().CoerceType(targetType, value);
        }

        public T Deserialize<T>()
        {
            return (T) this.Read(typeof(T), false);
        }

        public object Deserialize()
        {
            return this.Deserialize((Type) null);
        }

        public T Deserialize<T>(int start)
        {
            this.index = start;
            return (T) this.Read(typeof(T), false);
        }

        public object Deserialize(int start)
        {
            this.index = start;
            return this.Deserialize((Type) null);
        }

        public static T Deserialize<T>(string value)
        {            
            return (T) Deserialize(value, 0, typeof(T));
        }

        public static object Deserialize(string value)
        {
            return Deserialize(value, 0, null);
        }

        public object Deserialize(Type type)
        {
            return this.Read(type, false);
        }

        public object Deserialize(int start, Type type)
        {
            this.index = start;
            return this.Read(type, false);
        }

        public static T Deserialize<T>(string value, int start)
        {
            return (T) Deserialize(value, start, typeof(T));
        }

        public static object Deserialize(string value, int start)
        {
            return Deserialize(value, start, null);
        }

        public static object Deserialize(string value, Type type)
        {
            return Deserialize(value, 0, type);
        }

        public static object Deserialize(string value, int start, Type type)
        {
            return new JsonReader(value).Deserialize(start, type);
        }

        private bool MatchLiteral(string literal)
        {
            int length = literal.Length;
            int num2 = 0;
            for (int i = this.index; (num2 < length) && (i < this.SourceLength); i++)
            {
                if (literal[num2] != this.Source[i])
                {
                    return false;
                }
                num2++;
            }
            return true;
        }

        private object Read(Type expectedType, bool typeIsHint)
        {
            if (expectedType == typeof(object))
            {
                expectedType = null;
            }
            switch (this.Tokenize())
            {
                case JsonToken.Undefined:
                    this.index += "undefined".Length;
                    return null;

                case JsonToken.Null:
                    this.index += "null".Length;
                    return null;

                case JsonToken.False:
                    this.index += "false".Length;
                    return false;

                case JsonToken.True:
                    this.index += "true".Length;
                    return true;

                case JsonToken.NaN:
                    this.index += "NaN".Length;
                    return (double) 1.0 / (double) 0.0;

                case JsonToken.PositiveInfinity:
                    this.index += "Infinity".Length;
                    return (double) 1.0 / (double) 0.0;

                case JsonToken.NegativeInfinity:
                    this.index += "-Infinity".Length;
                    return (double) -1.0 / (double) 0.0;

                case JsonToken.Number:
                    return this.ReadNumber(!typeIsHint ? expectedType : null);

                case JsonToken.String:
                    return this.ReadString(!typeIsHint ? expectedType : null);

                case JsonToken.ArrayStart:
                    return this.ReadArray(!typeIsHint ? expectedType : null);

                case JsonToken.ObjectStart:
                    return this.ReadObject(!typeIsHint ? expectedType : null);
            }
            return null;
        }

        private IEnumerable ReadArray(Type arrayType)
        {
            JsonToken token;
            if (this.Source[this.index] != '[')
            {
                throw new JsonDeserializationException("Expected JSON array.", this.index);
            }
            bool flag = arrayType != null;
            bool typeIsHint = !flag;
            Type expectedType = null;
            if (flag)
            {
                if (arrayType.HasElementType)
                {
                    expectedType = arrayType.GetElementType();
                }
                else if (arrayType.IsGenericType)
                {
                    Type[] genericArguments = arrayType.GetGenericArguments();
                    if (genericArguments.Length == 1)
                    {
                        expectedType = genericArguments[0];
                    }
                }
            }
            ArrayList list = new ArrayList();
            do
            {
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Unterminated JSON array.", this.index);
                }
                token = this.Tokenize();
                if (token == JsonToken.ArrayEnd)
                {
                    break;
                }
                object obj2 = this.Read(expectedType, typeIsHint);                
                list.Add(obj2);
                if (obj2 == null)
                {
                    if ((expectedType != null) && expectedType.IsValueType)
                    {
                        expectedType = null;
                    }
                    flag = true;
                }
                else if ((expectedType != null) && !expectedType.IsAssignableFrom(obj2.GetType()))
                {
                    if (obj2.GetType().IsAssignableFrom(expectedType))
                    {
                        expectedType = obj2.GetType();
                    }
                    else
                    {
                        expectedType = null;
                        flag = true;
                    }
                }
                else if (!flag)
                {
                    expectedType = obj2.GetType();
                    flag = true;
                }
                token = this.Tokenize();
            }
            while (token == JsonToken.ValueDelim);
            if (token != JsonToken.ArrayEnd)
            {
                throw new JsonDeserializationException("Unterminated JSON array.", this.index);
            }
            this.index++;
            if ((expectedType != null) && (expectedType != typeof(object)))
            {
                return list.ToArray(expectedType);                
            }
            return list.ToArray();
        }

        private object ReadNumber(Type expectedType)
        {
            bool flag = false;
            bool flag2 = false;
            int index = this.index;
            int num2 = 0;
            int result = 0;
            if (this.Source[this.index] == '-')
            {
                this.index++;
                if ((this.index >= this.SourceLength) || !char.IsDigit(this.Source[this.index]))
                {
                    throw new JsonDeserializationException("Illegal JSON number.", this.index);
                }
            }
            while ((this.index < this.SourceLength) && char.IsDigit(this.Source[this.index]))
            {
                this.index++;
            }
            if ((this.index < this.SourceLength) && (this.Source[this.index] == '.'))
            {
                flag = true;
                this.index++;
                if ((this.index >= this.SourceLength) || !char.IsDigit(this.Source[this.index]))
                {
                    throw new JsonDeserializationException("Illegal JSON number.", this.index);
                }
                while ((this.index < this.SourceLength) && char.IsDigit(this.Source[this.index]))
                {
                    this.index++;
                }
            }
            num2 = (this.index - index) - (!flag ? 0 : 1);
            if ((this.index < this.SourceLength) && ((this.Source[this.index] == 'e') || (this.Source[this.index] == 'E')))
            {
                flag2 = true;
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Illegal JSON number.", this.index);
                }
                int startIndex = this.index;
                if ((this.Source[this.index] == '-') || (this.Source[this.index] == '+'))
                {
                    this.index++;
                    if ((this.index >= this.SourceLength) || !char.IsDigit(this.Source[this.index]))
                    {
                        throw new JsonDeserializationException("Illegal JSON number.", this.index);
                    }
                }
                else if (!char.IsDigit(this.Source[this.index]))
                {
                    throw new JsonDeserializationException("Illegal JSON number.", this.index);
                }
                while ((this.index < this.SourceLength) && char.IsDigit(this.Source[this.index]))
                {
                    this.index++;
                }
                int.TryParse(this.Source.Substring(startIndex, this.index - startIndex), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out result);
            }
            string s = this.Source.Substring(index, this.index - index);
            if ((!flag && !flag2) && (num2 < 0x13))
            {
                decimal num5 = decimal.Parse(s, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
                if (expectedType != null)
                {
                    return this.Settings.Coercion.CoerceType(expectedType, num5);
                }
                if ((num5 >= -2147483648M) && (num5 <= 2147483647M))
                {
                    return (int) num5;
                }
                if ((num5 >= -9223372036854775808M) && (num5 <= 9223372036854775807M))
                {
                    return (long) num5;
                }
                return num5;
            }
            if (expectedType == typeof(decimal))
            {
                return decimal.Parse(s, NumberStyles.Float, NumberFormatInfo.InvariantInfo);
            }
            double num6 = double.Parse(s, NumberStyles.Float, (IFormatProvider) NumberFormatInfo.InvariantInfo);
            if (expectedType != null)
            {
                return this.Settings.Coercion.CoerceType(expectedType, num6);
            }
            return num6;
        }

        private object ReadObject(Type objectType)
        {
            object obj2;
            JsonToken token;
            if (this.Source[this.index] != '{')
            {
                throw new JsonDeserializationException("Expected JSON object.", this.index);
            }
            Type type = null;
            Dictionary<string, MemberInfo> memberMap = null;
            if (objectType != null)
            {
                #region 这里是映射JsonWriter(619行)所设定的特殊类型
                if (objectType == typeof(Vector2))
                {
                    obj2 = new Vector2();
                    memberMap = this.Settings.Coercion.CreateFieldMemberMap(objectType);
                }
                else if (objectType == typeof(Vector3))
                {
                    obj2 = new Vector3();
                    memberMap = this.Settings.Coercion.CreateFieldMemberMap(objectType);
                }
                else if (objectType == typeof(Vector4))
                {
                    obj2 = new Vector4();
                    memberMap = this.Settings.Coercion.CreateFieldMemberMap(objectType);
                }
                #endregion
                else
                { 
                    obj2 = this.Settings.Coercion.InstantiateObject(objectType, out memberMap);
                }
                
                if (memberMap == null)
                {
                    Type type2 = objectType.GetInterface("System.Collections.Generic.IDictionary`2");
                    if (type2 != null)
                    {
                        Type[] genericArguments = type2.GetGenericArguments();
                        if (genericArguments.Length == 2)
                        {
                            if (genericArguments[0] != typeof(string))
                            {
                                throw new JsonDeserializationException(string.Format("Types which implement Generic IDictionary<TKey, TValue> need to have string keys to be deserialized. ({0})", objectType), this.index);
                            }
                            if (genericArguments[1] != typeof(object))
                            {
                                type = genericArguments[1];
                            }
                        }
                    }
                }
            }
            else
            {
                obj2 = new Dictionary<string, object>();
            }
            do
            {
                Type type3;
                MemberInfo info;
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Unterminated JSON object.", this.index);
                }
                token = this.Tokenize(this.Settings.AllowUnquotedObjectKeys);
                if (token == JsonToken.ObjectEnd)
                {
                    break;
                }
                if ((token != JsonToken.String) && (token != JsonToken.UnquotedName))
                {
                    throw new JsonDeserializationException("Expected JSON object property name.", this.index);
                }
                string memberName = (token != JsonToken.String) ? this.ReadUnquotedKey() : ((string) this.ReadString(null));
                if ((type == null) && (memberMap != null))
                {
                    type3 = TypeCoercionUtility.GetMemberInfo(memberMap, memberName, out info);
                }
                else
                {
                    type3 = type;
                    info = null;
                }
                if (this.Tokenize() != JsonToken.NameDelim)
                {
                    throw new JsonDeserializationException("Expected JSON object property name delimiter.", this.index);
                }
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Unterminated JSON object.", this.index);
                }
                object obj3 = this.Read(type3, false);
                if (obj2 is IDictionary)
                {
                    if ((objectType == null) && this.Settings.IsTypeHintName(memberName))
                    {
                        obj2 = this.Settings.Coercion.ProcessTypeHint((IDictionary) obj2, obj3 as string, out objectType, out memberMap);
                    }
                    else
                    {
                        ((IDictionary) obj2)[memberName] = obj3;
                    }
                }
                else
                {
                    if (objectType.GetInterface("System.Collections.Generic.IDictionary`2") != null)
                    {
                        throw new JsonDeserializationException(string.Format("Types which implement Generic IDictionary<TKey, TValue> also need to implement IDictionary to be deserialized. ({0})", objectType), this.index);
                    }
                    this.Settings.Coercion.SetMemberValue(obj2, type3, info, obj3);
                }
                token = this.Tokenize();
            }
            while (token == JsonToken.ValueDelim);
            if (token != JsonToken.ObjectEnd)
            {
                throw new JsonDeserializationException("Unterminated JSON object.", this.index);
            }
            this.index++;
            return obj2;
        }

        private object ReadString(Type expectedType)
        {
            if ((this.Source[this.index] != '"') && (this.Source[this.index] != '\''))
            {
                throw new JsonDeserializationException("Expected JSON string.", this.index);
            }
            char ch = this.Source[this.index];
            this.index++;
            if (this.index >= this.SourceLength)
            {
                throw new JsonDeserializationException("Unterminated JSON string.", this.index);
            }
            int index = this.index;
            StringBuilder builder = new StringBuilder();
            while (this.Source[this.index] != ch)
            {
                if (this.Source[this.index] != '\\')
                {
                    goto Label_026D;
                }
                builder.Append(this.Source, index, this.index - index);
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Unterminated JSON string.", this.index);
                }
                char ch2 = this.Source[this.index];
                switch (ch2)
                {
                    case 'n':
                        builder.Append('\n');
                        goto Label_0231;

                    case 'r':
                        builder.Append('\r');
                        goto Label_0231;

                    case 't':
                        builder.Append('\t');
                        goto Label_0231;

                    case 'u':
                        int num2;
                        if (((this.index + 4) >= this.SourceLength) || !int.TryParse(this.Source.Substring(this.index + 1, 4), NumberStyles.AllowHexSpecifier, NumberFormatInfo.InvariantInfo, out num2))
                        {
                            goto Label_01F7;
                        }
                        builder.Append(char.ConvertFromUtf32(num2));
                        this.index += 4;
                        goto Label_0231;

                    default:
                        if (ch2 != '0')
                        {
                            if (ch2 != 'b')
                            {
                                if (ch2 == 'f')
                                {
                                    break;
                                }
                                goto Label_0214;
                            }
                            builder.Append('\b');
                        }
                        goto Label_0231;
                }
                builder.Append('\f');
                goto Label_0231;
            Label_01F7:
                builder.Append(this.Source[this.index]);
                goto Label_0231;
            Label_0214:
                builder.Append(this.Source[this.index]);
            Label_0231:
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Unterminated JSON string.", this.index);
                }
                index = this.index;
                continue;
            Label_026D:
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Unterminated JSON string.", this.index);
                }
            }
            builder.Append(this.Source, index, this.index - index);
            this.index++;
            if ((expectedType != null) && (expectedType != typeof(string)))
            {
                return this.Settings.Coercion.CoerceType(expectedType, builder.ToString());
            }
            return builder.ToString();
        }

        private string ReadUnquotedKey()
        {
            int index = this.index;
            do
            {
                this.index++;
            }
            while (this.Tokenize(true) == JsonToken.UnquotedName);
            return this.Source.Substring(index, this.index - index);
        }

        private JsonToken Tokenize()
        {
            return this.Tokenize(false);
        }

        private JsonToken Tokenize(bool allowUnquotedString)
        {
            if (this.index >= this.SourceLength)
            {
                return JsonToken.End;
            }
            while (char.IsWhiteSpace(this.Source[this.index]))
            {
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    return JsonToken.End;
                }
            }
            if (this.Source[this.index] == "/*"[0])
            {
                if ((this.index + 1) >= this.SourceLength)
                {
                    throw new JsonDeserializationException("Illegal JSON sequence.", this.index);
                }
                this.index++;
                bool flag = false;
                if (this.Source[this.index] == "/*"[1])
                {
                    flag = true;
                }
                else if (this.Source[this.index] != "//"[1])
                {
                    throw new JsonDeserializationException("Illegal JSON sequence.", this.index);
                }
                this.index++;
                if (flag)
                {
                    int index = this.index - 2;
                    if ((this.index + 1) >= this.SourceLength)
                    {
                        throw new JsonDeserializationException("Unterminated comment block.", index);
                    }
                    while ((this.Source[this.index] != "*/"[0]) || (this.Source[this.index + 1] != "*/"[1]))
                    {
                        this.index++;
                        if ((this.index + 1) >= this.SourceLength)
                        {
                            throw new JsonDeserializationException("Unterminated comment block.", index);
                        }
                    }
                    this.index += 2;
                    if (this.index >= this.SourceLength)
                    {
                        return JsonToken.End;
                    }
                }
                else
                {
                    while ("\r\n".IndexOf(this.Source[this.index]) < 0)
                    {
                        this.index++;
                        if (this.index >= this.SourceLength)
                        {
                            return JsonToken.End;
                        }
                    }
                }
                while (char.IsWhiteSpace(this.Source[this.index]))
                {
                    this.index++;
                    if (this.index >= this.SourceLength)
                    {
                        return JsonToken.End;
                    }
                }
            }
            if (this.Source[this.index] == '+')
            {
                this.index++;
                if (this.index >= this.SourceLength)
                {
                    return JsonToken.End;
                }
            }
            switch (this.Source[this.index])
            {
                case '[':
                    return JsonToken.ArrayStart;

                case ']':
                    return JsonToken.ArrayEnd;

                case '{':
                    return JsonToken.ObjectStart;

                case '}':
                    return JsonToken.ObjectEnd;

                case '"':
                case '\'':
                    return JsonToken.String;

                case ',':
                    return JsonToken.ValueDelim;

                case ':':
                    return JsonToken.NameDelim;
            }
            if (char.IsDigit(this.Source[this.index]) || (((this.Source[this.index] == '-') && ((this.index + 1) < this.SourceLength)) && char.IsDigit(this.Source[this.index + 1])))
            {
                return JsonToken.Number;
            }
            if (this.MatchLiteral("false"))
            {
                return JsonToken.False;
            }
            if (this.MatchLiteral("true"))
            {
                return JsonToken.True;
            }
            if (this.MatchLiteral("null"))
            {
                return JsonToken.Null;
            }
            if (this.MatchLiteral("NaN"))
            {
                return JsonToken.NaN;
            }
            if (this.MatchLiteral("Infinity"))
            {
                return JsonToken.PositiveInfinity;
            }
            if (this.MatchLiteral("-Infinity"))
            {
                return JsonToken.NegativeInfinity;
            }
            if (this.MatchLiteral("undefined"))
            {
                return JsonToken.Undefined;
            }
            if (!allowUnquotedString)
            {
                throw new JsonDeserializationException("Illegal JSON sequence.", this.index);
            }
            return JsonToken.UnquotedName;
        }

        [Obsolete("This has been deprecated in favor of JsonReaderSettings object")]
        public bool AllowNullValueTypes
        {
            get
            {
                return this.Settings.AllowNullValueTypes;
            }
            set
            {
                this.Settings.AllowNullValueTypes = value;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonReaderSettings object")]
        public string TypeHintName
        {
            get
            {
                return this.Settings.TypeHintName;
            }
            set
            {
                this.Settings.TypeHintName = value;
            }
        }
    }
}

