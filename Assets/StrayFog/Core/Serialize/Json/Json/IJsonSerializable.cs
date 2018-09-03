namespace JsonFx.Json
{
    using System;

    public interface IJsonSerializable
    {
        void ReadJson(JsonReader reader);
        void WriteJson(JsonWriter writer);
    }
}

