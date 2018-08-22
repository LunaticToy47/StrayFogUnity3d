namespace JsonFx.Json
{
    using System;
    using System.IO;
    using System.Text;

    public interface IDataWriter
    {
        void Serialize(TextWriter output, object data);

        Encoding ContentEncoding { get; }

        string ContentType { get; }

        string FileExtension { get; }
    }
}

