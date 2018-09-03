namespace JsonFx.Json
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EcmaScriptWriter : JsonWriter
    {
        private static readonly IList<string> BrowserObjects;
        private const string EcmaScriptDateCtor1 = "new Date({0})";
        private const string EcmaScriptDateCtor7 = "new Date({0:0000},{1},{2},{3},{4},{5},{6})";
        private static readonly DateTime EcmaScriptEpoch = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private const string EmptyRegExpLiteral = "(?:)";
        private const string NamespaceCheck = "if(\"undefined\"===typeof {0}){{{0}={{}};}}";
        private const string NamespaceCheckDebug = "\r\nif (\"undefined\" === typeof {0}) {{\r\n\t{0} = {{}};\r\n}}";
        private const string NamespaceDelim = ".";
        private static readonly char[] NamespaceDelims = new char[] { '.' };
        private const char OperatorCharEscape = '\\';
        private const char RegExpLiteralDelim = '/';
        private const string RootDeclaration = "var {0};";
        private const string RootDeclarationDebug = "\r\n/* namespace {1} */\r\nvar {0};";

        static EcmaScriptWriter()
        {
            string[] collection = new string[] { "console", "document", "event", "frames", "history", "location", "navigator", "opera", "screen", "window" };
            BrowserObjects = new List<string>(collection);
        }

        public EcmaScriptWriter(Stream output) : base(output)
        {
        }

        public EcmaScriptWriter(TextWriter output) : base(output)
        {
        }

        public EcmaScriptWriter(string outputFileName) : base(outputFileName)
        {
        }

        public EcmaScriptWriter(StringBuilder output) : base(output)
        {
        }
        public new static string Serialize(object value)
        {
            StringBuilder output = new StringBuilder();
            using (EcmaScriptWriter writer = new EcmaScriptWriter(output))
            {
                writer.Write(value);
            }
            return output.ToString();
        }

        public override void Write(DateTime value)
        {
            WriteEcmaScriptDate(this, value);
        }

        public override void Write(double value)
        {
            base.TextWriter.Write(value.ToString("r"));
        }

        public override void Write(float value)
        {
            base.TextWriter.Write(value.ToString("r"));
        }

        protected override void Write(object value, bool isProperty)
        {
            if (value is Regex)
            {
                if (isProperty && base.Settings.PrettyPrint)
                {
                    base.TextWriter.Write(' ');
                }
                WriteEcmaScriptRegExp(this, (Regex) value);
            }
            else
            {
                base.Write(value, isProperty);
            }
        }

        public static void WriteEcmaScriptDate(JsonWriter writer, DateTime value)
        {
            if (value.Kind == DateTimeKind.Unspecified)
            {
                object[] arg = new object[] { value.Year, value.Month - 1, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond };
                writer.TextWriter.Write("new Date({0:0000},{1},{2},{3},{4},{5},{6})", arg);
            }
            else
            {
                if (value.Kind == DateTimeKind.Local)
                {
                    value = value.ToUniversalTime();
                }
                long totalMilliseconds = (long) value.Subtract(EcmaScriptEpoch).TotalMilliseconds;
                writer.TextWriter.Write("new Date({0})", totalMilliseconds);
            }
        }

        public static void WriteEcmaScriptRegExp(JsonWriter writer, Regex regex)
        {
            WriteEcmaScriptRegExp(writer, regex, false);
        }

        public static void WriteEcmaScriptRegExp(JsonWriter writer, Regex regex, bool isGlobal)
        {
            if (regex == null)
            {
                writer.TextWriter.Write("null");
            }
            else
            {
                string str = regex.ToString();
                if (string.IsNullOrEmpty(str))
                {
                    str = "(?:)";
                }
                string str2 = !isGlobal ? string.Empty : "g";
                switch ((regex.Options & (RegexOptions.Multiline | RegexOptions.IgnoreCase)))
                {
                    case RegexOptions.IgnoreCase:
                        str2 = str2 + "i";
                        break;

                    case RegexOptions.Multiline:
                        str2 = str2 + "m";
                        break;

                    case (RegexOptions.Multiline | RegexOptions.IgnoreCase):
                        str2 = str2 + "im";
                        break;
                }
                writer.TextWriter.Write('/');
                int length = str.Length;
                int startIndex = 0;
                for (int i = startIndex; i < length; i++)
                {
                    char ch = str[i];
                    if (ch == '/')
                    {
                        writer.TextWriter.Write(str.Substring(startIndex, i - startIndex));
                        startIndex = i + 1;
                        writer.TextWriter.Write('\\');
                        writer.TextWriter.Write(str[i]);
                    }
                }
                writer.TextWriter.Write(str.Substring(startIndex, length - startIndex));
                writer.TextWriter.Write('/');
                writer.TextWriter.Write(str2);
            }
        }

        public static bool WriteNamespaceDeclaration(TextWriter writer, string ident, List<string> namespaces, bool isDebug)
        {
            if (string.IsNullOrEmpty(ident))
            {
                return false;
            }
            if (namespaces == null)
            {
                namespaces = new List<string>();
            }
            string[] strArray = ident.Split(NamespaceDelims, StringSplitOptions.RemoveEmptyEntries);
            string item = strArray[0];
            bool flag = false;
            for (int i = 0; i < (strArray.Length - 1); i++)
            {
                flag = true;
                if (i > 0)
                {
                    item = item + "." + strArray[i];
                }
                if (!namespaces.Contains(item) && !BrowserObjects.Contains(item))
                {
                    namespaces.Add(item);
                    if (i == 0)
                    {
                        if (isDebug)
                        {
                            writer.Write("\r\n/* namespace {1} */\r\nvar {0};", item, string.Join(".", strArray, 0, strArray.Length - 1));
                        }
                        else
                        {
                            writer.Write("var {0};", item);
                        }
                    }
                    if (isDebug)
                    {
                        writer.WriteLine("\r\nif (\"undefined\" === typeof {0}) {{\r\n\t{0} = {{}};\r\n}}", item);
                    }
                    else
                    {
                        writer.Write("if(\"undefined\"===typeof {0}){{{0}={{}};}}", item);
                    }
                }
            }
            if (isDebug && flag)
            {
                writer.WriteLine();
            }
            return flag;
        }

        protected override void WriteObjectPropertyName(string name)
        {
            if (EcmaScriptIdentifier.IsValidIdentifier(name, false))
            {
                base.TextWriter.Write(name);
            }
            else
            {
                base.WriteObjectPropertyName(name);
            }
        }
    }
}

