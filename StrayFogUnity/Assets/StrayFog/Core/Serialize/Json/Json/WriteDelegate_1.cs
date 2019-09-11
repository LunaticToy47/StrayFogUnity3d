namespace JsonFx.Json
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void WriteDelegate<T>(JsonWriter writer, T value);
}

