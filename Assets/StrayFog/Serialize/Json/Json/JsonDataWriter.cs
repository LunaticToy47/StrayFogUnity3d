namespace JsonFx.Json
{
    using System;
    using System.IO;
    using System.Text;

    public class JsonDataWriter : IDataWriter
    {
        public const string JsonFileExtension = ".json";
        public const string JsonMimeType = "application/json";
        private readonly JsonWriterSettings Settings;

        public JsonDataWriter(JsonWriterSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            this.Settings = settings;
        }

        public static JsonWriterSettings CreateSettings(bool prettyPrint)
        {
            JsonWriterSettings settings = new JsonWriterSettings();
            settings.PrettyPrint = prettyPrint;
            return settings;
        }

        public void Serialize(TextWriter output, object data)
        {
            new JsonWriter(output, this.Settings).Write(data);
        }

        public Encoding ContentEncoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }

        public string ContentType
        {
            get
            {
                return "application/json";
            }
        }

        public string FileExtension
        {
            get
            {
                return ".json";
            }
        }
    }
}

