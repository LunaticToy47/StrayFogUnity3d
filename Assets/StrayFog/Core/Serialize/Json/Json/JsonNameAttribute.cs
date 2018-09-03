namespace JsonFx.Json
{
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.All, AllowMultiple=false)]
    public class JsonNameAttribute : Attribute
    {
        private string jsonName;

        public JsonNameAttribute()
        {
        }

        public JsonNameAttribute(string jsonName)
        {
            this.jsonName = EcmaScriptIdentifier.EnsureValidIdentifier(jsonName, false);
        }

        public static string GetJsonName(object value)
        {
            if (value == null)
            {
                return null;
            }
            Type enumType = value.GetType();
            MemberInfo element = null;
            if (enumType.IsEnum)
            {
                string name = Enum.GetName(enumType, value);
                if (string.IsNullOrEmpty(name))
                {
                    return null;
                }
                element = enumType.GetField(name);
            }
            else
            {
                element = value as MemberInfo;
            }
            if (element == null)
            {
                throw new ArgumentException();
            }
            if (!Attribute.IsDefined(element, typeof(JsonNameAttribute)))
            {
                return null;
            }
            JsonNameAttribute customAttribute = (JsonNameAttribute) Attribute.GetCustomAttribute(element, typeof(JsonNameAttribute));
            return customAttribute.Name;
        }

        public string Name
        {
            get
            {
                return this.jsonName;
            }
            set
            {
                this.jsonName = EcmaScriptIdentifier.EnsureValidIdentifier(value, false);
            }
        }
    }
}

