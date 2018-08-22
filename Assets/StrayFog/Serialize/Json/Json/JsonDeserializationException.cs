namespace JsonFx.Json
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;

    public class JsonDeserializationException : JsonSerializationException
    {
        private int index;

        public JsonDeserializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.index = -1;
        }

        public JsonDeserializationException(string message, int index) : base(message)
        {
            this.index = -1;
            this.index = index;
        }

        public JsonDeserializationException(string message, Exception innerException, int index) : base(message, innerException)
        {
            this.index = -1;
            this.index = index;
        }

        public void GetLineAndColumn(string source, out int line, out int col)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            col = 1;
            line = 1;
            bool flag = false;
            for (int i = Math.Min(this.index, source.Length); i > 0; i--)
            {
                if (!flag)
                {
                    col++;
                }
                if (source[i - 1] == '\n')
                {
                    line++;
                    flag = true;
                }
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
        }
    }
}

