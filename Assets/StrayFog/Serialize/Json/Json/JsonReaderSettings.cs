namespace JsonFx.Json
{
    using System;

    public class JsonReaderSettings
    {
        private bool allowUnquotedObjectKeys;
        internal readonly TypeCoercionUtility Coercion = new TypeCoercionUtility();
        private string typeHintName;

        internal bool IsTypeHintName(string name)
        {
            return ((!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(this.typeHintName)) && StringComparer.Ordinal.Equals(this.typeHintName, name));
        }

        public bool AllowNullValueTypes
        {
            get
            {
                return this.Coercion.AllowNullValueTypes;
            }
            set
            {
                this.Coercion.AllowNullValueTypes = value;
            }
        }

        public bool AllowUnquotedObjectKeys
        {
            get
            {
                return this.allowUnquotedObjectKeys;
            }
            set
            {
                this.allowUnquotedObjectKeys = value;
            }
        }

        public string TypeHintName
        {
            get
            {
                return this.typeHintName;
            }
            set
            {
                this.typeHintName = value;
            }
        }
    }
}

