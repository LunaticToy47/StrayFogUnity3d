namespace JsonFx.Json
{
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.All, AllowMultiple=false)]
    public sealed class JsonIgnoreAttribute : Attribute
    {
        public static bool IsJsonIgnore(object value)
        {
            if (value == null)
            {
                return false;
            }
            Type enumType = value.GetType();
            ICustomAttributeProvider field = null;
            if (enumType.IsEnum)
            {
                field = enumType.GetField(Enum.GetName(enumType, value));
            }
            else
            {
                field = value as ICustomAttributeProvider;
            }
            if (field == null)
            {
                throw new ArgumentException();
            }
            return field.IsDefined(typeof(JsonIgnoreAttribute), true);
        }

        public static bool IsXmlIgnore(object value)
        {
            if (value != null)
            {
                Type enumType = value.GetType();
                ICustomAttributeProvider field = null;
                if (enumType.IsEnum)
                {
                    field = enumType.GetField(Enum.GetName(enumType, value));
                }
                else
                {
                    field = value as ICustomAttributeProvider;
                }
                if (field == null)
                {
                    throw new ArgumentException();
                }
            }
            return false;
        }
    }
}

