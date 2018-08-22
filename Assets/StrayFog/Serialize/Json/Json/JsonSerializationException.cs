namespace JsonFx.Json
{
    using System;
    using System.Runtime.Serialization;

    public class JsonSerializationException : InvalidOperationException
    {
        public JsonSerializationException()
        {
        }

        public JsonSerializationException(string message) : base(message)
        {
        }

        public JsonSerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public JsonSerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

