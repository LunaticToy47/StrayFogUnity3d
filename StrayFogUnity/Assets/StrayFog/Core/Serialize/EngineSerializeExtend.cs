using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
/// <summary>
/// 序列化扩展
/// </summary>
public static class EngineSerializeExtend
{
    #region JSON序列化
    /// <summary>
    /// Json序列化
    /// </summary>
    /// <param name="_obj">要序列化的对象</param>
    /// <returns>对象序列化后的字符串</returns>
    public static string JsonSerialize(this object _obj)
    {
        string rtn = string.Empty;
        if (_obj != null)
        {
            rtn = JsonFx.Json.JsonWriter.Serialize(_obj);
        }
        return rtn;
    }

    /// <summary>
    /// Json反序列化
    /// T类型不能为泛型List，只能为[]数组类型
    /// </summary>
    /// <typeparam name="T">反序列化的对象类型</typeparam>
    /// <param name="_json">要反序列化的字符串</param>
    /// <returns>反序列化后的对象</returns>
    public static T JsonDeserialize<T>(this string _json)
    {
        T rtn = default(T);
        if (!string.IsNullOrEmpty(_json))
        {
            rtn = JsonFx.Json.JsonReader.Deserialize<T>(_json);
        }
        return rtn;
    }

    /// <summary>
    /// Json反序列化
    /// T类型不能为泛型List，只能为[]数组类型
    /// </summary>
    /// <param name="_json">要反序列化的字符串</param>
    /// <param name="_type">类型</param>
    /// <returns>反序列化后的对象</returns>
    public static object JsonDeserialize(this string _json, Type _type)
    {
        object obj = null;
        if (!string.IsNullOrEmpty(_json))
        {
            obj = JsonFx.Json.JsonReader.Deserialize(_json, _type);
        }
        return obj;
    }
    #endregion

    #region XML序列化
    /// <summary>
    /// XML序列化
    /// </summary>
    /// <param name="_value">要序列化的对象</param>
    public static string XmlSerialize<T>(this T _value)
    {
        if (_value == null)
        {
            return null;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = new UTF8Encoding(false);
        settings.Indent = false;
        settings.OmitXmlDeclaration = false;
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        MemoryStream stream = new MemoryStream();

        using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(xmlWriter, _value, ns);
        }
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    /// <summary>
    /// XML反序列化
    /// </summary>
    /// <param name="_xml">反序列化的XML字符</param>
    public static T XmlDeserialize<T>(this string _xml)
    {

        if (string.IsNullOrEmpty(_xml))
        {
            return default(T);
        }
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        XmlReaderSettings settings = new XmlReaderSettings();

        using (StringReader textReader = new StringReader(_xml))
        {
            using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
            {
                return (T)serializer.Deserialize(xmlReader);
            }
        }
    }
    #endregion

    #region 二进制序列化（内存对象）
    /// <summary>
    /// 二进制序列化
    /// </summary>
    /// <typeparam name="T">要序列化的对象类型</typeparam>
    /// <param name="_source">源对象</param>
    /// <returns>源对象的二进制数据</returns>
    public static byte[] BinaryMemorySerialize<T>(this T _source)
    {
        byte[] bts;
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            binFormatter.Serialize(ms, _source);
            bts = new byte[ms.Length];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(bts, 0, bts.Length);
        }
        return bts;
    }

    /// <summary>
    /// 二进制反序列化
    /// </summary>
    /// <typeparam name="T">要反序列化的对象类型</typeparam>
    /// <param name="_bytes">二进制数据</param>
    /// <returns>反序列化的对象</returns>
    public static T BinaryMemoryDeserialize<T>(this byte[] _bytes)
    {
        T obj;
        using (MemoryStream ms = new MemoryStream(_bytes))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                obj = (T)formatter.Deserialize(ms);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return obj;
    }
    #endregion
}
