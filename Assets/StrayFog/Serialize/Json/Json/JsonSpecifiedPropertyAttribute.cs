namespace JsonFx.Json
{
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple=false)]
    public class JsonSpecifiedPropertyAttribute : Attribute
    {
        private string specifiedProperty;

        public JsonSpecifiedPropertyAttribute(string propertyName)
        {
            this.specifiedProperty = propertyName;
        }

        public static string GetJsonSpecifiedProperty(MemberInfo memberInfo)
        {
            if ((memberInfo == null) || !Attribute.IsDefined(memberInfo, typeof(JsonSpecifiedPropertyAttribute)))
            {
                return null;
            }
            JsonSpecifiedPropertyAttribute customAttribute = (JsonSpecifiedPropertyAttribute) Attribute.GetCustomAttribute(memberInfo, typeof(JsonSpecifiedPropertyAttribute));
            return customAttribute.SpecifiedProperty;
        }

        public string SpecifiedProperty
        {
            get
            {
                return this.specifiedProperty;
            }
            set
            {
                this.specifiedProperty = value;
            }
        }
    }
}

