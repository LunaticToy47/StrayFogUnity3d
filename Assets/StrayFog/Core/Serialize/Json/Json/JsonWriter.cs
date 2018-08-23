namespace JsonFx.Json
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using UnityEngine;

    public class JsonWriter : IDisposable
    {
        private const string AnonymousTypePrefix = "<>f__AnonymousType";
        private int depth;
        private const string ErrorIDictionaryEnumerator = "Types which implement Generic IDictionary<TKey, TValue> must have an IEnumerator which implements IDictionaryEnumerator. ({0})";
        private const string ErrorMaxDepth = "The maxiumum depth of {0} was exceeded. Check for cycles in object graph.";
        public const string JsonFileExtension = ".json";
        public const string JsonMimeType = "application/json";
        private JsonWriterSettings settings;
        private readonly System.IO.TextWriter Writer;

        public JsonWriter(Stream output) : this(output, new JsonWriterSettings())
        {
        }

        public JsonWriter(System.IO.TextWriter output) : this(output, new JsonWriterSettings())
        {
        }

        public JsonWriter(string outputFileName) : this(outputFileName, new JsonWriterSettings())
        {
        }

        public JsonWriter(StringBuilder output) : this(output, new JsonWriterSettings())
        {
        }

        public JsonWriter(Stream output, JsonWriterSettings settings)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this.Writer = new StreamWriter(output, Encoding.UTF8);
            this.settings = settings;
            this.Writer.NewLine = this.settings.NewLine;
        }

        public JsonWriter(System.IO.TextWriter output, JsonWriterSettings settings)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this.Writer = output;
            this.settings = settings;
            this.Writer.NewLine = this.settings.NewLine;
        }

        public JsonWriter(string outputFileName, JsonWriterSettings settings)
        {
            if (outputFileName == null)
            {
                throw new ArgumentNullException("outputFileName");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            Stream stream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write, FileShare.Read);
            this.Writer = new StreamWriter(stream, Encoding.UTF8);
            this.settings = settings;
            this.Writer.NewLine = this.settings.NewLine;
        }

        public JsonWriter(StringBuilder output, JsonWriterSettings settings)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this.Writer = new StringWriter(output, CultureInfo.InvariantCulture);
            this.settings = settings;
            this.Writer.NewLine = this.settings.NewLine;
        }

        private static Enum[] GetFlagList(Type enumType, object value)
        {
            ulong num = Convert.ToUInt64(value);
            Array values = Enum.GetValues(enumType);
            List<Enum> list = new List<Enum>(values.Length);
            if (num == 0)
            {
                list.Add((Enum) Convert.ChangeType(value, enumType));
                return list.ToArray();
            }
            for (int i = values.Length - 1; i >= 0; i--)
            {
                ulong num3 = Convert.ToUInt64(values.GetValue(i));
                if (((i != 0) || (num3 != 0)) && ((num & num3) == num3))
                {
                    num -= num3;
                    list.Add(values.GetValue(i) as Enum);
                }
            }
            if (num != 0)
            {
                list.Add(Enum.ToObject(enumType, num) as Enum);
            }
            return list.ToArray();
        }

        protected virtual bool InvalidIeee754(decimal value)
        {
            try
            {
                return (((decimal) ((double) value)) != value);
            }
            catch
            {
                return true;
            }
        }

        private bool IsDefaultValue(MemberInfo member, object value)
        {
            DefaultValueAttribute customAttribute = Attribute.GetCustomAttribute(member, typeof(DefaultValueAttribute)) as DefaultValueAttribute;
            if (customAttribute == null)
            {
                return false;
            }
            if (customAttribute.Value == null)
            {
                return (value == null);
            }
            return customAttribute.Value.Equals(value);
        }

        private bool IsIgnored(Type objType, MemberInfo member, object obj)
        {
            if (JsonIgnoreAttribute.IsJsonIgnore(member))
            {
                return true;
            }
            string jsonSpecifiedProperty = JsonSpecifiedPropertyAttribute.GetJsonSpecifiedProperty(member);
            if (!string.IsNullOrEmpty(jsonSpecifiedProperty))
            {
                PropertyInfo property = objType.GetProperty(jsonSpecifiedProperty);
                if (property != null)
                {
                    object obj2 = property.GetValue(obj, null);
                    if ((obj2 is bool) && !Convert.ToBoolean(obj2))
                    {
                        return true;
                    }
                }
            }
            if (this.settings.UseXmlSerializationAttributes)
            {
                if (JsonIgnoreAttribute.IsXmlIgnore(member))
                {
                    return true;
                }
                PropertyInfo info2 = objType.GetProperty(member.Name + "Specified");
                if (info2 != null)
                {
                    object obj3 = info2.GetValue(obj, null);
                    if ((obj3 is bool) && !Convert.ToBoolean(obj3))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string Serialize(object value)
        {
            StringBuilder output = new StringBuilder();
            using (JsonWriter writer = new JsonWriter(output))
            {
                writer.Write(value);
            }
            return output.ToString();
        }

        void IDisposable.Dispose()
        {
            if (this.Writer != null)
            {
                this.Writer.Dispose();
            }
        }

        public virtual void Write(bool value)
        {
            this.Writer.Write(!value ? "false" : "true");
        }

        public virtual void Write(byte value)
        {
            this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
        }

        public virtual void Write(char value)
        {
            this.Write(new string(value, 1));
        }

        public virtual void Write(DateTime value)
        {
            if (this.settings.DateTimeSerializer != null)
            {
                this.settings.DateTimeSerializer(this, value);
            }
            else
            {
                DateTimeKind kind = value.Kind;
                if (kind != DateTimeKind.Utc)
                {
                    if (kind != DateTimeKind.Local)
                    {
                        this.Write(string.Format("{0:s}", value));
                        return;
                    }
                    value = value.ToUniversalTime();
                }
                this.Write(string.Format("{0:s}Z", value));
            }
        }

        public virtual void Write(decimal value)
        {
            if (this.InvalidIeee754(value))
            {
                this.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
            else
            {
                this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
        }

        public virtual void Write(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                this.Writer.Write("null");
            }
            else
            {
                this.Writer.Write(value.ToString("r", CultureInfo.InvariantCulture));
            }
        }

        public virtual void Write(Enum value)
        {
            string jsonName = null;
            Type enumType = value.GetType();
            if (enumType.IsDefined(typeof(FlagsAttribute), true) && !Enum.IsDefined(enumType, value))
            {
                Enum[] flagList = GetFlagList(enumType, value);
                string[] strArray = new string[flagList.Length];
                for (int i = 0; i < flagList.Length; i++)
                {
                    strArray[i] = JsonNameAttribute.GetJsonName(flagList[i]);
                    if (string.IsNullOrEmpty(strArray[i]))
                    {
                        strArray[i] = flagList[i].ToString("f");
                    }
                }
                jsonName = string.Join(", ", strArray);
            }
            else
            {
                jsonName = JsonNameAttribute.GetJsonName(value);
                if (string.IsNullOrEmpty(jsonName))
                {
                    jsonName = value.ToString("f");
                }
            }
            this.Write(jsonName);
        }

        public virtual void Write(Guid value)
        {
            this.Write(value.ToString("D"));
        }

        public virtual void Write(short value)
        {
            this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
        }

        public virtual void Write(int value)
        {
            this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
        }

        public virtual void Write(long value)
        {
            if (this.InvalidIeee754(value))
            {
                this.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
            else
            {
                this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
        }

        public void Write(object value)
        {
            this.Write(value, false);
        }

        public virtual void Write(Vector2 value)
        {
            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add("x", value.x);
            dic.Add("y", value.y);
            this.WriteDictionary(dic);
        }

        public virtual void Write(Vector3 value)
        {
            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add("x", value.x);
            dic.Add("y", value.y);
            dic.Add("z", value.z);
            this.WriteDictionary(dic);
        }

        public virtual void Write(Vector4 value)
        {
            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add("x", value.x);
            dic.Add("y", value.y);
            dic.Add("z", value.z);
            dic.Add("w", value.w);
            this.WriteDictionary(dic);
        }


        public virtual void Write(sbyte value)
        {
            this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
        }

        public virtual void Write(float value)
        {
            if (float.IsNaN(value) || float.IsInfinity(value))
            {
                this.Writer.Write("null");
            }
            else
            {
                this.Writer.Write(value.ToString("r", CultureInfo.InvariantCulture));
            }
        }

        public virtual void Write(string value)
        {
            if (value == null)
            {
                this.Writer.Write("null");
            }
            else
            {
                int startIndex = 0;
                int length = value.Length;
                this.Writer.Write('"');
                for (int i = startIndex; i < length; i++)
                {
                    char ch = value[i];
                    if (((ch <= '\x001f') || (ch >= '\x007f')) || (((ch == '<') || (ch == '"')) || (ch == '\\')))
                    {
                        if (i > startIndex)
                        {
                            this.Writer.Write(value.Substring(startIndex, i - startIndex));
                        }
                        startIndex = i + 1;
                        char ch2 = ch;
                        switch (ch2)
                        {
                            case '\b':
                            {
                                this.Writer.Write(@"\b");
                                continue;
                            }
                            case '\t':
                            {
                                this.Writer.Write(@"\t");
                                continue;
                            }
                            case '\n':
                            {
                                this.Writer.Write(@"\n");
                                continue;
                            }
                            case '\f':
                            {
                                this.Writer.Write(@"\f");
                                continue;
                            }
                            case '\r':
                            {
                                this.Writer.Write(@"\r");
                                continue;
                            }
                        }
                        switch (ch2)
                        {
                            case '"':
                            case '\\':
                            {
                                this.Writer.Write('\\');
                                this.Writer.Write(ch);
                                continue;
                            }
                            default:
                            {
                                this.Writer.Write(@"\u");
                                this.Writer.Write(char.ConvertToUtf32(value, i).ToString("X4"));
                                continue;
                            }
                        }
                    }
                }
                if (length > startIndex)
                {
                    this.Writer.Write(value.Substring(startIndex, length - startIndex));
                }
                this.Writer.Write('"');
            }
        }

        public virtual void Write(TimeSpan value)
        {
            this.Write(value.Ticks);
        }

        public virtual void Write(ushort value)
        {
            this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
        }

        public virtual void Write(uint value)
        {
            if (this.InvalidIeee754(value))
            {
                this.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
            else
            {
                this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
        }

        public virtual void Write(ulong value)
        {
            if (this.InvalidIeee754(value))
            {
                this.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
            else
            {
                this.Writer.Write(value.ToString("g", CultureInfo.InvariantCulture));
            }
        }

        public virtual void Write(Uri value)
        {
            this.Write(value.ToString());
        }

        public virtual void Write(Version value)
        {
            this.Write(value.ToString());
        }

        protected virtual void Write(object value, bool isProperty)
        {
            if (isProperty && this.settings.PrettyPrint)
            {
                this.Writer.Write(' ');
            }
            if (value == null)
            {
                this.Writer.Write("null");
            }
            else if (value is IJsonSerializable)
            {
                try
                {
                    if (isProperty)
                    {
                        this.depth++;
                        if (this.depth > this.settings.MaxDepth)
                        {
                            throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
                        }
                        this.WriteLine();
                    }
                    ((IJsonSerializable) value).WriteJson(this);
                }
                finally
                {
                    if (isProperty)
                    {
                        this.depth--;
                    }
                }
            }
            else if (value is Enum)
            {
                this.Write((Enum) value);
            }
            else
            {
                Type type = value.GetType();
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Empty:
                    case TypeCode.DBNull:
                        this.Writer.Write("null");
                        return;

                    case TypeCode.Boolean:
                        this.Write((bool) value);
                        return;

                    case TypeCode.Char:
                        this.Write((char) value);
                        return;

                    case TypeCode.SByte:
                        this.Write((sbyte) value);
                        return;

                    case TypeCode.Byte:
                        this.Write((byte) value);
                        return;

                    case TypeCode.Int16:
                        this.Write((short) value);
                        return;

                    case TypeCode.UInt16:
                        this.Write((ushort) value);
                        return;

                    case TypeCode.Int32:
                        this.Write((int) value);
                        return;

                    case TypeCode.UInt32:
                        this.Write((uint) value);
                        return;

                    case TypeCode.Int64:
                        this.Write((long) value);
                        return;

                    case TypeCode.UInt64:
                        this.Write((ulong) value);
                        return;

                    case TypeCode.Single:
                        this.Write((float) value);
                        return;

                    case TypeCode.Double:
                        this.Write((double) value);
                        return;

                    case TypeCode.Decimal:
                        this.Write((decimal) value);
                        return;

                    case TypeCode.DateTime:
                        this.Write((DateTime) value);
                        return;

                    case TypeCode.String:
                        this.Write((string) value);
                        return;
                }
                if (value is Guid)
                {
                    this.Write((Guid) value);
                }
                else if (value is Uri)
                {
                    this.Write((Uri) value);
                }
                else if (value is TimeSpan)
                {
                    this.Write((TimeSpan) value);
                }
                else if (value is Version)
                {
                    this.Write((Version) value);
                }
                #region 这里是映射JsonReader(432行)所设定的特殊类型
                else if (value is Vector2)
                {
                    this.Write((Vector2)value);
                }
                else if (value is Vector3)
                {
                    this.Write((Vector3)value);
                }
                else if (value is Vector4)
                {
                    this.Write((Vector4)value);
                }
                #endregion
                else if (value is IDictionary)
                {
                    try
                    {
                        if (isProperty)
                        {
                            this.depth++;
                            if (this.depth > this.settings.MaxDepth)
                            {
                                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
                            }
                            this.WriteLine();
                        }
                        this.WriteObject((IDictionary)value);
                    }
                    finally
                    {
                        if (isProperty)
                        {
                            this.depth--;
                        }
                    }
                }
                else if (type.GetInterface("System.Collections.Generic.IDictionary`2") != null)
                {
                    try
                    {
                        if (isProperty)
                        {
                            this.depth++;
                            if (this.depth > this.settings.MaxDepth)
                            {
                                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
                            }
                            this.WriteLine();
                        }
                        this.WriteDictionary((IEnumerable)value);
                    }
                    finally
                    {
                        if (isProperty)
                        {
                            this.depth--;
                        }
                    }
                }
                else if (value is IEnumerable)
                {
                    try
                    {
                        if (isProperty)
                        {
                            this.depth++;
                            if (this.depth > this.settings.MaxDepth)
                            {
                                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
                            }
                            this.WriteLine();
                        }
                        this.WriteArray((IEnumerable)value);
                    }
                    finally
                    {
                        if (isProperty)
                        {
                            this.depth--;
                        }
                    }
                }
                else
                {
                    try
                    {
                        if (isProperty)
                        {
                            this.depth++;
                            if (this.depth > this.settings.MaxDepth)
                            {
                                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
                            }
                            this.WriteLine();
                        }
                        this.WriteObject(value, type);
                    }
                    finally
                    {
                        if (isProperty)
                        {
                            this.depth--;
                        }
                    }
                }
            }
        }

        protected internal virtual void WriteArray(IEnumerable value)
        {
            bool flag = false;
            this.Writer.Write('[');
            this.depth++;
            if (this.depth > this.settings.MaxDepth)
            {
                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
            }
            try
            {
                IEnumerator enumerator = value.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        object current = enumerator.Current;
                        if (flag)
                        {
                            this.WriteArrayItemDelim();
                        }
                        else
                        {
                            flag = true;
                        }
                        this.WriteLine();
                        this.WriteArrayItem(current);
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
            }
            finally
            {
                this.depth--;
            }
            if (flag)
            {
                this.WriteLine();
            }
            this.Writer.Write(']');
        }

        protected virtual void WriteArrayItem(object item)
        {
            this.Write(item, false);
        }

        protected virtual void WriteArrayItemDelim()
        {
            this.Writer.Write(',');
        }

        public virtual void WriteBase64(byte[] value)
        {
            this.Write(Convert.ToBase64String(value));
        }

        protected virtual void WriteDictionary(IEnumerable value)
        {
            IDictionaryEnumerator enumerator = value.GetEnumerator() as IDictionaryEnumerator;
            if (enumerator == null)
            {
                throw new JsonSerializationException(string.Format("Types which implement Generic IDictionary<TKey, TValue> must have an IEnumerator which implements IDictionaryEnumerator. ({0})", value.GetType()));
            }
            bool flag = false;
            this.Writer.Write('{');
            this.depth++;
            if (this.depth > this.settings.MaxDepth)
            {
                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
            }
            try
            {
                while (enumerator.MoveNext())
                {
                    if (flag)
                    {
                        this.WriteObjectPropertyDelim();
                    }
                    else
                    {
                        flag = true;
                    }
                    this.WriteObjectProperty(Convert.ToString(enumerator.Entry.Key), enumerator.Entry.Value);
                }
            }
            finally
            {
                this.depth--;
            }
            if (flag)
            {
                this.WriteLine();
            }
            this.Writer.Write('}');
        }

        public virtual void WriteHexString(byte[] value)
        {
            if ((value == null) || (value.Length == 0))
            {
                this.Write(string.Empty);
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < value.Length; i++)
                {
                    builder.Append(value[i].ToString("x2"));
                }
                this.Write(builder.ToString());
            }
        }

        protected virtual void WriteLine()
        {
            if (this.settings.PrettyPrint)
            {
                this.Writer.WriteLine();
                for (int i = 0; i < this.depth; i++)
                {
                    this.Writer.Write(this.settings.Tab);
                }
            }
        }

        protected virtual void WriteObject(IDictionary value)
        {
            this.WriteDictionary(value);
        }

        protected virtual void WriteObject(object value, Type type)
        {
            bool flag = false;
            this.Writer.Write('{');
            this.depth++;
            if (this.depth > this.settings.MaxDepth)
            {
                throw new JsonSerializationException(string.Format("The maxiumum depth of {0} was exceeded. Check for cycles in object graph.", this.settings.MaxDepth));
            }
            try
            {
                if (!string.IsNullOrEmpty(this.settings.TypeHintName))
                {
                    if (flag)
                    {
                        this.WriteObjectPropertyDelim();
                    }
                    else
                    {
                        flag = true;
                    }
                    this.WriteObjectProperty(this.settings.TypeHintName, type.FullName + ", " + type.Assembly.GetName().Name);
                }
                bool flag2 = type.IsGenericType && type.Name.StartsWith("<>f__AnonymousType");
                foreach (PropertyInfo info in type.GetProperties())
                {
                    if ((info.CanRead && (info.CanWrite || flag2)) && !this.IsIgnored(type, info, value))
                    {
                        object obj2 = info.GetValue(value, null);
                        if (!this.IsDefaultValue(info, obj2))
                        {
                            if (flag)
                            {
                                this.WriteObjectPropertyDelim();
                            }
                            else
                            {
                                flag = true;
                            }
                            string jsonName = JsonNameAttribute.GetJsonName(info);
                            if (string.IsNullOrEmpty(jsonName))
                            {
                                jsonName = info.Name;
                            }
                            this.WriteObjectProperty(jsonName, obj2);
                        }
                    }
                }
                foreach (FieldInfo info2 in type.GetFields())
                {
                    if ((info2.IsPublic && !info2.IsStatic) && !this.IsIgnored(type, info2, value))
                    {
                        object obj3 = info2.GetValue(value);
                        if (!this.IsDefaultValue(info2, obj3))
                        {
                            if (flag)
                            {
                                this.WriteObjectPropertyDelim();
                                this.WriteLine();
                            }
                            else
                            {
                                flag = true;
                            }
                            string name = JsonNameAttribute.GetJsonName(info2);
                            if (string.IsNullOrEmpty(name))
                            {
                                name = info2.Name;
                            }
                            this.WriteObjectProperty(name, obj3);
                        }
                    }
                }
            }
            finally
            {
                this.depth--;
            }
            if (flag)
            {
                this.WriteLine();
            }
            this.Writer.Write('}');
        }

        private void WriteObjectProperty(string key, object value)
        {
            this.WriteLine();
            this.WriteObjectPropertyName(key);
            this.Writer.Write(':');
            this.WriteObjectPropertyValue(value);
        }

        protected virtual void WriteObjectPropertyDelim()
        {
            this.Writer.Write(',');
        }

        protected virtual void WriteObjectPropertyName(string name)
        {
            this.Write(name);
        }

        protected virtual void WriteObjectPropertyValue(object value)
        {
            this.Write(value, true);
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public WriteDelegate<DateTime> DateTimeSerializer
        {
            get
            {
                return this.settings.DateTimeSerializer;
            }
            set
            {
                this.settings.DateTimeSerializer = value;
            }
        }

        protected int Depth
        {
            get
            {
                return this.depth;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public int MaxDepth
        {
            get
            {
                return this.settings.MaxDepth;
            }
            set
            {
                this.settings.MaxDepth = value;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public string NewLine
        {
            get
            {
                return this.settings.NewLine;
            }
            set
            {
                string str = value;
                this.settings.NewLine = str;
                this.Writer.NewLine = str;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public bool PrettyPrint
        {
            get
            {
                return this.settings.PrettyPrint;
            }
            set
            {
                this.settings.PrettyPrint = value;
            }
        }

        public JsonWriterSettings Settings
        {
            get
            {
                return this.settings;
            }
            set
            {
                if (value == null)
                {
                    value = new JsonWriterSettings();
                }
                this.settings = value;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public string Tab
        {
            get
            {
                return this.settings.Tab;
            }
            set
            {
                this.settings.Tab = value;
            }
        }

        public System.IO.TextWriter TextWriter
        {
            get
            {
                return this.Writer;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public string TypeHintName
        {
            get
            {
                return this.settings.TypeHintName;
            }
            set
            {
                this.settings.TypeHintName = value;
            }
        }

        [Obsolete("This has been deprecated in favor of JsonWriterSettings object")]
        public bool UseXmlSerializationAttributes
        {
            get
            {
                return this.settings.UseXmlSerializationAttributes;
            }
            set
            {
                this.settings.UseXmlSerializationAttributes = value;
            }
        }
    }
}

