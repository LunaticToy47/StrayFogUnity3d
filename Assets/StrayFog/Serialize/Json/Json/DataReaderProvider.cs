namespace JsonFx.Json
{
    using System;
    using System.Collections.Generic;

    public class DataReaderProvider : IDataReaderProvider
    {
        private readonly IDictionary<string, IDataReader> ReadersByMime = new Dictionary<string, IDataReader>(StringComparer.OrdinalIgnoreCase);

        public DataReaderProvider(IEnumerable<IDataReader> readers)
        {
            if (readers != null)
            {
                IEnumerator<IDataReader> enumerator = readers.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        IDataReader current = enumerator.Current;
                        if (!string.IsNullOrEmpty(current.ContentType))
                        {
                            this.ReadersByMime[current.ContentType] = current;
                        }
                    }
                }
                finally
                {
                    if (enumerator == null)
                    {
                    }
                    enumerator.Dispose();
                }
            }
        }

        public IDataReader Find(string contentTypeHeader)
        {
            string key = DataWriterProvider.ParseMediaType(contentTypeHeader);
            if (this.ReadersByMime.ContainsKey(key))
            {
                return this.ReadersByMime[key];
            }
            return null;
        }
    }
}

