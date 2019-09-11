namespace JsonFx.Json
{
    using System;

    public interface IDataReaderProvider
    {
        IDataReader Find(string contentTypeHeader);
    }
}

