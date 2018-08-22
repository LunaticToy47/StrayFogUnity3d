namespace JsonFx.Json
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class DataWriterProvider : IDataWriterProvider
    {
        private readonly IDataWriter DefaultWriter;
        private readonly IDictionary<string, IDataWriter> WritersByExt = new Dictionary<string, IDataWriter>(StringComparer.OrdinalIgnoreCase);
        private readonly IDictionary<string, IDataWriter> WritersByMime = new Dictionary<string, IDataWriter>(StringComparer.OrdinalIgnoreCase);

        public DataWriterProvider(IEnumerable<IDataWriter> writers)
        {
            if (writers != null)
            {
                IEnumerator<IDataWriter> enumerator = writers.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        IDataWriter current = enumerator.Current;
                        if (this.DefaultWriter == null)
                        {
                            this.DefaultWriter = current;
                        }
                        if (!string.IsNullOrEmpty(current.ContentType))
                        {
                            this.WritersByMime[current.ContentType] = current;
                        }
                        if (!string.IsNullOrEmpty(current.ContentType))
                        {
                            string str = NormalizeExtension(current.FileExtension);
                            this.WritersByExt[str] = current;
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

        public IDataWriter Find(string extension)
        {
            extension = NormalizeExtension(extension);
            if (this.WritersByExt.ContainsKey(extension))
            {
                return this.WritersByExt[extension];
            }
            return null;
        }

        public IDataWriter Find(string acceptHeader, string contentTypeHeader)
        {
            IEnumerator<string> enumerator = ParseHeaders(acceptHeader, contentTypeHeader).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    string current = enumerator.Current;
                    if (this.WritersByMime.ContainsKey(current))
                    {
                        return this.WritersByMime[current];
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
            return null;
        }

        private static string NormalizeExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension))
            {
                return string.Empty;
            }
            return Path.GetExtension(extension);
        }

        [DebuggerHidden]
        public static IEnumerable<string> ParseHeaders(string accept, string contentType)
        {
            ParseHeaders_c__Iterator0 iterator = new ParseHeaders_c__Iterator0();
            iterator.accept = accept;
            iterator.contentType = contentType;
            iterator.accept__1 = accept;
            iterator.contentType__1 = contentType;
            iterator.PC = -2;
            return iterator;
        }

        public static string ParseMediaType(string type)
        {
            IEnumerator<string> enumerator = SplitTrim(type, ';').GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    return enumerator.Current;
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
            return string.Empty;
        }

        [DebuggerHidden]
        private static IEnumerable<string> SplitTrim(string source, char ch)
        {
            SplitTrim_c__Iterator1 iterator = new SplitTrim_c__Iterator1();
            iterator.source = source;
            iterator.ch = ch;
            iterator.source__1 = source;
            iterator.ch__1 = ch;
            iterator.PC = -2;
            return iterator;
        }

        public IDataWriter DefaultDataWriter
        {
            get
            {
                return this.DefaultWriter;
            }
        }

        [CompilerGenerated]
        private sealed class ParseHeaders_c__Iterator0 : IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable, IEnumerable
        {
            internal string current;
            internal int PC;
            internal string accept__1;
            internal string contentType__1;
            internal IEnumerator<string> s_4__0;
            internal string mime__2;
            internal string type__1;
            internal string accept;
            internal string contentType;

            [DebuggerHidden]
            public void Dispose()
            {
                uint num = (uint) this.PC;
                this.PC = -1;
                switch (num)
                {
                    case 1:
                        try
                        {
                        }
                        finally
                        {
                            if (this.s_4__0 == null)
                            {
                            }
                            this.s_4__0.Dispose();
                        }
                        break;
                }
            }

            public bool MoveNext()
            {
                uint num = (uint) this.PC;
                this.PC = -1;
                bool flag = false;
                switch (num)
                {
                    case 0:
                        this.s_4__0 = DataWriterProvider.SplitTrim(this.accept, ',').GetEnumerator();
                        num = 0xfffffffd;
                        break;

                    case 1:
                        break;

                    case 2:
                        goto Label_0106;

                    default:
                        goto Label_010D;
                }
                try
                {
                    while (this.s_4__0.MoveNext())
                    {
                        this.type__1 = this.s_4__0.Current;
                        this.mime__2 = DataWriterProvider.ParseMediaType(this.type__1);
                        if (!string.IsNullOrEmpty(this.mime__2))
                        {
                            this.current = this.mime__2;
                            this.PC = 1;
                            flag = true;
                            goto Label_010F;
                        }
                    }
                }
                finally
                {
                    if (!flag)
                    {
                    }
                    if (this.s_4__0 == null)
                    {
                    }
                    this.s_4__0.Dispose();
                }
                this.mime__2 = DataWriterProvider.ParseMediaType(this.contentType);
                if (!string.IsNullOrEmpty(this.mime__2))
                {
                    this.current = this.mime__2;
                    this.PC = 2;
                    goto Label_010F;
                }
            Label_0106:
                this.PC = -1;
            Label_010D:
                return false;
            Label_010F:
                return true;
            }

            [DebuggerHidden]
            public void Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                if (Interlocked.CompareExchange(ref this.PC, 0, -2) == -2)
                {
                    return this;
                }
                DataWriterProvider.ParseHeaders_c__Iterator0 iterator = new DataWriterProvider.ParseHeaders_c__Iterator0();
                iterator.accept = this.accept__1;
                iterator.contentType = this.contentType__1;
                return iterator;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;// this.System.Collections.Generic.IEnumerable<string>.GetEnumerator();
            }

            string IEnumerator<string>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.current;
                }
            }
        }

        [CompilerGenerated]
        private sealed class SplitTrim_c__Iterator1 : IEnumerable<string>, IEnumerator<string>, IEnumerator, IDisposable, IEnumerable
        {
            internal string current;
            internal int PC;
            internal char ch__1;
            internal string source__1;
            internal int length__0;
            internal int next__2;
            internal string part__3;
            internal int prev__1;
            internal char ch;
            internal string source;

            [DebuggerHidden]
            public void Dispose()
            {
                this.PC = -1;
            }

            public bool MoveNext()
            {
                uint num = (uint) this.PC;
                this.PC = -1;
                switch (num)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(this.source))
                        {
                            this.length__0 = this.source.Length;
                            this.prev__1 = 0;
                            this.next__2 = 0;
                            while ((this.prev__1 < this.length__0) && (this.next__2 >= 0))
                            {
                                this.next__2 = this.source.IndexOf(this.ch, this.prev__1);
                                if (this.next__2 < 0)
                                {
                                    this.next__2 = this.length__0;
                                }
                                this.part__3 = this.source.Substring(this.prev__1, this.next__2 - this.prev__1).Trim();
                                if (this.part__3.Length > 0)
                                {
                                    this.current = this.part__3;
                                    this.PC = 1;
                                    return true;
                                }
                            //Label_00E1:
                                this.prev__1 = this.next__2 + 1;
                            }
                            this.PC = -1;
                            
                            break;
                        }
                        break;
                    case 1:
                        //goto Label_00E1;
                        this.prev__1 = this.next__2 + 1;
                        break;

                }
                return false;
            }

            [DebuggerHidden]
            public void Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                if (Interlocked.CompareExchange(ref this.PC, 0, -2) == -2)
                {
                    return this;
                }
                DataWriterProvider.SplitTrim_c__Iterator1 iterator = new DataWriterProvider.SplitTrim_c__Iterator1();
                iterator.source = this.source__1;
                iterator.ch = this.ch__1;
                return iterator;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;//this.System.Collections.Generic.IEnumerable<string>.GetEnumerator();
            }

            string IEnumerator<string>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.current;
                }
            }
        }
    }
}

