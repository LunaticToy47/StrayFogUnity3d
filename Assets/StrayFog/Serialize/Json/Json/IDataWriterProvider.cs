namespace JsonFx.Json
{
    using System;

    public interface IDataWriterProvider
    {
        IDataWriter Find(string extension);
        IDataWriter Find(string acceptHeader, string contentTypeHeader);

        IDataWriter DefaultDataWriter { get; }
    }
}

