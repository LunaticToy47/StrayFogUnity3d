namespace JsonFx.Json
{
    using System;

    public class JsonWriterSettings
    {
        private WriteDelegate<DateTime> dateTimeSerializer;
        private int maxDepth = 0x19;
        private string newLine = Environment.NewLine;
        private bool prettyPrint;
        private string tab = "\t";
        private string typeHintName;
        private bool useXmlSerializationAttributes;

        public virtual WriteDelegate<DateTime> DateTimeSerializer
        {
            get
            {
                return this.dateTimeSerializer;
            }
            set
            {
                this.dateTimeSerializer = value;
            }
        }

        public virtual int MaxDepth
        {
            get
            {
                return this.maxDepth;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("MaxDepth must be a positive integer as it controls the maximum nesting level of serialized objects.");
                }
                this.maxDepth = value;
            }
        }

        public virtual string NewLine
        {
            get
            {
                return this.newLine;
            }
            set
            {
                this.newLine = value;
            }
        }

        public virtual bool PrettyPrint
        {
            get
            {
                return this.prettyPrint;
            }
            set
            {
                this.prettyPrint = value;
            }
        }

        public virtual string Tab
        {
            get
            {
                return this.tab;
            }
            set
            {
                this.tab = value;
            }
        }

        public virtual string TypeHintName
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

        public virtual bool UseXmlSerializationAttributes
        {
            get
            {
                return this.useXmlSerializationAttributes;
            }
            set
            {
                this.useXmlSerializationAttributes = value;
            }
        }
    }
}

