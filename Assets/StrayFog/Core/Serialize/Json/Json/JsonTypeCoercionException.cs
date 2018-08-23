namespace JsonFx.Json
{
    using System;
    using System.Runtime.Serialization;

    public class JsonTypeCoercionException : ArgumentException
    {
        public JsonTypeCoercionException()
        {
        }

        public JsonTypeCoercionException(string message) : base(message)
        {
        }

        public JsonTypeCoercionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public JsonTypeCoercionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

