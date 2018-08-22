namespace JsonFx.Json
{
    using System;
    using System.IO;

    public interface IDataReader
    {
        object Deserialize(TextReader input, Type data);

        string ContentType { get; }
    }
}

