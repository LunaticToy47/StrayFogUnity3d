namespace JsonFx.Json
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class EcmaScriptIdentifier : IJsonSerializable
    {
        [CompilerGenerated]
        private static Dictionary<string, int> f__switch_map0;
        private readonly string identifier;

        public EcmaScriptIdentifier() : this(null)
        {
        }

        public EcmaScriptIdentifier(string ident)
        {
            this.identifier = !string.IsNullOrEmpty(ident) ? EnsureValidIdentifier(ident, true) : string.Empty;
        }

        public static string EnsureValidIdentifier(string varExpr, bool nested)
        {
            return EnsureValidIdentifier(varExpr, nested, true);
        }

        public static string EnsureValidIdentifier(string varExpr, bool nested, bool throwOnEmpty)
        {
            if (string.IsNullOrEmpty(varExpr))
            {
                if (throwOnEmpty)
                {
                    throw new ArgumentException("Variable expression is empty.");
                }
                return string.Empty;
            }
            varExpr = varExpr.Replace(" ", string.Empty);
            if (!IsValidIdentifier(varExpr, nested))
            {
                throw new ArgumentException("Variable expression \"" + varExpr + "\" is not supported.");
            }
            return varExpr;
        }

        public override bool Equals(object obj)
        {
            EcmaScriptIdentifier identifier = obj as EcmaScriptIdentifier;
            if (identifier == null)
            {
                return base.Equals(obj);
            }
            return ((string.IsNullOrEmpty(this.identifier) && string.IsNullOrEmpty(identifier.identifier)) || StringComparer.Ordinal.Equals(this.identifier, identifier.identifier));
        }

        public override int GetHashCode()
        {
            if (this.identifier == null)
            {
                return 0;
            }
            return this.identifier.GetHashCode();
        }

        private static bool IsReservedWord(string varExpr)
        {
            string key = varExpr;
            if (key != null)
            {
                int num;
                if (f__switch_map0 == null)
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>(0x3d);
                    dictionary.Add("null", 0);
                    dictionary.Add("false", 0);
                    dictionary.Add("true", 0);
                    dictionary.Add("break", 0);
                    dictionary.Add("case", 0);
                    dictionary.Add("catch", 0);
                    dictionary.Add("continue", 0);
                    dictionary.Add("debugger", 0);
                    dictionary.Add("default", 0);
                    dictionary.Add("delete", 0);
                    dictionary.Add("do", 0);
                    dictionary.Add("else", 0);
                    dictionary.Add("finally", 0);
                    dictionary.Add("for", 0);
                    dictionary.Add("function", 0);
                    dictionary.Add("if", 0);
                    dictionary.Add("in", 0);
                    dictionary.Add("instanceof", 0);
                    dictionary.Add("new", 0);
                    dictionary.Add("return", 0);
                    dictionary.Add("switch", 0);
                    dictionary.Add("this", 0);
                    dictionary.Add("throw", 0);
                    dictionary.Add("try", 0);
                    dictionary.Add("typeof", 0);
                    dictionary.Add("var", 0);
                    dictionary.Add("void", 0);
                    dictionary.Add("while", 0);
                    dictionary.Add("with", 0);
                    dictionary.Add("abstract", 0);
                    dictionary.Add("boolean", 0);
                    dictionary.Add("byte", 0);
                    dictionary.Add("char", 0);
                    dictionary.Add("class", 0);
                    dictionary.Add("const", 0);
                    dictionary.Add("double", 0);
                    dictionary.Add("enum", 0);
                    dictionary.Add("export", 0);
                    dictionary.Add("extends", 0);
                    dictionary.Add("final", 0);
                    dictionary.Add("float", 0);
                    dictionary.Add("goto", 0);
                    dictionary.Add("implements", 0);
                    dictionary.Add("import", 0);
                    dictionary.Add("int", 0);
                    dictionary.Add("interface", 0);
                    dictionary.Add("long", 0);
                    dictionary.Add("native", 0);
                    dictionary.Add("package", 0);
                    dictionary.Add("private", 0);
                    dictionary.Add("protected", 0);
                    dictionary.Add("public", 0);
                    dictionary.Add("short", 0);
                    dictionary.Add("static", 0);
                    dictionary.Add("super", 0);
                    dictionary.Add("synchronized", 0);
                    dictionary.Add("throws", 0);
                    dictionary.Add("transient", 0);
                    dictionary.Add("volatile", 0);
                    dictionary.Add("let", 0);
                    dictionary.Add("yield", 0);
                    f__switch_map0 = dictionary;
                }
                if (f__switch_map0.TryGetValue(key, out num) && (num == 0))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidIdentifier(string varExpr, bool nested)
        {
            if (string.IsNullOrEmpty(varExpr))
            {
                return false;
            }
            if (nested)
            {
                char[] separator = new char[] { '.' };
                foreach (string str in varExpr.Split(separator))
                {
                    if (!IsValidIdentifier(str, false))
                    {
                        return false;
                    }
                }
                return true;
            }
            if (IsReservedWord(varExpr))
            {
                return false;
            }
            bool flag = false;
            foreach (char ch in varExpr)
            {
                if (!flag || !char.IsDigit(ch))
                {
                    if ((!char.IsLetter(ch) && (ch != '_')) && (ch != '$'))
                    {
                        return false;
                    }
                    flag = true;
                }
            }
            return true;
        }

        void IJsonSerializable.ReadJson(JsonReader reader)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        void IJsonSerializable.WriteJson(JsonWriter writer)
        {
            if (string.IsNullOrEmpty(this.identifier))
            {
                writer.TextWriter.Write("null");
            }
            else
            {
                writer.TextWriter.Write(this.identifier);
            }
        }

        public static implicit operator string(EcmaScriptIdentifier ident)
        {
            if (ident == null)
            {
                return string.Empty;
            }
            return ident.identifier;
        }

        public static implicit operator EcmaScriptIdentifier(string ident)
        {
            return new EcmaScriptIdentifier(ident);
        }

        public static EcmaScriptIdentifier Parse(string value)
        {
            return new EcmaScriptIdentifier(value);
        }

        public override string ToString()
        {
            return this.identifier;
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }
        }
    }
}

